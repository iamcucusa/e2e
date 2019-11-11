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

        public CasesOverviewSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainCasesPage = new MainCasesPage(environment.Driver);
        }
        
        [When(@"I go to the Cases overview screen")]
        public void WhenIGoToTheCasesOverviewScreen()
        {
            mainCasesPage.PressCasesButton();
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
                    catch(StaleElementReferenceException ex)
                    {
                        environment.Log.Error("Error getting data: " + ex.Message);
                        return false;
                    }

                }, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
        }
    }
}
