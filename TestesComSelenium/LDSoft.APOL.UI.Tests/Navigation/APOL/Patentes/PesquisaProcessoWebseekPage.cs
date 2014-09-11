using System;
using System.Linq;
using LDSoft.APOL.UI.Tests.Common;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes
{
    public class PesquisaProcessoWebseekPage : PatentesInternoBase
    {
        public PesquisaProcessoWebseekPage(OpenQA.Selenium.Remote.RemoteWebDriver remoteWebDriver)
            : base(remoteWebDriver)
        {
        }

        public ProcessoDetalhePage IrParaPrimeiroProcesso()
        {
            //Obtem a lista de Processos
            var xpath = String.Format("//a[contains(@href,'{0}')]", Constants.Patentes.ProcessoDetalhePageUrl);

            var processosPatente = Driver.FindElementsByXPath(xpath);

            //TODO: LEANDRO | Verificar melhor forma de tratar antes do Click
            //Primeiro Processo da lista
            var processo = processosPatente.First();

            //Detalhe do Processo Click
            processo.Click();

            return new ProcessoDetalhePage(Driver);
        }
    }
}
