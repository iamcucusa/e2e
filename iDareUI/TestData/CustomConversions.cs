using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace iDareUI.TestData
{
    [Binding]
    class CustomConversions
    {
        [StepArgumentTransformation]
        [Scope(Tag = "FileUploadingCases")]
        public List<string> GetFileNameList(string fileNameDelimited)
        {
            List<string> fileNameList = new List<string>();
            if (!fileNameDelimited.Contains(','))
            {
                fileNameList.Add(fileNameDelimited);
                return fileNameList;
            }
            else
            {
                var fileNames = fileNameDelimited.Split(",", StringSplitOptions.RemoveEmptyEntries);
                for (var index = 0; index < fileNames.Length; index++)
                {
                    fileNames[index] = fileNames[index].Trim();
                }
                return fileNames.ToList();
            }
        }
    }
}
