using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation
{
    public abstract class BasePage
    {
        private readonly RemoteWebDriver _driver;

        protected BasePage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        protected BasePage()
        {
            _driver = new FirefoxDriver();
        }

        public RemoteWebDriver Driver
        {
            get { return _driver; }
        }

        public Uri Uri
        {
            get { return new Uri(Driver.Url); }
        }

        public string Url
        {
            get { return Driver.Url; }
        }

        public string Title
        {
            get { return Driver.Title; }
        }
        public NameValueCollection Parametros
        {
            get
            {
                var queryStringArray = Url.Split('?').Skip(1).ToArray();
                var querystring = String.Join(String.Empty, queryStringArray);

                return HttpUtility.ParseQueryString(querystring);
            }
        }
    }
}
