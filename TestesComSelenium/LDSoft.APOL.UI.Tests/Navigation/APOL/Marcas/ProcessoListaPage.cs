using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Marcas
{
    public class ProcessoListaPage : MarcasInternoBase
    {
        public ProcessoListaPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public ProcessoListaPage PesquisarPorNumero(string numero)
        {
            throw new NotImplementedException();
        }
    }
}
