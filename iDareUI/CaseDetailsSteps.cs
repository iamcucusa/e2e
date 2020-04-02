using iDareUI.Common;
using iDareUI.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using iDareUI.PageInteractions;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class CaseDetailsSteps
    {
        private TestingEnvironment environment;
        private CaseDetailsPage caseDetailsPage;
        public CaseDetailsSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.caseDetailsPage = new CaseDetailsPage(environment.Driver);
        }
        [Then(@"the Instrument Information should be shown under the Instrument Information section")]
        public void ThenTheInstrumentInformationShouldBeShownUnderTheInstrumentInformationSection()
        {
            string[] expectedInstrumentInformationTitles = new string[] { "Lab name", "Lab address", "Instrument type", "Instrument serial number", "Software version", "Instrument time zone" };
            string[] expectedInstrumentInformationData = new string[] { "Customer", "Spain", "-", "12345", "01.03.08.1011", "(UTC-11:00) Coordinated Universal Time-11" };
            var obtainedTitles = caseDetailsPage.GetInstrumentInformationTitles();
            var obtainedData = caseDetailsPage.GetInstrumentInformationData();
            Assert.True(expectedInstrumentInformationTitles.SequenceEqual(obtainedTitles),
                $"The Information Titles are not the expected ones. \nExpected: {string.Join(", ", expectedInstrumentInformationTitles)}, \nActual: {string.Join(", ", obtainedTitles)}");
            Assert.True(expectedInstrumentInformationData.SequenceEqual(obtainedData),
                $"The Information Titles are not the expected ones. \nExpected: {string.Join(", ", expectedInstrumentInformationData)}, \nActual: {string.Join(", ", obtainedData)}");
        }
    }
}
