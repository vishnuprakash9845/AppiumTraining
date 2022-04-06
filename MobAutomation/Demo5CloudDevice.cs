using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MobAutomation
{
    [TestClass]
    public class Demo5CloudDevice
    {

        [TestMethod]
        public void HybridAppTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions caps = new AppiumOptions();

            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", "vishnuprakashmun_qbOvJP");
            caps.AddAdditionalCapability("browserstack.key", "PQaiEzmBB6f597myFPU1");

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "bs://bb53b738faa4250f18185702bfda5957267f16fb");

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "Samsung Galaxy S10e");
            caps.AddAdditionalCapability("os_version", "9.0");

            // Specify the platform name
            caps.PlatformName = "Android";

            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "Khan Academy project");
            caps.AddAdditionalCapability("build", "Khan Academy Build");
            caps.AddAdditionalCapability("name", "Khan Sign in Test");


            // Initialize the remote Webdriver using BrowserStack remote URL
            // and desired capabilities defined above
            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if (driver.FindElementsByXPath("//android.widget.TextView[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//android.widget.TextView[@text='Dismiss']").Click();
            }

            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();

            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();

            driver.FindElementByXPath("//android.widget.EditText[@content-desc='Enter an e-mail address or username']").SendKeys("abc@gmail.com");

            driver.FindElementByXPath("//android.widget.EditText[@text='Password']").SendKeys("Test12345");

            driver.FindElementByXPath("//android.widget.Button[@content-desc='Sign in']").Click();

            string text = driver.FindElementByXPath("//*[contains(@text,'issue')]").Text;
            Console.WriteLine("Issue Text : " + text);

            driver.Quit();
        }

        [TestMethod]
        public void SampleAndroidAppTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions caps = new AppiumOptions();

            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", "vishnuprakashmun_qbOvJP");
            caps.AddAdditionalCapability("browserstack.key", "PQaiEzmBB6f597myFPU1");

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "bs://c700ce60cf13ae8ed97705a55b8e022f13c5827c");

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "Samsung Galaxy S10e");
            caps.AddAdditionalCapability("os_version", "9.0");

            // Specify the platform name
            caps.PlatformName = "Android";

            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "Sample Project");
            caps.AddAdditionalCapability("build", "Sample Project Build");
            caps.AddAdditionalCapability("name", "Sample Project Test");


            // Initialize the remote Webdriver using BrowserStack remote URL
            // and desired capabilities defined above
            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Console.WriteLine("Issue Text : " + driver.PageSource);

            driver.Quit();
        }

        [TestMethod]
        public void SampleIOSAppTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions caps = new AppiumOptions();

            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", "vishnuprakashmun_qbOvJP");
            caps.AddAdditionalCapability("browserstack.key", "PQaiEzmBB6f597myFPU1");

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "bs://444bd0308813ae0dc236f8cd461c02d3afa7901d");

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "iPhone 11 Pro");
            caps.AddAdditionalCapability("os_version", "13");


            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "Sample IOS Project");
            caps.AddAdditionalCapability("build", "Sample IOS Project Build");
            caps.AddAdditionalCapability("name", "Sample IOS Project Test");


            // Initialise the remote Webdriver using BrowserStack remote URL
            // and desired capabilities defined above
            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(
                new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Console.WriteLine("Issue Text : " + driver.PageSource);

            driver.FindElementByXPath("//XCUIElementTypeStaticText[@name='Text']").Click();

            driver.FindElementByXPath("//XCUIElementTypeTextField[@name=\"Text Input\"]").SendKeys("Test IOS");

            driver.FindElementByXPath("(//XCUIElementTypeButton[@name=\"UI Elements\"])[1]").Click();

            driver.FindElementByXPath("//XCUIElementTypeStaticText[@name='Alert']").Click();

            driver.FindElementByXPath("//XCUIElementTypeButton[@name='OK']").Click();


            driver.Quit();
        }
    }
}
