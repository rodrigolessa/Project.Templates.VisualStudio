using System;
using System.Configuration;
using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Base
{
    public abstract class APOLBase : BasePage
    {
        protected APOLBase(RemoteWebDriver driver)
            : base(driver)
        {
        }

        #region Properties

        public static string ApolServidor
        {
            get { return ConfigurationManager.AppSettings["Apol_Server"]; }
        }

        public static string ApolPorta
        {
            get { return ConfigurationManager.AppSettings["Apol_Port"]; }
        }

        public static string ApolDiretorioVirtual
        {
            get { return ConfigurationManager.AppSettings["Apol_WebDirectory"]; }
        }

        public static string UrlCopiaDeTrabalho
        {
            get { return String.Format("{0}:{1}", ApolServidor, ApolPorta); }
        }

        public string UrlApolInterno
        {
            get { return String.Format("{0}{1}", UrlCopiaDeTrabalho, ApolDiretorioVirtual); }
        }

        public string UrlLoginInterno
        {
            get { return String.Format("{0}{1}", UrlApolInterno, Constants.LoginInternoPageUrl); }
        }

        public string UrlCapturaCaptcha
        {
            get { return String.Format("{0}{1}", UrlApolInterno, Constants.GetCaptchaPageUrl); }
        }

        #endregion
    }
}
