using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL
{
    public class UsuarioDetalhePage : IntranetBase
    {
        public UsuarioDetalhePage(RemoteWebDriver driver)
            : base(driver)
        {
        }


        public void AlterarDiretorioModuloConsulta(string diretorio)
        {
            //http://netuno:101/apol/adm/cad_usu.asp?id=2636&navega=ok

            var form = Driver.FindElementByName("frm");
            var txtPasta = form.FindElement(By.Name("pasta_mco"));

            txtPasta.Clear();
            txtPasta.SendKeys(diretorio);

            Driver.FindElementByName("Vpesquisa").Click();
        }

        public UsuarioDetalhePage PreencherDados(string usuario, string modulo, string email, string dataDeBloqueio, string empresa, string CPFCNPJ, string contato)
        {
            // Nome do novo usuario
            Driver.FindElementByName("Vnome").SendKeys(usuario);

            // Seleção do módulo de primeiro acesso
            var options = Driver.FindElementByName("modulo_default");
            var select = new SelectElement(options);
            select.SelectByText(modulo);

            // Email do novo usuario
            Driver.FindElementByName("Vemail").SendKeys(email);

            // Data de bloqueio do novo usuario. Ex: 01/01/2015
            Driver.FindElementByName("databl").SendKeys(dataDeBloqueio);

            // Empresa do novo usuario
            Driver.FindElementByName("Vempresa").SendKeys(empresa);

            //CPF ou CNPJ do novo usuario
            Driver.FindElementByName("Vcgc").SendKeys(CPFCNPJ);

            //CPF ou CNPJ do novo usuario
            Driver.FindElementByName("Vcontato").SendKeys(contato);

            return this;
        }


        public UsuarioListaPage Submeter()
        {
            Driver.FindElementByName("Vpesquisa").Click();

            return new UsuarioListaPage(Driver);
        }

    }
}
