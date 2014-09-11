using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Marcas
{
    public class MarcasInternoBase : APOLInternoBasePage
    {
        public MarcasInternoBase(RemoteWebDriver driver)
            : base(driver, Modulos.Marcas)
        {
            base.Menu = new MenuMarcas(driver);
        }

    }
}
