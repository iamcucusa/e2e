using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace iDareUI.PageInteractions
{
    public class IssueUpdatePage
    { 


        private string supportedIssuesUpdateXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdate']";
        private string supportedIssuesUpdateHeaderXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdateHeader']";
        private string supportedIssuesUpdateHeaderTitleXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdateHeaderTitle']";
        private string supportedIssuesUpdateHeaderButtonXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdateHeaderButton']";
        private string supportedIssuesUpdateHeaderIconXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdateHeaderIcon']";
        private string supportedIssuesUpdateCancelButtonXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdateCancelButton']";
        private string supportedIssuesUpdateSaveButtonXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdateSaveButton']";
        private string SupportedIssuesUpdateNoteXPath => "//*[@attr.data-idare-id='SupportedIssuesUpdateNote']";

        private IWebElement supportedIssuesUpdate => driver.FindElement(By.XPath(supportedIssuesUpdateXPath));
        private IWebElement supportedIssuesUpdateHeader => driver.FindElement(By.XPath(supportedIssuesUpdateHeaderTitleXPath));
        private IWebElement supportedIssuesUpdateHeaderTitle => driver.FindElement(By.XPath(supportedIssuesUpdateHeaderTitleXPath));
        private IWebElement supportedIssuesUpdateHeaderButton => driver.FindElement(By.XPath(supportedIssuesUpdateHeaderButtonXPath));
        private IWebElement supportedIssuesUpdateHeaderIcon => driver.FindElement(By.XPath(supportedIssuesUpdateHeaderIconXPath));
        private IWebElement supportedIssuesUpdateCancelButton => driver.FindElement(By.XPath(supportedIssuesUpdateCancelButtonXPath));
        private IWebElement supportedIssuesUpdateSaveButton => driver.FindElement(By.XPath(supportedIssuesUpdateSaveButtonXPath));
        private IWebElement supportedIssuesUpdateNote => driver.FindElement(By.XPath(SupportedIssuesUpdateNoteXPath));

        public IssueFormPage issueFormPage;

        private RemoteWebDriver driver;
        public IssueUpdatePage(RemoteWebDriver driver)
        {
            this.driver = driver;
            this.issueFormPage = new IssueFormPage(driver);

        }

        public bool EditIssueDialogIsOpenAndCorrectlyLoaded()
        {
           return driver.FindElements(By.XPath(supportedIssuesUpdateXPath)).Count == 1 && 
                   driver.FindElements(By.XPath(supportedIssuesUpdateHeaderXPath)).Count == 1 && 
                   driver.FindElements(By.XPath(supportedIssuesUpdateHeaderTitleXPath)).Count == 1 && 
                   driver.FindElements(By.XPath(supportedIssuesUpdateHeaderButtonXPath)).Count == 1 && 
                   driver.FindElements(By.XPath(supportedIssuesUpdateHeaderIconXPath)).Count == 1 &&  
                   driver.FindElements(By.XPath(supportedIssuesUpdateCancelButtonXPath)).Count == 1 &&   
                   driver.FindElements(By.XPath(supportedIssuesUpdateSaveButtonXPath)).Count == 1 &&   
                   driver.FindElements(By.XPath(SupportedIssuesUpdateNoteXPath)).Count == 1
                   && issueFormPage.AreIssueFormElementsLoaded();
        }

        public bool SaveIssueButtonIsEnabled() {

            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(supportedIssuesUpdateSaveButton);

            return supportedIssuesUpdateSaveButton.GetAttribute("disabled") == null;
        }

        public bool SaveIssueButtonIsDisabled()
        {
           
            return supportedIssuesUpdateSaveButton.GetAttribute("disabled") == "true";
        }

        public void SaveIssue()
        {

            supportedIssuesUpdateSaveButton.Click();
        }

        public void CancelUpdateIssue() {
            supportedIssuesUpdateCancelButton.Click();
        }
    }

    
}
