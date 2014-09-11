using System;
using System.Configuration;
using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet
{
    public abstract class IntranetBase : BasePage
    {
        protected IntranetBase(RemoteWebDriver driver)
            : base(driver)
        {
        }

        #region Attributes

        public static string IntranetServer
        {
            get { return ConfigurationManager.AppSettings["Intranet_Server"]; }
        }

        public static string IntranetPort
        {
            get { return ConfigurationManager.AppSettings["Intranet_Port"]; }
        }

        public static string IntranetWebDirectory
        {
            get { return ConfigurationManager.AppSettings["Intranet_WebDirectory"]; }
        }

        public static string IntranetUrl
        {
            get { return String.Format("{0}:{1}{2}", IntranetServer, IntranetPort, IntranetWebDirectory); }
        }

        public static string IntranetLoginUrl
        {
            get { return String.Format("{0}:{1}{2}/{3}", IntranetServer, IntranetPort, IntranetWebDirectory, Constants.Intranet.LoginPageUrl); }
        }


        #endregion
    }
}
