using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace MobAutomation
{
    [TestClass]
    public class AndroidAutomation
    {
        [TestMethod]
        public void InstallAppTest()
        {
            Console.WriteLine("Native App Automation");

            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string appPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\\MobAutomation\\App\\Demo.apk"));

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName","android");
            option.AddAdditionalCapability("deviceName", "mototrola one");//mototrola one
            option.AddAdditionalCapability("app", appPath);

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);

            Console.WriteLine(driver.PageSource);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [TestMethod]
        public void WebAppTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");//mototrola one
            option.AddAdditionalCapability("browserName", "Chrome");
            option.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\muniswamyv\Downloads\Appium\chromedriver_win32\chromedriver.exe");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://nasscom.in/about-us/contact-us";
            Console.WriteLine(driver.PageSource);



            driver.FindElementByXPath("//a[contains(.,'New User')]").Click();
            Thread.Sleep(500);

            driver.FindElementByXPath("//input[contains(@id,'-fname-reg')]").SendKeys("Vishnu");
            Thread.Sleep(500);

            driver.FindElementByXPath("//input[contains(@id,'-field-lname')]").SendKeys("Prakash");
            Thread.Sleep(500);

            driver.FindElementByXPath("//input[@id='edit-mail']").SendKeys("vishnuprakash.muniswamy@westpharma.com");
            Thread.Sleep(500);

            driver.FindElementByXPath("//input[@id='edit-field-company-name-registration']").SendKeys("EAST-WEST");
            Thread.Sleep(500);

            SelectElement se = new SelectElement(driver.FindElementByXPath("//select[@id='edit-field-business-focus-reg']"));
            se.SelectByValue("47");

            Console.WriteLine(driver.Url);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [TestMethod]
        public void HDFCAssignmentTest()
        {
            Console.WriteLine("Web App Automation");

            DriverOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");//mototrola one
            option.AddAdditionalCapability("browserName", "Chrome");
            option.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\muniswamyv\Downloads\Appium\chromedriver_win32\chromedriver.exe");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://netbanking.hdfcbank.com/netbanking/";

            IWebElement iFrameElement = driver.FindElementByXPath("//frame[@name='login_page']");
            driver.SwitchTo().Frame(iFrameElement);

            driver.FindElementByXPath("//input[@name='fldLoginUserId']").SendKeys("123");
            Thread.Sleep(500);

            driver.FindElementByXPath("//a[contains(@class,'login-btn') and text()='CONTINUE']").Click();
            Thread.Sleep(500);

            //driver.SwitchTo().DefaultContent();

            driver.FindElementByXPath("//input[@id='fldPasswordDispId']").SendKeys("123");
            Thread.Sleep(500);

            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }

            driver.FindElementByXPath("//a[contains(@class,'login-btn') and contains(text(),'LOGIN')]").Click();
            Thread.Sleep(500);

            string alertMessage = driver.SwitchTo().Alert().Text;

            driver.SwitchTo().Alert().Accept();

            Console.WriteLine($"Alert Text is : {alertMessage}");
            Thread.Sleep(500);

           

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
