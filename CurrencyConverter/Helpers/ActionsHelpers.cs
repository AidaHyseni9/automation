using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading;
using CurrencyConverter.Selenium;

namespace CurrencyConverter.Helpers
{
    public class ActionsHelpers
    {


        public static IWebElement SelectElementById(string id)
        {
            return Driver.Instance.FindElement(By.Id(id));
        }

        public static IWebElement SelectElementByName(string name)
        {
            return Driver.Instance.FindElement(By.Name(name));
        }

        public static IWebElement SelectElementByCssSelector(string selector)
        {
            return Driver.Instance.FindElement(By.CssSelector(selector));
        }

        public static IWebElement SelectElemenstByCssSelector(string selector, int pos)
        {
            return Driver.Instance.FindElements(By.CssSelector(selector))[pos];
        }

        public static void ClickExpand(string selector, int pos)
        {
            var expand = Driver.Instance.FindElements(By.CssSelector(selector))[pos];
            expand.Click();
        }

        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }
        public static void GiveAmount(string keys)
        {
            var amount = ActionsHelpers.SelectElementByCssSelector("#amount");
            amount.Click();
            amount.SendKeys(keys);
        }
        public static void ChoseCurrency(string usd)
        {
            var currency = ActionsHelpers.SelectElementById("midmarketFromCurrency");
            currency.Click();
            currency.SendKeys(usd);
            currency.Click();

        }


        public static void ClearElement(IWebElement element)
        {
            element.Clear();
        }

        public static void MoveToOffset(IWebElement dropElement, int Xcord, int Ycord)
        {
            (new Actions(Driver.Instance)).DragAndDropToOffset(dropElement, Xcord, Ycord).Perform();
        }

        public static void ClickAndHoldElement(IWebElement dragElement, IWebElement dropElement)
        {
            (new Actions(Driver.Instance)).ClickAndHold(dragElement).MoveToElement(dropElement).DragAndDrop(dragElement, dropElement).Perform();
        }
    }
}
