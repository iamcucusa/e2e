using System;
using System.Collections.Generic;
using System.IO;

namespace iDareUI.Common
{
    public static class DataLocation
    {
        public static string GetProblemReportsDirectory(List<string> fileNamesList)
        {

            string fileNameConcat = GetProblemReportFilePath(fileNamesList[0]);
            fileNamesList.RemoveAt(0);

            foreach (string name in fileNamesList)
            {
                string nextFileName = GetProblemReportFilePath(name);
                fileNameConcat = fileNameConcat + "\r\n" + nextFileName;
            }
            return fileNameConcat;
        }

        public static string GetProblemReportFilePath(string fileName)
        {
            string filePath = Path.GetDirectoryName(typeof(DataLocation).Assembly.Location) + "\\TestData\\ProblemReport\\" + fileName;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find the path: " + filePath);
            }
            return filePath;
        }
    }
}
