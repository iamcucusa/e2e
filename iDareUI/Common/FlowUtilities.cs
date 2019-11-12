using System;
using System.Diagnostics;
using System.Threading;

namespace iDareUI.Common
{
    public static class FlowUtilities
    {
        public static void WaitUntil(Func<bool> a, TimeSpan timeout, TimeSpan period)
        {
            Stopwatch watch = Stopwatch.StartNew();
            while (watch.Elapsed < timeout)
            {
                if (a())
                {
                    return;
                }
                Thread.Sleep(period);
            }
            if (!a())
            {
                throw new TimeoutException();
            }
        }

        public static class DisposeDriverService
        {
            public static DateTime? TestRunStartTime { get; set; }
            public static void KillChromeDriver()
            {
                Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
               
                foreach (var chromeDriverProcess in chromeDriverProcesses)
                {  
                    if (chromeDriverProcess.StartTime < TestRunStartTime)
                    {
                        chromeDriverProcess.Kill();
                    }
                } 
            }
        }
    }
}
