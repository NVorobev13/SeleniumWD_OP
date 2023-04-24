using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumWD_OP.model;
using SeleniumWD_OP.pages;

namespace SeleniumWD_OP
{
    public class Application
    {
        private IWebDriver driver;
        private WebDriverWait? wait;
        private InceptionPage inceptionPage;



        public Application()
        {
                driver = new ChromeDriver();
                inceptionPage = new InceptionPage(driver);
        }

        public void Quit()
        {
                driver.Quit();
        }

        internal void AddedNewDuck(Customer customer)
        {
            int DuckAdd = 0;
            inceptionPage.OpenPage();
            //цикл добавления в корзину
            for (int i = 0; i < 5; i++)
            {
                driver.FindElement(By.XPath($"//ul[@class='listing-wrapper products']/li[{i + 1}]/a[1]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("duck"));
                var DuckQuantity  = (int.Parse(driver.FindElement(By.XPath("//span[@class='quantity']")).GetAttribute("textContent")) + 1).ToString();
                try
                {
                    SelectElement ProductDuckSize = new(driver.FindElement(By.XPath(".//*[@id=\"box-product\"]/div[2]/div[2]/div[5]/form/table/tbody/tr[1]/td/select")));
                    ProductDuckSize.SelectByValue("Medium");
                }
                catch (NoSuchElementException) { }

                driver.FindElement(By.XPath(".//button[@name='add_cart_product']")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.XPath(".//span[@class='quantity']")), inceptionPage.DuckCounting.ToString()));
                DuckAdd++;
                inceptionPage.OpenPage();
            }
            //проваливаемся в корзину и дожидаемся загрузки всех элементов
            driver.FindElement(By.XPath(".//div[@id='cart']/a[@class='link']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("checkout"));
            IWebElement? element = null;

            //записываем в новую переменную количество текущего товара в корзине
            var ProductBasketCount = driver.FindElements(By.XPath(".//table[@class='dataTable rounded-corners']//td[@class='item']")).Count;

            //цикл удаления из корзины
            for (int j = 0; j < ProductBasketCount; j++)
            {
                var BasketOurItem = driver.FindElement(By.XPath(".//div[@style='display: inline-block;']//a")).GetAttribute("textContent");
                var BasketItems = driver.FindElements(By.XPath(".//table[@class='dataTable rounded-corners']//td[@class='item']"));

                foreach (var Item in BasketItems)
                {
                    if (Item.GetAttribute("textContent") == BasketOurItem) element = Item;
                }

                driver.FindElement(By.XPath(".//button[@value='Remove']")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(".//em")));
            inceptionPage.OpenPage();
        }
    }
}