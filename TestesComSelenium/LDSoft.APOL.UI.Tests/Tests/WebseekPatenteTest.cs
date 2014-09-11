using System.Linq;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.Webseek;
using NUnit.Framework;
using LDSoft.APOL.UI.Tests.Common;

namespace LDSoft.APOL.UI.Tests
{
    [TestFixture]
    public class WebseekPatenteTest : BaseTest
    {
        private WebseekNavigation _helper;

        [SetUp]
        public void TestInitialize()
        {
            Driver = BrowserHelper.Open(Browsers.FireFox);
            _helper = new WebseekNavigation(Driver);
        }

        [TearDown]
        public void TestFinalize()
        {
            BrowserHelper.Close(Driver);
        }

        [Test(Description = "Acessar o detalhe do processo de Patente clicar no link de download do PDF de Carta Patente")]
        public void LinkDeDownloadParaProcessoQuePossuiCartaPatente()
        {
            const string numeroDoProcesso = "0002736";

            _helper.Autenticacao.Entrar(NomeUsuarioTitularWebseek, SenhaUsuarioTitularWebseek);
            _helper.Patente.AcessarPrimeiraOcorrenciaEmBuscaPorNumeroDoProcesso(numeroDoProcesso);

            var listaLinks = Driver.FindElementsByName("downloadCartaPatente");

            Assert.IsNotNull(listaLinks);
            Assert.IsTrue(listaLinks.Any());

            var linkCartaPatente = listaLinks.FirstOrDefault();

            linkCartaPatente.Click();

            //TODO: selenium handle file download dialog
        }

        [Test]
        public void LinkDeDownloadParaProcessoSemCartaPatente()
        {
            const string numeroDoProcesso = "9906116";

            _helper.Autenticacao.Entrar(NomeUsuarioTitularWebseek, SenhaUsuarioTitularWebseek);
            _helper.Patente.AcessarPrimeiraOcorrenciaEmBuscaPorNumeroDoProcesso(numeroDoProcesso);

            var linkCartaPatente = Driver.FindElementsByName("downloadCartaPatente");

            Assert.IsTrue(!linkCartaPatente.Any());
        }
    }
}
