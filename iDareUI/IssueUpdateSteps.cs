using System;
using iDareUI.Common;
using iDareUI.PageInteractions;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class IssueUpdateSteps
    {
        private TestingEnvironment environment;
        private TeachingMainPage mainTeachingPage;
        private IssueUpdatePage issueUpdatePage;


        public IssueUpdateSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainTeachingPage = new TeachingMainPage(environment.Driver);
            this.issueUpdatePage = new IssueUpdatePage(environment.Driver);

        
        }


        [Given(@"Issue list is displayed")]
        public void GivenIssueListIsDisplayed()
        {
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListIsLoaded());
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListTableHeaderIsCorrect());
           
        }
        
        [Given(@"The issue list has at least one issue")]
        public void GivenTheIssueListHasAtLeastOneIssue()
        {
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListTableIsPopulatedWithAtLeastOneRow());
        }

        [Given(@"I click in the edit button for the first issue in the list")]
        public void GivenIClickInTheEditButtonForTheFirstIssueInTheList()
        {
            Assert.True(mainTeachingPage.issuesRulesPage.editIssue(0));
            Assert.True(issueUpdatePage.EditIssueDialogIsOpenAndCorrectlyLoaded());
        }


        [Then(@"the edit issue save button must be disabled")]
        public void ThenTheEditIssueSaveButtonMustBeDisabled()
        {
            Assert.True(issueUpdatePage.SaveIssueButtonIsDisabled());
        }

        [Then(@"the edit save button must be enabled")]
        public void ThenTheEditSaveButtonMustBeEnabled()
        {
            Assert.True(issueUpdatePage.SaveIssueButtonIsEnabled());
        }

        [When(@"I click edit save button is enabled")]
        public void WhenIClickEditSaveButtonIsEnabled()
        {
            Assert.True(issueUpdatePage.SaveIssueButtonIsEnabled());
            issueUpdatePage.SaveIssue();
        }



        [Then(@"I cancel the first issue update and the issue remaings unchanged")]
        public void ThenICancelTheFirstIssueUpdateAndTheIssueRemaingsUnchanged()
        {
            var firstIssue = mainTeachingPage.issuesRulesPage.getIssueRowDataByRowIndex(0);
            issueUpdatePage.CancelUpdateIssue();
            var firstIssueAfterCancel = mainTeachingPage.issuesRulesPage.getIssueRowDataByRowIndex(0);
            Assert.Equal(firstIssue.Title, firstIssueAfterCancel.Title);
            Assert.Equal(firstIssue.Category, firstIssueAfterCancel.Category);
            Assert.Equal(firstIssue.Footprints, firstIssueAfterCancel.Footprints);
            Assert.Equal(firstIssue.Modified, firstIssueAfterCancel.Modified);
            Assert.Equal(firstIssue.ModifiedBy, firstIssueAfterCancel.ModifiedBy);
            Assert.Equal(firstIssue.RuleInWork, firstIssueAfterCancel.RuleInWork);
        }


        [Then(@"The Category field of the edited issue is equal to '(.*)'")]
        public void ThenTheCategoryFieldOfTheEditedIssueIsEqualTo(string category)
        {
            mainTeachingPage.issuesRulesPage.refreshIssueList();

            var firstIssue = mainTeachingPage.issuesRulesPage.getIssueRowDataByRowIndex(0);
            Assert.Equal(firstIssue.Category, category);
        }
        
        [Then(@"the ModifiedBy field of the edited issue is equal to the logged username")]
        public void ThenTheModifiedByFieldOfTheEditedIssueIsEqualToTheLoggedUsername()
        {
            mainTeachingPage.issuesRulesPage.refreshIssueList();

            var firstIssue = mainTeachingPage.issuesRulesPage.getIssueRowDataByRowIndex(0);
            Assert.Equal(firstIssue.ModifiedBy, mainTeachingPage.loggedUserName());

        }
        
        [Then(@"The Modified field of the edited issue is equal to '(.*)' when I save")]
        public void ThenTheModifiedFieldOfTheEditedIssueIsEqualTo(string modified)
        {

            Assert.True(issueUpdatePage.SaveIssueButtonIsEnabled());

            var currentDate = DateTime.Now.ToUniversalTime();

            issueUpdatePage.SaveIssue();
            mainTeachingPage.issuesRulesPage.refreshIssueList();

            var firstIssue = mainTeachingPage.issuesRulesPage.getIssueRowDataByRowIndex(0);

            DateTime modifiedDateTime;
            Assert.True(DateTime.TryParse(firstIssue.Modified, out modifiedDateTime));

            TimeSpan difference = currentDate.Subtract(modifiedDateTime);

            
            Assert.True(difference.TotalSeconds <= 10);

        }
    }
}
