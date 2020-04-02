using iDareUI.Common;
using iDareUI.Models;
using iDareUI.PageInteractions;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class LoginSteps
    {
        private TestingEnvironment environment;
        private CaseMainPage mainCasesPage;
        private LoginPage loginPage;
        public LoginSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.loginPage = new LoginPage(environment.Driver, environment.Log);
            this.mainCasesPage = new CaseMainPage(environment.Driver);
        }

        [Given(@"I am in the Overview screen")]
        public void GivenIAmInTheOverviewScreen()
        {
            this.environment.Driver.Manage().Window.Maximize();
            this.loginPage.NavigateTo();
        }

        [Then(@"I should see the Cases screen for (.*)")]
        public void ThenIShouldSeeTheCasesScreenfor(string userName)
        {
            string userWebName = mainCasesPage.UserRole;
            Assert.Equal(userName, userWebName);
        }
    }
}
