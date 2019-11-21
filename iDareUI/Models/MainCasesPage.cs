using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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

        internal void WaitUntilRangeLabelChanges()
        {
            FlowUtilities.WaitUntil(() => RangeLabelText.StartsWith("1 -"), TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));
        }
    }
}
