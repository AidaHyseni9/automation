using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CurrencyConverter.Helpers;
using CurrencyConverter.Selenium;
using System.Threading;

namespace CurrencyConverter.Navigation
{
    public class Amount
    {

        public static void NumericSource()
        {
            ActionsHelpers.GiveAmount("10");
            ActionsHelpers.ChoseCurrency("USD-Dollar");
            ActionsHelpers.SelectElemenstByCssSelector("button[class='button__BaseButton-sc-1qpsalo-0 clGTKJ']", 2).Click();
            Thread.Sleep(5000);
        }
        public static void Integer()
        {
            ActionsHelpers.GiveAmount("2");
        }

        public static void Decimal()
        {
            ActionsHelpers.GiveAmount("2.76");
        }
        public static void Negative()
        {
            ActionsHelpers.GiveAmount("-2");

        }
        public static void NonNumeric()
        {
            ActionsHelpers.GiveAmount("a");
        }
        public static void SwapButton()
        {


            ActionsHelpers.SelectElementByCssSelector("div[class='currency-converter___StyledDiv-zieln1-0 dYwyct']>button").Click();

        }
        public static bool isEuro
        {
            get
            {
                Thread.Sleep(1000);
                var expected = ActionsHelpers.SelectElementByCssSelector("span[class='amount-input']");

                if (expected.Text.Equals("€"))
                    return true;
                return false;
            }
        }
        public static bool Values
        {
            get
            {
                Thread.Sleep(1000);
                var result = ActionsHelpers.SelectElementByCssSelector("p[class='result__BigRate-sc-1bsijpp-1 iGrAod']");
                Thread.Sleep(1000);
                var convert = ActionsHelpers.SelectElementByCssSelector("div[class='unit-rates___StyledDiv-sc-1dk593y-0 dEqdnx']");

                if (convert.Text.Contains("0.96") && result.Text.Contains("9.6"))
                    return true;
                else
                    return false;
            }
        }
        public static bool isDollar
        {
            get
            {
                Thread.Sleep(1000);
                var expected = ActionsHelpers.SelectElementByCssSelector("span[class='amount-input']");

                if (expected.Text.Equals("$"))
                    return true;
                return false;
            }
        }
        public static bool isOk
        {
            get
            {
                Thread.Sleep(1000);
                var result1 = ActionsHelpers.SelectElementByCssSelector("#__next > div:nth-child(2) > div.fluid-container__BaseFluidContainer-qoidzu-0.gJBOzk > section > div:nth-child(2) > div > main > form > div.currency-converter__GridContainer-zieln1-1.jdUeRL > div.currency-converter__ErrorText-zieln1-2.dkXbBF");
                if (result1.Text.Contains("Please enter an amount greater than 0"))
                    return false;
                else
                    return true;
            }
        }
        public static bool isOkDec
        {
            get
            {
                Thread.Sleep(1000);
                var result1 = ActionsHelpers.SelectElementByCssSelector("#__next > div:nth-child(2) > div.fluid-container__BaseFluidContainer-qoidzu-0.gJBOzk > section > div:nth-child(2) > div > main > form > div.currency-converter__GridContainer-zieln1-1.jdUeRL > div.currency-converter__ErrorText-zieln1-2.dkXbBF");
                if (result1.Text.Equals(""))
                    return false;
                else
                    return true;
            }
        }
        public static bool Int
        {
            get
            {
                Thread.Sleep(1000);
                var convertbutton = ActionsHelpers.SelectElemenstByCssSelector("button[class='button__BaseButton-sc-1qpsalo-0 clGTKJ']", 2);

                if (convertbutton.Displayed)
                    return true;
                else
                    return false;
            }
        }

        public static bool IsValidNumber
        {
            get
            {
                Thread.Sleep(1000);
                var result1 = ActionsHelpers.SelectElementByCssSelector("#__next > div:nth-child(2) > div.fluid-container__BaseFluidContainer-qoidzu-0.gJBOzk > section > div:nth-child(2) > div > main > form > div.currency-converter__GridContainer-zieln1-1.jdUeRL > div.currency-converter__ErrorText-zieln1-2.dkXbBF");
                if (result1.Text.Equals("Please enter a valid amount"))
                    return false;
                else
                    return true;
            }
        }

        public static bool isDecimal
        {


            get
            {
                Thread.Sleep(1000);
                var result1 = ActionsHelpers.SelectElementByCssSelector("p[class='result__ConvertedText-sc-1bsijpp-0 gwvOOF']");



                if (result1.Text.Contains('9'))
                    return true;
                return false;
            }
        }

        public static bool WithParameters
        {
            get
            {
                Thread.Sleep(2000);
                var verify = ActionsHelpers.SelectElementByCssSelector("p[class='result__ConvertedText-sc-1bsijpp-0 gwvOOF']");
                if (verify.Text.Equals("10.00 US Dollars ="))
                    return true;
                else
                    return false;
            }

        }

        public static bool Results
        {
            get
            {
                Thread.Sleep(1000);
                var result1 = ActionsHelpers.SelectElementByCssSelector("p[class='result__BigRate-sc-1bsijpp-1 iGrAod']");

                var result = ActionsHelpers.SelectElemenstByCssSelector("div[class='unit-rates___StyledDiv-sc-1dk593y-0 dEqdnx']>p", 0);
                Thread.Sleep(2000);

                if (result.Text.Contains("1 USD = 0.96") && result1.Text.Contains("Euros"))
                    return true;
                else
                    return false;
            }
        }
        public static bool SingleUnit
        {
            get
            {
                Thread.Sleep(1000);
                var units = ActionsHelpers.SelectElementByCssSelector("div[class='unit-rates___StyledDiv-sc-1dk593y-0 dEqdnx']");
                //  var elementCount = Driver.Instance.FindElement(By.CssSelector("ul[id=projectsList]")).FindElements(By.TagName("li")).Count;
                var result = ActionsHelpers.SelectElemenstByCssSelector("div[class='unit-rates___StyledDiv-sc-1dk593y-0 dEqdnx']>p", 0);
                Thread.Sleep(2000);

                if (units.Text.Contains("1 USD") && units.Text.Contains("1 EUR"))
                    return true;
                else
                    return false;
            }
        }
    }
}

