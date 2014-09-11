using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LDSoft.APOL.UI.Tests.Navigation
{
    public static class Config
    {
        public static readonly TimeSpan ImplicitWait = new TimeSpan(0, 0, 0, 10);
        public static readonly TimeSpan NoWait = new TimeSpan(0, 0, 0, 0);
    }

    public static class WebElementExtensions
    {
        //TODO LEANDRO RIBEIRO | Comparar performance com o teste abaixo
        //public static bool ElementIsPresent(this IWebDriver driver, By by)
        //{
        //    try
        //    {
        //        return driver.FindElement(by).Displayed;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            var present = false;
            driver.Manage().Timeouts().ImplicitlyWait(Config.NoWait);
            try
            {
                present = driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
            }
            driver.Manage().Timeouts().ImplicitlyWait(Config.ImplicitWait);
            return present;
        }

        public static IWebElement GetParent(this IWebElement e)
        {
            return e.FindElement(By.XPath(".."));
        }

        public static void Set(this IWebElement e, string text)
        {
            e.Clear();
            e.SendKeys(text);
        }

        public static string SelectBySubText(this SelectElement me, string subText)
        {
            foreach (var option in me.Options.Where(option => option.Text.Contains(subText)))
            {
                var optionText = option.Text;
                option.Click();
                return optionText;
            }
            me.SelectByText(subText);
            return subText;
        }

        public static IWebElement FindVisibleElement(this IWebDriver driver, By by)
        {
            var elements = driver.FindElements(by);
            foreach (var element in elements.Where(e => e.Displayed))
            {
                return element;
            }
            throw new NoSuchElementException("Unable to find visible element with " + @by);
        }

        public static bool VisibleElementExists(this IWebDriver driver, By by, Int32 implicitWait = 10)
        {
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0));
            var elements = driver.FindElements(by);
            var visibleElements = elements.Count(e => e.Displayed);
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, implicitWait));
            return visibleElements != 0;
        }



    }
}
