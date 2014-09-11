using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao
{
    public class MenuAdministracao : MenuBase, IModuloMenuNavigation
    {
        public MenuAdministracao(RemoteWebDriver driver)
            : base(driver, Modulos.Administrativo)
        {
        }
    }
}
