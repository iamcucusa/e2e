using iDareUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebTestingTestApp.idare
{
    public class MainCasesPage
    {
        private RemoteWebDriver driver;
        public MainCasesPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement userLabel => driver.FindElement(By.CssSelector(".prv-headline--role"));
        private IWebElement newCaseButton => driver.FindElement(By.CssSelector("button.mat-icon-button"));
        public string UserRole => userLabel.Text;
        public void NewCase()
        {
            newCaseButton.Click();
        }
    }
}
