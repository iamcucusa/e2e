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
    }
}
