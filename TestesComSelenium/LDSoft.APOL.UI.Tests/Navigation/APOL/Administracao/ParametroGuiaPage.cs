using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao
{
    public class ParametroGuiaPage : AdministracaoInternoBase
    {

        public ParametroGuiaPage(RemoteWebDriver driver)
            : base(driver)
        {
            //TODO LEANDRO RIBEIRO
            //if (!selenium.getTitle().equals("Home Page of logged in user")) {
            //    throw new IllegalStateException("This is not Home Page of logged in user, current page" +
            //                    "is: " + selenium.getLocation());
            //}
        }

        public SacadorDetalhePage IrParaDetalheDoPrimeiroSacador()
        {
            // Click na caixa de cadastro de sacador
            Driver.FindElementByXPath("//a[contains(@href, 'guia_cad_empresa.asp')]").Click();

            return new SacadorDetalhePage(Driver);
        }
    }
}
