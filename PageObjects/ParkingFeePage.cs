using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;

namespace Automation.PageObjects
{
    public class ParkingFeePage : BasePage
    {
        // Property for Parking Fees (with wait logic inside the property getter)
        const int orderOfComplaintsTab = 4;
        const int numberTotalComplaintsTab = 9;
        private readonly By allComplaints = By.CssSelector(".ui-grid-coluiGrid-00HY .ui-grid-cell-contents.tooltip-viewport-container a.ng-binding");
        private IWebElement lnkFristComplaint => WaitForElementToBeClickable(allComplaints);
        // Constructor of HomePage class
        public ParkingFeePage(IWebDriver driver) : base(driver)
        {
            // No need for a separate wait here, as waiting logic is already in the property getters
        }

        public void CliclOnComplaintsTab()
        {
            GetButtonByOrder(orderOfComplaintsTab).Click();
        }
        public ComplaintPage CliclOnFristComplaint()
        {
            //Thread.Sleep(2000);
            lnkFristComplaint.Click();
            return new ComplaintPage(driver);
        }
        public bool VerifyListComplaintsLoadSccessfully()
        {
            try
            {
                // Wait for the element to be visible (or you can adjust the wait condition as needed)
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(allComplaints));

                // Return true if the element is found, indicating the page has loaded
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                // Return false if the element is not found within the timeout period
                return false;
            }
        }
        public bool VerifyListTabLoadSccessfully()
        {
            var dynamicLocator = By.XPath($"(//button[contains(@class, 'nav-link')])[{numberTotalComplaintsTab}]");

            try
            {
                // Wait for the element to be visible (or you can adjust the wait condition as needed)
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(dynamicLocator));

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
