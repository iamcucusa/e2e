using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;


namespace iDareUI.Models
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
        private IWebElement rangeLabel => driver.FindElement(By.ClassName("mat-paginator-range-label"));
        private IWebElement firstIdRow => driver.FindElements(By.CssSelector("mat-cell.mat-cell.cdk-column-rexis.mat-column-rexis.ng-star-inserted"))[0];
        public string UserRole => userLabel.Text;
        public string RangeLabelText => rangeLabel.Text;
        public string firstIdRowText => firstIdRow.Text;


        public void PressNextPageButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement nextPageClickableButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mat-paginator-navigation-next.mat-icon-button")));
            nextPageClickableButton.Click();
        }
        public void NewCase()
        {
            newCaseButton.Click();
        }

        //IWebElement caseBox = environment.Driver.FindElements(By.CssSelector("mat-cell.mat-cell.cdk-column-rexis.mat-column-rexis.ng-star-inserted"))[0];
        //string caseBoxText = caseBox.Text;

    }
}
