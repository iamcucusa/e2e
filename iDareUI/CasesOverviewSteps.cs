using iDareUI.Common;
using iDareUI.Models;
using System;
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
            string[] casesGridColumns = new string[] { " Case ", " System ", " Serial ", " Version ", " Creation ", " Customer ", " Country ", " Creator ", " Issues " };
            var obtainColumns = mainCasesPage.GetGridHeaderNames();
            Assert.True(casesGridColumns.SequenceEqual(obtainColumns),
                $"The grid headers are not the expected ones. \nExpected: {string.Join(", ", casesGridColumns)}, \nActual: {string.Join(", ", obtainColumns)}");
        }
        
        [Then(@"cases are sorted by creation time")]
        public void ThenCasesAreSortedByCreationTime()
        {
            var obtainedCreationDateTime = mainCasesPage.GetCreationDateTime();
            var orderedCreationDateTime = mainCasesPage.GetSortedDates();
            Assert.True(orderedCreationDateTime.SequenceEqual(obtainedCreationDateTime),
                $"The cases are not correctly ordered by their creation date/time. \nExpected:\n{string.Join(",\n", orderedCreationDateTime)}, \nActual:\n{string.Join(",\n", obtainedCreationDateTime)}");
        }
    }
}
