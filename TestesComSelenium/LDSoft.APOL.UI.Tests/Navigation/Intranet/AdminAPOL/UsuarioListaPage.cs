using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL
{
    public class UsuarioListaPage : IntranetBase
    {
        public UsuarioListaPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public void PesquisarUsuarios()
        {
            //http://netuno:101/apol/adm/usuarios.asp

            PesquisarUsuario(String.Empty);
        }

        public void PesquisarUsuario(string usuarioAPOL)
        {
            //http://netuno:101/apol/adm/usuarios.asp

            Driver.FindElement(By.Name("radical")).SendKeys(usuarioAPOL);

            //submit
            Driver.FindElement(By.XPath("//input[contains(@type,'submit')]")).Click();
        }

        public UsuarioDetalhePage AcessarDetalheUsuario(string usuarioAPOL)
        {
            //http://netuno:101/apol/adm/usuarios.asp

            Driver.FindElementByLinkText(usuarioAPOL).Click();

            return new UsuarioDetalhePage(Driver);
        }

        public UsuarioDetalhePage CadastrarNovoUsuario()
        {
            Driver.FindElementByXPath("//a[contains(@href,'cad_usu.asp')]").Click();

            return new UsuarioDetalhePage(Driver);
        }
    }
}
