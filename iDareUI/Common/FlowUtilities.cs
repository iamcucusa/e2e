using System;
using System.Diagnostics;
using System.Threading;

namespace iDareUI.Common
{
    public static class FlowUtilities
    {
        public static bool WaitUntil(Func<bool> a, TimeSpan timeout, TimeSpan period, string errorMessage = "", bool throwException=true, bool ignoreErrors = true)
        {
            Stopwatch watch = Stopwatch.StartNew();
            while (watch.Elapsed < timeout)
            {
                try
                {
                    if (a())
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    if (ignoreErrors == true)
                    {
                        Console.WriteLine("Error Ignored:\r\n" + e);
                        continue;
                    }

                    throw;
                }
               
                Thread.Sleep(period);
            }
            if (!a() && throwException)
            {
                throw new TimeoutException(errorMessage);
            }
            return false;
        }
        public static bool WaitUntilWithoutException(Func<bool> a, TimeSpan timeout, TimeSpan period)
        {
            return WaitUntil(a, timeout, period, "", false);
        }

    }
}
