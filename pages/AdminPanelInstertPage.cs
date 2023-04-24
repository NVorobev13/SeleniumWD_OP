using OpenQA.Selenium;

namespace SeleniumWD_OP
{
    internal class AdminPanelInstertPage : Page
    {
        public AdminPanelInstertPage(IWebDriver driver) : base(driver) { }
        
        internal AdminPanelInstertPage Open()
        {
            driver.Url = "http://localhost/litecart/admin";
            return this;
        }

        internal bool IsOnThisPage()
        {
            return driver.FindElements(By.Id("box-login")).Count > 0;
        }
        internal AdminPanelInstertPage EnterUsername(string username)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            return this;
        }

        internal AdminPanelInstertPage EnterPassword(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
            return this;
        }

        internal void SubmitLogin()
        {
            driver.FindElement(By.Name("login")).Click();
            wait.Until(d => d.FindElement(By.Id("box-apps-menu")));
        }
    }
}