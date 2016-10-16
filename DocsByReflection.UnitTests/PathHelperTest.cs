using System;
using NUnit.Framework;
using System.Runtime.InteropServices;

namespace DocsByReflection.UnitTests
{
    [TestFixture]
    public class PathHelperTest
    {
        [Test]
        public void GetAssemblyDocFileNameFromCodeBase_NullOrEmpty_Exception()
        {
            var ex1 = Assert.Throws<ArgumentNullException>(() => PathHelper.GetAssemblyDocFileNameFromCodeBase(null));
            Assert.AreEqual("Value cannot be null.\r\nParameter name: assemblyCodeBase", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() => PathHelper.GetAssemblyDocFileNameFromCodeBase(""));
            Assert.AreEqual("Value cannot be null.\r\nParameter name: assemblyCodeBase", ex2.Message);
        }

        [Test]
        public void GetAssemblyDocFileNameFromCodeBase_DoesNotStartWithPrefix_Exception()
        {
            var ex1 = Assert.Throws<DocsByReflectionException>(() => PathHelper.GetAssemblyDocFileNameFromCodeBase("file://notExists"));
            Assert.AreEqual("Could not ascertain assembly filename from assembly code base 'file://notExists'.", ex1.Message);

            var ex2 = Assert.Throws<DocsByReflectionException>(() => PathHelper.GetAssemblyDocFileNameFromCodeBase("file://notExists"));
            Assert.AreEqual("Could not ascertain assembly filename from assembly code base 'file://notExists'.", ex2.Message);
        }

        [Test]
        public void GetAssemblyDocFileNameFromCodeBase_RightCodeBase_DocFileName()
        {
            var actual = PathHelper.GetAssemblyDocFileNameFromCodeBase("file:///Users/giacomelli/Dropbox/jogosdaqui/Plataforma/src/jogosdaqui.WebApi/Bin/jogosdaqui.WebApi.dll");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.AreEqual("Users/giacomelli/Dropbox/jogosdaqui/Plataforma/src/jogosdaqui.WebApi/Bin/jogosdaqui.WebApi.xml", actual);
            }
            else
            {
                Assert.AreEqual("/Users/giacomelli/Dropbox/jogosdaqui/Plataforma/src/jogosdaqui.WebApi/Bin/jogosdaqui.WebApi.xml", actual);                
            }
        }
    }
}

