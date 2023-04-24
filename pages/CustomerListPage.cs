using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumWD_OP
{
    internal class CustomerListPage : Page
    {
        public CustomerListPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal CustomerListPage Open()
        {
            driver.Url = "http://localhost/litecart/admin/?app=customers&doc=customers";
            return this;
        }

        [FindsBy(How = How.CssSelector, Using = "table.dataTable tr.row")]
        IList<IWebElement> customerRows;

        internal ISet<string> GetCustomerIds()
        {
            return new HashSet<string>(
                customerRows.Select(e => e.FindElements(By.TagName("td"))[2].Text).ToList());
        }
    }
}