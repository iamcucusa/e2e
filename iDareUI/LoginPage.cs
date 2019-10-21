using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebTestingTestApp.idare
{
    public class LoginPage
    {
        private readonly RemoteWebDriver driver;
        private const string PageUri = @"https://idare-sp13demo-ui.azurewebsites.net";
        public LoginPage(RemoteWebDriver driver)
        {
            this.driver = driver;     
        }
        public LoginPage NavigateTo()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(PageUri);
            return new LoginPage(driver);
        }
        
        private IWebElement userName => driver.FindElements(By.XPath("//input[@id='undefinedInput']"))[0];
        private IWebElement password => driver.FindElements(By.XPath("//input[@id='undefinedInput']"))[1];
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement errorMessage => driver.FindElement(By.XPath("//span[contains(.,' Authentication failed: Token invalid.')]"));
     

        public string UserName
        {
            set
            {
                userName.SendKeys(value);
            }
        }
        public string Password
        {
            set
            {
                password.SendKeys(value);
            }
        }

        public MainCasesPage LoginApplication()
        {
            loginButton.Click();
            return new MainCasesPage(driver);
        }

        public string ErrorMessageText => errorMessage.Text;
    }
}
