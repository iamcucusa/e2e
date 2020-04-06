using System;
using System.Collections.Generic;
using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


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

        private IWebElement supportedIssueForm => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueForm']"));
        private IWebElement supportedIssueFormFieldTitle => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldTitle']"));
        private IWebElement supportedIssueFormFieldTitleLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldTitleLable']"));
        private IWebElement supportedIssueFormFieldDescription => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldDescription']"));
        private IWebElement supportedIssueFormFieldDescriptionLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldDescriptionLabel']"));
        private IWebElement supportedIssueFormFieldDescriptionValue => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldDescriptionValue']"));
        private IWebElement supportedIssueFormFieldInstrument => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldInstrument']"));
        private IWebElement supportedIssueFormFieldInstrumentLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldInstrumentLabel']"));
        private IWebElement supportedIssueFormFieldInstrumentValue => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldInstrumentValue']"));
        private IWebElement supportedIssueFormFieldSystem => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystem']"));
        private IWebElement supportedIssueFormFieldSystemLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystemLabel']"));
        private IWebElement supportedIssueFormFieldSystemSelect => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystemSelect']"));
        private IList<IWebElement> supportedIssueFormSystems => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystemSelectOption']"));
        private IList<IWebElement> supportedIssueFormFieldCategory => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldCategory']"));
        private IList<IWebElement> supportedIssueFormFieldCategoryLabel => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldCategoryLabel']"));
        private IList<IWebElement> supportedIssueFormFieldCategoryValue => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldCategoryValue']"));
        private IList<IWebElement> supportedIssueFormFieldSWVersions => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSWVersions']"));
        private IList<IWebElement> supportedIssueFormFieldSWVersionsLabel => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSWVersionsLabel']"));
        private IList<IWebElement> supportedIssueFormFieldSWVersionsValue => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSWVersionsValue']"));

        public IList<IWebElement> GetSystemOptions()
        {
            return supportedIssueFormSystems;
        }

        private RemoteWebDriver driver;
        public IssueCreationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
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
            NewIssueDialogIsOpen = this.supportedIssueForm != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldTitle != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldTitleLabel != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldDescription != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldDescriptionLabel != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldDescriptionValue != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldInstrument != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldInstrumentLabel != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldInstrumentValue != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldSystem != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldSystemLabel != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldSystemSelect != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldCategory != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldCategoryLabel != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldCategoryValue != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldSWVersions != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldSWVersionsLabel != null && NewIssueDialogIsOpen;
            NewIssueDialogIsOpen = this.supportedIssueFormFieldSWVersionsValue != null && NewIssueDialogIsOpen;

            return NewIssueDialogIsOpen;
        }
    }

    
}
