using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace MobAutomation
{
    [TestClass]
    public class Demo5AndroidApp
    {
        [TestMethod]
        public void TouchActionMethodTest()
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

            TouchAction action = new TouchAction(driver);

            for (int i = 0; i < 1; i++)
            {
                IWebElement switchOption = driver.FindElementByXPath("//android.widget.TextView[@text='Sound effects']/following-sibling::android.widget.Switch");

                action.Tap(switchOption, count: 2).Perform();

                Thread.Sleep(1000);
            }

            driver.PressKeyCode(AndroidKeyCode.Home);


            IWebElement motoApp = driver.FindElementByXPath("//*[contains(@text,'Moto')]");
            action.LongPress(motoApp).Perform();

            driver.FindElementByXPath("//*[contains(@text,'App info')]").Click();

            driver.Quit();
        }

        [TestMethod]
        public void HybridAppTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("appActivity", "android.support.customtabs.trusted.LauncherActivity");
            option.AddAdditionalCapability("appPackage", "com.ltts.myts");
            option.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\muniswamyv\Downloads\Appium\chromedriver_win32\chromedriver.exe");
            //option.AddAdditionalCapability("noReset", true);
            //option.AddAdditionalCapability("unlockType", "password");
            //option.AddAdditionalCapability("unlockKey", "Vishnu@123");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Console.WriteLine("Current Context : " + driver.Context);

            IReadOnlyCollection<string> allViews = driver.Contexts;
            foreach (string view in allViews)
            {
                Console.WriteLine(view);

                //Check for if condition for list of webelements
                //perform the action and break
                driver.Context = view;
                if (driver.FindElementsByXPath("//*[@type='email']").Count > 0)
                {
                    break;
                }
            }

            driver.Context = "WEBVIEW_chrome";

            //Email
            driver.FindElementByXPath("//*[@type='email']").SendKeys("abc@gmail.com");

            //Next Button
            driver.FindElementByXPath("//*[@id='idSIButton9']").Click();

            //Password
            driver.FindElementByXPath("//*[@type='password']").SendKeys("abc@gmail.com");

            //Signin Button
            driver.FindElementByXPath("//*[@id='idSIButton9']").Click();

            driver.Quit();
        }

        [TestMethod]
        public void AppiumInbuiltMethodsTest()
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

            //Video Recording
            driver.StartRecordingScreen();

            driver.FindElementByXPath("//android.widget.ImageView[@content-desc='Settings']").Click();
            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();
            driver.FindElementByXPath("//android.widget.TextView[@text='Sign in']").Click();
            driver.FindElementByXPath("//android.widget.EditText[@content-desc='Enter an e-mail address or username']").SendKeys("abc@gmail.com");
            driver.FindElementByXPath("//android.widget.EditText[@text='Password']").SendKeys("Test12345");

            //Stop Recording
            string output = driver.StopRecordingScreen();

            //Save the Recording to File
            File.WriteAllBytes("C:\\Auto\\khan.mp4", Convert.FromBase64String(output));

            if(driver.IsAppInstalled("Package name"))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                driver.InstallApp(".apk");
            }

            Console.WriteLine(driver.DeviceTime);
            Console.WriteLine(driver.Capabilities);
            Console.WriteLine(driver.CurrentActivity);
            Console.WriteLine(driver.CurrentPackage);

            driver.BackgroundApp(TimeSpan.FromSeconds(3));



            driver.Quit();

        }

        [TestMethod]
        public void AndroidUICommandsTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("browserName", "Chrome");
            option.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\muniswamyv\Downloads\Appium\chromedriver_win32\chromedriver.exe");
            //option.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");
            //option.AddAdditionalCapability("appPackage", "org.khanacademy.android");
            //option.AddAdditionalCapability("noReset", true);

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string deeplink = "https://app.cred.club/spQx/9c72f56a";

            driver.Url = deeplink;
            Console.WriteLine(driver.PageSource);

            dynamic output = driver.ExecuteScript("mobile: batteryInfo");
            Console.WriteLine(output);

            Console.WriteLine(output["level"]);
            Console.WriteLine(output["state"]);

            output = driver.ExecuteScript("mobile: deviceInfo");
            Console.WriteLine(output);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("max", 2);
            dynamic text = driver.ExecuteScript("mobile: listSms", dic);
            Console.WriteLine(text);

            //Console.WriteLine(text["items"][0]["body"]);
            //Console.WriteLine(text["items"][1]["body"]);

            //foreach (var item in text["items"])
            //{
            //    Console.WriteLine(item["body"]);
            //}

            
            dic.Clear();
            dic.Add("url", deeplink);
            dic.Add("package", "com.westpharma.uxframework.dev");

            driver.ExecuteScript("mobile: deepLink", dic);

            driver.Quit();

        }
    }
}
