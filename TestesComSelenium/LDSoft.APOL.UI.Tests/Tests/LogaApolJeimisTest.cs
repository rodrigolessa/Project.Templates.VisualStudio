using System.Linq;
using System.Threading;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.APOL;
using NUnit.Framework;

namespace LDSoft.APOL.UI.Tests.Tests
{
    [TestFixture]
    class LogaApolJeimisTest : BaseTest
    {
        private LoginPage _paginaLogin;
        private Navigation.PortalLD.LoginPage _loginPortal;

        [SetUp]
        public void TestInitialize()
        {
            Driver = BrowserHelper.Open(Browsers.FireFox);

            _loginPortal = new Navigation.PortalLD.LoginPage(Driver);
        }

        [TearDown]
        public void TestFinalize()
        {
            BrowserHelper.Close(Driver);
        }
        
        #region Valida Jeimis

        [Test(Description = "Acessar a tela do captcha com usuário de módulo inicial de Marcas")]
        public void JeimisExibidoNaTelaDoCaptchaParaMarcas()
        {
            const string usuario = "albinold";
            const string senha = "123";
            const string imgModuloMarcas = "marca.jpg";

            _paginaLogin = _loginPortal.Entrar(usuario, senha);

            var _jeimis = _paginaLogin.ObterJeimis();

            StringAssert.Contains(imgModuloMarcas, _jeimis, "Imagem Jeimis para clientes do módulo de Marcas");
        }

        [Test(Description = "Acessar a tela do captcha com usuário de módulo inicial de Patentes")]
        public void JeimisExibidoNaTelaDoCaptchaParaPatentes()
        {
            const string usuario = "aaguiar";
            const string senha = "123";
            const string imgModuloPatentes = "patente.jpg";

            _paginaLogin = _loginPortal.Entrar(usuario, senha);

            var _jeimis = _paginaLogin.ObterJeimis();

            StringAssert.Contains(imgModuloPatentes, _jeimis, "Imagem Jeimis para clientes do módulo de Patentes");
        }

        [Test(Description = "Acessar a tela do captcha com usuário de módulo inicial de Jurídico")]
        public void JeimisExibidoNaTelaDoCaptchaParaJuridico()
        {
            const string usuario = "aaddcc";
            const string senha = "123";
            const string imgModuloJuridico = "juridico.jpg";

            _paginaLogin = _loginPortal.Entrar(usuario, senha);

            var _jeimis = _paginaLogin.ObterJeimis();

            StringAssert.Contains(imgModuloJuridico, _jeimis, "Imagem Jeimis para clientes do módulo de Jurídico");
        }

        [Test(Description = "Acessar a tela do captcha com usuário de módulo inicial de Contrato")]
        public void JeimisExibidoNaTelaDoCaptchaParaContrato()
        {
            const string usuario = "bga0007";
            const string senha = "123";
            const string imgModuloContrato = "contrato.jpg";

            _paginaLogin = _loginPortal.Entrar(usuario, senha);

            var _jeimis = _paginaLogin.ObterJeimis();

            StringAssert.Contains(imgModuloContrato, _jeimis, "Imagem Jeimis para clientes do módulo de Contrato");
        }

        [Test(Description = "Acessar a tela do captcha com usuário Teste de Marcas")]
        public void JeimisExibidoNaTelaDoCaptchaParaUsuarioTesteMarcas()
        {
            const string usuario = "brunatribunaist";
            const string senha = "123";
            const string imgModuloContrato = "marca.jpg";

            _paginaLogin = _loginPortal.Entrar(usuario, senha);

            var _jeimis = _paginaLogin.ObterJeimis();

            StringAssert.Contains(imgModuloContrato, _jeimis, "Imagem Jeimis para usuário Teste de Marcas");
        }

        #endregion
    }
}
