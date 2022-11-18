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
    public class Currency
    {


        public static void Cockies()
        {
            ActionsHelpers.SelectElementByCssSelector("#__next > div.fluid-container__BaseFluidContainer-qoidzu-0.gHjEXY.ConsentBannerstyles__Banner-smyzu-1.dGQMCW > section > div:nth-child(4) > button.button__BaseButton-sc-1qpsalo-0.haqezJ").Click();
            ActionsHelpers.SelectElementById("__next");
        }
        public static void List() { }

        public static bool Source
        {
            get
            {
                Thread.Sleep(1000);
                var expected = ActionsHelpers.SelectElementById("midmarketFromCurrency-descriptiveText");

                if (expected.Text.Equals("USD – US Dollar") || expected.Text.Equals("EUR - Euro"))
                    return true;
                return false;
            }
        }
        public static bool Target
        {
            get
            {
                Thread.Sleep(1000);
                var expected = ActionsHelpers.SelectElementById("midmarketToCurrency-descriptiveText");

                if (expected.Text.Equals("USD – US Dollar") || expected.Text.Equals("EUR – Euro"))
                    return true;
                return false;
            }
        }
    }
}
