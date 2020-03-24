using iDareUI.Common;
using iDareUI.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace iDareUI
{
    [Binding]
    public class CasesOverviewSteps
    {
        private TestingEnvironment environment;
        private MainCasesPage mainCasesPage;
        private CaseDetailsPage casesDetailsPage;
        private CaseCreationSteps caseCreationSteps;
        private CaseCreationPage caseCreationPage;
        private Case caseCreatedForSearch;
        public enum CaseSearchProperty
        {
            CaseId,
            SerialNumber,
            Customer,
            Country
        }

        public CasesOverviewSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainCasesPage = new MainCasesPage(environment.Driver);
            this.casesDetailsPage = new CaseDetailsPage(environment.Driver);
            this.caseCreationPage = new CaseCreationPage(environment.Driver);
            this.caseCreationSteps = new CaseCreationSteps(environment);
        }

        [When(@"I go to the Cases overview screen")]
        public void WhenIGoToTheCasesOverviewScreen()
        {
            mainCasesPage.PressCasesButton();
        }
        [When(@"I enter to the details of a case")]
        public void WhenIEnterToTheDetailsOfACase()
        {
            FlowUtilities.WaitUntil(
                () => (mainCasesPage.firstIdRowText.Contains("CAS-0123")), TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(100),
                "The created case is not located in the first position of the Cases Overview grid");

            FlowUtilities.WaitUntil(
                () =>
                {
                    try
                    {
                        mainCasesPage.PressDetailsButton();
                        casesDetailsPage.PressCloseCaseDetailsButton();
                        return mainCasesPage.firstCaseSWVersionText.Contains("01.");
                    }
                    catch
                    {
                        return false;
                    }
                }, TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(1000));

            mainCasesPage.PressDetailsButton();
            Assert.True(casesDetailsPage.closeCaseDetailsButton.Enabled, "The case details page was not opened.");
        }

        [Then(@"the cases grid with the correct columns is displayed")]
        public void ThenTheCasesGridWithTheCorrectColumnsIsDisplayed()
        {
            string[] casesGridColumns = new string[] { "Case ID", "System", "Serial No.", "SW Version", "Created (UTC)", "Customer", "Country", "Created by", "Issues" };
            var obtainColumns = mainCasesPage.GetGridHeaderNames();
            Assert.True(casesGridColumns.SequenceEqual(obtainColumns),
                $"The grid headers are not the expected ones. \nExpected: {string.Join(", ", casesGridColumns)}, \nActual: {string.Join(", ", obtainColumns)}");
        }

        [Then(@"cases are sorted by creation time")]
        public void ThenCasesAreSortedByCreationTime()
        {
            IEnumerable<DateTime> obtainedCreationDateTime = null;
            IEnumerable<DateTime> orderedCreationDateTime = null;

            FlowUtilities.WaitUntil(
                () =>
                {
                    try
                    {
                        obtainedCreationDateTime = mainCasesPage.GetCreationDateTime();
                        orderedCreationDateTime = mainCasesPage.GetSortedDates();

                        return orderedCreationDateTime.SequenceEqual(obtainedCreationDateTime);
                    }
                    catch (StaleElementReferenceException ex)
                    {
                        environment.Log.Error("Error getting data: " + ex.Message);
                        return false;
                    }

                }, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
        }

        [Given(@"I create two duplicate cases and a different case")]
        public void GivenICreateTwoDuplicateCasesAndADifferentCase()
        {
            caseCreatedForSearch = Case.GetRandomCase();
            this.CreateCase(caseCreatedForSearch);
            this.CreateCase(caseCreatedForSearch);
            var myCase2 = Case.GetRandomCase();
            this.CreateCase(myCase2);
            mainCasesPage.WaitUntilCasesAreCreated(myCase2.CaseID);
        }

        private void CreateCase(Case c)
        {
            caseCreationSteps.GivenIEnterToCreateANewCase();
            caseCreationSteps.WhenIEnterAsRexisID(c.CaseID);
            caseCreationSteps.WhenIEnterAsSerialNumber(c.SerialNo);
            caseCreationSteps.WhenIEnterAsCountry(c.Country);
            caseCreationSteps.WhenIEnterAsCustomer(c.Customer);
            caseCreationSteps.WhenIEnterTheOptionOfTheDropdownAsTimezone(2);
            caseCreationSteps.WhenIPressTheSaveButton();
        }


        [When(@"I search by (.*) of the duplicate cases")]
        public void WhenISearchByOfTheDuplicateCases(CaseSearchProperty property)
        {
            switch (property)
            {
                case CaseSearchProperty.CaseId:
                    mainCasesPage.SearchFilterCases(caseCreatedForSearch.CaseID);
                    break;
                case CaseSearchProperty.Country:
                    mainCasesPage.SearchFilterCases(caseCreatedForSearch.Country);
                    break;
                case CaseSearchProperty.Customer:
                    mainCasesPage.SearchFilterCases(caseCreatedForSearch.Customer);
                    break;
                case CaseSearchProperty.SerialNumber:
                    mainCasesPage.SearchFilterCases(caseCreatedForSearch.SerialNo);
                    break;
                default:
                    throw new InvalidOperationException("The search property is wrong.");
            }
            
            mainCasesPage.PressSearchButton();
        }


        [Then(@"the only two cases with the same (.*) I created are displayed")]
        public void ThenTheOnlyTwoCasesWithTheSameICreatedAreDisplayed(CaseSearchProperty property)
        {
            FlowUtilities.WaitUntil(
                () => (mainCasesPage.SelectCases(caseCreatedForSearch, property)), TimeSpan.FromSeconds(2000), TimeSpan.FromMilliseconds(25));

            Assert.True(mainCasesPage.SelectCases(caseCreatedForSearch, property), "The searching filter is not working");
            //Assert.Equal(2, ret.Count());
        }
    }
}
