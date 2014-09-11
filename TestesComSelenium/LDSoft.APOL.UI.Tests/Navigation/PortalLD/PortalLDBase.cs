using System;
using System.Configuration;
using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.PortalLD
{
    public abstract class PortalLDBase : BasePage
    {
        protected PortalLDBase(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public static string PortalLDServidor
        {
            get { return ConfigurationManager.AppSettings["PortalLD_Server"]; }
        }

        public static string PortalLDPort
        {
            get { return ConfigurationManager.AppSettings["PortalLD_Port"]; }
        }

        public static string PortalLDWebDirectory
        {
            get { return ConfigurationManager.AppSettings["PortalLD_WebDirectory"]; }
        }

        public string UrlLoginInterno
        {
            get { return String.Format("{0}{1}", UrlPortalLDInterno, Constants.PortalLD.LoginApolPageUrl); }
        }

        public string UrlPortalLDInterno
        {
            get { return String.Format("{0}{1}", UrlCopiaDeTrabalho, BaseTest.PortalLDWebDirectory); }
        }
                
        public static string UrlCopiaDeTrabalho
        {
            get { return String.Format("{0}:{1}", PortalLDServidor, BaseTest.ApplicationNetworkPort); }
        }

        public static string PortalLDLoginApolUrl
        {
            get { return String.Format("{0}:{1}{2}{3}", PortalLDServidor, PortalLDPort, PortalLDWebDirectory, Constants.PortalLD.LoginApolPageUrl); }
        }

        public static string PortalLDLoginUrl
        {
            get { return String.Format("{0}:{1}{2}{3}", PortalLDServidor, PortalLDPort, PortalLDWebDirectory, Constants.PortalLD.InicioPageUrl); }
        }
    }
}
