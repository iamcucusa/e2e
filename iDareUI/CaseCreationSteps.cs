﻿using iDareUI.Common;
using iDareUI.Models;
using System;
using TechTalk.SpecFlow;
using Xunit;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace iDareUI
{
    [Binding]
    public class CaseCreationSteps
    {
        private TestingEnvironment environment;
        private MainCasesPage mainCasesPage;
        private CaseCreationPage caseCreationPage;

        private string uniqueID;

        public CaseCreationSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainCasesPage = new MainCasesPage(environment.Driver);
            this.caseCreationPage = new CaseCreationPage(environment.Driver);
        }

        [Given(@"I navigate to the next case page")]
        public void GivenINavigateToTheNextCasePage()
        {
            mainCasesPage.PressNextPageButton();
        }

        [Given(@"I enter to create a new case")]
        public void GivenIEnterToCreateANewCase()
        {
            mainCasesPage.NewCase();
        }

        [When(@"I enter a Rexis ID with a unique ID")]
        public void WhenIEnterARexisIDWithAUniqueID()
        {
            uniqueID = caseCreationPage.SetUniqueRexisId();
        }

        [When(@"I enter (.*) as Rexis ID")]
        public void WhenIEnterAsRexisID(string value)
        {
            caseCreationPage.SetRexisId(value);
        }
        [When(@"I enter (.*) as Serial number")]
        public void WhenIEnterAsSerialNumber(string value)
        {
            caseCreationPage.SetSerialNo(value);
        }

        [When(@"I enter (.*) as Customer")]
        public void WhenIEnterAsCustomer(string value)
        {
            caseCreationPage.SetCustomer(value);
        }

        [When(@"I enter (.*) as Country")]
        public void WhenIEnterAsCountry(string value)
        {
            caseCreationPage.SetCountry(value);
        }

        [When(@"I enter the option (.*) of the dropdown as Timezone")]
        public void WhenIEnterTheOptionOfTheDropdownAsTimezone(int p0)
        {
            
            caseCreationPage.SelectOptionInTimezoneDropdown(p0);
        }

        [When(@"I leave the ID field empty")]
        public void WhenILeaveTheIDFieldEmpty()
        {
            caseCreationPage.SetRexisId("");
        }
        [When(@"I upload a Problem Report with name (.*)")]
        public void WhenIUploadAProblemReportWithName(string fileName)
        {
            caseCreationPage.PressUploadFileButton();
            string filePath = DataLocation.GetProblemReportDirectory(fileName);
            caseCreationPage.UploadDummyProblemReport(filePath);
            FlowUtilities.WaitUntil(
            () => (caseCreationPage.uploadedFile.Text.Contains(fileName)),
            TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
        }
        [When(@"I press the Save button")]
        public void WhenIPressTheSaveButton()
        {
            caseCreationPage.PressSaveButton();
        }
        [When(@"I press the Cancel button")]
        public void WhenIPressTheCancelButton()
        {
            caseCreationPage.PressCancelButton();
        }

        [Then(@"the Save button is disabled")]
        public void ThenTheSaveButtonIsDisabled()
        {
            Assert.False(caseCreationPage.SaveButton.Enabled, "The Save button is enabled");
        }

        [Then(@"the first page of the cases overview is shown")]
        public void ThenTheFirstPageOfTheCasesOverviewIsShown()
        {

            mainCasesPage.WaitUntilRangeLabelChanges();
            Assert.StartsWith("1 -", mainCasesPage.RangeLabelText);
        }

        [Then(@"the case with the unique ID as Rexis ID is on the top of the list")]
        public void ThenTheCaseWithTheUniqueIdAsRexisIDIsOnTheTopOfTheList()
        {
            FlowUtilities.WaitUntil(() => uniqueID.Contains(mainCasesPage.firstIdRowText), TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));
        }

        [When(@"I create a new Case")]
        public void WhenICreateANewCase()
        {
            this.GivenIEnterToCreateANewCase();
            this.WhenIEnterAsRexisID("CAS-0123");
            this.WhenIEnterAsSerialNumber("12345");
            this.WhenIEnterAsCountry("Spain");
            this.WhenIEnterAsCustomer("Customer");
            this.WhenIEnterTheOptionOfTheDropdownAsTimezone(2);
            this.WhenIUploadAProblemReportWithName(Constants.ProblemReportOnlySummary);
            this.WhenIPressTheSaveButton();
        }
    }
}
