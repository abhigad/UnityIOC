using DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

namespace DIUnittest
{
    /// <summary>
    /// Unit test code
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private readonly UnityContainer container;
        private readonly Writer writer;
        private readonly ILogger filelogger;
        
        public UnitTest1()
        {
            filelogger = new FileLogger();

            container = new UnityContainer();
            container.RegisterType<ILogger, FileLogger>();
            container.RegisterType<Writer>();
            //call to constructor
            writer = container.Resolve<Writer>();
        }

        [TestMethod]
        public void TestFileLogger()
        {
            var response = true;
            Assert.AreEqual(response, filelogger.WriteLog("hello"));
        }

        [TestMethod]
        public void TestFileLoggerFail()
        {
            var response = false;
            Assert.AreEqual(response, filelogger.WriteLog(string.Empty));
        }

        [TestMethod]
        public void TestFileLoggerFailType()
        {
            var response = false;
            Assert.AreEqual(response, filelogger.WriteLog(""));
        }
        
        [TestMethod]
        public void TestFileLoggerviaUnity()
        {
            //call to the constructor
            var response = writer.Write("hello");
            Assert.AreEqual(response, true);
        }

        [TestMethod]
        public void TestFileLoggerviaUnityFail()
        {
            //call to the constructor
            var response = writer.Write("");
            Assert.AreEqual(response, false);
        }

        [TestMethod]
        public void TestFileLoggerviaUnityFailEmptyString()
        {
            var response = writer.Write(string.Empty);
            Assert.AreEqual(response, false);
        }

    }
}
