using System.Threading;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter.Navigation;
using CurrencyConverter.Tests.Utilities;
using CurrencyConverter.Tests;
using CurrencyConverter.Navigation;
using CurrencyConverter.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CurrencyConverter.Helpers;

namespace CurrencyConverter.Tests
{
    [TestClass]
    public class Tests : Base
    {
        [TestMethod]
        public void CheckPage()
        {
            Assert.IsTrue(ConverterPage.IsAt, "Page not finded");
            ConverterPage.Cockies();

        }

        //User should be able to specify numeric amount, source and target currency, and obtain conversion amount.
        [TestMethod]
        public void VerifyAmount()
        {
            CheckPage();
            Amount.NumericSource();
            Assert.IsTrue(Amount.Results, "Can not specify amount, source and target");

        }
        //Users should be able to specif decimal numeric amounts.
        [TestMethod]
        public void Decimal()
        {
            CheckPage();
            Amount.Decimal();
            Assert.IsFalse(Amount.isOkDec, "Please enter a valid amount");

        }
        //Users should be able to specify whole integers
        [TestMethod]
        public void Integer()
        {
            CheckPage();
            Amount.Integer();
            Assert.IsTrue(Amount.Int, "Can not specify integers");

        }
        //If users specify negative numeric values, they should be converted to positive numeric values before performing conversion
        [TestMethod]
        public void Negativenumbers()
        {
            CheckPage();
            Amount.Negative();
            Assert.IsTrue(Amount.isOk, "Please enter an amount greater than 0");
        }
        //If users specify non numeric values, the system should assume that 1 was the value specified,
        //and should calculate the conversion accordingly.
        [TestMethod]
        public void NonNumericNumber()
        {
            CheckPage();
            Amount.NonNumeric();
            Assert.IsTrue(Amount.IsValidNumber, "Please enter an valid amount");
        }

        //User should be able to swap source and target currencies by clicking the ‘Invert Currencies’ button. If user clicks the submit (yellow arrow) 
        //button afterwards the conversion should be reversed accordingly.
        [TestMethod]
        public void SwapCurrencies()
        {
            CheckPage();
            Amount.SwapButton();
            Assert.IsTrue(Amount.isEuro, "Swap currencies is not working");
            Amount.SwapButton();
            Assert.IsTrue(Amount.isDollar, "Reverse currencies is not working");
        }

        //Whenever user performs a conversion (or reverses it), the page URI should be updated to reflect the amount,
        //source and target currency for the conversion.
        [TestMethod]
        public void Url()
        {
            CheckPage();
            string url1 = Driver.Instance.Url;
            Amount.NumericSource();
            string url = Driver.Instance.Url;
            Thread.Sleep(2000);
            Assert.AreNotEqual(url, url1);
            Assert.AreEqual(url, "https://www.xe.com/currencyconverter/convert/?Amount=10&From=USD&To=EUR");
        }

        //Users should be able to access a conversion page directly by specifying the right query string parameters
        [TestMethod]
        public void SendingUrlwithparameters()
        {
            Driver.Instance.Navigate().GoToUrl("https://www.xe.com/currencyconverter/convert/?Amount=10&From=USD&To=EUR");
            ConverterPage.Cockies();
            Assert.IsTrue(Amount.WithParameters, "Direct url is not working");


        }
        //Whenever system provides conversion results, it should display the full conversion amount for the value
        //specified as well as the conversion rate of a single unit for both currencies.
        [TestMethod]
        public void FullConversion()
        {
            VerifyAmount();
            //conversion rate for both currencies.
            Assert.IsTrue(Amount.SingleUnit, "Can't see currencies");
        }

        //The conversion values presented for the amount specified (e.g. 10 USD = 8.90909 EUR) and the 1 unit values should be mathematically correct. i.e. if 1 USD = 0.890909 EUR, 
        //then 10 USD should equate to 8.90909 EUR.
        [TestMethod]
        public void ValuesAmount()
        {
            CheckPage();
            Amount.NumericSource();
            Assert.IsTrue(Amount.Values, "Unit values are wrong");

        }
        //The source and target currency dropdowns should list the most popular currencies at the top of the dropdown, and then list all other currencies in alphabetical order
        [TestMethod]
        public void USDEUR()
        {
            CheckPage();
            Assert.IsTrue(Currency.Source, "source isnt usd or euro");
            Assert.IsTrue(Currency.Target, "target isn't eur or usd");
        }

    }
}


