using System;
using System.Collections.Generic;
using System.Linq;
using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace iDareUI.PageInteractions
{
    public class CaseDetailsPage
    {
        private RemoteWebDriver driver;
        public CaseDetailsPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement closeCaseDetailsButton => driver.FindElement(By.CssSelector("button.prv-context-info__close.mat-icon-button"));


        public IEnumerable<string> GetInstrumentInformationTitles()
        {
            IList<IWebElement> instrumentInformationFieldsElements = driver.FindElements(By.CssSelector("p.prv-instrument__title"));
            var instrumentInformationFieldsText = instrumentInformationFieldsElements.Select(element => element.Text);
            return instrumentInformationFieldsText;
        }

        public IEnumerable<string> GetInstrumentInformationData()
        {
            IList<IWebElement> instrumentInformationDataElements = driver.FindElements(By.CssSelector("p.prv-instrument__instrument-data"));
            var instrumentInformationDataText = instrumentInformationDataElements.Select(element => element.Text);
            return instrumentInformationDataText;
        }

        public void PressCloseCaseDetailsButton()
        {
            FlowUtilities.WaitUntil(() => closeCaseDetailsButton.Enabled, TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(100));
            closeCaseDetailsButton.Click();
        }
    }
}
