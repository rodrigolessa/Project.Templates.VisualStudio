using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation;
using LDSoft.APOL.UI.Tests.Navigation.Intranet;

namespace LDSoft.APOL.UI.Tests.Steps
{
    [Binding, TestFixture]
    public class CadastroImagensJeimisSteps : BaseTest
    {
        #region Membros

        private LoginPage _paginaLogin;

        #endregion

        #region Construtor

        public CadastroImagensJeimisSteps()
        {
            Driver = BrowserHelper.Open(Browsers.FireFox);

            _paginaLogin = new LoginPage(Driver);
        }

        #endregion

        #region Contexto da Funcionalidade

        [Given(@"Que Estou na Tela de Listagem de Imagens do Jeimis")]
        public void DadoQueEstouNaTelaDeListagemDeImagensDoJeimis()
        {
            _paginaLogin.Entrar(NomeUsuarioIntranet, SenhaUsuarioIntranet).IrParaAdministracaoAPOL();
        }

        #endregion

        [Given(@"que existe a imagem ""(.*)""")]
        public void DadoQueExisteAImagem(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que cadastrei uma imagem para o módulo de Marca")]
        public void DadoQueCadastreiUmaImagemParaOModuloDeMarca()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que não existe imagem para o módulo ""(.*)""")]
        public void DadoQueNaoExisteImagemParaOModulo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que acesso a tela de cadastrado do Jeimis")]
        public void DadoQueAcessoATelaDeCadastradoDoJeimis()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"informo a imagem ""(.*)""")]
        public void DadoInformoAImagem(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"seleciono o módulo ""(.*)""")]
        public void DadoSelecionoOModulo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"acesso a lista de imagens do Jeimis no ""(.*)"" registro")]
        public void QuandoAcessoAListaDeImagensDoJeimisNoRegistro(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"acesso a lista de imagens do Jeimis para o módulo ""(.*)""")]
        public void QuandoAcessoAListaDeImagensDoJeimisParaOModulo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"clico em excluir o registro do Jeimis para a imagem ""(.*)""")]
        public void QuandoClicoEmExcluirORegistroDoJeimisParaAImagem(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"clico em salvar imagem do Jeimis")]
        public void QuandoClicoEmSalvarImagemDoJeimis()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"visualizo o nome ""(.*)"" e o módulo ""(.*)"" da imagem")]
        public void EntaoVisualizoONomeEOModuloDaImagem(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"visualizo a mensagem ""(.*)"" na tela")]
        public void EntaoVisualizoAMensagemNaTela(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"obtenho um item nulo para a imagem do Jeimis")]
        public void EntaoObtenhoUmItemNuloParaAImagemDoJeimis()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
