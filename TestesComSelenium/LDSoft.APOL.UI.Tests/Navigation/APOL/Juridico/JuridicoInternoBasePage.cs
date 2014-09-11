using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico
{
    public abstract class JuridicoInternoBase : APOLInternoBasePage
    {
        protected JuridicoInternoBase(RemoteWebDriver driver)
            : base(driver, Modulos.Juridico)
        {
            base.Menu = new MenuJuridico(driver);
        }
    }

}
