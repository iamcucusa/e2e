using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace iDareUI.PageInteractions
{
    class CaseUpdatePage
    {
        private readonly RemoteWebDriver driver;
        public CaseUpdatePage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement editCaseButton => driver.FindElement(By.XPath("//*[@attr.data-idare-id='CaseListComponentEditCaseButton']"));
        private IList<IWebElement> fileUploadedRow => driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseFileListTableHeaderRows']"));

        public void OpenCaseUpdate() { editCaseButton.Click(); }
        public IEnumerable<string> GetFileUploadedNameListText()
        {
            var filesUploadedText = this.GetFileUploadedNameList();
            return filesUploadedText.Select(element => element.Text);
        }
        public IList<IWebElement> GetFileUploadedNameList()
        {
            IList<IWebElement> allFilesUploaded = driver.FindElements(By.XPath("//*[@attr.data-idare-id='CaseFileListTableHeaderRows']"));
            return allFilesUploaded;
        }

        public string GetFileUploadedStatus (string fileName)
        {
            string status = null;
            foreach (IWebElement row in fileUploadedRow)
            {
                if (row.Text.Contains(fileName))
                {
                    IWebElement currentStatusFileUploaded = row.FindElement(By.XPath("//*[@attr.data-idare-id='CaseFileListTableStatus']"));
                    status = currentStatusFileUploaded.Text;
                }
            }
            Assert.NotNull(status);
            return status;
        }
        public void PressFileUploadedDeleteButton(string fileName)
        {
            IWebElement deleteButton = null;
            foreach (IWebElement row in fileUploadedRow)
            {
                if (row.Text.Contains(fileName))
                {
                    deleteButton = row.FindElement(By.XPath("//*[@attr.data-idare-id='CaseFileListTableDeleteButton']"));
                }
            }
            Assert.NotNull(deleteButton);
            deleteButton.Click();
        }
    }
}
