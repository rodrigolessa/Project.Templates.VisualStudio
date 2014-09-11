using System;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.PortalLD;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Tests
{
    [TestFixture]
    public class PortalLDTest : BaseTest
    {
        private LoginPage _login;
        //private InicioPage _inicio;

        [SetUp]
        public void TestInitialize()
        {
            Driver = BrowserHelper.Open(Browsers.FireFox);
            _login = new LoginPage(Driver);
        }

        [TearDown]
        public void TestFinalize()
        {
            BrowserHelper.Close(Driver);
        }

        [Test]
        public void TelaLoginApol_Test()
        {
            IrParaPaginaCaptchaApol();
        }

        private void IrParaPaginaCaptchaApol()
        {
            const string usuario = "albinold";
            const string senha = "123";
            
            var _loginApol = _login.Entrar(usuario, senha);

            StringAssert.Contains(Constants.LoginInternoPageUrl, _loginApol.Url, "Página Captcha Apol");
        }
    }
}
