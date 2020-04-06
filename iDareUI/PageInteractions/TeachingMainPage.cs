using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace iDareUI.PageInteractions
{
    class TeachingMainPage
    {
        private IWebElement newIssueButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueRuleContainerActionsButton']"));
        private IWebElement newIssueButtonIcon => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueRuleContainerActionsIcon']"));

        private IWebElement issueListContainer => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueRuleContainerList']"));
        private IWebElement supportedIssuesList => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesList']"));
        private IWebElement supportedIssuesListFilter => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListFilter']"));
        private IWebElement supportedIssuesListFilterInput => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListFilterValue']"));
        private IWebElement supportedIssuesListTable => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListTable']"));
        private IWebElement supportedIssuesListPaginator => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListPaginator']"));

   

        private RemoteWebDriver driver;
        public TeachingMainPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToTeachingModule()
        {
            driver.Manage().Window.Maximize();

            var targetUrl = Constants.PageTeachingUri;

            driver.Navigate().GoToUrl(targetUrl);
            FlowUtilities.WaitUntil(
            () =>
            {
                try
                {
                    IWebElement teachingRocheIconHeader = driver.FindElement(By.XPath("//*[@attr.data-idare-id='TeachingRocheIcon']"));
                    return true;
                }
                catch (NoSuchElementException ex)
                {
                    return false;
                }
            }, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100), "The URL specified could not be found");
        }

        public bool NewIssue()
        {

            var NewIssueButtonLoaded = true;
            NewIssueButtonLoaded  = this.newIssueButton != null && NewIssueButtonLoaded;
            NewIssueButtonLoaded = this.newIssueButtonIcon != null && NewIssueButtonLoaded;

            newIssueButton.Click();

            return NewIssueButtonLoaded;
        }

        public bool IssueListIsLoaded() {
            var IssueListElementsLoaded = true;

            IssueListElementsLoaded = this.issueListContainer != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesList != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListFilter != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListFilterInput != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListTable != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListPaginator != null && IssueListElementsLoaded;
            return IssueListElementsLoaded;
        }

    }
}
