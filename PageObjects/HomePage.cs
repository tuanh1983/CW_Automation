using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.PageObjects
{
    public class HomePage : BasePage
    {
        // Define the elements
        private readonly By parkingFeesLocator = By.CssSelector("[class='nav-link-text ng-binding']");
        private readonly By allParkingFeesLocator = By.XPath("//span[@class='nav-link-text ng-binding' and text()='Alle afgifter']");
        private readonly By parkingFeesList = By.CssSelector(".ui-grid-canvas .ui-grid-row .ui-grid-cell a.ng-binding");
        // Property for Parking Fees (with wait logic inside the property getter)
        private IWebElement lnkParkingFees => WaitForElementToBeClickable(parkingFeesLocator);

        // Property for All Parking Fees (with wait logic inside the property getter)
        private IWebElement lnkAllParkingFees => WaitForElementToBeClickable(allParkingFeesLocator);

        private IWebElement lnkFirstParkingFeeRow => WaitForElementToBeClickable(parkingFeesList);

        // Constructor of HomePage class
        public HomePage(IWebDriver driver) : base(driver)
        {
            // No need for a separate wait here, as waiting logic is already in the property getters
        }

        // Click on Parking Fees link
        public void ClickOnParkingFees()
        {
            lnkParkingFees.Click();
        }
        public bool VerifyPageLoadSccessfully()
        {
            try
            {
                // Wait for the element to be visible (or you can adjust the wait condition as needed)
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(parkingFeesLocator));

                // Return true if the element is found, indicating the page has loaded
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                // Return false if the element is not found within the timeout period
                return false;
            }
        }
        public bool VerifyParkingFeesListLoadSccessfully()
        {
            try
            {
                // Wait for the element to be visible (or you can adjust the wait condition as needed)
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(parkingFeesList));

                // Return true if the element is found, indicating the page has loaded
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                // Return false if the element is not found within the timeout period
                return false;
            }
        }
        // Click on All Parking Fees link
        public ParkingFeePage ClickOnFirstParkingFeeRow()
        {
            lnkFirstParkingFeeRow.Click();  // Click on the first parking fee row
            return new ParkingFeePage(driver);  // Return the new page object (ParkingFreePage)
        }
    }
}
