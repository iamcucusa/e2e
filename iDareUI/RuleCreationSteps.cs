using System;
using TechTalk.SpecFlow;

namespace iDareUI
{
    [Binding]
    public class RuleCreationSteps
    {
        [Given(@"I click in the issue Issue(.*) from the issue list")]
        public void GivenIClickInTheIssueIssueFromTheIssueList(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click add footprint for Issue(.*)")]
        public void GivenIClickAddFootprintForIssue(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Event Catalog is correct for the system cobas(.*)")]
        public void GivenEventCatalogIsCorrectForTheSystemCobas(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I select Case(.*) from production")]
        public void GivenISelectCaseFromProduction(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I add the event '(.*)' from the catalog to the sequenced events")]
        public void GivenIAddTheEventFromTheCatalogToTheSequencedEvents(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I save the Rule")]
        public void WhenISaveTheRule()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the rule is correct")]
        public void ThenTheRuleIsCorrect()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
