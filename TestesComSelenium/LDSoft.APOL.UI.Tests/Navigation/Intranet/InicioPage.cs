using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet
{
    public class InicioPage : IntranetBase
    {
        public InicioPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public ListaDeOpcoesPage IrParaAdministracaoAPOL()
        {
            //http://netuno:101/portal_webseek/intranet/main.asp

            var linkAdministracao = Driver.FindElementByLinkText("Administração APOL");
            linkAdministracao.Click();

            var popUp = Driver.WindowHandles.Last();
            Driver.SwitchTo().Window(popUp);

            return new ListaDeOpcoesPage(Driver);
        }
    }
}
