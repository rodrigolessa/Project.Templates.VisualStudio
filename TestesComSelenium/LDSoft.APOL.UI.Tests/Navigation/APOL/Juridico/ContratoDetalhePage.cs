using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico {
    public class ContratoDetalhePage : JuridicoInternoBase
    {

        public ArquivoAnexoPage ArquivoAnexoPopUp;

        public ContratoDetalhePage(OpenQA.Selenium.Remote.RemoteWebDriver driver)
            : base(driver) {
            ArquivoAnexoPopUp = new ArquivoAnexoPage(driver);
        }
    }
}
