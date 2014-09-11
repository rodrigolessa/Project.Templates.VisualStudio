using System.Linq;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes
{
    public class InicioPage : PatentesInternoBase
    {
        public InicioPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public void IrPara()
        {
            Driver.FindElementById("llink").Click();
            Driver.FindElementByLinkText("Patentes").Click();

            var patenteWindow = Driver.WindowHandles.Last();

            Driver.SwitchTo().Window(patenteWindow);
        }

        public PesquisaProcessoWebseekPage BuscaPorRadicalNoWebseek(string radical)
        {
            //Localiza campo radical e busca processos publicados
            var descricao = Driver.FindElementByName("radical");
            descricao.SendKeys(radical);

            //Localiza o botão de pesquisa
            var pesquisar = Driver.FindElementsByXPath("//input[contains(@src,'imagem/botao_busca.gif')]");
            var botao = pesquisar.First();
            botao.Click();

            return new PesquisaProcessoWebseekPage(Driver);
        }

        public PesquisaProcessoWebseekPage BuscarPorNumeroProcessoNoWebSeek(string numeroProcesso)
        {
            //Localiza campo radical e busca processos publicados
            var inputProcesso = Driver.FindElementByName("processo");
            inputProcesso.SendKeys(numeroProcesso);

            //Localiza o botão de pesquisa
            var pesquisar = Driver.FindElementsByXPath("//input[contains(@src,'imagem/botao_busca.gif')]");
            var botao = pesquisar.First();
            botao.Click();

            return new PesquisaProcessoWebseekPage(Driver);
        }

    }
}
