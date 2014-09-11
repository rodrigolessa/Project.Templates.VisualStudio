using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Marcas
{
    public class MenuMarcas : MenuBase
    {
        public MenuMarcas(RemoteWebDriver driver)
            : base(driver, Modulos.Marcas)
        {
        }
    }
}
