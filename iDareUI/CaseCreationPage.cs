using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebTestingTestApp.idare;
using System;
using System.Collections.Generic;
using System.Text;

namespace iDareUI
{
    public class CaseCreationPage
    {
        private RemoteWebDriver driver;
        public CaseCreationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement RexisId => driver.FindElements(By.CssSelector("input#undefinedInput"))[0];
        private IWebElement SerialNo => driver.FindElements(By.CssSelector("input#undefinedInput"))[2];
        private IWebElement SwVersion => driver.FindElements(By.CssSelector("input#undefinedInput"))[3];
        private IWebElement Customer => driver.FindElements(By.CssSelector("input#undefinedInput"))[4];
        private IWebElement Country => driver.FindElements(By.CssSelector("input#undefinedInput"))[5];
        private IWebElement CancelButton => driver.FindElement(By.XPath("//*[contains(text(), 'Cancel')]"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("//*[contains(text(), 'Save')]"));

        public void SetRexisId(string value) { RexisId.SendKeys(value); }
        public void SetSerialNo(string value) { SerialNo.SendKeys(value); }
        public void SetSwVersion(string value) { SwVersion.SendKeys(value); }
        public void SetCustomer(string value) { Customer.SendKeys(value); }
        public void SetCountry(string value) { Country.SendKeys(value); }

        public void ClearRexisId() { RexisId.Clear(); }
        public void ClearSerialNo() { SerialNo.Clear(); }
        public void ClearSwVersion() { SwVersion.Clear(); }
        public void ClearCustomer() { Customer.Clear(); }
        public void ClearCountry() { Country.Clear(); }

        public void PressCancelButton() { CancelButton.Click(); }
        public void PressSaveButton() { SaveButton.Click(); }


    }
}
