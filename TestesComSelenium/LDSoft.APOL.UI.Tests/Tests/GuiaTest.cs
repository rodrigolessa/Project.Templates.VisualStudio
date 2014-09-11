using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.APOL;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests
{

    [TestFixture]
    public class GuiaTest : BaseTest
    {
        private const string NOME_USUARIO_TITULAR = "Rosemary";
        private const string SENHA_USUARIO_TITULAR = "1Qualidade";

        private LoginPage _paginaLogin;
        private InicioPage _paginaPrincipal;
        private SacadorDetalhePage _sacadorDetalhe;

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

        [Test]
        public void Inserindo_Sacador()
        {
            _paginaPrincipal = _paginaLogin.Entrar(NOME_USUARIO_TITULAR, SENHA_USUARIO_TITULAR).IrParaModuloAdministracao();

            _sacadorDetalhe = _paginaPrincipal
                .IrParaParametrosDeGuia()
                .IrParaDetalheDoPrimeiroSacador();

            Assert.Inconclusive();

        }
    }
}
