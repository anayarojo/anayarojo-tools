using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.Log
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void GetConfiguration()
        {
            // Assert
            Assert.AreNotEqual(Logs.Log.Configuration, null);
        }
    }
}
