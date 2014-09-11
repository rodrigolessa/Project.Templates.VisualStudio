using System;
using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.ModuloConsulta
{
    public class ModuloConsultaNavigation : ModuloConsultaBase
    {
        #region Properties

        public ModuloConsultaAutenticacaoNavigation Autenticacao
        {
            get;
            private set;
        }

        #endregion

        public ModuloConsultaNavigation(RemoteWebDriver driver): base(driver)
        {
            this.Autenticacao = new ModuloConsultaAutenticacaoNavigation(driver, this);
        }

        public void IrParaUltimoDespacho(string pasta, string modulo, string numeroDoProcesso)
        {

            switch (modulo)
            {
                case Constants.ModuloConsulta.Modulo.Marca:

                    if (pasta == Constants.ModuloConsulta.Pastas.Comum)
                    {
                        var area = Driver.FindElement(By.XPath("//area[contains(@href,'ultimos_despachos_marcas.asp')]"));
                        var js = Driver as IJavaScriptExecutor;
                        js.ExecuteScript("arguments[0].click();", area);

                        // Buscando o href do determinado processo que vai ser testado e efetuando o click
                        var processo = Driver.FindElement(By.XPath("//a[contains(@href,'processo_detalhe.asp?idioma=P&uprocesso=" + numeroDoProcesso + "')]"));
                        processo.Click();
                        break;
                    }

                    if (pasta == Constants.ModuloConsulta.Pastas.Camelier || pasta == Constants.ModuloConsulta.Pastas.DPortilho)
                    {
                        // Buscando pela tag area
                        var area = Driver.FindElementByTagName("area");

                        // Dentro de area verificando se tem a determinada href e clicando;
                        area.FindElement(By.XPath("//area[contains(@href,'ultimos_despachos_marcas.asp')]")).Click();

                        // Buscando o href do determinado processo que vai ser testado e efetuando o click
                        var processo = Driver.FindElement(By.XPath("//a[contains(@href,'processo_detalhe.asp?idioma=P&uprocesso=" + numeroDoProcesso + "')]"));
                        processo.Click();
                        break;
                    }

                    break;

                // TODO IMPLEMENTAÇÕES
                case Constants.ModuloConsulta.Modulo.Patente:

                    if (pasta == Constants.ModuloConsulta.Pastas.Comum)
                    {
                        throw new NotImplementedException();
                    }

                    if (pasta == Constants.ModuloConsulta.Pastas.Camelier)
                    {
                        throw new NotImplementedException();
                    }

                    break;
            }

        }

        public void IrParaConsulta(string pasta, string modulo, string tipoDeConsulta, string numeroDoProcesso, string natureza)
        {
            switch (modulo)
            {
                case Constants.ModuloConsulta.Modulo.Marca:

                    if (pasta == Constants.ModuloConsulta.Pastas.Comum || pasta == Constants.ModuloConsulta.Pastas.Vale)
                    {
                        throw new NotImplementedException();
                    }

                    if (pasta == Constants.ModuloConsulta.Pastas.Camelier || pasta == Constants.ModuloConsulta.Pastas.CPQD || pasta == Constants.ModuloConsulta.Pastas.DPortilho)
                    {
                        throw new NotImplementedException();
                    }

                    break;

                case Constants.ModuloConsulta.Modulo.MarcaInternacional:

                    if (pasta == Constants.ModuloConsulta.Pastas.Comum || pasta == Constants.ModuloConsulta.Pastas.Vale)
                    {
                        throw new NotImplementedException();
                    }

                    if (pasta == Constants.ModuloConsulta.Pastas.Camelier || pasta == Constants.ModuloConsulta.Pastas.CPQD || pasta == Constants.ModuloConsulta.Pastas.DPortilho)
                    {
                        throw new NotImplementedException();
                    }

                    break;

                case Constants.ModuloConsulta.Modulo.Patente:

                    if (pasta == Constants.ModuloConsulta.Pastas.Comum || pasta == Constants.ModuloConsulta.Pastas.Vale)
                    {

                        var area = Driver.FindElement(By.XPath("//area[contains(@href,'consulta_patentes.asp')]"));
                        IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                        js.ExecuteScript("arguments[0].click();", area);

                        Driver.FindElementByName("proc1").SendKeys(numeroDoProcesso);

                        Driver.FindElement(By.XPath("//input[contains(@value,'" + tipoDeConsulta + "')]")).Click();

                        var processo = Driver.FindElement(By.XPath("//a[contains(@href,'processo_patente_detalhe.asp?processo=" + numeroDoProcesso + "&natureza=" + natureza + "')]"));
                        processo.Click();

                    }

                    if (pasta == Constants.ModuloConsulta.Pastas.Camelier || pasta == Constants.ModuloConsulta.Pastas.CPQD)
                    {
                        var area = Driver.FindElementByTagName("area");

                        area.FindElement(By.XPath("//area[contains(@href,'consulta_patentes.asp')]")).Click();

                        Driver.FindElementByName("proc1").SendKeys(numeroDoProcesso);

                        Driver.FindElement(By.XPath("//input[contains(@value,'" + tipoDeConsulta + "')]")).Click();

                        var processo = Driver.FindElement(By.XPath("//a[contains(@href,'processo_patente_detalhe.asp?processo=" + numeroDoProcesso + "&natureza=" + natureza + "')]"));
                        processo.Click();
                        break;
                    }

                    break;

                case Constants.ModuloConsulta.Modulo.PatenteInternacional:

                    if (pasta == Constants.ModuloConsulta.Pastas.Comum || pasta == Constants.ModuloConsulta.Pastas.Vale)
                    {
                        var area = Driver.FindElement(By.XPath("//area[contains(@href,'consulta_patentes_int.asp')]"));
                        IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                        js.ExecuteScript("arguments[0].click();", area);

                        Driver.FindElementByName("proc1").SendKeys(numeroDoProcesso);

                        Driver.FindElement(By.XPath("//input[contains(@value,'" + tipoDeConsulta + "')]")).Click();

                        var processo = Driver.FindElement(By.XPath("//a[contains(@href,'processo_patente_detalhe_int.asp?processo=" + numeroDoProcesso + "&nat=" + natureza + "')]"));
                        processo.Click();

                        break;
                    }

                    break;


            }
        }

    }
}
