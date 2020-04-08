using System;
using TechTalk.SpecFlow;

namespace iDareUI
{
    [Binding]
    public class IssueUpdateSteps
    {
        [Given(@"Issue list is displayed")]
        public void GivenIssueListIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The issue list has at least one issue")]
        public void GivenTheIssueListHasAtLeastOneIssue()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click in the edit button for the first issue in the list")]
        public void GivenIClickInTheEditButtonForTheFirstIssueInTheList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter '(.*)' as Category")]
        public void GivenIEnterAsCategory(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I cancel the first issue update and the issue remaings unchanged")]
        public void ThenICancelTheFirstIssueUpdateAndTheIssueRemaingsUnchanged()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the updated issue is the first in the list of issues")]
        public void ThenTheUpdatedIssueIsTheFirstInTheListOfIssues()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Category field of the edited issue is equal to '(.*)'")]
        public void ThenTheCategoryFieldOfTheEditedIssueIsEqualTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the ModifiedBy field of the edited issue is equal to DebugUser")]
        public void ThenTheModifiedByFieldOfTheEditedIssueIsEqualToDebugUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Modified field of the edited issue is equal to '(.*)'")]
        public void ThenTheModifiedFieldOfTheEditedIssueIsEqualTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
