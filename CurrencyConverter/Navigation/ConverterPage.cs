using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CurrencyConverter.Helpers;
using CurrencyConverter.Selenium;

namespace CurrencyConverter.Navigation
{
    public class ConverterPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"].ToString());
        }

        public static bool IsAt
        {
            get
            {
                var page = ActionsHelpers.SelectElementById("__next");
                if (page.Displayed)
                    return true;
                else
                    return false;
            }

        }
        public static void Cockies()
        {
            ActionsHelpers.SelectElementByCssSelector("#__next > div.fluid-container__BaseFluidContainer-qoidzu-0.gHjEXY.ConsentBannerstyles__Banner-smyzu-1.dGQMCW > section > div:nth-child(4) > button.button__BaseButton-sc-1qpsalo-0.haqezJ").Click();

        }


    }
}
