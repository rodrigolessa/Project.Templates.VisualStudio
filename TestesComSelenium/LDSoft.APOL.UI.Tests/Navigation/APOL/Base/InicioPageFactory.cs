using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Remote;
using Patentes = LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes;
using Marcas = LDSoft.APOL.UI.Tests.Navigation.APOL.Marcas;
using Juridico = LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Base
{
    public abstract class InicioPageFactory
    {
        public static APOLInternoBasePage CriarInicioPage(string modulo, RemoteWebDriver driver)
        {
            switch (modulo)
            {
                case Constants.Patentes.PatenteSigla:
                    return new Patentes.InicioPage(driver);
                case Constants.Juridico.JuridicoSigla:
                    return new Juridico.InicioPage(driver);
                case Constants.Marcas.MarcasSigla:
                    return new Marcas.InicioPage(driver);
                default:
                    throw new ArgumentException(String.Format("Não existe pagina inicial para o módulo \"{0}\" informado!", modulo));
            }
        }
    }
}
