using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico
{
    public class MenuJuridico : MenuBase
    {
        public MenuJuridico(RemoteWebDriver driver)
            : base(driver, Modulos.Juridico)
        {
        }
    }
}
