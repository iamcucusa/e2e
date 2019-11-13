using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;
using Xunit.Abstractions;
using static iDareUI.Common.FlowUtilities;

namespace iDareUI.Common
{
   public class TestingEnvironment:IDisposable
    {
        private RemoteWebDriver driver = null;
        public RemoteWebDriver Driver
        {
            get
            {
                if (this.driver == null)
                {
                    this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                }
                return driver;
            }
        }
        public TestingEnvironment(ITestOutputHelper helper)
        {
            this.Log = new Log(helper);
        }

        public ILog Log;

        public void Dispose()
        {
            if (this.driver != null)
            {
                this.driver.Dispose();
                this.driver = null;
            }
        }
    }
}
