using System;
using System.Collections.Generic;
using System.Linq;
using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Xunit;

namespace iDareUI.PageInteractions
{
    public class CaseCreationPage
    {
        private readonly RemoteWebDriver driver;
        public CaseCreationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement RexisId => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCaseIDInput']"));
        private IWebElement SerialNo => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentSerialNoInput']"));
        private IWebElement Customer => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCustomerInput']"));
        private IWebElement Country => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCountryInput']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCancelButton']"));
        private IWebElement CloseButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCloseButton']"));
        private IWebElement CaseFilesUploadList => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseFilesToUploadList']"));
        private IWebElement FileUploadInput => driver.FindElement(By.XPath("//*[@attr.data-idare-id='FileUploadInput']"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentSaveButton']"));
        public IWebElement UploadFileButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='FileUploadSubmitButton']"));
        public IWebElement CaseFilesToUploadList => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseFilesToUploadList']"));
        public IWebElement TimezoneElement => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentTimezoneLabel']")); 
        public IWebElement CaseCreationDialog => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDialog']")); 
        public IList<IWebElement> GetTimezoneOptions()
        {
            IList<IWebElement> timezoneOptions = driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseComponentTimezoneOption']"));
            return timezoneOptions;
        }

        public void SetRexisId(string value)
        {
            InteractionUtilities.SendKeysCharByChar(RexisId, value);
        }
        public void SetSerialNo(string value) { SerialNo.SendKeys(value); }
        public void SetCustomer(string value) { Customer.SendKeys(value); }
        public void SetCountry(string value) { Country.SendKeys(value); }

        public string SetUniqueRexisId()
        {
            Guid guid = Guid.NewGuid();
            string unicId = guid.ToString();
            InteractionUtilities.SendKeysCharByChar(RexisId, unicId);
            return unicId;
        }
        
        public void PressCancelButton() { CancelButton.Click(); }
        public void PressSaveButton() { SaveButton.Click(); }
        public void PressUploadFileButton() { UploadFileButton.Click(); }
        public List<string> GetFileNameList(string fileNameDelimited)
        {
            List<string> fileNameList = new List<string>();
            if (!fileNameDelimited.Contains(','))
            {
                fileNameList.Add(fileNameDelimited);
                return fileNameList;
            }
            else
            {
                var fileNames = fileNameDelimited.Split(",", StringSplitOptions.RemoveEmptyEntries);
                for (var index = 0; index < fileNames.Length; index++)
                {
                    fileNames[index] = fileNames[index].Trim();
                }

                return fileNames.ToList();
            }
        }
        public void SimulateFileUploading(string filePath)
        {
            IWebElement inputFile = this.FileUploadInput;
            inputFile.SendKeys(filePath);
        }
        public void AssertFileUploadListFileIsDisplayed(string fileName)
        {
            var response = FlowUtilities.WaitUntil(() =>
            {
                IWebElement caseFileUploaded = this.CaseFilesToUploadList;
                return caseFileUploaded.Text.Contains(fileName);
            }, TimeSpan.FromSeconds(60), TimeSpan.FromMilliseconds(100));
            
            Assert.True(response.Success, response.ToString());
        }
        public void SelectOptionInTimezoneDropdown(int optionIndex)
        {
            TimezoneElement.Click();
            TimezoneElement.SendKeys("U");
            var response = FlowUtilities.WaitUntil(() =>
            {
                var optionsLoaded = GetTimezoneOptions().Count >= optionIndex - 1;

                if (!optionsLoaded)
                {
                    TimezoneElement.Click();
                }

                return optionsLoaded;
            }, TimeSpan.FromSeconds(4), TimeSpan.FromMilliseconds(100));

            Assert.True(response.Success, response.ToString());

            IWebElement timezoneOption = GetTimezoneOptions().ToArray()[optionIndex - 1];
            timezoneOption.Click();
        }
    }
}
