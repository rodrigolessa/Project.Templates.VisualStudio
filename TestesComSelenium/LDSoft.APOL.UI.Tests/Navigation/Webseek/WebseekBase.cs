using System;
using System.Configuration;
using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Webseek
{
    public abstract class WebseekBase : BasePage
    {
        protected WebseekBase(RemoteWebDriver driver)
            : base(driver)
        {
        }


        public static string ApolServidor
        {
            get { return ConfigurationManager.AppSettings["Apol_Server"]; }//TODO LEANDRO
        }

        public string UrlLoginInterno
        {
            get { return String.Format("{0}{1}", UrlWebseekInterno, Constants.Webseek.LoginInternoPageUrl); }
        }

        public string UrlWebseekInterno
        {
            get { return String.Format("{0}{1}", UrlCopiaDeTrabalho, BaseTest.WebseekWebDirectory); }
        }

        public string UrlCapturaCaptcha
        {
            get { return String.Format("{0}{1}", UrlWebseekInterno, Constants.Webseek.GetCaptchaPageUrl); }
        }

        public static string UrlCopiaDeTrabalho
        {
            get { return String.Format("{0}:{1}", ApolServidor, BaseTest.ApplicationNetworkPort); }
        }

    }
}
