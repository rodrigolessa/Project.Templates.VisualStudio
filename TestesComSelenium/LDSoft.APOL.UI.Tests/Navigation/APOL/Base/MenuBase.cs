using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Marcas;
using OpenQA.Selenium.Remote;
using Administracao = LDSoft.APOL.UI.Tests.Navigation.APOL.Administracao;
using Patentes = LDSoft.APOL.UI.Tests.Navigation.APOL.Patentes;
using Juridico = LDSoft.APOL.UI.Tests.Navigation.APOL.Juridico;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL.Base
{
    public class MenuBase : IModuloMenuNavigation
    {
        protected RemoteWebDriver Driver;
        private readonly Modulos _moduloCorrente;

        public MenuBase(RemoteWebDriver driver, Modulos moduloCorrente)
        {
            Driver = driver;
            _moduloCorrente = moduloCorrente;
        }

        public virtual Administracao.InicioPage IrParaModuloAdministracao()
        {
            if (_moduloCorrente == Modulos.Administrativo)
                return new Administracao.InicioPage(Driver);

            //Go to Administração Module
            Driver.FindElementById("llink").Click();
            Driver.FindElementByLinkText("Administração").Click();

            var administracaoWindow = Driver.WindowHandles.Last();

            Driver.SwitchTo().Window(administracaoWindow);

            return new Administracao.InicioPage(Driver);
        }

        public virtual Marcas.InicioPage IrParaModuloMarcas()
        {
            if (_moduloCorrente == Modulos.Marcas)
                return new Marcas.InicioPage(Driver);

            //Go to Administração Module
            Driver.FindElementById("llink").Click();
            Driver.FindElementByLinkText("Marcas").Click();

            var administracaoWindow = Driver.WindowHandles.Last();

            Driver.SwitchTo().Window(administracaoWindow);

            return new Marcas.InicioPage(Driver);
        }

        public Patentes.InicioPage IrParaModuloPatentes()
        {
            if (_moduloCorrente == Modulos.Patentes)
                return new Patentes.InicioPage(Driver);

            //Go to Administração Module
            Driver.FindElementById("llink").Click();
            Driver.FindElementByLinkText("Patentes").Click();

            var window = Driver.WindowHandles.Last();

            Driver.SwitchTo().Window(window);

            return new Patentes.InicioPage(Driver);
        }


        public Juridico.InicioPage IrParaModuloJuridico()
        {
            if (_moduloCorrente == Modulos.Juridico)
                return new Juridico.InicioPage(Driver);

            //Go to Administração Module
            Driver.FindElementById("llink").Click();
            Driver.FindElementByLinkText("Jurídico").Click();

            var administracaoWindow = Driver.WindowHandles.Last();

            Driver.SwitchTo().Window(administracaoWindow);

            return new Juridico.InicioPage(Driver);
        }

    }
}
