using System;
using System.Linq;
using System.Text.RegularExpressions;
using LDSoft.APOL.UI.Tests.Common;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Webseek
{
    public class WebseekNavigation : WebseekBase
    {
        #region Properties

        public WebseekCommonNavigation Common { get; private set; }

        public WebseekAutenticacaoNavigation Autenticacao
        {
            get;
            private set;
        }

        public WebseekPatenteNavigation Patente
        {
            get;
            private set;
        }


        #endregion

        #region Constructors

        public WebseekNavigation(RemoteWebDriver driver):base(driver)
        {
            Common = new WebseekCommonNavigation(driver, this);
            Autenticacao = new WebseekAutenticacaoNavigation(driver, this);
            Patente = new WebseekPatenteNavigation(driver, this);
        }

        #endregion
    }

    public class WebseekCommonNavigation
    {
        #region Attributes

        private readonly RemoteWebDriver _driver;
        private readonly WebseekNavigation _parent;

        #endregion

        #region Constructors

        public WebseekCommonNavigation(RemoteWebDriver driver, WebseekNavigation parent)
        {
            this._driver = driver;
            this._parent = parent;
        }

        #endregion
    }

    public class WebseekAutenticacaoNavigation
    {
        #region Attributes

        private readonly RemoteWebDriver _driver;
        private readonly WebseekNavigation _parent;

        #endregion

        #region Constructors

        public WebseekAutenticacaoNavigation(RemoteWebDriver driver, WebseekNavigation parent)
        {
            this._driver = driver;
            this._parent = parent;
        }

        #endregion

        public void Entrar(string usuario, string senha)
        {
            //Go Login Interno
            _driver.Navigate().GoToUrl(_parent.UrlLoginInterno);

            //Get Captcha Code
            var generatedCaptcha = GetGeneratedCaptcha();

            //Back Login Interno
            _driver.Navigate().Back();

            var _login = _driver.FindElementByName("str_usuario");
            _login.SendKeys(usuario);

            var _senha = _driver.FindElementByName("str_senha");
            _senha.SendKeys(senha);

            var captcha = _driver.FindElementByName("imagecheck");
            captcha.SendKeys(generatedCaptcha);

            var buttonApol = _driver.FindElementByName("cmd_Executar");
            buttonApol.Submit();

            Assert.IsTrue(_driver.Url.Contains(Constants.Webseek.PrincipalPageUrl), "Navegar Para Página Principal");

        }

        private string GetGeneratedCaptcha()
        {
            _driver.Navigate().GoToUrl(_parent.UrlCapturaCaptcha);

            var pageCaptcha = _driver.PageSource;

            var regex = new Regex("\\<[^\\>]*\\>");
            var generatedCaptcha = regex.Replace(pageCaptcha, String.Empty).Trim();

            return generatedCaptcha;
        }
    }

    public class WebseekPatenteNavigation
    {
        #region Attributes

        private readonly RemoteWebDriver _driver;
        private readonly WebseekNavigation _parent;

        #endregion

        #region Constructors

        public WebseekPatenteNavigation(RemoteWebDriver driver, WebseekNavigation parent)
        {
            this._driver = driver;
            this._parent = parent;
        }

        #endregion

        public void AcessarBuscaPorProcesso()
        {
            //Localiza link para módulo de Patente
            var linkPatente = _driver.FindElementById("lagenda");
            linkPatente.Click();

            //Localiza link para pesquisar por processos
            var linksProcessos = _driver.FindElementsByXPath("//a[contains(@href,'pesq_procp.asp')]");
            var link = linksProcessos.First();
            link.Click();
        }

        public void AcessarPrimeiraOcorrenciaEmBuscaPorNumeroDoProcesso(string numeroProcesso)
        {
            this.AcessarBuscaPorProcesso();

            //Localiza campo radical e busca processos publicados
            var inputProcesso = _driver.FindElementByName("vproc1");
            inputProcesso.SendKeys(numeroProcesso);

            //Localiza o botão de pesquisa
            var pesquisar = _driver.FindElementByName("cmd_Pesquisar");
            pesquisar.Click();

            //Obtem a lista de Processos
            var xpath = String.Format("//a[contains(@href,'{0}')]", Constants.Webseek.DetalheProcessoPatentePageUrl);
            var processosPatente = _driver.FindElementsByXPath(xpath);

            //Primeiro Processo da lista
            var processo = processosPatente.First();

            Assert.IsNotNull(processo);

            //Detalhe do Processo Click
            processo.Click();
        }
    }
}
