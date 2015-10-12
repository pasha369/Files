using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.Logger;

namespace Testing.Shim
{
    [TestClass]
    public class TestLogger
    {
        [TestMethod]
        public void ShouldReturnCurrentDate_Test()
        {
            // Arrange:
            var now = new System.DateTime(2015, 9, 20);

            using (ShimsContext.Create())
            {
                
                System.Fakes.ShimDateTime.NowGet = () => { return new System.DateTime(2015, 9, 20); };
                
                var logger = new TextLogger();
                // Act:
                DateTime date = logger.GetCurrentTime();
                // Assert:
                Assert.AreEqual(now, date);
            }
        }
    }
}
