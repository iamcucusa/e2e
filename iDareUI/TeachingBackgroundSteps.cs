using iDareUI.Common;
using iDareUI.PageInteractions;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class TeachingBackgroundSteps
    {
        private TestingEnvironment environment;
        private TeachingMainPage mainTeachingPage;
        private NavigationPage navigationPage;

        public TeachingBackgroundSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainTeachingPage = new TeachingMainPage(environment.Driver);
            this.navigationPage = new NavigationPage(environment.Driver);
        }

        [Given(@"I navigate successfully to the teaching module")]
        public void GivenINavigateSuccessfullyToTheTeachingModule()
        {
            environment.Driver.Manage().Window.Maximize();
            navigationPage.NavigateToTeachingModule();
        }
        
        [Given(@"I am in the issue list in teaching module")]
        public void GivenIAmInTheIssueListInTeachingModule()
        {
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListIsLoaded());
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListTableHeaderIsCorrect());
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListTableIsPopulatedWithAtLeastOneRow());
        }

        [Given(@"I am logged in as teacher user")]
        public void IAmLoggedInAsTeacherUser()
        {
            Assert.True(mainTeachingPage.userIsLoggedInAs("Teacher", "DebugUser"));
            
        }
        
    }
}
