using System;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.Intranet;
using LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL;
using LDSoft.APOL.UI.Tests.Navigation.ModuloConsulta;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Linq;

namespace LDSoft.APOL.UI.Tests
{
    [TestFixture]
    public class ModuloConsultaTest : BaseTest
    {
        private const string MODULO_CONSULTA_DIRETORIO_GERAL = "consulta";
        private const string MODULO_CONSULTA_DIRETORIO_VALE = "vale";
        private const string MODULO_CONSULTA_DIRETORIO_CPQD = "cpqd";
        private const string MODULO_CONSULTA_CONSULTA_DOMINIO = "consulta_dominios.asp";

        private ModuloConsultaNavigation _helper;
        private LoginPage _login;
        private InicioPage _inicio;
        private ListaDeOpcoesPage _listaOpcoes;

        [SetUp]
        public void TestInitialize()
        {
            Driver = BrowserHelper.Open(Browsers.FireFox);
            _helper = new ModuloConsultaNavigation(Driver);
            _login = new LoginPage(Driver);
        }

        [TearDown]
        public void TestFinalize()
        {
            BrowserHelper.Close(Driver);
        }

        #region Testes de consulta de ultimo despacho

        [Test]
        public void ConsultarUltimoDespachoComAnexo_Camelier()
        {
            const string numeroDoProcesso = "903339439";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(Constants.ModuloConsulta.Pastas.Camelier);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Camelier);

            _helper.IrParaUltimoDespacho(Constants.ModuloConsulta.Pastas.Camelier, Constants.ModuloConsulta.Modulo.Marca, numeroDoProcesso);

            // Buscando pelo onclick o anexo
            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();

        }

        [Test]
        public void ConsultarUltimoDespachoComAnexo_Consulta()
        {
            const string numeroDoProcesso = "903339439";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(Constants.ModuloConsulta.Pastas.Camelier);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Interno);

            _helper.IrParaUltimoDespacho(Constants.ModuloConsulta.Pastas.Comum, Constants.ModuloConsulta.Modulo.Marca, numeroDoProcesso);

            // Buscando pelo onclick o anexo
            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();
        }

        #endregion

        #region Testes de consulta de patentes nacionais e internacionais

        [Test]
        public void ConsultarPatenteNacionalResumidoComAnexo_Camelier()
        {
            const string numeroDoProcesso = "0410029";
            const string natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(Constants.ModuloConsulta.Pastas.Camelier);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Camelier);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Camelier, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Resumida, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();

        }

        [Test]
        public void ConsultarPatenteNacionalDetalhadoComAnexo_Camelier()
        {
            var numeroDoProcesso = "9908175";
            var natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(Constants.ModuloConsulta.Pastas.Camelier);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Camelier);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Camelier, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Detalhada, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();
        }

        [Test]
        public void ConsultarPatenteNacionalResumidoComAnexo_Consulta()
        {
            const string numeroDoProcesso = "9908175";
            const string natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_GERAL);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Interno);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Comum, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Resumida, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();
        }

        [Test]
        public void ConsultarPatenteNacionalDetalhadoComAnexo_Consulta()
        {
            const string numeroDoProcesso = "9908175";
            const string natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_GERAL);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Interno);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Comum, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Detalhada, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();
        }

        [Test]
        public void ConsultarPatenteInternacionalResumidoComAnexo_Consulta()
        {
            const string numeroDoProcesso = "028928732";
            const string natureza = "MU";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_GERAL);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Interno);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Comum, Constants.ModuloConsulta.Modulo.PatenteInternacional,
               Constants.ModuloConsulta.TipoDeConsulta.Resumida, numeroDoProcesso, natureza);
        }

        [Test]
        public void ConsultarPatenteInternacionalDetalhadoComAnexo_Consulta()
        {
            const string numeroDoProcesso = "098772122";
            const string natureza = "C6";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_GERAL);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Interno);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Comum, Constants.ModuloConsulta.Modulo.PatenteInternacional,
               Constants.ModuloConsulta.TipoDeConsulta.Detalhada, numeroDoProcesso, natureza);
        }

        [Test]
        public void ConsultarPatenteNacionalResumidoComAnexo_CPQD()
        {
            const string numeroDoProcesso = "0410029";
            const string natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_CPQD);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.CPQD);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.CPQD, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Resumida, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();

        }

        [Test]
        public void ConsultarPatenteNacionalDetalhadoComAnexo_CPQD()
        {
            const string numeroDoProcesso = "9908175";
            const string natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_CPQD);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.CPQD);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.CPQD, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Detalhada, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();
        }

        [Test]
        public void ConsultarPatenteNacionalResumidoComAnexo_Vale()
        {
            const string numeroDoProcesso = "0410029";
            const string natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_VALE);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Vale);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Vale, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Resumida, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();

        }

        [Test]
        public void ConsultarPatenteNacionalDetalhadoComAnexo_Vale()
        {
            const string numeroDoProcesso = "9908175";
            const string natureza = "PI";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_VALE);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Vale);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Vale, Constants.ModuloConsulta.Modulo.Patente,
               Constants.ModuloConsulta.TipoDeConsulta.Detalhada, numeroDoProcesso, natureza);

            var anexo = Driver.FindElement(By.XPath("//a[contains(@onclick,'document.getElementById(')]"));
            anexo.Click();
        }

        [Test]
        public void ConsultarPatenteInternacionalDetalhadoComAnexo_Vale()
        {
            const string numeroDoProcesso = "098772122";
            const string natureza = "C6";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_VALE);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Vale);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Vale, Constants.ModuloConsulta.Modulo.PatenteInternacional,
               Constants.ModuloConsulta.TipoDeConsulta.Detalhada, numeroDoProcesso, natureza);

        }

        [Test]
        public void ConsultarPatenteInternacionalResumidoComAnexo_Vale()
        {
            const string numeroDoProcesso = "098772122";
            const string natureza = "C6";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_VALE);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Vale);

            _helper.IrParaConsulta(Constants.ModuloConsulta.Pastas.Vale, Constants.ModuloConsulta.Modulo.PatenteInternacional,
               Constants.ModuloConsulta.TipoDeConsulta.Resumida, numeroDoProcesso, natureza);
        }

        #endregion

        #region Teste de consulta de direito autoral

        [Test]
        public void ConsultarDireitoAutoralResumidoComAnexo_Consulta()
        {
            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(MODULO_CONSULTA_DIRETORIO_GERAL);

            // Colocando os dados do usuario;
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Interno);

            var area = Driver.FindElement(By.XPath(String.Format("//area[contains(@href,'{0}')]", Constants.ModuloConsulta.ConsultaDireitosAutorais)));
            var js = Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", area);

            Driver.FindElementByName("texto01_nome").SendKeys("222222");

            Driver.FindElementByName("Resumido").Click();

            var processo = Driver.FindElementByLinkText("222222");
            processo.Click();

        }

        #endregion

        [Test]
        public void ConsultarDominioNacionalNoModuloComumListaResumido()
        {
            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var usuarioDetalhe = IrParaCadastroUsuario(NomeUsuarioTitularApol);

            usuarioDetalhe.AlterarDiretorioModuloConsulta(Constants.ModuloConsulta.Pastas.Comum);

            // Logar no Módulo Comum para os clientes
            _helper.Autenticacao.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol, Constants.ModuloConsulta.Clientes.Camelier);

            // Acessar Consulta de Domínio Nacional
            var area = Driver.FindElementByTagName("area");

            area.FindElement(By.XPath(String.Format("//area[contains(@href,{0})]", MODULO_CONSULTA_CONSULTA_DOMINIO))).Click();

            // Na tela de filtro do relatório, acessar o botão Resumido
            var botaoResumido = Driver.FindElementByName("Resumido");

            botaoResumido.Click();

            // Na tela de lista do relatório Resumido
            var linksDetalhe = Driver.FindElementsByXPath("//a[contains(@href,'dominio_detalhe.asp?dominio=')]");

            Assert.IsTrue(linksDetalhe.Any());
            Assert.GreaterOrEqual(1, linksDetalhe.Count());

            // Primeiro Domínio da lista
            var linkDominio = linksDetalhe.First();

            Assert.IsNotNull(linkDominio);

            // Detalhe do Domínio Click
            linkDominio.Click();

            // Na tela de detalhe do Domínio
            var urlDominio = Driver.FindElementsByXPath("//b[contains('.com.br')]");

            Assert.IsNotNull(urlDominio);

            // <td>Brasil
        }

        private void IrParaPaginaInicial()
        {
            _inicio = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet);

            StringAssert.Contains(Constants.Intranet.InicioPageUrl, _inicio.Url, "Página Principal");
        }

        private void IrParaAdministracaoAPOL()
        {
            _listaOpcoes = _inicio.IrParaAdministracaoAPOL();

            StringAssert.Contains(Constants.Intranet.AdministracaoApolPageUrl, _listaOpcoes.Url,
                "Administração APOL");
        }

        private UsuarioDetalhePage IrParaCadastroUsuario(string usuarioModuloConsulta)
        {
            var listaUsuario = _listaOpcoes.IrParaCadastroDeUsuario();

            Assert.IsTrue(Driver.Url.Contains("usuarios.asp"), "Usuários");

            listaUsuario.PesquisarUsuario(usuarioModuloConsulta);

            Assert.IsTrue(Driver.Url.Contains("usuarios.asp"), "Usuários");

            var cadastroUsuario = listaUsuario.AcessarDetalheUsuario(usuarioModuloConsulta);

            Assert.IsTrue(Driver.Url.Contains("cad_usu.asp"), "Detalhe Usuário");

            return cadastroUsuario;
        }

    }
}