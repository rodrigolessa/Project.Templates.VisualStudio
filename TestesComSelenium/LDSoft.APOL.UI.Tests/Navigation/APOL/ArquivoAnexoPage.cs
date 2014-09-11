using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL {

    public class ArquivoAnexoPage : APOLBase {

        public ArquivoAnexoPage(OpenQA.Selenium.Remote.RemoteWebDriver driver)
            : base(driver) {
        }

        public IEnumerable<IWebElement> ObterAnexosCadastrados(string containsValue) {
            Driver.SwitchTo().Frame("frame_anexo");

            var searchValue = String.Format("//a[contains(@href,'{0}')]", containsValue);

            var anexos = Driver.FindElementByName("frmanexo").FindElements(By.XPath(searchValue));

            return anexos;
        }

        public IEnumerable<string> BuscarArquivoAnexo(string anexoContainsValue, string nome) {
            var anexos = ObterAnexosCadastrados(anexoContainsValue);

            return BuscarArquivoAnexo(nome, anexos);
        }

        public IEnumerable<string> BuscarArquivoAnexo(string nome, IEnumerable<IWebElement> anexos) {
            return anexos.Where(x => x.Text == nome).Select(x => x.Text).ToList();
        }

        public void InserirArquivoAnexo(string descricao, string diretorioArquivo) {
            var xpath = String.Format("//a[contains(@href,'{0}')]", Constants.EditArquivoPageUrl);
            var link = Driver.FindElementByXPath(xpath);
            link.Click();

            //captura popup
            var popUpAnexo = Driver.WindowHandles.Last();
            Driver.SwitchTo().Window(popUpAnexo);

            //tipo de anexo
            var tipo = new SelectElement(Driver.FindElementByName("id_tipo_anexo"));
            tipo.SelectByIndex(1);

            //descricao
            var descricaoAnexo = Driver.FindElementByName("descricao");
            descricaoAnexo.SendKeys(descricao);

            //arquivo
            var arquivo = Driver.FindElementByName("arquivo");
            arquivo.SendKeys(diretorioArquivo);

            //bts
            var button = Driver.FindElementByName("bts");
            button.Click();
        }

        public void AlterandoArquivoAnexo(string descricaoAnexo) {
            var anexos = ObterAnexosCadastrados(Constants.EditAnexoPageUrl);

            //TODO LEANDRO
            //Assert.IsTrue(anexos.Any(), "Arquivos anexos cadastrados");

            anexos.First().Click();

            //captura popup
            var popUpAnexo = Driver.WindowHandles.Last();
            Driver.SwitchTo().Window(popUpAnexo);

            // Limpa e altera a descrição
            var descricao = Driver.FindElementByName("descricao");
            descricao.Clear();

            descricao.SendKeys(descricaoAnexo);

            //bts
            var button = Driver.FindElementByName("gravar");
            button.Click();
        }

        public void ExcluindoArquivoAnexo() {
            var anexos = ObterAnexosCadastrados("javascript: top.mostra_exc");

            //TODO LEANDRO
            //Assert.IsTrue(anexos.Any(), "Arquivos anexos cadastrados");

            anexos.First().Click();

            Driver.SwitchTo().DefaultContent();

            var div = Driver.FindElement(By.Id("exclui"));

            var confirmaExclusao = div.FindElement(By.XPath("//a[contains(@href,'conf_excluir')]"));

            confirmaExclusao.Click();
        }



    }
}
