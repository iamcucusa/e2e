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

        [When(@"I edit the issue title with '(.*)' as Title")]
        public void WhenIEditTheIssueTitleWithAsTitle(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit the issue title with '(.*)' as Category")]
        public void WhenIEditTheIssueTitleWithAsCategory(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit the issue title with '(.*)' as System")]
        public void WhenIEditTheIssueTitleWithAsSystem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the edit issue save button must be disabled")]
        public void ThenTheEditIssueSaveButtonMustBeDisabled()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit '(.*)' as System")]
        public void WhenIEditAsSystem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit '(.*)' as Category")]
        public void WhenIEditAsCategory(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit '(.*)' as Title")]
        public void WhenIEditAsTitle(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the edit save button must be enabled")]
        public void ThenTheEditSaveButtonMustBeEnabled()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I edit '(.*)' as Category")]
        public void GivenIEditAsCategory(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click edit save button is enabled")]
        public void WhenIClickEditSaveButtonIsEnabled()
        {
            ScenarioContext.Current.Pending();
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
