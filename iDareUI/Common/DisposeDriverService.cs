using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace iDareUI.Common
{
    public static class DisposeDriverService
    {
        public static void KillChromeDriver(DateTime testRunStartTime)
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                if (chromeDriverProcess.StartTime < testRunStartTime)
                {
                    chromeDriverProcess.Kill();
                }
            }
        }
    }
}
