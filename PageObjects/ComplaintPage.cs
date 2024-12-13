using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Automation.PageObjects
{
    public class ComplaintPage : BasePage
    {
        // Define the elements
        private readonly By complaintDateTime = By.CssSelector("input.form-control.main-input[placeholder='dd.MM.yyyy']");
        
        // Property for All Parking Fees (with wait logic inside the property getter)
        private IWebElement txtComplaintDateTime => WaitForElementToBeClickable(complaintDateTime);

        // Constructor of HomePage class
        public ComplaintPage(IWebDriver driver) : base(driver)
        {
            // No need for a separate wait here, as waiting logic is already in the property getters
        }

        public void SetValueOntxtComplaintDateTime(string value)
        {
            txtComplaintDateTime.SendKeys(value);
        }
        public string GetCssValueOfTxtComplaintDateTime(string value)
        {
            txtComplaintDateTime.Click();
            return txtComplaintDateTime.GetCssValue(value);
        }
        public bool VerifyComplaintsPageLoadSccessfully()
        {
            try
            {
                // Wait for the element to be visible (or you can adjust the wait condition as needed)
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(complaintDateTime));

                // Return true if the element is found, indicating the page has loaded
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                // Return false if the element is not found within the timeout period
                return false;
            }
        }
    }
}
