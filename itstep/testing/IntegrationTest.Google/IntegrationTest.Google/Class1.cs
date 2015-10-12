using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTest.Google
{
    [TestFixture]
    public class GoogleTests
    {
        [Test]
        public void should_open_google_enter_string_and_check_first_link()
        {
            using (var driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                driver.Navigate().GoToUrl("http://google.ua");
                var element = driver.FindElement(By.Id("lst-ib"));

                element.SendKeys("Selenium");
                element.SendKeys(Keys.Enter);

                wait.Until(x => x.FindElement(By.LinkText("Selenium - Web Browser Automation")));

            }

        }
        [Test]
        public void should_login_and_send_mail()
        {
            using (var driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 120)  );

                driver.Navigate().GoToUrl("http://google.ua");
                // google popup
                var element = driver.FindElement(By.Id("gbwa"));
                element.Click();
                wait.Until(x => x.FindElement(By.Id("gb23")).Displayed);
                var elementMail = driver.FindElementById("gb23");
                elementMail.Click();

                wait.Until(x => x.FindElement(By.ClassName(@"google-js")).Displayed);
                // top left btn Gmail
                var elementSignIn = driver.FindElementById("gmail-sign-in");
                elementSignIn.Click();
                // load email
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
                var inputElementEmail = driver.FindElementById("Email");
                inputElementEmail.SendKeys("zhmakp@gmail.com");
                driver.FindElement(By.Id("next")).Click();
                // load password page
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Passwd")));
                var inputElementPass = driver.FindElementByXPath("//*[@id='Passwd']");
                // enter password
                char[] password = { '1','5','p','a','s','h','u','k'};
                for (int i = 0; i < password.Length; i++)
                {
                    driver.Keyboard.PressKey(password[i].ToString());
                }
                
                driver.FindElement(By.Id("signIn")).Click();
                // load gmail
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=':j2']/div/div")));
                driver.FindElement(By.XPath("//*[@id=':j2']/div/div")).Click();
                // load msg popup
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=':oc']")));
                var txtTo = driver.FindElement(By.XPath("//*[@id=':oc']"));
                var txtMsg = driver.FindElement(By.XPath("//*[@id=':oz']"));
                var btnSend = driver.FindElement(By.XPath("//*[@id=':nn']"));

                txtTo.SendKeys("zhmakp@gmail.com");
                txtMsg.SendKeys("test");
                btnSend.Click();
            }
        }
        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                using (var driver = new ChromeDriver())
                {
                    Screenshot screen = ((ITakesScreenshot) driver).GetScreenshot();
                    var date = DateTime.Now.ToString();
                    var filename = string.Format(@"D:\error{0}.jpg", date.Replace(':', '_'));
                    if (screen != null) 
                        screen.SaveAsFile(filename, ImageFormat.Jpeg);
                }
            }
        }
    }
}
