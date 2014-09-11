using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao
{

    public class InicioPage : AdministracaoInternoBase
    {

        public InicioPage(RemoteWebDriver driver)
            : base(driver)
        {

            //TODO LEANDRO RIBEIRO
            //if (!selenium.getTitle().equals("Home Page of logged in user")) {
            //    throw new IllegalStateException("This is not Home Page of logged in user, current page" +
            //                    "is: " + selenium.getLocation());
            //}
        }

        public ParametroGuiaPage IrParaParametrosDeGuia()
        {

            Driver.FindElementById("ldiv").Click();

            Driver.FindElementByLinkText("Parâm. Guia").Click();

            return new ParametroGuiaPage(Driver);
        }

        public EnvolvidoListaPage IrParaPesquisaEnvolvidos()
        {
            //Go to Envolvidos Page
            Driver.FindElementById("lrpi").Click();
            Driver.FindElementByLinkText("Envolvidos").Click();

            return new EnvolvidoListaPage(Driver);
        }
    }
}
