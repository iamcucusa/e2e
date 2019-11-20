using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
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

        private IWebElement RexisId => driver.FindElement(By.Id("mat-input-1"));
        private IWebElement SerialNo => driver.FindElement(By.Id("mat-input-2"));
        private IWebElement Customer => driver.FindElement(By.Id("mat-input-3"));
        private IWebElement Country => driver.FindElement(By.Id("mat-input-4"));
        private IWebElement CancelButton => driver.FindElements(By.CssSelector("button.mat-button"))[0];
        public IWebElement SaveButton => driver.FindElements(By.CssSelector("button.mat-button"))[2];
        public IWebElement uploadFileButton => driver.FindElement(By.CssSelector("#mat-dialog-0 > prv-case > div > mat-dialog-content > prv-file-select > div > div.file-select-add > button"));
        public IWebElement uploadedFile => driver.FindElement(By.CssSelector("div.file-to-upload-name"));
        public IWebElement timezoneElement => driver.FindElements(By.CssSelector("div.mat-select-value"))[2];
        public IList<IWebElement> GetTimezoneOptions()
        {
            IList<IWebElement> timezoneOptions = driver.FindElements(By.CssSelector("span.mat-option-text"));
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



        public void UploadDummyProblemReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("Could not find the path: " + filePath);
            }

            FlowUtilities.WaitUntil(
                () => (WindowsApi.FindWindow(null, "Abrir") != IntPtr.Zero || WindowsApi.FindWindow(null, "Open") != IntPtr.Zero),
                TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
            if (WindowsApi.FindWindow(null, "Abrir") != IntPtr.Zero)
            {
                var dialogHWnd = WindowsApi.FindWindow(null, "Abrir");
                var setFocus = WindowsApi.SetForegroundWindow(dialogHWnd);
                if (setFocus)
                {
                    Thread.Sleep(500);
                    SendKeys.SendWait(filePath);
                    SendKeys.SendWait("{ENTER}");
                }
            }
            else
            {
                var dialogHWnd = WindowsApi.FindWindow(null, "Open");
                var setFocus = WindowsApi.SetForegroundWindow(dialogHWnd);
                if (setFocus)
                {
                    Thread.Sleep(500);
                    SendKeys.SendWait(filePath);
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }
    }
}
