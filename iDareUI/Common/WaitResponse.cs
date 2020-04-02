using System;
using System.Text;

namespace iDareUI.Common
{
    public class WaitResponse
    {
        public bool Success;
        public string Reason { get; set; }
        public bool TimedOut { get; set; }
        public Exception Exception { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.TimedOut)
                sb.Append("TimedOut=True");

            if (!string.IsNullOrEmpty(this.Reason))
                sb.Append($"Reason={this.Reason}");

            if (this.Exception != null)
                sb.Append($"Exception={this.Exception}");

            return sb.ToString();
        }
    }
}