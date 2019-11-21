using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iDareUI.Common
{
    public static class DataLocation
    {
        public static string GetProblemReportDirectory(string zipFileName)
        {
            string fileName = Path.GetDirectoryName(typeof(DataLocation).Assembly.Location) + "\\TestData\\ProblemReport\\" + zipFileName;
            return fileName;
        }
    }
}
