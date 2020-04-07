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
        private IWebElement DetailsTitleCaseId => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CasedDetailHeaderHeading1']"));
        private IWebElement instrumentInformationCard => driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfo']"));
        private IWebElement instrumentInformationHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoHeader']")); 
        private IWebElement recordedRunsCard => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailRecordedRunsInfoContainer']"));
        private IWebElement recordedRunsHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailRecordedRunsInfoContainerTitle']"));
       
        public void PressMatExpansionPanelInstrumentInformation() { instrumentInformationHeader.Click(); }
        public void PressMatExpansionPanelRecordedRuns() { recordedRunsHeader.Click(); }
        public IEnumerable<string> GetDetailsCardHeaders()
        {
            IList<IWebElement> detailsHeaders = driver.FindElements(By.CssSelector("span.section-title"));
            List<string> detailsHeadersText = new List<string> (detailsHeaders.Select(element => element.Text));

            detailsHeadersText.Add(instrumentInformationHeader.Text);
            detailsHeadersText.Add(recordedRunsHeader.Text);

            return detailsHeadersText;
        }

        public IEnumerable<string> GetInstrumentInformationTitles()
        {
            IList<IWebElement> instrumentInformationFieldsElements = new List<IWebElement>();
            instrumentInformationFieldsElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoLabNameLabel']")));
            instrumentInformationFieldsElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoLabAddressLabel']")));
            instrumentInformationFieldsElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoInstrumentTypeLabel']")));
            instrumentInformationFieldsElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoSerialNumberLabel']")));
            instrumentInformationFieldsElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoSfVersionLabel']")));
            instrumentInformationFieldsElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoTimeZoneLabel']")));
            var instrumentInformationFieldsText = instrumentInformationFieldsElements.Select(element => element.Text);
            return instrumentInformationFieldsText;
        }

        public IEnumerable<string> GetInstrumentInformationData()
        {
            IList<IWebElement> instrumentInformationDataElements = new List<IWebElement>();
            instrumentInformationDataElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoLabNameValue']")));
            instrumentInformationDataElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoLabAddressValue']")));
            instrumentInformationDataElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoInstrumentTypeValue']")));
            instrumentInformationDataElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoSerialNumberValue']")));
            instrumentInformationDataElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoSfVersionValue']")));
            instrumentInformationDataElements.Add(driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoTimeZoneValue']")));
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
