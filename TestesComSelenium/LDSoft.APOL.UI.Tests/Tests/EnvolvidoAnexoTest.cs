using System.IO;
using System.Linq;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.APOL;
using NUnit.Framework;
using Administracao = LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao;
using Patentes = LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes;
using Juridico = LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico;
using Marcas = LDSoft.APOL.UI.Tests.Navigation.APOL.Marcas;

namespace LDSoft.APOL.UI.Tests
{

    [TestFixture]
    public class EnvolvidoAnexoTest : BaseTest
    {

        private LoginPage _login;
        private Administracao.InicioPage _inicioAdministracao;
        private Administracao.EnvolvidoDetalhePage _envolvidoDetalhe;
        private Patentes.InicioPage _inicioPatente;
        private Juridico.InicioPage _inicioJuridico;
        //private Marcas.InicioPage _homeMarcas;
        private Patentes.PesquisaProcessoWebseekPage _pesquisaProcessoWebseek;
        private Patentes.ProcessoDetalhePage _processoDetalhe;

        private const string NomeArquivoAnexo = "ARQUIVOANEXO.txt";

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
        public void Lista_Documentos_Envolvido_Test()
        {
            _inicioAdministracao = _login
                .Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol)
                .IrParaModuloAdministracao();

            _envolvidoDetalhe = _inicioAdministracao
                .IrParaPesquisaEnvolvidos()
                .PesquisarTodos()
                .IrParaDetalhePrimeiroEnvolvido();

            var anexos = _envolvidoDetalhe
                .ArquivoAnexoPopUp
                .ObterAnexosCadastrados(Constants.VerAnexoPageUrl);

            Assert.IsTrue(anexos.Any(), "Anexos cadastrados");

            var anexosEncontrados = _envolvidoDetalhe
                .ArquivoAnexoPopUp
                .BuscarArquivoAnexo(NomeArquivoAnexo, anexos);

            Assert.IsTrue(anexosEncontrados.Any(), "Nome arquivo anexo enontrado");

        }

        [Test]
        public void Inserir_Novo_ArquivoAnexo_Test()
        {

            _inicioAdministracao = _login
                .Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol)
                .IrParaModuloAdministracao();

            _envolvidoDetalhe = _inicioAdministracao
                .IrParaPesquisaEnvolvidos()
                .PesquisarTodos()
                .IrParaDetalhePrimeiroEnvolvido();

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), NomeArquivoAnexo);

            _envolvidoDetalhe.ArquivoAnexoPopUp.InserirArquivoAnexo("teste de anexo pelo selenium", caminhoArquivo);

        }

        [Test(Description = "Documentos Anexos em Processos de Patente Nacional")]
        public void InserirNovoAnexoEmProcessoPublicadoDePatente_Test()
        {

            _inicioPatente = _login.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol).IrParaModuloPatentes();

            _pesquisaProcessoWebseek = _inicioPatente.BuscaPorRadicalNoWebseek("baquelite");

            _processoDetalhe = _pesquisaProcessoWebseek.IrParaPrimeiroProcesso();

            // Na tela de Detalhes do processo de PATENTES (não associado)
            _processoDetalhe.AssociarProcesso();

            // Cadastrando anexo
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), NomeArquivoAnexo);
            _processoDetalhe.ArquivoAnexoPopUp.InserirArquivoAnexo("teste de cadastro de anexo...", caminhoArquivo);

            // Retorno para a tela/IFrame de detalhe do processo
            var janelaProcesso = Driver.WindowHandles.LastOrDefault();
            Driver.SwitchTo().Window(janelaProcesso);

            var anexos = _processoDetalhe.ArquivoAnexoPopUp.ObterAnexosCadastrados(Constants.VerAnexoPageUrl);

            Assert.IsTrue(anexos.Any(), "Anexos cadastrados");

            Assert.IsTrue(_processoDetalhe.ArquivoAnexoPopUp.BuscarArquivoAnexo(NomeArquivoAnexo, anexos).Any(), "Nome arquivo anexo enontrado");

        }

        [Test]
        public void Inserir_Novo_Arquivo_Anexo_Juridico_Test()
        {

            _inicioJuridico = _login.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol).IrParaModuloJuridico();

            var contratoLista = _inicioJuridico.IrParaManutencaoERelatorio();

            var contratoDetalhe = contratoLista.IrParaDetalhePrimeiroProcesso();

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), NomeArquivoAnexo);

            contratoDetalhe.ArquivoAnexoPopUp.InserirArquivoAnexo("leonado 123", caminhoArquivo);

        }

        [Test]
        public void Excluir_Arquivo_Anexo_Juridico_Test()
        {
            _inicioJuridico = _login.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol).IrParaModuloJuridico();

            var contratoLista = _inicioJuridico.IrParaManutencaoERelatorio();

            var contratoDetalhe = contratoLista.IrParaDetalhePrimeiroProcesso();

            contratoDetalhe.ArquivoAnexoPopUp.ExcluindoArquivoAnexo();
        }

        [Test]
        public void Alterar_Arquivo_Anexo_Juridico_Test()
        {
            _inicioJuridico = _login.Entrar(NomeUsuarioTitularApol, SenhaUsuarioTitularApol).IrParaModuloJuridico();

            var contratoLista = _inicioJuridico.IrParaManutencaoERelatorio();

            var contratoDetalhe = contratoLista.IrParaDetalhePrimeiroProcesso();

            contratoDetalhe.ArquivoAnexoPopUp.AlterandoArquivoAnexo("Leonardo alterado");
        }


    }

}
