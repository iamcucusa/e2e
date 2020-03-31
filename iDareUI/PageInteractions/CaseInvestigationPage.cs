using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace iDareUI.PageInteractions
{
    public class CaseInvestigationPage
    {
        private RemoteWebDriver driver;
        public CaseInvestigationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement instrumentInformationCard => driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfo']"));
        private IWebElement instrumentInformationHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='InstrumentInfoHeader']")); 
        private IWebElement countersCard => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailHardwareCounters']"));
        private IWebElement countersHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailHardwareCountersHeader']"));
        private IWebElement instrumentStatesCard => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailInvestigateTimelineBox']"));
        private IWebElement instrumentStatesHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailInvestigateTimelineTitle']")); 
        private IWebElement recordedRunsCard => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailInvestigateRunBox']"));
        private IWebElement recordedRunsHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailInvestigateRunsTitle']")); 
        private IWebElement flagsCard => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailInvestigateFlagsBox']")); 
        private IWebElement flagsHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailInvestigateFlagsTitle']"));
        private IWebElement flagsTabsContainer => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseDetailFlagsTabs']"));
        private IList<IWebElement> flagsTabs => flagsTabsContainer.FindElements(By.CssSelector("div.mat-tab-label"));
        private IWebElement flagsProcessingModuleA => flagsTabs[0];
        private IWebElement flagsProcessingModuleB => flagsTabs[1];
        private IWebElement InvestigateTab => driver.FindElement(By.XPath("/html/body/prv-root/prv-case-details/div/section/mat-tab-group/mat-tab-header/div[2]/div/div/div[2]"));



        public void PressInvestigateTab() { InvestigateTab.Click(); }
        public void PressMatExpansionPanelInstrumentInformation() { instrumentInformationHeader.Click(); }
        public void PressMatExpansionPanelCounters() { countersHeader.Click(); }
        public void PressFlagProcessingModuleATab() { flagsProcessingModuleA.Click(); }
        public void PressFlagProcessingModuleBTab() { flagsProcessingModuleB.Click(); }




    }
}
