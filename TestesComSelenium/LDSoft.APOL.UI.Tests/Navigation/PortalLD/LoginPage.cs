using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.PortalLD
{
    public class LoginPage : PortalLDBase
    {
        public LoginPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public string Usuario
        {
            get
            {
                return Driver.FindElementByName("str_usuario").GetAttribute("value");
            }
            set
            {
                Driver.FindElementByName("str_usuario").SendKeys(value);
            }

        }

        public string Senha
        {
            get
            {
                return Driver.FindElementByName("str_senha").GetAttribute("value");
            }
            set
            {
                Driver.FindElementByName("str_senha").SendKeys(value);
            }
        }

        public static LoginPage Create(RemoteWebDriver driver)
        {
            var login = new LoginPage(driver);

            login.IrPara();

            return login;
        }

        public void IrParaApol()
        {
            //Go Login Interno
            Driver.Navigate().GoToUrl(PortalLDLoginApolUrl);
        }

        public void IrPara()
        {
            //Go Login Interno
            Driver.Navigate().GoToUrl(PortalLDLoginUrl);
        }

        public APOL.LoginPage Entrar()
        {
            if (String.IsNullOrEmpty(Usuario))
                throw new ArgumentNullException("Usuario");

            if (String.IsNullOrEmpty(Senha))
                throw new ArgumentNullException("Senha");

            var btnEntrar = Driver.FindElementByLinkText("APOL");
            btnEntrar.Click();

            var popUp = Driver.WindowHandles.Last();
            Driver.SwitchTo().Window(popUp);

            return new APOL.LoginPage(Driver);
        }

        
        public APOL.LoginPage Entrar(string usuarioApol, string senhaApol)
        {
            IrPara();

            Usuario = usuarioApol;
            Senha = senhaApol;

            return Entrar();
        }
    }
}
