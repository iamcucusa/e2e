using System;
using System.Collections.Generic;
using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace iDareUI.PageInteractions
{
    public class IssueCreationPage
    {
        private IWebElement supportedIssuesNewContainer => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNew']"));
        private IWebElement supportedIssuesNewHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNewHeader']"));
        private IWebElement supportedIssuesNewHeaderTitle => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNewHeaderTitle']"));
        private IWebElement supportedIssuesNewHeaderButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNewHeaderButton']"));
        private IWebElement supportedIssuesNewHeaderIcon => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNewHeaderIcon']"));
        private IWebElement supportedIssuesNewCancelButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNewCancelButton']"));
        private IWebElement supportedIssuesNewSaveButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNewSaveButton']"));
        private IWebElement supportedIssuesNewNote => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesNewNote']"));

        public IssueFormPage issueFormPage;


        private RemoteWebDriver driver;
        public IssueCreationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
            this.issueFormPage = new IssueFormPage(driver);

        }

        public bool NewIssueDialogIsOpen()
        {
            var NewIssueDialogIsOpen = true;

            NewIssueDialogIsOpen = this.supportedIssuesNewContainer != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssuesNewHeader != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssuesNewHeaderTitle != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssuesNewHeaderButton != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssuesNewHeaderIcon != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssuesNewCancelButton != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssuesNewSaveButton != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssuesNewNote != null && NewIssueDialogIsOpen;


            return NewIssueDialogIsOpen && this.issueFormPage.AreIssueFormElementsLoaded();
        }

        public bool SaveIssueButtonIsEnabled() {

            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(supportedIssuesNewSaveButton);

            return supportedIssuesNewSaveButton.GetAttribute("disabled") == null;
        }

        public bool SaveIssueButtonIsDisabled()
        {
           
            return supportedIssuesNewSaveButton.GetAttribute("disabled") == "true";
        }
    }

    
}
