using iDareUI.Common;
using System;
using TechTalk.SpecFlow;

namespace iDareUI
{
    [Binding]
    public sealed class KillChromeDriver
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            DisposeDriverService.KillChromeDriver(DateTime.Now);
        }
    }
}
