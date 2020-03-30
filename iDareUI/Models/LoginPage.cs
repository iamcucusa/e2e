using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace iDareUI.Models
{
    public class LoginPage
    {
        private readonly RemoteWebDriver driver;
        private readonly ILog log;

        public LoginPage(RemoteWebDriver driver, ILog log)
        {
            this.driver = driver;
            this.log = log;
        }
        public void NavigateTo()
        {
            driver.Manage().Window.Maximize();

            var targetUrl = Constants.PageUri;
            this.log.Info($"Navigating to {targetUrl}");

            driver.Navigate().GoToUrl(targetUrl);
            FlowUtilities.WaitUntil(
            () =>
            {
                try
                {
                    IWebElement rocheLogo = driver.FindElement(By.CssSelector("svg.prv-roche-icon"));
                    return true;
                }
                catch (NoSuchElementException ex)
                {
                    log.Error("The URL specified could not be found" + ex);
                    return false;
                }
            }, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100), "The URL specified could not be found");
        }

        private IWebElement userName => driver.FindElements(By.XPath("//input[@id='undefinedInput']"))[0];
        private IWebElement password => driver.FindElements(By.XPath("//input[@id='undefinedInput']"))[1];
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement errorMessage => driver.FindElement(By.XPath("//span[contains(.,' Authentication failed: Wrong credentials.')]"));
     

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
