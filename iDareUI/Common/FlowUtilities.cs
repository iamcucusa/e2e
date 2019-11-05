using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
    }
}
