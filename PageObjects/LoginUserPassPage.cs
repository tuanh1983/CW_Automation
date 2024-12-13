using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.PageObjects
{
    public class LoginUserPassPage
    {
        private IWebDriver driver;

        // Constructor to initialize the driver and elements
        public LoginUserPassPage(IWebDriver driver)
        {
            this.driver = driver;
            // Manually initialize the elements (no more PageFactory.InitElements)
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("form-username")));  // Example wait for element

            // Initialize the elements manually (with FindElement)
            TxtUsername = driver.FindElement(By.Id("form-username"));
            TxtPassword = driver.FindElement(By.Id("form-password"));
            BtnSubmit = driver.FindElement(By.CssSelector("button[type='submit']"));
        }

        // Define the elements
        private IWebElement TxtUsername;
        private IWebElement TxtPassword;
        private IWebElement BtnSubmit;        
        // Example method to interact with elements
        public HomePage Login(string user, string pass)
        {
            TxtUsername.SendKeys(user);
            TxtPassword.SendKeys(pass);
            BtnSubmit.Click();
            return new HomePage(driver);
        }
    }
}