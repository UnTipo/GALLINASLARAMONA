using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Statics
{
    public class Constants
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static string EmailNoReply = ConfigurationManager.AppSettings["EmailNoReply"];
        public static string EmailNoReplyPassword = ConfigurationManager.AppSettings["EmailNoReplyPassword"];
        public static string EmailSMTPNoReply = ConfigurationManager.AppSettings["EmailSMTPNoReply"];
        public static string EmailPort = ConfigurationManager.AppSettings["EmailPort"];

        #region // Global resources
        public static string GetResources()
        {
            string resourceFile = "~/CAResources/CocheAmigoSpanish.resx";
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            System.Resources.ResourceManager resourceManager = System.Resources.ResourceManager.CreateFileBasedResourceManager(resourceFile, filePath, null);
            string resourceValue = resourceManager.GetString("ErrorResetPassword");
            return resourceValue;
        }
       
        #endregion

    }
}