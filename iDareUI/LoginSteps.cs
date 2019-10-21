using iDareUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace WebTestingTestApp.idare
{
    [Binding]
    public class LoginSteps
    {
        private TestingEnvironment environment;
        public LoginSteps(TestingEnvironment environment)
        {
            this.environment = environment;
        }


        private LoginPage loginPage;
        private MainCasesPage mainCasesPage;

        [Given(@"I am in the Login screen")]
        public void GivenIAmInTheLoginScreen()
        {
            this.environment.Driver.Manage().Window.Maximize();
            loginPage= LoginPage.NavigateTo(this.environment.Driver);         
        }

        [Given(@"I enter the username (.*)")]
        public void GivenIEnterTheUsername(string userName)
        {
            loginPage.EnterUserName = userName;
        }

        [Given(@"I enter the password (.*)")]
        public void GivenIEnterThePassword(string password)
        {
            loginPage.EnterPassword = password;
        }

        [When(@"I login")]
        public void WhenILogin()
        {
            mainCasesPage = loginPage.LoginApplication();
        }

        [Then(@"I should see the Cases screen for (.*)")]
        public void ThenIShouldSeeTheCasesScreenfor(string userName)
        {
            Thread.Sleep(3000);

            Assert.Equal(userName, mainCasesPage.UserRole.ToLower());
        }

        [Then(@"I should an error message")]
        public void ThenIShouldAnErrorMessage()
        {
            Thread.Sleep(1500);
            Assert.Equal("Authentication failed: Token invalid.", loginPage.ErrorMessageText);
        }
    }
}
