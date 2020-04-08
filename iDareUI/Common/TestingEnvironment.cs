using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit.Abstractions;

namespace iDareUI.Common
{
   public class TestingEnvironment : IDisposable
    {
        public bool IsIDE 
        {
            get { return System.Diagnostics.Debugger.IsAttached; }
        }
        private ChromeDriver driver = null;
        public ChromeDriver Driver
        {
            get
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                if (this.driver == null)
                {
                    if (!IsIDE)
                    {
                        chromeOptions.AddArgument("headless");
                    }

                    this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),chromeOptions);
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
