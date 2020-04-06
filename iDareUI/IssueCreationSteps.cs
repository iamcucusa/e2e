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

        public IssueCreationSteps(TestingEnvironment environment)
        {
            this.environment = environment;
            this.mainTeachingPage = new TeachingMainPage(environment.Driver);
            this.issueCreationPage = new IssueCreationPage(environment.Driver);
        }

        [Given(@"I navigate successfully to the teaching module")]
        public void GivenINavigateSuccessfullyToTheTeachingModule()
        {
            this.environment.Driver.Manage().Window.Maximize();
            this.mainTeachingPage.NavigateToTeachingModule();
        }
        
        [Given(@"I am in the issue list in teaching module")]
        public void GivenIAmInTheIssueListInTeachingModule()
        {
            Assert.True(this.mainTeachingPage.IssueListIsLoaded());
        }
        
        [Given(@"I click add issue button")]
        public void GivenIClickAddIssueButton()
        {
            Assert.True(this.mainTeachingPage.NewIssue());
           
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
            Assert.True(true);
        }
        
        [When(@"I enter '(.*)' as System")]
        public void WhenIEnterAsSystem(string system)
        {
            Assert.True(true);
        }
        
        
        [When(@"I enter '(.*)' as Title")]
        public void WhenIEnterAsTitle(string title)
        {
            Assert.True(true);
        }
        
        [When(@"I click save button is enabled")]
        public void WhenIClickSaveButtonIsEnabled()
        {
            Assert.True(true);
        }
        
        [Then(@"the save button must be disabled")]
        public void ThenTheSaveButtonMustBeDisabled()
        {
            Assert.True(true);
        }
        
        [Then(@"the save button must be enabled")]
        public void ThenTheSaveButtonMustBeEnabled()
        {
            Assert.True(true);
        }
        
        [Then(@"the issue list is updated successfully and includes the new created issue")]
        public void ThenTheIssueListIsUpdatedSuccessfullyAndIncludesTheNewCreatedIssue()
        {
            Assert.True(true);
        }
        
        [Then(@"the the fiedls have the correct value")]
        public void ThenTheTheFiedlsHaveTheCorrectValue(Table table)
        {
            Assert.True(true);
        }
        
        [Then(@"the first issue edit button must be the last cell with the defined icon")]
        public void ThenTheFirstIssueEditButtonMustBeTheLastCellWithTheDefinedIcon()
        {
            Assert.True(true);
        }
    }
}
