using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iDareUI.Common
{
    public static class GetTestData
    {
        public static string GetPRDirectory(string zipFileName)
        {
            string fileName = Path.GetDirectoryName(typeof(GetTestData).Assembly.Location) + "\\TestData\\ProblemReport\\" + zipFileName;
            return fileName;
        }
    }
}
