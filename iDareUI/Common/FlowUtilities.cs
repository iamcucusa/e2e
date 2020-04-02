using System;
using System.Diagnostics;
using System.Threading;

namespace iDareUI.Common
{
    public static class FlowUtilities
    {
        public static WaitResponse WaitUntil(Func<bool> waitUntilResult, TimeSpan timeout, TimeSpan period, string errorMessage = "", bool throwException=true, bool ignoreErrors = true)
        {
            Stopwatch watch = Stopwatch.StartNew();
            while (watch.Elapsed < timeout)
            {
                try
                {
                    if (waitUntilResult())
                    {
                        return new WaitResponse {Success = true};
                    }
                }
                catch (Exception e)
                {
                    if (ignoreErrors == true)
                    {
                        Console.WriteLine("Error Ignored:\r\n" + e);
                        continue;
                    }

                    return new WaitResponse { Exception = e, Reason = e.Message, TimedOut = false  };
                }
               
                Thread.Sleep(period);
            }
            if (!waitUntilResult() && throwException)
            {
                return new WaitResponse{Exception = new TimeoutException(errorMessage), TimedOut  =  true, Reason = "TimedOut"} ;
            }

            return new WaitResponse{Success = true};
        }
        public static WaitResponse WaitUntilWithoutException(Func<bool> waitUntilResult, TimeSpan timeout, TimeSpan period)
        {
            return WaitUntil(waitUntilResult, timeout, period, "", false);
        }

    }
}
