using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using LDSoft.APOL.UI.Tests.Common;
using System.IO;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL
{
    public class JeimisCadastroPage : IntranetBase
    {
        public JeimisCadastroPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public JeimisListaPage Submeter()
        {
            Driver.FindElementByName("btnGravar").Click();

            return new JeimisListaPage(Driver);
        }

        internal JeimisListaPage GravarImagem(Modulos modulo, string nomeArquivo)
        {
            //E seleciono o módulo "Marca"
            var tipo = new SelectElement(Driver.FindElementByName("cboModulo"));
            tipo.SelectByIndex(this.RetornaPosicaoCboModulo(modulo));

            //E informo a imagem "D:\temp\marca.jpg"
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), Constants.SubDiretorioImagens + nomeArquivo);
            var arquivo = Driver.FindElementByName("arquivo");
            arquivo.SendKeys(caminhoArquivo);

            //Quando clico em salvar imagem do Jeimis
            var button = Driver.FindElementByName("btnGravar");
            button.Click();

            return new JeimisListaPage(Driver);
        }

        internal JeimisMensagem GravarImagem(Modulos modulo)
        {
            //E seleciono o módulo "Marca"
            var tipo = new SelectElement(Driver.FindElementByName("cboModulo"));
            tipo.SelectByIndex(this.RetornaPosicaoCboModulo(modulo));

            //Quando clico em salvar imagem do Jeimis
            var button = Driver.FindElementByName("btnGravar");
            button.Click();

            IAlert alert = Driver.SwitchTo().Alert();
            var msg = alert.Text;
            alert.Accept();

            return new JeimisMensagem(Driver, msg);
        }

        internal JeimisListaPage GravarImagem(string nomeArquivo)
        {
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), Constants.SubDiretorioImagens + nomeArquivo);
            var arquivo = Driver.FindElementByName("arquivo");
            arquivo.SendKeys(caminhoArquivo);

            //Quando clico em salvar imagem do Jeimis
            var button = Driver.FindElementByName("btnGravar");
            button.Click();

            return new JeimisListaPage(Driver);
        }

        private int RetornaPosicaoCboModulo(Modulos modulo)
        {
            switch (modulo)
            {
                case Modulos.Marcas:
                    return 1;
                case Modulos.Patentes:
                    return 2;
                case Modulos.Juridico:
                    return 3;
                case Modulos.Contratos:
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
