using EO.Internal;
using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace iDareUI.Models
{
    public class MainCasesPage
    {
        private RemoteWebDriver driver;
        public MainCasesPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement userLabel => driver.FindElement(By.CssSelector(".prv-headline--role"));
        private IWebElement newCaseButton => driver.FindElement(By.CssSelector("button.mat-icon-button"));
        private IWebElement rangeLabel => driver.FindElement(By.ClassName("mat-paginator-range-label"));
        private IWebElement firstIdRow => driver.FindElements(By.CssSelector("mat-cell.mat-cell.cdk-column-caseReference.mat-column-caseReference.ng-star-inserted"))[0];
        private IWebElement casesButton => driver.FindElements(By.CssSelector("span.prv-sidebar__title"))[0];
        private IWebElement detailsButton => driver.FindElement(By.XPath("/html/body/prv-root/prv-layout/prv-template/div/section[2]/mat-drawer-container/mat-drawer-content/prv-list-cases/div/div[2]/section/div[1]/mat-table/mat-row[1]/mat-cell[11]/button"));
        private IWebElement firstCaseSWVersion => driver.FindElement(By.XPath("/html/body/prv-root/prv-layout/prv-template/div/section[2]/mat-drawer-container/mat-drawer-content/prv-list-cases/div/div[2]/section/div[1]/mat-table/mat-row[1]/mat-cell[4]"));
        public IWebElement nextPageClickableButton => driver.FindElement(By.CssSelector("button.mat-paginator-navigation-next.mat-icon-button"));
        public string[] caseCreationValues = new string[] { "CAS-0123", "1234", "Spain", "Customer" };
        private IWebElement searchFilter => driver.FindElement(By.XPath("/html/body/prv-root/prv-layout/prv-template/div/section[2]/mat-drawer-container/mat-drawer-content/prv-list-cases/div/div[1]/div/prv-table-search/form/mat-form-field/div/div[1]/div/input"));
        private IWebElement searchButton => driver.FindElements(By.CssSelector("button.mat-icon-button"))[1];

        public int GetCaseCreationLabelIdx(string value)
        {
            string[] caseCreationLabels = new string[] { "Case ID", "Serial No", "Country", "Customer" };
            List<string> caseCreationLabelsList = new List<string>();
            caseCreationLabelsList = caseCreationLabels.ToList();
            int idx = caseCreationLabelsList.IndexOf(value);
            return idx;
        }

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
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("mat-row.ng-star-inserted"));
            return rows;
        }
        public IEnumerable<Case> GetRowsElementsCases()
        {
            var ret = new List<Case>();
            var rows = this.GetRowsElements();

            foreach (var row in rows)
            {
                IWebElement rowCaseID = row.FindElement(By.CssSelector("mat-cell.mat-cell.cdk-column-caseReference.mat-column-caseReference.ng-star-inserted"));
                IWebElement rowSerialNo = row.FindElement(By.CssSelector("mat-cell.mat-cell.cdk-column-serial-no.mat-column-serial-no.ng-star-inserted"));
                IWebElement rowCustomer = row.FindElement(By.CssSelector("mat-cell.mat-cell.cdk-column-customer.mat-column-customer.ng-star-inserted"));
                IWebElement rowCountry = row.FindElement(By.CssSelector("mat-cell.mat-cell.cdk-column-country.mat-column-country.ng-star-inserted"));

                var myCase = new Case();
                myCase.CaseID = rowCaseID.Text;
                myCase.SerialNo = rowSerialNo.Text;
                myCase.Customer = rowCustomer.Text;
                myCase.Country = rowCountry.Text;

             ret.Add(myCase);
            }
            return ret;
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
        public void PressSearchButton()
        {
            searchButton.Click();
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
                        var ret = GetRowsElementsCases();
                        return ret.Any(myCase => myCase.CaseID.Contains(caseId));
                    }
                    catch
                    {
                        return false;
                    }
                }, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(25));
        }

        public int ReadLabel()
        {
            int x = -1;
            FlowUtilities.WaitUntilWithoutException(
                () =>
                {
                    string b = driver.FindElement(By.XPath("/html/body/prv-root/prv-layout/prv-template/div/section[2]/mat-drawer-container/mat-drawer-content/prv-list-cases/div/div[2]/section/div[1]/mat-paginator/div/div/div[2]/div")).Text;
                    int start = b.LastIndexOf(" ");
                    if (start < 0)
                    {
                        return false;
                    }
                    string c = b.Substring(start);
                    x = Int32.Parse(c);
                    return x > 0;
                },TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(25));
            return x;
        }
    }
}
