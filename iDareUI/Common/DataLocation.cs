using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iDareUI.Common
{
    public static class DataLocation
    {
        public static string GetProblemReportsDirectory(List<string> zipFileName)
        {

            string fileName = GetProblemReportDirectory(zipFileName[0]);
            zipFileName.RemoveAt(0);

            foreach (string name in zipFileName)
            {
                string nextFileName = GetProblemReportDirectory(name);
                fileName = fileName + "\r\n" + nextFileName;
            }
            return fileName;
        }

        public static string GetProblemReportDirectory(string zipFileName)
        {
            string fileName = Path.GetDirectoryName(typeof(DataLocation).Assembly.Location) + "\\TestData\\ProblemReport\\" + zipFileName;
            if (!File.Exists(fileName))
            {
                throw new Exception("Could not find the path: " + fileName);
            }
            return fileName;
        }
    }
}
