using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.Logger;
using Testing.Logger.Fakes;

namespace Testing.Stub
{
    [TestClass]
    public class TestLogSaver
    {
        [TestMethod]
        public void TakeLoggerAndPath_ShouldSaveLogInFile_Test()
        {
            // Arrange:
            ILogger logger = new StubILogger()
                                 {
                                     SaveString = (path) =>
                                     {
                                         using (FileStream writer = File.Create(path))
                                         {
                                         }
                                     }
                                 };
            // Act:
            var logSaver = new LogSaver();
            var filename = @"D:\test.txt";

            logSaver.WriteLog(logger, filename);
            // Assert:
            Assert.AreEqual(true, File.Exists(filename));
        }
    }
}
