using iDareUI.Common;
using iDareUI.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class CasesOverviewSteps
    {
        private TestingEnvironment environment;
        private MainCasesPage mainCasesPage;
        private CaseDetailsPage casesDetailsPage;

        public CasesOverviewSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainCasesPage = new MainCasesPage(environment.Driver);
            this.casesDetailsPage = new CaseDetailsPage(environment.Driver);
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
            string[] casesGridColumns = new string[] { "Case ID", "System", "Serial No.", "SW Version", "Created", "Customer", "Country", "Created by", "Issues" };
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
    }
}
