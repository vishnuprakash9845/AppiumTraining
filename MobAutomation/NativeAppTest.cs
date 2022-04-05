using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Click();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").Clear();
            driver.FindElementByXPath("(//*[@resource-id='android:id/numberpicker_input'])[3]").SendKeys("1999");
            driver.FindElementByXPath("//*[@text='OK']").Click();

            driver.FindElementByXPath("//android.widget.TextView[@text='CREATE']").Click();

            driver.Quit();
        }

        [TestMethod]
        public void KhanSwipeTest()
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

            //Search
            driver.FindElementById("org.khanacademy.android:id/tab_bar_button_search").Click();

            //Option Arts and humanities
            //driver.FindElementByXPath("//android.widget.TextView[@text='Arts and humanities']").Click();
            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Arts and humanities\")").Click();

            //Scroll-1
            //ScrollToElementAndClick(driver, "Art of Asia");
            //ScrollToElementByPercentageAndClick(driver, "Art of Asia");
            ScrollToElementByUISelectorAndClick(driver, "Art of Asia");

            //Scroll-2
            //ScrollToElementAndClick(driver, "Himalayas");
            //ScrollToElementByPercentageAndClick(driver, "Himalayas");
            ScrollToElementByUISelectorAndClick(driver, "Himalayas");

            //Scroll-3 : Click on Cabinet for strong offering
            //ScrollToElementAndClick(driver, "Cabinet for storing offerings");
            //ScrollToElementByPercentageAndClick(driver, "Cabinet for storing offerings");
            ScrollToElementByUISelectorAndClick(driver, "Cabinet for storing offerings");



            driver.Quit();
        }

        [TestMethod]
        public void KhanSwipeCommandsTest()
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

            //Search
            driver.FindElementById("org.khanacademy.android:id/tab_bar_button_search").Click();

            //Option Arts and humanities
            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Arts and humanities\")").Click();

            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //dic.Add("strategy", "-android uiautomator");
            //dic.Add("selector", "UiSelector().textContains(\"Asia\")");
            //driver.ExecuteScript("mobile: scroll", dic);

            //Not working
            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //dic.Add("strategy", "xpath");
            //dic.Add("selector", By.XPath("//*[contains(@text,'Asia')]"));
            //driver.ExecuteScript("mobile: scroll", dic);

            ScrollToElementByMobileCommandsAndClick(driver,"Asia");

            ScrollToElementByMobileCommandsAndClick(driver, "Himalayas");

            ScrollToElementByMobileCommandsAndClick(driver, "Cabinet for storing offerings");

            driver.Quit();
        }

        [TestMethod]
        public void listSMSTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");
            option.AddAdditionalCapability("appPackage", "org.khanacademy.android");
            option.AddAdditionalCapability("noReset", true);
            option.AddAdditionalCapability("unlockType", "password");
            option.AddAdditionalCapability("unlockKey", "Vishnu@123");


            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("max", 2);
            object text = driver.ExecuteScript("mobile: listSms", dic);
            Console.WriteLine(text);
            string sms = Convert.ToString(text);
            Console.WriteLine(sms);
            
            driver.Quit();
        }

        [TestMethod]
        public void MobileShellCommandsTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("appActivity", "org.khanacademy.android.ui.library.MainActivity");
            option.AddAdditionalCapability("appPackage", "org.khanacademy.android");
            option.AddAdditionalCapability("noReset", true);
            option.AddAdditionalCapability("unlockType", "password");
            option.AddAdditionalCapability("unlockKey", "Vishnu@123");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Search
            driver.FindElementById("org.khanacademy.android:id/tab_bar_button_search").Click();

            //Option Arts and humanities
            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Arts and humanities\")").Click();

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("command", "input touchscreen swipe 349 1015 349 400");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByAndroidUIAutomator($"UiSelector().textContains(\"Art of Asia\")").Count == 0)
            {
                driver.ExecuteScript("mobile: shell",dic);
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElementByAndroidUIAutomator($"UiSelector().textContains(\"Art of Asia\")").Click();

            driver.Quit();
        }

        [TestMethod]
        public void CarsAppTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("appActivity", "com.cuvora.carinfo.splash.SplashScreenActivity");
            option.AddAdditionalCapability("appPackage", "com.cuvora.carinfo");
            option.AddAdditionalCapability("noReset", true);
            option.AddAdditionalCapability("unlockType", "password");
            option.AddAdditionalCapability("unlockKey", "Vishnu@123");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IReadOnlyCollection<IWebElement> options = driver.FindElementsByXPath("//android.widget.LinearLayout[@resource-id='com.cuvora.carinfo:id/linearLayout']/android.widget.ImageView");

            foreach (IWebElement item in options)
            {
                item.Click();
            }

            driver.Quit();
        }

        [TestMethod]
        public void MedPlusAppTest()
        {
            Console.WriteLine("Native App Automation");

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "mototrola one");
            option.AddAdditionalCapability("appActivity", "com.medplus.mobile.android.MainActivity");
            option.AddAdditionalCapability("appPackage", "com.medplus.mobile.android");
            option.AddAdditionalCapability("noReset", true);
            option.AddAdditionalCapability("unlockType", "password");
            option.AddAdditionalCapability("unlockKey", "Vishnu@123");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ScrollToElementByPercentageAndClick(driver, "Flexi Rewards");

            //Filter
            driver.FindElementByXPath("//android.widget.Button[contains(@text,'Sort & Filter')]").Click();

            TouchAction action = new TouchAction(driver);
            action.Tap(230, 970).Perform();

            action.Tap(644, 563).Perform();

            //Add To Cart
            driver.FindElementByXPath("//android.widget.Button[contains(@text,'Add to Cart')]").Click();


            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Mobile Number\")").Click();
            driver.FindElementByAndroidUIAutomator("UiSelector().textContains(\"Mobile Number\")").SendKeys("8687686800");

            //driver.FindElementByXPath("//android.widget.EditText[contains(@text,'Mobile Number')]").Click();
            //driver.FindElementByXPath("//android.widget.EditText[contains(@text,'Mobile Number')]").SendKeys("8687686800");

            driver.Quit();
        }

        #region Generic Method

        public void ScrollToElementAndClick(AndroidDriver<IWebElement> driver, string fieldName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByAndroidUIAutomator($"UiSelector().textContains(\"{fieldName}\")").Count == 0)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(349, 1015).Wait(1000).MoveTo(349, 400).Release().Perform();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElementByAndroidUIAutomator($"UiSelector().textContains(\"{fieldName}\")").Click();
        }
        public void ScrollToElementByPercentageAndClick(AndroidDriver<IWebElement> driver, string fieldName)
        {
            Size size = driver.Manage().Window.Size;
            Console.WriteLine("Width : " + size.Width);
            Console.WriteLine("Height : " + size.Height);

            double startX = size.Width / 2.0;
            double startY = size.Height * 0.80;
            double endX = startX;
            double endY = size.Height * 0.20;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (driver.FindElementsByAndroidUIAutomator($"UiSelector().textContains(\"{fieldName}\")").Count == 0)
            {
                TouchAction action = new TouchAction(driver);
                action.Press(startX, startY).Wait(1000).MoveTo(endX, endY).Release().Perform();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElementByAndroidUIAutomator($"UiSelector().textContains(\"{fieldName}\")").Click();
        }
        public void ScrollToElementByUISelectorAndClick(AndroidDriver<IWebElement> driver, string fieldName)
        {
            driver.FindElementByAndroidUIAutomator(
                                        "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + fieldName + "\").instance(0))").Click();

            //driver.FindElementByAndroidUIAutomator(
            //                           "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + fieldName + "\").instance(0))");
        }

        public void ScrollToElementByMobileCommandsAndClick(AndroidDriver<IWebElement> driver, string fieldName)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("strategy", "-android uiautomator");
            dic.Add("selector", $"UiSelector().textContains(\"{fieldName}\")");
            driver.ExecuteScript("mobile: scroll", dic);

            driver.FindElementByAndroidUIAutomator($"UiSelector().textContains(\"{fieldName}\")").Click();
        }
        #endregion
    }
}
