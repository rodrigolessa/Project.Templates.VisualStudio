using System;
using System.Configuration;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.ModuloConsulta
{
    public abstract class ModuloConsultaBase : BasePage
    {
        protected ModuloConsultaBase(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public static string ModuloConsultaServidor
        {
            get { return ConfigurationManager.AppSettings["ModuloConsulta_Server"]; }
        }

        public static string ModuloConsultaPorta
        {
            get { return ConfigurationManager.AppSettings["ModuloConsulta_Port"]; }
        }

        public static string ModuloConsultaDiretorioVirtual
        {
            get { return ConfigurationManager.AppSettings["ModuloConsulta_WebDirectory"]; }
        }

        public static string UrlCopiaDeTrabalho
        {
            get { return String.Format("{0}:{1}", ModuloConsultaServidor, ModuloConsultaPorta); }
        }

        public string UrlInterno
        {
            get { return String.Format("{0}{1}", UrlCopiaDeTrabalho, ModuloConsultaDiretorioVirtual); }
        }

    }
}
