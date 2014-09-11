using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao
{
    public class EnvolvidoDetalhePage : AdministracaoInternoBase
    {
        public ArquivoAnexoPage ArquivoAnexoPopUp;

        public EnvolvidoDetalhePage(RemoteWebDriver driver)
            : base(driver)
        {
            ArquivoAnexoPopUp = new ArquivoAnexoPage(driver);
        }
    }
}
