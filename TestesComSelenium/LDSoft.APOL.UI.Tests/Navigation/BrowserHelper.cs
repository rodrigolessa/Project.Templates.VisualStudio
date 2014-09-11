using LDSoft.APOL.UI.Tests.Common;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation
{
    public static class BrowserHelper
    {
        #region Public Methods

        public static RemoteWebDriver Open(Browsers browser)
        {
            switch (browser)
            {
                case Browsers.GoogleChrome:
                    return ConfigureBrowserChrome();
                case Browsers.InternetExplorer:
                    return ConfigureBrowserInternetExplorer();
                default:
                    return ConfigureBrowserFirefox();
            }
        }

        public static void Close(RemoteWebDriver driver)
        {
            driver.Quit();
            driver.Dispose();
        }

        #endregion

        #region Private Methods

        private static FirefoxDriver ConfigureBrowserFirefox()
        {
            // --------------------------------
            // firefox
            // --------------------------------
            var profile = new FirefoxProfile();
            profile.SetPreference("network.security.ports.banned.override", BaseTest.ApplicationNetworkPort);

            return new FirefoxDriver(profile);
        }

        private static InternetExplorerDriver ConfigureBrowserInternetExplorer()
        {
            // --------------------------------
            // internet explorer 6-10
            // --------------------------------
            return new InternetExplorerDriver();
        }

        private static ChromeDriver ConfigureBrowserChrome()
        {
            // --------------------------------
            // chrome
            // --------------------------------
            var options = new ChromeOptions();
            options.AddArgument("--explicitly-allowed-ports=101");

            return new ChromeDriver(options);
        }

        #endregion

    }

}
