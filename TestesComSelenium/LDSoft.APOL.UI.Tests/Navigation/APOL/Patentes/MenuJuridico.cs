using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes
{
    public class MenuPatentes : MenuBase
    {
        public MenuPatentes(RemoteWebDriver driver)
            : base(driver, Modulos.Patentes)
        {
        }
    }
}
