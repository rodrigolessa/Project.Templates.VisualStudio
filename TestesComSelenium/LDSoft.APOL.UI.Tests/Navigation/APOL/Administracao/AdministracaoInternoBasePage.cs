using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao
{
    public abstract class AdministracaoInternoBase : APOLInternoBasePage
    {
        protected AdministracaoInternoBase(RemoteWebDriver driver)
            : base(driver, Modulos.Administrativo)
        {
            base.Menu = new MenuAdministracao(driver);
        }
    }
}
