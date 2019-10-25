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
        public LoginSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.loginPage = new LoginPage(environment.Driver, environment.Log);
        }


        private LoginPage loginPage;
        private MainCasesPage mainCasesPage;

        [Given(@"I am in the Login screen")]
        public void GivenIAmInTheLoginScreen()
        {
            this.environment.Driver.Manage().Window.Maximize();
            this.loginPage.NavigateTo();
        }

        [Given(@"I enter the username (.*)")]
        public void GivenIEnterTheUsername(string userName)
        {
            loginPage.UserName = userName;
        }

        [Given(@"I enter the password (.*)")]
        public void GivenIEnterThePassword(string password)
        {
            loginPage.Password = password;
        }

        [When(@"I login")]
        public void WhenILogin()
        {
            mainCasesPage = loginPage.LoginApplication();
        }

        [Then(@"I should see the Cases screen for (.*)")]
        public void ThenIShouldSeeTheCasesScreenfor(string userName)
        {
            Assert.Equal(userName, mainCasesPage.UserRole.ToLower());
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            Assert.True(loginPage.ErrorMessageText != null, "The error message 'Authentication failed: Token invalid.' didn't appear");
        }

        [Given(@"I am logged in as teacher")]
        public void GivenIAmLoggedInAsTeacher()
        {
            this.GivenIAmInTheLoginScreen();
            this.GivenIEnterTheUsername(Constants.TeacherUserName);
            this.GivenIEnterThePassword(Constants.TeacherPassword);
            this.WhenILogin();
        }
        [Given(@"I am logged in as investigator")]
        public void GivenIAmLoggedInAsInvestigator()
        {
            this.GivenIAmInTheLoginScreen();
            this.GivenIEnterTheUsername(Constants.InvestigatorName);
            this.GivenIEnterThePassword(Constants.InvestigatorPassword);
            this.WhenILogin();
        }

    }
}
