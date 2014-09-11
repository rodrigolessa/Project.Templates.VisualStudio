using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.ModuloConsulta
{
    public class ModuloConsultaAutenticacaoNavigation : ModuloConsultaBase
    {
        #region Attributes

        private readonly ModuloConsultaNavigation _parent;

        #endregion

        #region Constructors

        public ModuloConsultaAutenticacaoNavigation(RemoteWebDriver driver, ModuloConsultaNavigation parent):base(driver)
        {
            this._parent = parent;
        }

        #endregion

        public void Entrar(string usuario, string senha, string urlDoCliente)
        {

            IWebElement button;

            Driver.Navigate().GoToUrl(UrlInterno + urlDoCliente);

            var login = Driver.FindElementByName("Vusuario");
            login.SendKeys(usuario);

            var password = Driver.FindElementByName("Vsenha");
            password.SendKeys(senha);

            switch (urlDoCliente)
            {
                case Constants.ModuloConsulta.Clientes.Interno:
                case Constants.ModuloConsulta.Clientes.Vale:
                    button = Driver.FindElementByXPath("//a[contains(@href,'javascript:valida')]");
                    button.Click();
                    break;

                default:
                    button = Driver.FindElementByName("Ventra");
                    button.Click();
                    break;
            }


        }
    }
}