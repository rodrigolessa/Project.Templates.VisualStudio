using System;
using System.Configuration;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests
{
    public abstract class BaseTest
    {
        protected RemoteWebDriver Driver;

        public string NomeUsuarioTitularApol
        {
            get { return ConfigurationManager.AppSettings["Apol_NomeUsuario"]; }
        }
        public string SenhaUsuarioTitularApol
        {
            get { return ConfigurationManager.AppSettings["Apol_SenhaUsuario"]; }
        }

        public string NomeUsuarioTitularWebseek
        {
            get { return ConfigurationManager.AppSettings["Webseek_NomeUsuario"]; }
        }
        public string SenhaUsuarioTitularWebseek
        {
            get { return ConfigurationManager.AppSettings["Webseek_SenhaUsuario"]; }
        }

        public string NomeUsuarioIntranet
        {
            get { return ConfigurationManager.AppSettings["Intranet_NomeUsuario"]; }
        }
        public string SenhaUsuarioIntranet
        {
            get { return ConfigurationManager.AppSettings["Intranet_SenhaUsuario"]; }
        }

        public static string ApplicationNetworkPort
        {
            get
            {
                return String.Format("{0}, {1}, {2}",
                    ConfigurationManager.AppSettings["Apol_Port"],
                    ConfigurationManager.AppSettings["Intranet_Port"],
                    ConfigurationManager.AppSettings["ModuloConsulta_Port"]);
            }
        }

        public static string WebseekWebDirectory
        {
            get { return ConfigurationManager.AppSettings["Webseek_WebDirectory"]; }
        }

        public static string PortalLDWebDirectory
        {
            get { return ConfigurationManager.AppSettings["PortalLD_WebDirectory"]; }
        }
    }
}
