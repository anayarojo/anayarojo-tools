using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.LogException
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void GetConfiguracionException()
        {
            // Assert
            Assert.AreNotEqual(Log.Configuration, null);
        }
    }
}
