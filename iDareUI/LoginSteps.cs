using iDareUI.Common;
using iDareUI.Models;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class LoginSteps
    {
        private TestingEnvironment environment;
        private MainCasesPage mainCasesPage;
        public LoginSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.loginPage = new LoginPage(environment.Driver, environment.Log);
            this.mainCasesPage = new MainCasesPage(environment.Driver);
        }


        private LoginPage loginPage;

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
