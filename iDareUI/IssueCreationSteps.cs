using iDareUI.Common;
using iDareUI.Models;
using System;
using System.Collections.Generic;
using iDareUI.PageInteractions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace iDareUI
{
    [Binding]
    public class IssueCreationSteps
    {
        private TestingEnvironment environment;
        private TeachingMainPage mainTeachingPage;
        private IssueCreationPage issueCreationPage;
        private NavigationPage navigationPage;

        public IssueCreationSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainTeachingPage = new TeachingMainPage(environment.Driver);
            this.issueCreationPage = new IssueCreationPage(environment.Driver);
        }

        [Given(@"I click add issue button")]
        public void GivenIClickAddIssueButton()
        {
            Assert.True(this.mainTeachingPage.issuesRulesPage.NewIssue());
           
        }
        
        [Given(@"Issue Dialog is open")]
        public void GivenIssueDialogIsOpen()
        {
            Assert.True(this.issueCreationPage.NewIssueDialogIsOpen());
        }
        
        [Given(@"I enter the following fields")]
        public void GivenIEnterTheFollowingFields(Table table)
        {
            var issueFormFields = table.CreateInstance<IssueForm>();

            issueCreationPage.issueFormPage.populateIssueForm(issueFormFields);

            Assert.True(issueCreationPage.issueFormPage.validateIssueFormFields(issueFormFields));
        }
        
        [When(@"I enter '(.*)' as Category")]
        public void WhenIEnterAsCategory(string category)
        {
            issueCreationPage.issueFormPage.SetCategory(category);
      
            Assert.True(issueCreationPage.issueFormPage.validateIssueCategoryField(category));
        }
        
        [When(@"I enter '(.*)' as System")]
        public void WhenIEnterAsSystem(string system)
        {
            issueCreationPage.issueFormPage.SetSystem(system);

            Assert.True(issueCreationPage.issueFormPage.validateIssueSystemField(system));
        }
        
        
        [When(@"I enter '(.*)' as Title")]
        public void WhenIEnterAsTitle(string title)
        {
            issueCreationPage.issueFormPage.SetTitle(title);

            var result = issueCreationPage.issueFormPage.validateIssueTitleField(title);

            Assert.True(result);
        }
        
        [When(@"I click save button is enabled")]
        public void WhenIClickSaveButtonIsEnabled()
        {
            Assert.True(issueCreationPage.SaveIssueButtonIsEnabled());
            issueCreationPage.SaveNewIssue();
        }
        
        [Then(@"the save button must be disabled")]
        public void ThenTheSaveButtonMustBeDisabled()
        {
            Assert.True(issueCreationPage.SaveIssueButtonIsDisabled());
        }
        
        [Then(@"the save button must be enabled")]
        public void ThenTheSaveButtonMustBeEnabled()
        {
            Assert.True(issueCreationPage.SaveIssueButtonIsEnabled());
        }
        
        [Then(@"the issue list is updated successfully and includes the new created issue")]
        public void ThenTheIssueListIsUpdatedSuccessfullyAndIncludesTheNewCreatedIssue(Table table)
        {
            var issueRowFields = table.CreateInstance<IssueRow>();

            Assert.True(mainTeachingPage.issuesRulesPage.IssueListIsLoaded());
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListTableHeaderIsCorrect());
            Assert.True(mainTeachingPage.issuesRulesPage.IssueListTableIsPopulatedWithAtLeastOneRow());
            Assert.True(mainTeachingPage.issuesRulesPage.IssueIsAddedOnTopOfTheList(issueRowFields));
        }
        
        [Then(@"the first issue edit button must be the last cell with the defined icon")]
        public void ThenTheFirstIssueEditButtonMustBeTheLastCellWithTheDefinedIcon()
        {
            Assert.True(mainTeachingPage.issuesRulesPage.IssueEditButtonIsCorrect(0));
        }

        [Then(@"I cancel the issue creation and no new issue is created in the list")]
        public void ICancelTheIssueCreationAndNoNewIssueIsCreatedInTheList()
        {
            var issueListTotal = mainTeachingPage.issuesRulesPage.numberOfIssuesInTheList();

            issueCreationPage.CancelNewIssue();

            Assert.Equal(issueListTotal, mainTeachingPage.issuesRulesPage.numberOfIssuesInTheList());
        }
    }
}
