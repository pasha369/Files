using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Auth
{
    public class VkPageObjectModel
    {
        private IWebDriver _driver { set; get; }

        public VkPageObjectModel(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(@"http://vk.com");
        }
        public void EnterLogin(string username)
        {
            Wait("quick_email");
            _driver.FindElement(By.Id("quick_email")).SendKeys(username); 
        }
        public void EnterPassword(string password)
        {

            Wait("quick_pass");
            _driver.FindElement(By.Id("quick_pass")).SendKeys(password); 
        }
        public void Enter()
        {
            var btnEnter = _driver.FindElement(By.Id("quick_login_button"));
            btnEnter.Click();
        }
        public string CurrentUrl
        {
            get { return _driver.Url; }
        }
        public void Wait(string Id)
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 120));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(Id)));
        }
    }
}
