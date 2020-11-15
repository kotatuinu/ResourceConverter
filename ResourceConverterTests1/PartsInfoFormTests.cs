using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResourceConverter.Tests
{
    [TestClass()]
    public class PartsInfoFormTests
    {
        [TestMethod()]
        public void ConvertTest_空行()
        {
            PartsInfoForm info = new PartsInfoForm();

            var result = info.Convert("");
            Assert.IsTrue(result.Item1.Count == 0);
        }

        [TestMethod()]
        public void ConvertTest_DIALOG検出()
        {
            var info = new PartsInfoForm();

            var result = info.Convert("IDD_ABOUTBOX DIALOG 0, 0, 170, 62");
            Assert.IsTrue(result.Item1.Count == 6);
            Assert.IsTrue(result.Item1[0] == "IDD_ABOUTBOX");
            Assert.IsTrue(result.Item1[1] == "DIALOG");
            Assert.IsTrue(result.Item1[2] == "0");
            Assert.IsTrue(result.Item1[3] == "0");
            Assert.IsTrue(result.Item1[4] == "170");
            Assert.IsTrue(result.Item1[5] == "62");
        }

        [TestMethod()]
        public void ConvertTest_DIALOGEX検出()
        {
            var info = new PartsInfoForm();

            var result = info.Convert("IDD_ABOUTBOX DIALOGEX 0, 0, 170, 62");
            Assert.IsTrue(result.Item1.Count == 6);
            Assert.IsTrue(result.Item1[0] == "IDD_ABOUTBOX");
            Assert.IsTrue(result.Item1[1] == "DIALOGEX");
            Assert.IsTrue(result.Item1[2] == "0");
            Assert.IsTrue(result.Item1[3] == "0");
            Assert.IsTrue(result.Item1[4] == "170");
            Assert.IsTrue(result.Item1[5] == "62");
        }
    }
}