using System;
using System.Collections.Generic;
using iDareUI.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace iDareUI.PageInteractions
{
    public class IssuesRulesPage
    {
        
        private RemoteWebDriver driver;
        public IssuesRulesPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        

        private IWebElement newIssueButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueRuleContainerActionsButton']"));
        private IWebElement newIssueButtonIcon => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueRuleContainerActionsIcon']"));

        private IWebElement issueListContainer => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IssueRuleContainerList']"));
        private IWebElement supportedIssuesList => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesList']"));
        private IWebElement supportedIssuesListFilter => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListFilter']"));
        private IWebElement supportedIssuesListFilterInput => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListFilterValue']"));
        private IWebElement supportedIssuesListTable => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListTable']"));
        private IWebElement supportedIssuesListPaginator => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListPaginator']"));

        private IWebElement supportedIssuesListHeaderRow => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListHeaderRow']"));
        private IWebElement supportedIssuesListRuleInWorkHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListRuleInWorkHeader']"));
        private IWebElement supportedIssuesListTitleHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListTitleHeader']"));
        private IWebElement supportedIssuesListCategoryHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListCategoryHeader']"));
        private IWebElement supportedIssuesListSystemHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListSystemHeader']"));
        private IWebElement supportedIssuesListFootprintsHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListFootprintsHeader']"));
        private IWebElement supportedIssuesListModifiedByHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListModifiedByHeader']"));
        private IWebElement supportedIssuesListModifiedHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListModifiedHeader']"));
        private IWebElement supportedIssuesListEditHeader => driver.FindElement(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListEditHeader']"));

        private IList<IWebElement> supportedIssuesListCellRows => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListCellRows']"));
        private IList<IWebElement> supportedIssuesListRuleInWorkCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListRuleInWorkCell']"));
        private IList<IWebElement> supportedIssuesListTitleCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListTitleCell']"));
        private IList<IWebElement> supportedIssuesListCategoryCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListCategoryCell']"));
        private IList<IWebElement> supportedIssuesListSystemCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListSystemCell']"));
        private IList<IWebElement> supportedIssuesListFootprintsCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListFootprintsCell']"));
        private IList<IWebElement> supportedIssuesListModifiedByCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListModifiedByCell']"));
        private IList<IWebElement> supportedIssuesListModifiedCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListModifiedCell']"));
        private IList<IWebElement> supportedIssuesListEditCells => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListEditCell']"));
        private IList<IWebElement> supportedIssuesListEditCellButtons => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListEditCellButton']"));
        private IList<IWebElement> supportedIssuesListEditCellIcons => driver.FindElements(By.XPath("//*[@attr.data-idare-id='SupportedIssuesListEditCellIcon']"));

        public bool NewIssue()
        {

            var NewIssueButtonLoaded = true;
            NewIssueButtonLoaded = this.newIssueButton != null && NewIssueButtonLoaded;
            NewIssueButtonLoaded = this.newIssueButtonIcon != null && NewIssueButtonLoaded;

            newIssueButton.Click();

            return NewIssueButtonLoaded;
        }

        public bool IssueListIsLoaded()
        {
            var IssueListElementsLoaded = true;

            IssueListElementsLoaded = this.issueListContainer != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesList != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListFilter != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListFilterInput != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListTable != null && IssueListElementsLoaded;
            IssueListElementsLoaded = this.supportedIssuesListPaginator != null && IssueListElementsLoaded;
            return IssueListElementsLoaded;
        }

        public bool IssueListTableHeaderIsCorrect() {

            return supportedIssuesListHeaderRow != null &&
                supportedIssuesListRuleInWorkHeader != null &&
                supportedIssuesListTitleHeader != null &&
                supportedIssuesListCategoryHeader != null &&
                supportedIssuesListSystemHeader != null &&
                supportedIssuesListFootprintsHeader != null &&
                supportedIssuesListModifiedByHeader != null &&
                supportedIssuesListModifiedHeader != null &&
                supportedIssuesListEditHeader != null &&
                supportedIssuesListCellRows.Count > 0;

            
       }

        public bool IssueListTableIsPopulatedWithAtLeastOneRow()
        {

            return supportedIssuesListRuleInWorkCells.Count > 0 &&
                supportedIssuesListTitleCells.Count > 0 &&
                supportedIssuesListCategoryCells.Count > 0 &&
                supportedIssuesListSystemCells.Count > 0 &&
                supportedIssuesListFootprintsCells.Count > 0 &&
                supportedIssuesListModifiedByCells.Count > 0 &&
                supportedIssuesListEditCells.Count > 0 && 
                supportedIssuesListModifiedCells.Count > 0;



        }

        public bool IssueIsAddedOnTopOfTheList(IssueRow issueRow) {
            return supportedIssuesListTitleCells[0].Text == issueRow.Title &&
                supportedIssuesListCategoryCells[0].Text == issueRow.Category &&
                supportedIssuesListSystemCells[0].Text == issueRow.System &&
                supportedIssuesListFootprintsCells[0].Text == issueRow.Footprints &&
                supportedIssuesListModifiedByCells[0].Text == issueRow.ModifiedBy;

        }

        public bool IssueEditButtonIsCorrect(int index) {

            return supportedIssuesListEditCells[index] != null &&
                supportedIssuesListEditCellButtons[index] != null &&
                supportedIssuesListEditCellButtons[index].TagName == "button" &&
                supportedIssuesListEditCellIcons[index] != null;
        }

        public int numberOfIssuesInTheList() {
            return supportedIssuesListCellRows.Count;
        }

        public bool editIssue(int index) {

            var editButtonValid = supportedIssuesListEditCellButtons.Count > 0 &&
            supportedIssuesListEditCellButtons[index].TagName == "button";

            supportedIssuesListEditCellButtons[index].Click();

            return editButtonValid;
        }
    }


}
