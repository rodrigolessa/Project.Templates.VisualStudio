using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico
{
    public class InicioPage : JuridicoInternoBase
    {
        public InicioPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public void IrParaHome()
        {
            Driver.FindElementById("llink").Click();
            Driver.FindElementByLinkText("Jurídico").Click();

            var juridicoWindow = Driver.WindowHandles.Last();

            Driver.SwitchTo().Window(juridicoWindow);
        }


        public ContratoListaPage IrParaManutencaoERelatorio(bool navigationFull = true)
        {

            //Go to Envolvidos Page
            Driver.FindElementById("lproc").Click();
            Driver.FindElementByLinkText("Manutenção e Relatório").Click();

            //Pesquisar Click
            Driver.FindElementByName("bts").Click();

            return new ContratoListaPage(Driver);
        }

    }
}
