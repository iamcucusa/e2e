﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iDareUI.Common
{
    public class Constants
    {
        private const string pageUri = @"https://idare-sp13demo-ui.azurewebsites.net";
        public static string PageUri
        {
            get
            {
                var environmentUrl = Environment.GetEnvironmentVariable("testUrl", EnvironmentVariableTarget.Process);
                if(environmentUrl.Length != 0)
                {
                    return environmentUrl;
                }

                return pageUri;
            }
        }

        public const string TeacherUserName = "teacher";
        public const string TeacherPassword = "whatever";


    }
}
