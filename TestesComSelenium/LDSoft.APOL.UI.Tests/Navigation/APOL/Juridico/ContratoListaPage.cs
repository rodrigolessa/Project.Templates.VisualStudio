using System;
using System.Linq;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico {

    public class ContratoListaPage : JuridicoInternoBase
    {

        public ContratoListaPage(RemoteWebDriver driver)
            : base(driver) {

        }

        public ContratoDetalhePage IrParaDetalhePrimeiroProcesso(bool navigationFull = true) {

            //Obtem a lista de Envolvidos
            var xpath = String.Format("//a[contains(@href,'{0}')]", Constants.ProcessoPageUrl);
            var processsosJuridico = Driver.FindElementsByXPath(xpath);

            //TODO LEANDRO
            //CollectionAssert.IsNotEmpty(processsosJuridico, "Processos Jurídicos");

            //Primeiro Envolvido
            var processo = processsosJuridico.First();

            //TODO LEANDRO
            //Assert.IsNotNull(processo);

            //Envolvido Detalhe Click
            processo.Click();

            return new ContratoDetalhePage(Driver);
        }

    }
}
