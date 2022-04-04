using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MobAutomation
{
    [TestClass]
    public class NativeAppTest
    {

        [TestMethod]
        public void HDFCLoginSimulateInMobileTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.EnableMobileEmulation("Nexus 5");

            ChromeDriver driver = new ChromeDriver(@"C:\Users\muniswamyv\Downloads\chromedriver", options);

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

            driver.FindElementByXPath("//a[contains(@class,'login-btn') and contains(text(),'LOGIN')]").Click();
            Thread.Sleep(500);

            string alertMessage = driver.SwitchTo().Alert().Text;

            driver.SwitchTo().Alert().Accept();

            Console.WriteLine($"Alert Text is : {alertMessage}");
            Thread.Sleep(500);



            Thread.Sleep(5000);
            driver.Quit();
        }

        [TestMethod]
        public void OpenAppTest()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");
            option.AddAdditionalCapability("appPackage", "org.khanacademy.android");
            option.AddAdditionalCapability("noReset", true);

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if(driver.FindElementsByXPath("//android.widget.TextView[@text='Dismiss']").Count>0)
            {
                driver.FindElementByXPath("//android.widget.TextView[@text='Dismiss']").Click();
            }

            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();

        }


        [TestMethod]
        public void KhanInvalidCredentialTest()
        {
            Console.WriteLine("Native App Automation");

            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string appPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\\MobAutomation\\App\\Demo.apk"));

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            //option.AddAdditionalCapability("app", appPath);
            option.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");
            option.AddAdditionalCapability("appPackage", "org.khanacademy.android");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //*[@text='']
            //*[@content-desc='']
            //*[@resource-id='']

            driver.FindElementByXPath("//android.widget.TextView[@text='Dismiss']").Click();

            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();

            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();

            driver.FindElementByXPath("//android.widget.EditText[@content-desc='Enter an e-mail address or username']").SendKeys("abc@gmail.com");

            driver.FindElementByXPath("//android.widget.EditText[@text='Password']").SendKeys("Test12345");

            driver.FindElementByXPath("//android.widget.Button[@content-desc='Sign in']").Click();

            string text = driver.FindElementByXPath("//*[contains(@text,'issue')]").Text;

            driver.Quit();
        }

        [TestMethod]
        public void KhanSignUpWithUISelectorTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");
            option.AddAdditionalCapability("appPackage", "org.khanacademy.android");
            option.AddAdditionalCapability("noReset", true);

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Settings
            driver.FindElementByXPath("//android.widget.ImageView[@content-desc='Settings']").Click();

            //Sign In
            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();

            //Sign up with Email
            driver.FindElementByXPath("//android.widget.TextView[@text='Sign up with email']").Click();

            //UI Selector
            //.textContains -- Give part of text not full text
            driver.FindElementByAndroidUIAutomator("UiSelector().text(\"First name\")").SendKeys("Test UI Selector");

            driver.FindElementByAndroidUIAutomator("UiSelector().descriptionContains(\"Last name\")").SendKeys("Prakash");

            driver.FindElementByAndroidUIAutomator("UiSelector().description(\"Email address\")").SendKeys("abc@gmail.com");

            driver.FindElementByAndroidUIAutomator("UiSelector().description(\"Password\")").SendKeys("Password");

            // 2-aug-1999
            driver.FindElementByXPath("//android.widget.TextView[@text='Birthday']").Click();
            //UiSelector().resourceId(\"android:id/numberpicker_input\").instance(0)
            driver.FindElementByAndroidUIAutomator("UiSelector().resourceId(\"android:id/numberpicker_input\").instance(0)").Click();
            driver.FindElementByAndroidUIAutomator("UiSelector().resourceId(\"android:id/numberpicker_input\").instance(0)").Clear();
            driver.FindElementByAndroidUIAutomator("UiSelector().resourceId(\"android:id/numberpicker_input\").instance(0)").SendKeys("Aug");
            //driver.FindElementByXPath("//*[@resource-id='android:id/numberpicker_input']").Click();
            //driver.FindElementByXPath("//*[@resource-id='android:id/numberpicker_input']").Clear();
            //driver.FindElementByXPath("//*[@resource-id='android:id/numberpicker_input']").SendKeys("Aug");

            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[2]").Click();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[2]").Clear();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[2]").SendKeys("02");
            //driver.FindElementByXPath("//*[@text='OK']").Click();

            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Click();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Clear();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").SendKeys("1999");
            driver.FindElementByXPath("//*[@text='OK']").Click();

            driver.FindElementByXPath("//android.widget.TextView[@text='CREATE']").Click();

            driver.Quit();
        }
    }
}
