using System.Linq;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.Intranet;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace LDSoft.APOL.UI.Tests.Steps
{
    [Binding]
    public class AutenticacaoSteps
    {
        private RemoteWebDriver _driver;
        private LoginPage _login;
        private InicioPage _inicio;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver = BrowserHelper.Open(Browsers.FireFox);
            _login = LoginPage.Create(_driver);
        }

        [Given(@"I have filled out the form as follows")]
        public void GivenIHaveFilledOutTheFormAsFollows(Table table)
        {
            var row = table.Rows.First();

            _login.Usuario = row["Usuario"];
            _login.Senha = row["Senha"];
        }

        [When(@"I navigate to login page")]
        public void WhenINavigateToLoginPage()
        {
            _driver = BrowserHelper.Open(Browsers.FireFox);
            _login = LoginPage.Create(_driver);
        }

        [When(@"I press Entrar")]
        public void WhenIPressEntrar()
        {
            _inicio = _login.Entrar();
        }

        [Then(@"I should be on the login page")]
        public void ThenIShouldBeOnTheLoginPage()
        {
            Assert.IsNotNull(_login);
            StringAssert.Contains(Constants.Intranet.LoginPageUrl, _login.Url, "Pagina Login");
        }

        [Then(@"I should see a screen principal")]
        public void ThenIShouldSeeAScreenPrincipal()
        {
            Assert.IsNotNull(_inicio);
            StringAssert.Contains(Constants.Intranet.InicioPageUrl, _inicio.Url, "Pagina Principal");
        }

    }
}
