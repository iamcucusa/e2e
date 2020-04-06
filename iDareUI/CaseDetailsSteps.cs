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
        private CaseCreationSteps caseCreationSteps;
        private FeatureContext featureContext;
        private CaseMainPage caseMainPage;
        private CaseInvestigationPage caseInvestigationPage;

        public CaseDetailsSteps(TestingEnvironment environment, FeatureContext featureContext)
        {
            this.environment = environment;
            this.caseInvestigationPage = new CaseInvestigationPage(environment.Driver);
            this.caseDetailsPage = new CaseDetailsPage(environment.Driver);
            this.caseMainPage = new CaseMainPage(environment.Driver);
            this.caseCreationSteps = new CaseCreationSteps(environment, featureContext);
            this.featureContext = featureContext;
        }

        [Then(@"I enter to the details of a case")]
        public void ThenIEnterToTheDetailsOfACase()
        {
            caseMainPage.PressDetailsButton();
        }

        [When(@"all files of the (.*) case have been processed")]
        public void WhenAllFilesOfTheCASCaseHaveBeenProcessed(string caseId)
        {
            caseMainPage.WaitUntilCasesAreUpdated(caseId, "01.");
        }

        [Then(@"the Instrument Information should be shown under the Instrument Information section")]
        public void ThenTheInstrumentInformationShouldBeShownUnderTheInstrumentInformationSection()
        {
            string[] expectedInstrumentInformationTitles = new string[]{ "Lab name", "Lab address", "Instrument type", "Instrument serial number", "Software version", "Instrument time zone" };
            string[] expectedInstrumentInformationData = new string[] { "ศูนย์บริการโลหิตแห่งชาติ สภากาชาดไทย", "Forrenstrasse 2, 6343 Rotkreuz", "cobas 6800 movable", "WSIM001234", "01.03.08.1011", "(UTC-11:00) Coordinated Universal Time-11" };
            var obtainedTitles = caseDetailsPage.GetInstrumentInformationTitles();
            var obtainedData = caseDetailsPage.GetInstrumentInformationData();
            Assert.True(expectedInstrumentInformationTitles.SequenceEqual(obtainedTitles),
                $"The Information Titles are not the expected ones. \nExpected: {string.Join(", ", expectedInstrumentInformationTitles)}, \nActual: {string.Join(", ", obtainedTitles)}");
            Assert.True(expectedInstrumentInformationData.SequenceEqual(obtainedData),
                $"The Information Titles are not the expected ones. \nExpected: {string.Join(", ", expectedInstrumentInformationData)}, \nActual: {string.Join(", ", obtainedData)}");
        }

        [Then(@"the titles shown in the Details of the case are correct")]
        public void ThenTheTitlesShownInTheDetailsOfTheCaseAreCorrect()
        {
            string[] expectedDetailsHeaders = new string[] { "Instrument states", "Detected issues", "Footprint", "Instrument information", "Recorded runs" };
            var obtainedTitles = caseDetailsPage.GetDetailsCardHeaders();
            Assert.True(expectedDetailsHeaders.SequenceEqual(obtainedTitles),
               $"The Detail titles are not the expected ones. \nExpected: {string.Join(", ", expectedDetailsHeaders)}, \nActual: {string.Join(", ", obtainedTitles)}");
        }

        [Then(@"the system shall fill the case fields automatically")]
        public void ThenTheSystemShallFillTheCaseFieldsAutomatically()
        {
            caseCreationSteps.ThenTheProgressOfTheUploadsShouldDisappear();
            Case currentCaseCreated = new Case();
            Case caseDetails = (Case)this.featureContext["caseDetails"];
            caseMainPage.WaitUntilCasesAreUpdated(caseDetails.CaseID, "01.");
            IEnumerable<Case> caseListComponent = caseMainPage.GetRowsElementsCases();
            IEnumerable<Case> caseDetailsCreated = caseListComponent.Where(myCase => myCase.CaseID.Contains(caseDetails.CaseID));
            if (caseDetailsCreated.Count() == 1)
            {
                currentCaseCreated.SWVersion = caseDetailsCreated.ElementAt(0).SWVersion;
                currentCaseCreated.SerialNo = caseDetailsCreated.ElementAt(0).SerialNo;
                currentCaseCreated.Customer = caseDetailsCreated.ElementAt(0).Customer;
                currentCaseCreated.Country = caseDetailsCreated.ElementAt(0).Country;
            }
            Assert.False(String.IsNullOrEmpty(currentCaseCreated.SWVersion), "The fields were not automatically filled");
            Assert.False(String.IsNullOrEmpty(currentCaseCreated.SerialNo), "The fields were not automatically filled");
            Assert.False(String.IsNullOrEmpty(currentCaseCreated.Customer), "The fields were not automatically filled");
            Assert.False(String.IsNullOrEmpty(currentCaseCreated.Country), "The fields were not automatically filled");
        }
        [Then(@"The user navigates to the investigation view")]
        public void ThenTheUserNavigatesToTheInvestigationView()
        {
            caseInvestigationPage.PressInvestigateTab();
        }
    }
}
