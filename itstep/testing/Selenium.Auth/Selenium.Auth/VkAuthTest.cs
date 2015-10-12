using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Selenium.Auth
{
    [TestClass]
    public class VkAuthTest
    {
        [TestMethod]
        public void ShouldOpenPage()
        {
            // act
            var page = new VkPageObjectModel(new ChromeDriver());
            // arrange
            page.OpenPage();
        }

        [TestMethod]
        public void ShouldLoginAndRedirectToNews()
        {
            // act
            var page = new VkPageObjectModel(new ChromeDriver());
            // arrange
            page.OpenPage();
            page.EnterLogin("ermail@ukr.net");
            page.EnterPassword("fenrir");
            page.Enter();
            // assert
            Assert.AreEqual("http://vk.com/feed", page.CurrentUrl);
        }
    }
}
