using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace iDareUI.Common
{
    internal class Log : ILog
    {
        private ITestOutputHelper helper;

        public Log(ITestOutputHelper helper)
        {
            this.helper = helper;
        }

        public void Info(string s)
        {
            this.LogLine("INFO", s);
        }

        public void Debug(string s)
        {
            this.LogLine("DEBUG", s);
        }

        public void Trace(string s)
        {
            this.LogLine("TRACE", s);
        }

        public void Error(string s)
        {
            this.LogLine("ERROR", s);
        } 

        public void Fatal(string s)
        {
            this.LogLine("FATAL", s);
        } 

        private void LogLine(string level, string s)
        {
            var line = $"{DateTime.Now.ToString("yyyyMMdd - HH:mm:ss.fff")} {level} - {s}";
            this.helper.WriteLine(line);
        }
    }
}
