using System.Linq;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL
{
    public class ListaDeOpcoesPage : IntranetBase
    {
        public ListaDeOpcoesPage(RemoteWebDriver driver)
            : base(driver)
        {

        }

        public UsuarioListaPage IrParaCadastroDeUsuario()
        {
            //captura popup
            var popUpMenu = Driver.WindowHandles.Last();
            Driver.SwitchTo().Window(popUpMenu);

            var link1 = Driver.FindElementByXPath("//a[contains(@onclick,\"javascript:submeter('/apol/adm/usuarios.asp');\")]");
            link1.Click();

            return new UsuarioListaPage(Driver);
        }

        public JeimisListaPage IrParaUtilitarioDoJeimis()
        {
            //captura popup
            var popUpMenu = Driver.WindowHandles.Last();
            Driver.SwitchTo().Window(popUpMenu);

            var link1 = Driver.FindElementByXPath("//a[contains(@onclick,\"javascript:submeter('/apol/adm/jeimis/novo/listar.asp');\")]");
            link1.Click();

            return new JeimisListaPage(Driver);
        }
    }
}
