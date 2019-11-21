using System;
using System.Collections.Generic;
using System.Text;

namespace iDareUI.Common
{
    public class Constants
    {
        private const string pageUri = @"https://idare-demo-ui.azurewebsites.net/";
        public static string PageUri
        {
            get
            {
                var environmentUrl = Environment.GetEnvironmentVariable("testUrl", EnvironmentVariableTarget.Process);
                if(environmentUrl != null && environmentUrl.Length != 0)
                {
                    return environmentUrl;
                }

                return pageUri;
            }
        }

        public const string TeacherUserName = "teacher";
        public const string TeacherPassword = "whatever";

        public const string InvestigatorName = "investigator";
        public const string InvestigatorPassword = "whatever";

        public const string ProblemReportOnlySummary = "ProblemReport_OnlySummary.zip";
    }
}
