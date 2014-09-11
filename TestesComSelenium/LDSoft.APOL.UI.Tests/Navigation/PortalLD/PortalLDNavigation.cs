using System;
using System.Linq;
using System.Text.RegularExpressions;
using LDSoft.APOL.UI.Tests.Common;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace LDSoft.APOL.UI.Tests.Navigation.PortalLD
{
    class PortalLDNavigation : PortalLDBase
    {
        #region Properties

        public PortalLDCommonNavigation Common { get; private set; }

        #endregion
        
        #region Constructors

        public PortalLDNavigation(RemoteWebDriver driver)
            : base(driver)
        {
            Common = new PortalLDCommonNavigation(driver, this);
        }

        #endregion

        public class PortalLDCommonNavigation
        {
            #region Attributes

            private readonly RemoteWebDriver _driver;
            private readonly PortalLDNavigation _parent;

            #endregion

            #region Constructors

            public PortalLDCommonNavigation(RemoteWebDriver driver, PortalLDNavigation parent)
            {
                this._driver = driver;
                this._parent = parent;
            }

            #endregion
        }
    }
}
