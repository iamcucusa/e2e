using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace iDareUI.Models
{
    public class CaseCreationPage
    {
        private RemoteWebDriver driver;
        public TestingEnvironment environment;
        public CaseCreationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement RexisId => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCaseIDInput']"));
        private IWebElement SerialNo => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentSerialNoInput']"));
        private IWebElement Customer => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCustomerInput']"));
        private IWebElement Country => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCountryInput']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentCancelButton']"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentSaveButton']"));
        public IWebElement uploadFileButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='FileUploadSubmitButton']"));
        public IWebElement caseFilesToUploadList => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseFilesToUploadList']"));
        public IWebElement timezoneElement => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseComponentTimezoneLabel']"));
        public IList<IWebElement> GetTimezoneOptions()
        {
            IList<IWebElement> timezoneOptions = driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseComponentTimezoneOption']"));
            return timezoneOptions;
        }

        public void SetRexisId(string value)
        {
            SendKeysCharByChar(RexisId, value);
        }
        public void SetSerialNo(string value) { SerialNo.SendKeys(value); }
        public void SetCustomer(string value) { Customer.SendKeys(value); }
        public void SetCountry(string value) { Country.SendKeys(value); }

        public string SetUniqueRexisId()
        {
            Guid guid = Guid.NewGuid();
            string unicId = guid.ToString();
            SendKeysCharByChar(RexisId, unicId);
            return unicId;
        }
        protected void SendKeysCharByChar(IWebElement element, string keys)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                element.SendKeys(Char.ToString(keys[i]));
            }
        }
        public void PressCancelButton() { CancelButton.Click(); }
        public void PressSaveButton() { SaveButton.Click(); }
        public void PressUploadFileButton() { uploadFileButton.Click(); }
        public List<string> GetFileNameList(string fileName)
        {
            List<string> fileNameList = new List<string>();
            if (!fileName.Contains(','))
            {
                fileNameList.Add(fileName);
                return fileNameList;
            }
            else
            {
                fileNameList = new List<string>(fileName.Split(" , "));
                return fileNameList;
            }
        }
        public void SimulateFileUploading(string filePath)
        {
            IWebElement inputFile = driver.FindElement(By.XPath("//*[@attr.data-idare-id='FileUploadInput']"));
            inputFile.SendKeys(filePath);
        }

        public void WaitForTheFilesToUpload(string fileName)
        {
            FlowUtilities.WaitUntil(() =>
            {
                IWebElement caseFileUploaded = driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseFilesToUploadList']"));
                return caseFileUploaded.Text.Contains(fileName);
            }, TimeSpan.FromSeconds(4), TimeSpan.FromMilliseconds(100));
        }

        public void SelectOptionInTimezoneDropdown(int p0)
        {
            timezoneElement.Click();
            timezoneElement.SendKeys("U");
            FlowUtilities.WaitUntil(() =>
            {
                var optionsLoaded = GetTimezoneOptions().Count >= p0 - 1;

                if (!optionsLoaded)
                {
                    timezoneElement.Click();
                }

                return optionsLoaded;
            }, TimeSpan.FromSeconds(4), TimeSpan.FromMilliseconds(100));

            IWebElement timezoneOption = GetTimezoneOptions().ToArray()[p0 - 1];
            timezoneOption.Click();
        }
    }
}
