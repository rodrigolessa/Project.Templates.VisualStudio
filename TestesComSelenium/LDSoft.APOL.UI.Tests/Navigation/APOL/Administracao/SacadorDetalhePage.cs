using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao
{
    public class SacadorDetalhePage : AdministracaoInternoBase
    {
        public SacadorDetalhePage(RemoteWebDriver driver)
            : base(driver)
        {
            //TODO LEANDRO RIBEIRO
            //if (!selenium.getTitle().equals("Home Page of logged in user")) {
            //    throw new IllegalStateException("This is not Home Page of logged in user, current page" +
            //                    "is: " + selenium.getLocation());
            //}
        }
    }
}
