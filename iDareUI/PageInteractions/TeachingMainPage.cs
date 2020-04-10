using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace iDareUI.PageInteractions
{
    class TeachingMainPage
    {
        private IWebElement teachingUserInfo => driver.FindElement(By.XPath("//*[@attr.data-idare-id='TeachingUserInfo']"));   
        private IWebElement teachingHeadlineComponentGreeting => driver.FindElement(By.XPath("//*[@attr.data-idare-id='TeachingHeadlineComponentGreeting']"));
        private IWebElement teachingHeadlineComponentName => driver.FindElement(By.XPath("//*[@attr.data-idare-id='TeachingHeadlineComponentName']"));
        private IWebElement teachingHeadlineComponentRole => driver.FindElement(By.XPath("//*[@attr.data-idare-id='TeachingHeadlineComponentRole']"));

        public IssuesRulesPage issuesRulesPage;
        private RemoteWebDriver driver;
        public TeachingMainPage(RemoteWebDriver driver)
        {
            this.driver = driver;
            issuesRulesPage = new IssuesRulesPage(driver);
        }

        public bool userIsLoggedInAs(string role, string username) {

            return teachingUserInfo != null &&
                teachingHeadlineComponentName != null &&
                teachingHeadlineComponentName != null &&
                teachingHeadlineComponentRole != null &&
                teachingHeadlineComponentRole.Text == role &&
                teachingHeadlineComponentName.Text == username;

        }

        public string loggedUserName() {
            return teachingHeadlineComponentName.Text;
        }
        

    }
}
