using System;
using iDareUI.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace iDareUI.PageInteractions
{
    public class NavigationPage
    {
        RemoteWebDriver driver;

        public NavigationPage(RemoteWebDriver driver)
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
    }
}
