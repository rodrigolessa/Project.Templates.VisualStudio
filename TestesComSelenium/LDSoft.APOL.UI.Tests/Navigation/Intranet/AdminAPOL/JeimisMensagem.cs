using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.Intranet.AdminAPOL
{
    public class JeimisMensagem : IntranetBase
    {
        public string Mensagem { get; set; }

        public JeimisMensagem(RemoteWebDriver driver)
            : base(driver)
        {
            //alert alert-error
            //alert alert-success
            var mensagens = Driver.FindElementsByClassName("alert");

            if (mensagens.Count() > 0)
                this.Mensagem = mensagens.FirstOrDefault().Text;
        }

        public JeimisMensagem(RemoteWebDriver driver, string msg)
            : base(driver)
        {
            this.Mensagem = msg;
        }
    }
}
