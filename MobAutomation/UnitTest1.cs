using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
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

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
