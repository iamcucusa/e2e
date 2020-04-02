using System;
using System.Collections.Generic;
using System.Linq;
using iDareUI.Common;
using iDareUI.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Xunit;
using static iDareUI.CasesOverviewSteps;

namespace iDareUI.PageInteractions
{
    public class CaseMainPage
    {
        private RemoteWebDriver driver;
        public CaseMainPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement userLabel => driver.FindElement(By.XPath("//*[@attr.data-idare-id='IDareUserInfoUserName']")); 
        private IWebElement newCaseButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseListComponentAddCaseButton']"));
        private IWebElement rangeLabel => driver.FindElement(By.ClassName("mat-paginator-range-label"));
        private IWebElement firstIdRow => driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseListComponentCaseRow']"))[0]; 
        private IWebElement casesButton => driver.FindElements(By.CssSelector("span.prv-sidebar__title"))[0]; 
        private IWebElement detailsButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='DetectedIssuesContainerViewButton']"));
        private IWebElement firstCaseSWVersion => driver.FindElement(By.XPath("/html/body/prv-root/prv-layout/prv-template/div/section[2]/mat-drawer-container/mat-drawer-content/prv-list-cases/div/div[2]/section/div[1]/mat-table/mat-row[1]/mat-cell[4]"));
        public IWebElement nextPageClickableButton => driver.FindElement(By.CssSelector("button.mat-paginator-navigation-next.mat-icon-button"));
        private IWebElement searchFilter => driver.FindElement(By.XPath("/html/body/prv-root/prv-layout/prv-template/div/section[2]/mat-drawer-container/mat-drawer-content/prv-case-detected-issue/div/div[1]/div/mat-form-field/div/div[1]/div/input"));
        private IEnumerable<IWebElement> caseRows => driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseListComponentCaseRow']"));

        public string[] caseCreationValues = new string[] { "CAS-0123", "1234", "Spain", "Customer" };

        private IWebElement searchButton => driver.FindElements(By.CssSelector("button.mat-icon-button"))[1];

        public IEnumerable<string> GetGridHeaderNames()
        {
            var headers = this.GetGridHeaderElements();
            return headers.Select(element => element.Text);
        }

        public IList<IWebElement> GetGridHeaderElements()
        {
            IList<IWebElement> allHeaders = driver.FindElements(By.CssSelector("button.mat-sort-header-button"));
            return allHeaders;
        }
        public IList<IWebElement> GetRowsElements()
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseListComponentCaseRow']"));
            return rows;
        }
        public IEnumerable<Case> GetRowsElementsCases()
        {
            var ret = new List<Case>();
            var rows = this.GetRowsElements();

            foreach (var row in rows)
            {
                IWebElement rowCaseID = row.FindElement(By.XPath("//*[@attr.data-idare-id='CaseListComponentCaseIDValue']"));
                 IWebElement rowSerialNo = row.FindElement(By.XPath("//*[@attr.data-idare-id='CaseListComponentSerialNumberValue']")); 
                IWebElement rowCustomer = row.FindElement(By.XPath("//*[@attr.data-idare-id='CaseListComponentCustomerValue']"));
                IWebElement rowCountry = row.FindElement(By.XPath("//*[@attr.data-idare-id='CaseListComponentCountryValue']"));

                var myCase = new Case();
                myCase.CaseID = rowCaseID.Text;
                myCase.SerialNo = rowSerialNo.Text;
                myCase.Customer = rowCustomer.Text;
                myCase.Country = rowCountry.Text;

                ret.Add(myCase);
            }
            return ret;
        }

        public IList<IWebElement> GetRowsIds()
        {
            IList<IWebElement> caseIds = driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseListComponentCaseIDValue']"));
            return caseIds;
        }

        public IEnumerable<DateTime> GetCreationDateTime()
        {
            var dateTimes = this.GetCreationTimeText();
            return dateTimes.Select(element => DateTime.ParseExact(element, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
        }

        public IEnumerable<DateTime> GetSortedDates()
        {
            return this.GetCreationDateTime().OrderByDescending(element => element.Ticks);
        }

        public IEnumerable<string> GetCreationTimeText()
        {
            var dateTimesText = this.GetCreationTimeElements();
            return dateTimesText.Select(element => element.Text);
        }

        public IList<IWebElement> GetCreationTimeElements()
        {
            IList<IWebElement> allCreationTimeElements =
                driver.FindElements(By.CssSelector("mat-cell.cdk-column-creation-time.mat-column-creation-time.ng-star-inserted")).ToList();
            return allCreationTimeElements;
        }

        public string UserRole => userLabel.Text;
        public string RangeLabelText => rangeLabel.Text;
        public string firstIdRowText => firstIdRow.Text;
        public string firstCaseSWVersionText => firstCaseSWVersion.Text;

        public void PressNextPageButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement nextPageClickableButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mat-paginator-navigation-next.mat-icon-button")));
            nextPageClickableButton.Click();
        }
        public void PressPreviousPageButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement previousPageClickableButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mat-paginator-navigation-previous.mat-icon-button.mat-button-base")));
            previousPageClickableButton.Click();
        }
        public void NewCase()
        {
            newCaseButton.Click();
        }
        public void PressCasesButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement nextPageClickableButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("span.prv-sidebar__title")));
            casesButton.Click();
        }

        public void PressDetailsButton()
        {
            detailsButton.Click();
        }

        public void SearchFilterCases(string value)
        {
            searchFilter.Click();
            searchFilter.SendKeys(value);
        }
        public void PressEnterToFilter()
        {
            searchFilter.SendKeys(Keys.Enter);
        }

        internal void WaitUntilRangeLabelChanges()
        {
            FlowUtilities.WaitUntil(() => RangeLabelText.StartsWith("1 -"), TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));
        }
        internal void WaitUntilCasesAreCreated(string caseId)
        {
            FlowUtilities.WaitUntil(
                () =>
                {
                    try
                    {
                        var ret = GetRowsIds();
                        return ret.Any(id => id.Text.Contains(caseId));
                    }
                    catch
                    {
                        return false;
                    }
                }, TimeSpan.FromSeconds(2000), TimeSpan.FromMilliseconds(25));
        }

        public bool SelectCases(Case caseCreatedForSearch, Enum property)
        {
            var ret = GetRowsElementsCases();
            string caseProperty = null;
            bool value = false;

            switch (property)
            {
                case CaseSearchProperty.CaseId:
                    caseProperty = caseCreatedForSearch.CaseID;
                    value = ret.All(myCase => myCase.CaseID.Contains(caseProperty));
                    break;
                case CaseSearchProperty.Country:
                    caseProperty = caseCreatedForSearch.Country;
                    value = ret.All(myCase => myCase.Country.Contains(caseProperty));
                    break;
                case CaseSearchProperty.Customer:
                    caseProperty = caseCreatedForSearch.Customer;
                    value = ret.All(myCase => myCase.Customer.Contains(caseProperty));
                    break;
                case CaseSearchProperty.SerialNumber:
                    caseProperty = caseCreatedForSearch.SerialNo;
                    value = ret.All(myCase => myCase.SerialNo.Contains(caseProperty));
                    break;
                default:
                    throw new InvalidOperationException("The search property is wrong.");
            }
            return value;
        }

        public int ReadPageLabel()
        {
            int numberOfCases = -1;
            var response = FlowUtilities.WaitUntilWithoutException(
                () =>
                {
                    IWebElement componentPaginator = driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseListComponentPaginator']"));
                    IWebElement inside1 = componentPaginator.FindElement(By.CssSelector("div.mat-paginator-range-label"));
                    string rangeLabel = inside1.Text;

                    int start = rangeLabel.LastIndexOf(" ");
                    if (start < 0)
                    {
                        return false;
                    }
                    string labelCut = rangeLabel.Substring(start);
                    numberOfCases = Int32.Parse(labelCut);
                    return numberOfCases > 0;
                },TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(25));

            Assert.True(response.Success, response.ToString());

            return numberOfCases;
        }

        public void AssertThatNoProgressBarIsShown()
        {
            //dont want a progress bar - if one appears we fail - so a timeout is good
            var response = FlowUtilities.WaitUntil(() => driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseUploadFileProgressBar']")).Count >= 1, 
                TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
            
            Assert.True(response.TimedOut);
        }

        public void WaitUntilProgressBarIsShown(int numberOfUploads)
        {
            for (int i = 0; i < numberOfUploads; i++)
            {
                FlowUtilities.WaitUntil(
                    () => driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseUploadFileProgressBar']")).Count == numberOfUploads, 
                    TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(100));
            }
        }

        public void WaitUntilProgressBarShowsUpdatedStatusSuccess(int maxWaitSeconds)
        {
            FlowUtilities.WaitUntil(() =>
                {
                    return driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseUploadFileSuccess']")) != null;
                }, TimeSpan.FromSeconds(maxWaitSeconds), TimeSpan.FromMilliseconds(100));
        }

        public void WaitUntilProgressBarShowsUpdatedStatusError(int maxWaitSeconds)
        {
            FlowUtilities.WaitUntil(() =>
            {
                return driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseUploadFileError']")) != null;
            }, TimeSpan.FromSeconds(maxWaitSeconds), TimeSpan.FromMilliseconds(100));
        }
    }
}
