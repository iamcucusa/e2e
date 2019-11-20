using System;
using System.Diagnostics;
using System.Threading;

namespace iDareUI.Common
{
    public static class FlowUtilities
    {
        public static void WaitUntil(Func<bool> a, TimeSpan timeout, TimeSpan period, string errorMessage = "")
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
                throw new TimeoutException(errorMessage);
            }
        }

        public static bool CheckOut (Func<bool> a, TimeSpan timeout, TimeSpan period, string errorMessage = "")
        {
            Stopwatch watch = Stopwatch.StartNew();
            while (watch.Elapsed < timeout)
            {
                if (a())
                {
                    return true;
                }
                Thread.Sleep(period);
            }
            if (!a())
            {
                return false;
            }
            return false;
        }
    }
}
