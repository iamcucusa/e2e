﻿using iDareUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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