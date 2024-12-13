using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace Automation.PageObjects
{
    // Define the elements

    public class BasePage
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //waitForPageLoad();

        }
        // Dynamic method to get the locator for All Parking Fees based on text
        private IWebElement GetDynamicLinkByText(string linkText)
        {
            // Create the XPath dynamically based on the provided link text
            var dynamicLocator = By.XPath($"//span[@class='nav-link-text ng-binding' and text()='{linkText}']");
            return WaitForElementToBeClickable(dynamicLocator); // Wait for the element to be clickable
        }
        private IWebElement GetDynamicTabByText(string linkText)
        {
            // Create the XPath dynamically based on the provided link text
            var dynamicLocator = By.XPath($"//button[contains(@class, 'nav-link ng-binding') and contains(text(), '{linkText}')]");
            return WaitForElementToBeClickable(dynamicLocator); // Wait for the element to be clickable
        }

        // Click on a link with a dynamic text
        public void ClickOnDynamicLink(string linkText)
        {
            var dynamicLink = GetDynamicLinkByText(linkText);
            dynamicLink.Click();
        }
        // Click on a tab with a dynamic text
        public void ClickOnDynamicTab(string linkText)
        {
            var dynamicLink = GetDynamicTabByText(linkText);
            dynamicLink.Click();
        }
        // Helper method to wait for an element to be clickable
        public IWebElement WaitForElementToBeClickable(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader-container-overlay")));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public IWebElement GetButtonByOrder(int order)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader-container-overlay")));
            var dynamicLocator = By.XPath($"(//button[contains(@class, 'nav-link')])[{order}]");
            return WaitForElementToBeClickable(dynamicLocator); // Wait for the element to be clickable
        }
    }
    
}
