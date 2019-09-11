using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.

namespace RegisterParking
{
    class Program
    {
        static void Main(string[] args)
        {
            string propertyName = "Post West Austin";
            string aptNumber = "3113";
            string make = "Infiniti";
            string model = "Q50";
            string licensePlate = "GSK0984";

            // Open Register2Park
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.register2park.com/";

            // Click Register Vehicle
            driver.FindElement(By.XPath("//*[@id=\"form-body\"]/div[1]/div/a")).Click();

            // Send property name
            driver.FindElement(By.XPath("//*[@id=\"propertyName\"]")).SendKeys(propertyName);
            driver.FindElement(By.Id("confirmProperty")).Click();

            // Wait for modal-fade element to pass and click property 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("please-wait")));
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            wait2.Until(ExpectedConditions.ElementToBeClickable(By.Name("property")));
            driver.FindElement(By.Name("property")).Click();
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            wait3.Until(ExpectedConditions.ElementToBeClickable(By.Id("confirmPropertySelection")));
            driver.FindElement(By.Id("confirmPropertySelection")).Click();

            // Click Visitor Parking
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("please-wait")));
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            wait4.Until(ExpectedConditions.ElementToBeClickable(By.Id("registrationTypeVisitor")));
            driver.FindElement(By.Id("registrationTypeVisitor")).Click();

            // Fill out vehicle information form
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            wait5.Until(ExpectedConditions.ElementIsVisible(By.Id("vehicleApt")));
            driver.FindElement(By.Id("vehicleApt")).SendKeys(aptNumber);
            driver.FindElement(By.Id("vehicleMake")).SendKeys(make);
            driver.FindElement(By.Id("vehicleModel")).SendKeys(model);
            driver.FindElement(By.Id("vehicleLicensePlate")).SendKeys(licensePlate);
            driver.FindElement(By.Id("vehicleInformation")).Click();

        }
    }
}
