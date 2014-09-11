using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using Administracao = LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao;
using Patentes = LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes;
using Juridico = LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL
{
    public class LoginPage : APOLBase
    {
        public LoginPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        private string ObterCaptcha()
        {
            Driver.Navigate().GoToUrl(UrlCapturaCaptcha);

            var captcha = new CaptureCaptchaPage(Driver).GetGeneratedCaptcha();

            return captcha;
        }

        public string ObterJeimis()
        {
            var imgJeimis = Driver.FindElementById("imgJeimis");

            return imgJeimis.GetAttribute("src");
        }

        public APOLInternoBasePage Entrar(string usuario, string senha)
        {
            IrParaLogin();

            var generatedCaptcha = ObterCaptcha();

            //Back Login Interno
            Driver.Navigate().Back();

            var txtUsuario = Driver.FindElementById("txt_usuario");
            txtUsuario.SendKeys(usuario);

            var txtSenha = Driver.FindElementById("txt_senha");
            txtSenha.SendKeys(senha);

            var captcha = Driver.FindElementById("imagecheck");
            captcha.SendKeys(generatedCaptcha);

            var buttonApol = Driver.FindElementById("btnLogin");
            buttonApol.Submit();

            return InicioPageFactory.CriarInicioPage(Parametros["modulo"], Driver);
        }

        private void IrParaLogin()
        {
            //Go Login Interno
            Driver.Navigate().GoToUrl(base.UrlLoginInterno);
        }
    }
}
