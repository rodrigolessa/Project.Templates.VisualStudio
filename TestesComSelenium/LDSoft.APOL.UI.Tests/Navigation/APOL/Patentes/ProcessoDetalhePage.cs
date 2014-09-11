using System.Linq;
using System.Collections.Generic;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes
{
    public class ProcessoDetalhePage : PatentesInternoBase
    {
        public ArquivoAnexoPage ArquivoAnexoPopUp;

        public ProcessoDetalhePage(OpenQA.Selenium.Remote.RemoteWebDriver remoteWebDriver)
            : base(remoteWebDriver)
        {
            ArquivoAnexoPopUp = new ArquivoAnexoPage(remoteWebDriver);
        }

        public void AssociarProcesso()
        {
            //Localiza o botão para associar o processo
            var listaLinksAssociar = Driver.FindElementsByXPath("//a[contains(@href,'javascript: mostra_cad')]");

            if (listaLinksAssociar.Any())
            {
                var linkAssociar = listaLinksAssociar.First();
                linkAssociar.Click();

                //Localiza o botão confirmando cadastro
                listaLinksAssociar = Driver.FindElementsByXPath("//a[contains(@href,'javascript: mostra_terc')]");
                var linkConfirmar = listaLinksAssociar.First();
                linkConfirmar.Click();

                //Localiza o botão para cadastrar como próprio
                listaLinksAssociar = Driver.FindElementsByXPath("//a[contains(@href,'javascript: cad_proc_tipo(0)')]");
                var linkProprio = listaLinksAssociar.First();
                linkProprio.Click();
            }
        }

        //public System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.IWebElement> ObterListaParecer()
        public List<OpenQA.Selenium.IWebElement> ObterListaParecer()
        {
            return Driver.FindElementsByClassName("dwParecer").ToList();
        }
    }
}
