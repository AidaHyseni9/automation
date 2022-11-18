using System;
using System.Collections.Generic;
using System.Text;
using CurrencyConverter.Navigation;
using CurrencyConverter.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace CurrencyConverter.Tests.Utilities
{
    public class Base
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            ConverterPage.GoTo();

            //Driver.Instance.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void Clenaup()
        {

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //extent.Flush();
            Driver.Instance.Close();
            Driver.Instance.Quit();
            //
        }
    }
}
