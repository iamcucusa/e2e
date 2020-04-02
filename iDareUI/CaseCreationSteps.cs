using iDareUI.Common;
using System;
using System.Collections.Generic;
using iDareUI.PageInteractions;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class CaseCreationSteps
    {
        private TestingEnvironment environment;
        private CaseMainPage mainCasesPage;
        private CaseCreationPage caseCreationPage;

        private string uniqueID;

        public CaseCreationSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainCasesPage = new CaseMainPage(environment.Driver);
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
            Assert.True(caseCreationPage.CaseCreationDialog.Displayed, "The dialog to create a new case was not displayed");
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
            string filePath = DataLocation.GetProblemReportFilePath(fileName);
            caseCreationPage.SimulateFileUploading(filePath);
            caseCreationPage.AssertFileUploadListFileIsDisplayed(fileName);
        }
        [When(@"I upload more than one Problem Report with name (.*)")]
        public void WhenIUploadMoreThanOneProblemReportWithName(string fileNameDelimited)
        {
            List<string> fileNameList = caseCreationPage.GetFileNameList(fileNameDelimited);
            string filePath = DataLocation.GetProblemReportsDirectory(fileNameList);
            caseCreationPage.SimulateFileUploading(filePath);

            foreach (string fileName in fileNameDelimited.Split(','))
            {
                caseCreationPage.AssertFileUploadListFileIsDisplayed(fileName);
            }
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
            mainCasesPage.PressPreviousPageButton();
            mainCasesPage.WaitUntilRangeLabelChanges();
            Assert.StartsWith("1 -", mainCasesPage.RangeLabelText);
        }

        [Then(@"the case with the unique ID as Rexis ID is on the top of the list")]
        public void ThenTheCaseWithTheUniqueIdAsRexisIDIsOnTheTopOfTheList()
        {
            var response = FlowUtilities.WaitUntil(() => mainCasesPage.firstIdRowText.Contains(uniqueID), 
                TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(100));

            Assert.True(response.Success, "The case is not displayed.");
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

        [Given(@"there are at least (.*) cases created")]
        public void ThereAreAtLeastCasesCreated(int cases)
        {
            FlowUtilities.WaitUntil(() =>
            {
                if (!(mainCasesPage.ReadPageLabel() > cases))
                {
                    this.GivenICreateANewCaseWithoutProblemReport();
                }
                return mainCasesPage.ReadPageLabel() > cases;
            }, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));
        }
        [Given(@"I create a new case without problem report")]
        public void GivenICreateANewCaseWithoutProblemReport()
        {
            this.GivenIEnterToCreateANewCase();
            this.WhenIEnterARexisIDWithAUniqueID();
            this.WhenIEnterAsSerialNumber("12345");
            this.WhenIEnterAsCountry("Spain");
            this.WhenIEnterAsCustomer("Customer");
            this.WhenIEnterTheOptionOfTheDropdownAsTimezone(2);
            this.WhenIPressTheSaveButton();
        }

        [Then(@"I should see the progress of the (.*) uploads")]
        public void ThenIShouldSeeTheProgressOfTheUpload(int numberOfUploads)
        {
            mainCasesPage.WaitUntilProgressBarIsShown(numberOfUploads);
        }
        [Then(@"The progress of the uploads should disappear")]
        public void ThenTheProgressOfTheUploadsShouldDisappear()
        {
            mainCasesPage.AssertThatAllProgressBarsAreRemoved();
        }

        [Then(@"I should not see any upload progress bars")]
        public void ThenIShouldNotSeeAnyProgressBars()
        {
            mainCasesPage.AssertThatNoProgressBarIsShown();
        }

        [Then(@"the status gets updated as successful")]
        public void ThenTheStatusGetsUpdatedAsSuccessful()
        {
            
            FlowUtilities.WaitUntil(() => uniqueID.Contains(mainCasesPage.firstIdRowText), TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));
            
        }

        [Then(@"the status gets updated as error")]
        public void ThenTheStatusGetsUpdatedAsError()
        {
            mainCasesPage.WaitUntilProgressBarShowsUpdatedStatusError(300);
        }


    }
}
