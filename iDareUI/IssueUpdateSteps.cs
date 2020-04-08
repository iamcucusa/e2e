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
        
        
        [Then(@"I cancel the first issue update and the issue remaings unchanged")]
        public void ThenICancelTheFirstIssueUpdateAndTheIssueRemaingsUnchanged()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the updated issue is the first in the list of issues")]
        public void ThenTheUpdatedIssueIsTheFirstInTheListOfIssues()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Category field of the edited issue is equal to '(.*)'")]
        public void ThenTheCategoryFieldOfTheEditedIssueIsEqualTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the ModifiedBy field of the edited issue is equal to DebugUser")]
        public void ThenTheModifiedByFieldOfTheEditedIssueIsEqualToDebugUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Modified field of the edited issue is equal to '(.*)'")]
        public void ThenTheModifiedFieldOfTheEditedIssueIsEqualTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
