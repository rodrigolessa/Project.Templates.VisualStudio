using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using LDSoft.APOL.UI.Tests.Common.DTO;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL
{
    public class JeimisListaPage : IntranetBase
    {
        public JeimisListaPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        public List<JeimisDTO> ObterListaDeImagens()
        {
            List<JeimisDTO> lista = new List<JeimisDTO>();

            var tabela = Driver.FindElements(By.Id("listaImagens")).FirstOrDefault();
            var linhas = tabela.FindElements(By.TagName("tr"));

            foreach (IWebElement item in linhas)
            {
                var colunas = item.FindElements(By.TagName("td"));

                JeimisDTO jeimis = new JeimisDTO();
                jeimis.Nome = colunas[1].Text;
                jeimis.Diretorio = colunas[2].Text;
                jeimis.Modulo = colunas[3].Text;
                jeimis.LinkEditar = colunas[1].FindElement(By.TagName("a")).GetAttribute("onClick");
                jeimis.LinkExcluir = colunas[0].FindElement(By.TagName("a")).GetAttribute("onClick");

                lista.Add(jeimis);
            }

            return lista;
        }

        public List<JeimisDTO> ObterListaDeImagens(string modulo)
        {
            List<JeimisDTO> lista = this.ObterListaDeImagens();

            return lista.Where(x => x.Modulo == modulo).ToList();
        }

        public JeimisCadastroPage IrParaTelaDeCadastrarDeNovoJeimis()
        {
            Driver.FindElementByName("btnNovo").Click();

            return new JeimisCadastroPage(Driver);
        }

        internal JeimisMensagem ExcluirImagem(JeimisDTO imagem)
        {
            Driver.FindElementByXPath("//a[contains(@onClick, '" + imagem.LinkExcluir + "')]").Click();

            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();

            return new JeimisMensagem(Driver);
        }

        internal JeimisCadastroPage EditarImagem(JeimisDTO imagem)
        {
            Driver.FindElementByXPath("//a[contains(@onClick, '" + imagem.LinkEditar + "')]").Click();

            return new JeimisCadastroPage(Driver);
        }
    }
}
