using System;
using System.Text.RegularExpressions;
using LDSoft.APOL.UI.Tests.Common;
using LDSoft.APOL.UI.Tests.Navigation.APOL.Base;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.APOL
{
    public class CaptureCaptchaPage : APOLBase
    {

        public CaptureCaptchaPage(RemoteWebDriver driver)
            : base(driver)
        {
            if (!driver.Url.Contains(Constants.GetCaptchaPageUrl))
                throw new InvalidOperationException(String.Format("A página atual é diferente da instânciada, é {0}", driver.Url));
        }

        public string GetGeneratedCaptcha()
        {
            var pageCaptcha = Driver.PageSource;

            var regex = new Regex("\\<[^\\>]*\\>");
            var generatedCaptcha = regex.Replace(pageCaptcha, String.Empty).Trim();

            return generatedCaptcha;
        }
    }
}
