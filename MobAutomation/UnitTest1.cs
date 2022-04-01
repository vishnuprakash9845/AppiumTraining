using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.IO;
using System.Reflection;

namespace MobAutomation
{
    [TestClass]
    public class AndroidAutomation
    {
        [TestMethod]
        public void InstallAppTest()
        {
            Console.WriteLine("Testing");

            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string appPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\\MobAutomation\\App\\Demo.apk"));

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName","android");
            option.AddAdditionalCapability("deviceName", "mototrola one");//mototrola one
            option.AddAdditionalCapability("app", appPath);

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);

        }
    }
}
