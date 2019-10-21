using iDareUI.Common;
using iDareUI.Models;
using TechTalk.SpecFlow;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class CaseCreationSteps
    {
        private TestingEnvironment environment;
        public CaseCreationSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainCasesPage = new MainCasesPage(environment.Driver);
            this.caseCreationPage = new CaseCreationPage(environment.Driver);
        }
        private MainCasesPage mainCasesPage;
        private CaseCreationPage caseCreationPage;
        
        [Given(@"I enter to create a new case")]
        public void GivenIEnterToCreateANewCase()
        {
            mainCasesPage.NewCase();
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

        [When(@"I enter (.*) as Software Version")]
        public void WhenIEnterAsSoftwareVersion(string value)
        {
            caseCreationPage.SetSwVersion(value);
        }

        [When(@"I enter (.*) as Country")]
        public void WhenIEnterAsCountry(string value)
        {
            caseCreationPage.SetCountry(value);
        }

        [When(@"I leave the Customer field empty")]
        public void WhenILeaveTheCustomerFieldEmpty()
        {
            caseCreationPage.SetCustomer("");
        }
        
        [Then(@"the Save button is disabled")]
        public void ThenTheSaveButtonIsDisabled()
        {
            Assert.False(caseCreationPage.SaveButton.Enabled, "The Save button is enabled");  
        }
    }
}
