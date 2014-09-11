using System.Linq;
using System.Threading;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.APOL;
using NUnit.Framework;
using Patentes = LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes;

namespace LDSoft.APOL.UI.Tests
{
    [TestFixture]
    public class PatenteDetalheTest : BaseTest
    {
        private LoginPage _paginaLogin;
        private Patentes.InicioPage _homePatente;
        private Patentes.PesquisaProcessoWebseekPage _pesquisaProcessoWebseek;
        private Patentes.ProcessoDetalhePage _processoDetalhePage;

        [SetUp]
        public void TestInitialize()
        {
            Driver = BrowserHelper.Open(Browsers.FireFox);

            _paginaLogin = new LoginPage(Driver);
        }

        [TearDown]
        public void TestFinalize()
        {
            BrowserHelper.Close(Driver);
        }

        #region Carta Patente

        [Test(Description = "Acessar o detalhe do processo de Patente clicar no link de download do PDF de Carta Patente")]
        public void LinkDeDownloadParaProcessoQuePossuiCartaPatente()
        {
            const string numeroDoProcesso = "0002736";
            _homePatente = _paginaLogin.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol).IrParaModuloPatentes();
            _pesquisaProcessoWebseek = _homePatente.BuscarPorNumeroProcessoNoWebSeek(numeroDoProcesso);

            var listaLinks = Driver.FindElementsByName("downloadCartaPatente");

            Assert.IsNotNull(listaLinks, "Lista de processos de Patentes");
            Assert.IsTrue(listaLinks.Any(), "Lista de processos de Patentes");

            var linkCartaPatente = listaLinks.FirstOrDefault();

            linkCartaPatente.Click();

            //TODO: selenium handle file download dialog
        }

        [Test]
        public void LinkDeDownloadParaProcessoSemCartaPatente()
        {
            const string numeroDoProcesso = "9906116";

            _homePatente = _paginaLogin.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol).IrParaModuloPatentes();
            _pesquisaProcessoWebseek = _homePatente.BuscarPorNumeroProcessoNoWebSeek(numeroDoProcesso);

            var linkCartaPatente = Driver.FindElementsByName("downloadCartaPatente");

            Assert.IsTrue(!linkCartaPatente.Any());
        }

        #endregion

        #region Parecer e Anterioridade

        [Test(Description = "Acessar o detalhe do processo de Patente clicar no link de download do PDF de Parecer")]
        public void LinkDeDownloadParaProcessoQuePossuiParecerEAnterioridade()
        {
            const string numeroDoProcesso = "9711024";

            _homePatente = _paginaLogin.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol).IrParaModuloPatentes();
            _processoDetalhePage = _homePatente.BuscarPorNumeroProcessoNoWebSeek(numeroDoProcesso).IrParaPrimeiroProcesso();

            // localiza a lista de links do Parecer ou Anterioridade
            //var listaLinks = Driver.FindElementsByClassName("dwParecer");
            var listaDeParecer = _processoDetalhePage.ObterListaParecer();

            Assert.IsTrue(listaDeParecer.Any(), "Itens de Parecer na lista de Despachos.");

            // Abrir dialog de download com links de parecer e anterioridade
            var iconeParecer = listaDeParecer.FirstOrDefault();
            iconeParecer.Click();

            Thread.Sleep(500);

            // Verifica se abriu a dialog de Download
            var tituloJanelaDeDialogo = Driver.FindElementByClassName("ui-dialog-title").Text;

            Assert.AreEqual("Download Parecer", tituloJanelaDeDialogo, "Título esperado para a dialog de Download.");

            var listaLinksDialogArquivos = Driver.FindElementsByXPath("//a[contains(@href,'PI9711024_RPI_2103')]");

            Assert.GreaterOrEqual(listaLinksDialogArquivos.Count(), 1, "Quantidade de links para Parecer e Anterioridade.");

            var linkParecer = listaLinksDialogArquivos.First();
            linkParecer.Click();

            //TODO: selenium handle file download dialog
        }

        #endregion
    }
}