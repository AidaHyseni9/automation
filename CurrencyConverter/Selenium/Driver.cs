using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
namespace CurrencyConverter.Selenium
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new ChromeDriver(System.Configuration.ConfigurationManager.AppSettings["WebDriverPath"].ToString());
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


    }
}
