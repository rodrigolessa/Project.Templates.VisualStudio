using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Common.DTO;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.Intranet;
using LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.IO;

namespace LDSoft.APOL.UI.Tests
{
    [TestFixture]
    public class IntranetTests : BaseTest
    {
        private LoginPage _login;
        private InicioPage _inicio;
        private ListaDeOpcoesPage _listaOpcoes;

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
        public void Autenticacao_Test()
        {
            IrParaPaginaInicial();
        }

        [Test]
        public void IrParaAdministracao_Test()
        {
            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();
        }

        [Test]
        public void PesquisarUsuario_Test()
        {
            const string usuarioModuloConsulta = "saramago";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            IrParaCadastroUsuario(usuarioModuloConsulta);
        }

        [Test]
        public void AlterarDiretorioModuloConsulta_Test()
        {
            const string usuarioModuloConsulta = "saramago";
            const string diretorio = "camelier";

            IrParaPaginaInicial();

            IrParaAdministracaoAPOL();

            var cadastroUsuario = IrParaCadastroUsuario(usuarioModuloConsulta);

            cadastroUsuario.AlterarDiretorioModuloConsulta(diretorio);
        }

        #region Testes de Cadastro do Jeimis

        JeimisListaPage _jeimisPage;
        JeimisCadastroPage _jeimisCadastroPage;
        JeimisMensagem _jeimisMsgPage;

        private const string NomeArquivoJeimisDefault = "default.jpg";
        private const string NomeArquivoJeimisMarca = "marca.jpg";
        private const string NomeArquivoJeimisPatente = "patente.jpg";
        private const string NomeArquivoJeimisJuridico = "juridico.jpg";
        private const string NomeArquivoJeimisJuridicoSegunda = "juridico2.jpg";
        private const string NomeArquivoJeimisContrato = "contrato.jpg";

        /// <summary>
        /// Consulta a página de listagem de imagens do Jeimis e verifica se existe o arquivo pelo nome e módulo
        /// </summary>
        /// <param name="nomeDaImagem"></param>
        /// <param name="nomeDoModulo"></param>
        public void ConsultarImagemJeimis(string nomeDaImagem, string nomeDoModulo)
        {
            //Dado que existe a imagem
            //Dado Que Estou na Tela de Listagem de Imagens do Jeimis
            if (_jeimisPage == null)
                throw new AssertionException(Resources.Mensagens.ERRO_ACESSAR_PAGINA_LISTA_JEIMIS);

            //Quando acesso a lista de imagens do Jeimis para o módulo
            var imagens = _jeimisPage.ObterListaDeImagens(nomeDoModulo);

            Assert.IsTrue(imagens.Any(), "Imagens cadastradas!");

            //Só deve existir uma imagem para cada módulo
            Assert.AreEqual(1, imagens.Count(), "Quantidade de imagens para o Módulo - " + nomeDoModulo);

            //Quando acesso a lista de imagens do Jeimis no "1" registro
            var imagemModulo = imagens.FirstOrDefault();

            //Então visualizo o nome ? e o módulo ? da imagem
            Assert.AreEqual(nomeDaImagem, imagemModulo.Nome, "Nome do arquivo de imagem para o Módulo - " + nomeDoModulo);
        }

        #region Sucesso

        [Test(Description = "Verifica se existe a imagem 'default.jpg' para quando o módulo for nulo")]
        public void ConsultarImagemDoJeimisParaTodosOsModulos()
        {
            //Dado Que Estou na Tela de Listagem de Imagens do Jeimis
            _jeimisPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis();

            //Dado que existe a imagem "default.jpg"
            this.ConsultarImagemJeimis(NomeArquivoJeimisDefault, Constants.Intranet.Modulo.Todos);
        }

        [Test(Description = "Verifica se existe a imagem 'marca.jpg' para o módulo 'Marca'")]
        public void ConsultarImagemDoJeimisParaOModuloDeMarca()
        {
            //Dado que existe a imagem "marca.jpg"

            //Dado Que Estou na Tela de Listagem de Imagens do Jeimis
            _jeimisPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis();

            //Quando acesso a lista de imagens do Jeimis para o módulo "Marca"
            this.ConsultarImagemJeimis(NomeArquivoJeimisMarca, Constants.Intranet.Modulo.Marca);
        }

        [Test]
        public void ExcluirImagemDoJeimisParaOModuloDeMarca()
        {
            //Dado que cadastrei uma imagem para o módulo de Marca

            //Dado Que Estou na Tela de Listagem de Imagens do Jeimis
            _jeimisPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis();

            //Quando acesso a lista de imagens do Jeimis para o módulo "Marca"
            var imagens = _jeimisPage.ObterListaDeImagens(Constants.Intranet.Modulo.Marca);

            Assert.IsTrue(imagens.Any(), "Lista de imagens de Marca encontrada!");

            var imagemMarca = imagens.FirstOrDefault();

            //E clico em excluir o registro do Jeimis para a imagem "marca.jpg"
            _jeimisMsgPage = _jeimisPage.ExcluirImagem(imagemMarca);

            //Então visualizo a mensagem "Imagem excluida com sucesso!" na tela
            Assert.AreEqual(Resources.Mensagens.SUCESSO_EXCLUIR_IMAGEM_JEIMIS, _jeimisMsgPage.Mensagem, "Mensagem de registro excluido!");
        }

        [Test(Description = "Cadastrar a imagem 'marca.jpg' para o módulo 'Marca'")]
        public void CadastrarImagemParaModuloDeMarca()
        {
            //Dado que acesso a tela de cadastrado do Jeimis
            _jeimisCadastroPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis()
                .IrParaTelaDeCadastrarDeNovoJeimis();

            //E informo a imagem "D:\temp\marca.jpg"
            //E seleciono o módulo "Marca"
            //Quando clico em salvar imagem do Jeimis
            _jeimisPage = _jeimisCadastroPage.GravarImagem(Modulos.Marcas, NomeArquivoJeimisMarca);

            //Verifica se a imagem foi cadastrada
            this.ConsultarImagemJeimis(NomeArquivoJeimisMarca, Constants.Intranet.Modulo.Marca);
        }

        [Test]
        public void AlterarArquivoDeImagemParaModuloJuridico()
        {
            _jeimisPage = this.DadoQueExisteAImagemJuridico();

            var imagemJuridico = _jeimisPage.ObterListaDeImagens(Constants.Intranet.Modulo.Juridico).FirstOrDefault();

            _jeimisCadastroPage = _jeimisPage.EditarImagem(imagemJuridico);

            _jeimisPage = _jeimisCadastroPage.GravarImagem(NomeArquivoJeimisJuridicoSegunda);

            this.ConsultarImagemJeimis(NomeArquivoJeimisJuridicoSegunda, Constants.Intranet.Modulo.Juridico);
        }

        public JeimisListaPage DadoQueExisteAImagemJuridico()
        {
            _jeimisPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis();

            var imagens = _jeimisPage.ObterListaDeImagens(Constants.Intranet.Modulo.Juridico);

            if (!imagens.Any())
            {
                _jeimisCadastroPage = _jeimisPage.IrParaTelaDeCadastrarDeNovoJeimis();

                _jeimisPage = _jeimisCadastroPage.GravarImagem(Modulos.Juridico, NomeArquivoJeimisJuridico);
            }

            return _jeimisPage;
        }

        #endregion

        #region Falha

        [Test]
        public void CadastrarDuasImagensParaModuloDeContrato()
        {
            
            //Dado Que Estou na Tela de Listagem de Imagens do Jeimis
            //E tenha a imagem "contrato.jpg" já cadastrada
            _jeimisCadastroPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis()
                .IrParaTelaDeCadastrarDeNovoJeimis();         

            //E informo a imagem "contrato_2.jpg"
            //E seleciono o módulo "Contratos"
            //Quando clico em Gravar imagem do Jeimis
            _jeimisPage = _jeimisCadastroPage.GravarImagem(Modulos.Contratos, NomeArquivoJeimisMarca);

            //Então verifica se a mensagem "O módulo selecionado já tem imagem cadastrada." é apresentada
            this.ConsultarImagemJeimis(NomeArquivoJeimisMarca, Constants.Intranet.Modulo.Contrato);

        }

        [Test]
        public void CadastrarImagemParaOModuloDePatenteSemInformarUmArquivo()
        {
            //Dado que acesso a tela de cadastrado do Jeimis
            _jeimisCadastroPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis()
                .IrParaTelaDeCadastrarDeNovoJeimis();

            //E informo a imagem ""
            //E seleciono o módulo "Patente"
            //Quando clico em salvar imagem do Jeimis
            _jeimisMsgPage = _jeimisCadastroPage.GravarImagem(Modulos.Patentes);

            //Então visualizo a mensagem "O campo Arquivo é obrigatório!" na tela
            Assert.AreEqual(Resources.Mensagens.ERRO_CADASTRO_JEIMIS_ARQUIVO_OBRIGATORIO, _jeimisMsgPage.Mensagem, "Mensagem de campo obrigatório!");
        }

        [Test]
        public void ProibirExclusãoDaImagemDefault()
        {
            //Dado Que Estou na Tela de Listagem de Imagens do Jeimis
            _jeimisCadastroPage = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet)
                .IrParaAdministracaoAPOL()
                .IrParaUtilitarioDoJeimis()
                .IrParaTelaDeCadastrarDeNovoJeimis();

            //Quando excluir a imagem do módulo "Todos" da Listagem de Imagens do Jeimis
            //E excluir todas as demais imagens da Listagem de Imagens do Jeimis      
            //Então verifica se a mensagem "O Módulo "Todos" deve ser cadastrado." é apresentada
            this.ConsultarImagemJeimis(NomeArquivoJeimisMarca, Constants.Intranet.Modulo.Contrato);
        }

        #endregion

        #endregion

        private void IrParaPaginaInicial()
        {
            _inicio = _login.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet);

            StringAssert.Contains(Constants.Intranet.InicioPageUrl, _inicio.Url, "Página Principal");
        }

        private void IrParaAdministracaoAPOL()
        {
            _listaOpcoes = _inicio.IrParaAdministracaoAPOL();

            StringAssert.Contains(Constants.Intranet.AdministracaoApolPageUrl, _listaOpcoes.Url, "Administração APOL");
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
