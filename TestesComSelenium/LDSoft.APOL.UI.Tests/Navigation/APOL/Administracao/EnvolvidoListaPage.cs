using System;
using System.Linq;
using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao
{
    public class EnvolvidoListaPage : AdministracaoInternoBase
    {
        public EnvolvidoListaPage(RemoteWebDriver driver)
            : base(driver)
        {

        }

        public EnvolvidoListaPage PesquisarTodos()
        {
            //Pesquisar Click
            Driver.FindElementByName("bts").Click();

            return this;
        }

        public EnvolvidoDetalhePage IrParaDetalhePrimeiroEnvolvido()
        {
            //Obtem a lista de Envolvidos
            var envolvidos = Driver.FindElementsByXPath(String.Format("//a[contains(@href,'{0}')]", Constants.EnvolvidoDetalhePageUrl));

            //Primeiro Envolvido
            var envolvido = envolvidos.First();

            //Envolvido Detalhe Click
            envolvido.Click();

            return new EnvolvidoDetalhePage(Driver);
        }
    }
}
