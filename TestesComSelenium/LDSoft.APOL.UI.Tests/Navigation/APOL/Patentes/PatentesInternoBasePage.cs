using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes
{
    public class PatentesInternoBase : APOLInternoBasePage
    {
        public PatentesInternoBase(RemoteWebDriver driver)
            : base(driver, Modulos.Patentes)
        {
            base.Menu = new MenuPatentes(driver);
        }

    }
}
