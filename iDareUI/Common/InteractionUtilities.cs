using System;
using OpenQA.Selenium;

namespace iDareUI.Common
{
    public static class InteractionUtilities
    {
        public static void SendKeysCharByChar(IWebElement element, string keys)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                element.SendKeys(Char.ToString(keys[i]));
            }
        }

        public static bool IsVisible(string id, IWebDriver webDriver)
        {
            bool displayed;
            try
            {
                displayed = webDriver.FindElement(By.XPath("//*[@attr.data-idare-id='" + id + "']")).Displayed;
            }
            catch (NoSuchElementException)
            {
                // As the element is not present in DOM, it returns true.
                displayed = false;
            }
            catch (StaleElementReferenceException)
            {
                // The stale element reference implies that element is no longer visible, hence returns true.
                displayed = false;
            }
            return displayed;
        }
    }
}
