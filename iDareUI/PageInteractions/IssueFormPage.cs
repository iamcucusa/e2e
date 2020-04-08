using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using iDareUI.Models;
using OpenQA.Selenium.Support.UI;

namespace iDareUI.PageInteractions
{
    public class IssueFormPage
    {
        private RemoteWebDriver driver;
        public IssueFormPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement supportedIssueForm => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueForm']"));
        private IWebElement supportedIssueFormFieldTitle => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldTitle']"));
        private IWebElement supportedIssueFormFieldTitleLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldTitleLable']"));
        private IWebElement supportedIssueFormFieldTitleValue => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldValue']"));
        private IWebElement supportedIssueFormFieldDescription => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldDescription']"));
        private IWebElement supportedIssueFormFieldDescriptionLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldDescriptionLabel']"));
        private IWebElement supportedIssueFormFieldDescriptionValue => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldDescriptionValue']"));
        private IWebElement supportedIssueFormFieldInstrument => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldInstrument']"));
        private IWebElement supportedIssueFormFieldInstrumentLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldInstrumentLabel']"));
        private IWebElement supportedIssueFormFieldInstrumentValue => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldInstrumentValue']"));
        private IWebElement supportedIssueFormFieldSystem => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystem']"));
        private IWebElement supportedIssueFormFieldSystemLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystemLabel']"));
        private IWebElement supportedIssueFormSystemsSelect => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystemSelect']"));
        private IList<IWebElement> supportedIssueFormSystems => driver.FindElements(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSystemSelectOption']"));
        private IWebElement supportedIssueFormFieldCategory => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldCategory']"));
        private IWebElement supportedIssueFormFieldCategoryLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldCategoryLabel']"));
        private IWebElement supportedIssueFormFieldCategoryValue => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldCategoryValue']"));

        private IWebElement supportedIssueFormFieldSWVersions => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSWVersions']"));
        private IWebElement supportedIssueFormFieldSWVersionsLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSWVersionsLabel']"));
        private IWebElement supportedIssueFormFieldSWVersionsValue => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueFormFieldSWVersionsValue']"));

        public void SetTitle(string value) {
            supportedIssueFormFieldTitleValue.Clear();
            if (value != "")
            {
                supportedIssueFormFieldTitleValue.SendKeys(value);
            }
            else {
                var len = supportedIssueFormFieldTitleValue.Text.Length + 1;
                for (int i = 0; i < len; i++) {
                    supportedIssueFormFieldTitleValue.SendKeys(Keys.Backspace);
                }
            }
       
            
        }
        public void SetDescription(string value) {
            supportedIssueFormFieldDescriptionValue.Clear();

            if (value != "")
                supportedIssueFormFieldDescriptionValue.SendKeys(value);
        }
        public void SetInstrument(string value) {
            supportedIssueFormFieldDescriptionValue.Clear();
            if (value != "")
                supportedIssueFormFieldInstrumentValue.SendKeys(value);
        }
        public void SetSystem(string value) {

            if (value != "")
            {
                supportedIssueFormSystemsSelect.Click();
                var SystemOption = driver.FindElement(By.XPath("//mat-option/span[contains(.,'" + " " + value + " " + "')]"));
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SystemOption));
                SystemOption.Click();
            }
            
        }
        public void SetCategory(string value) {
            supportedIssueFormFieldCategoryValue.Clear();
            if (value != "")
            {
                supportedIssueFormFieldCategoryValue.SendKeys(value);
            }
            else {
                var len = supportedIssueFormFieldTitleValue.Text.Length + 1;
                for (int i = 0; i < len; i++)
                {
                    supportedIssueFormFieldTitleValue.SendKeys(Keys.Backspace);
                }
            }
            
        }
        public void SetSWVersions(string value) {
            supportedIssueFormFieldSWVersionsValue.Clear();
            if (value != "")
                supportedIssueFormFieldSWVersionsValue.SendKeys(value);
        }

        public IList<IWebElement> GetSystemOptions()
        {
            return supportedIssueFormSystems;
        }

        public bool AreIssueFormElementsLoaded() {

            var IssueFormElementsLoaded = true;

            IssueFormElementsLoaded = supportedIssueFormFieldTitle != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldTitleLabel != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldDescription != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldDescriptionLabel != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldDescriptionValue != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldInstrument != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldInstrumentLabel != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldInstrumentValue != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldSystem != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldSystemLabel != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormSystemsSelect != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldCategory != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldCategoryLabel != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldCategoryValue != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldSWVersions != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldSWVersionsLabel != null && IssueFormElementsLoaded;
            IssueFormElementsLoaded = supportedIssueFormFieldSWVersionsValue != null && IssueFormElementsLoaded;

            return IssueFormElementsLoaded;
        }

        public void populateIssueForm(IssueForm issueFormFields) {
            SetTitle(issueFormFields.Title);
            SetCategory(issueFormFields.Category);
            SetInstrument(issueFormFields.ObservedInInstrument);
            SetSWVersions(issueFormFields.ExcludedSoftwareVersions);
            SetSystem(issueFormFields.System);
            SetDescription(issueFormFields.Description);
        }

        public bool validateIssueTitleField(string title)
        {
            var value = supportedIssueFormFieldTitleValue.GetAttribute("value");

            return value == title; ;
        }

        public bool validateIssueDescriptionField(string description)
        {

            return supportedIssueFormFieldDescriptionValue.GetAttribute("value") == description;
        }

        public bool validateIssueInstrumentField(string instrument)
        {

            return supportedIssueFormFieldInstrumentValue.GetAttribute("value") == instrument;
        }

        public bool validateIssueSWVersionField(string swVersion)
        {

            return supportedIssueFormFieldSWVersionsValue.GetAttribute("value") == swVersion;
        }

        public bool validateIssueSystemField(string system)
        {
            if (system != "")
            {
                var SystemOptionValueSpan = driver.FindElement(By.XPath("//*[@id='mat-select-1']/div/div[1]/span/span"));

                return SystemOptionValueSpan.Text == system;
            }
            return true;
            
        }

        public bool validateIssueCategoryField(string category)
        {

            return supportedIssueFormFieldCategoryValue.GetAttribute("value") == category;
        }

        public bool validateIssueFormFields(IssueForm issueFormFields)
        {

            return validateIssueTitleField(issueFormFields.Title)
                && validateIssueDescriptionField(issueFormFields.Description)
                && validateIssueInstrumentField(issueFormFields.ObservedInInstrument)
                && validateIssueSWVersionField(issueFormFields.ExcludedSoftwareVersions)
                && validateIssueSystemField(issueFormFields.System)
                && validateIssueCategoryField(issueFormFields.Category);
        }

        public void clearIssueForm() {

            supportedIssueFormFieldTitleValue.Clear();
            supportedIssueFormFieldDescriptionValue.Clear();
            supportedIssueFormFieldInstrumentValue.Clear();
            supportedIssueFormFieldCategoryValue.Clear();
            supportedIssueFormFieldSWVersionsValue.Clear();
        }

        
    }
}
