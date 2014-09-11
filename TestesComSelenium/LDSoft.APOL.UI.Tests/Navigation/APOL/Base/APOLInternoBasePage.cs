using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Base
{

    public abstract class APOLInternoBasePage : APOLBase, IModuloMenuNavigation
    {
        protected Modulos ModuloCorrente { get; set; }
        protected IModuloMenuNavigation Menu { get; set; }

        protected APOLInternoBasePage(RemoteWebDriver driver)
            : base(driver)
        {
            Menu = new MenuBase(driver, ModuloCorrente);
        }

        protected APOLInternoBasePage(RemoteWebDriver driver, Modulos modulo)
            : base(driver)
        {
            Menu = new MenuBase(driver, modulo);
            ModuloCorrente = modulo;
        }

        public Administracao.InicioPage IrParaModuloAdministracao()
        {
            return Menu.IrParaModuloAdministracao();
        }

        public Juridico.InicioPage IrParaModuloJuridico()
        {
            return Menu.IrParaModuloJuridico();
        }

        public Marcas.InicioPage IrParaModuloMarcas()
        {
            return Menu.IrParaModuloMarcas();
        }

        public Patentes.InicioPage IrParaModuloPatentes()
        {
            return Menu.IrParaModuloPatentes();
        }

    }
}
