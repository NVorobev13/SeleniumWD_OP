using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumWD_OP.pages
{
    internal class InceptionPage : Page
    {
        public InceptionPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal void OpenPage()
        {
            driver.Url = "http://localhost/litecart/";
        }

        [FindsBy(How = How.Name, Using = "open_cart_duck")]
        internal IWebElement OpenDuck;

        [FindsBy(How = How.Name, Using = "added_duck_to_busket")]
        internal IWebElement DuckInBusketAdd;

        [FindsBy(How = How.Name, Using = "open_busket")]
        internal IWebElement BusketToGo;

        [FindsBy(How = How.Name, Using = "delete_duck_in_busket")]
        internal IWebElement DuckInBusketDelete;

        [FindsBy(How = How.Name, Using = "counting_duck")]
        internal IWebElement DuckCounting;

        [FindsBy(How = How.Name, Using = "counting_duck_in_busket")]
        internal IWebElement DuckInBusketCounting;

    }
}
