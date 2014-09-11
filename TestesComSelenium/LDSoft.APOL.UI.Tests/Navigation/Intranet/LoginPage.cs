using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet
{
    public class LoginPage : IntranetBase
    {
        public LoginPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public string Usuario
        {
            get
            {
                return Driver.FindElementByName("txt_usuario").GetAttribute("value");
            }
            set
            {
                Driver.FindElementByName("txt_usuario").SendKeys(value);
            }

        }

        public string Senha
        {
            get
            {
                return Driver.FindElementByName("txt_senha").GetAttribute("value");
            }
            set
            {
                Driver.FindElementByName("txt_senha").SendKeys(value);
            }
        }

        public static LoginPage Create(RemoteWebDriver driver)
        {
            var login = new LoginPage(driver);

            login.IrPara();

            return login;
        }

        protected void IrPara()
        {
            //Go Login Interno
            Driver.Navigate().GoToUrl(IntranetLoginUrl);

            if (Driver.ElementIsPresent(By.Name("meio")))
            {
                var frame = Driver.FindElementByName("meio");
                Driver.SwitchTo().Frame(frame);
            }
        }

        public InicioPage Entrar()
        {
            if (String.IsNullOrEmpty(Usuario))
                throw new ArgumentNullException("Usuario");

            if (String.IsNullOrEmpty(Senha))
                throw new ArgumentNullException("Senha");

            var btnEntrar = Driver.FindElementByName("cmd_Executar");
            btnEntrar.Click();

            return new InicioPage(Driver);
        }

        public InicioPage Entrar(string usuarioIntranet, string senhaIntranet)
        {
            IrPara();

            Usuario = usuarioIntranet;
            Senha = senhaIntranet;

            return Entrar();
        }
    }
}
