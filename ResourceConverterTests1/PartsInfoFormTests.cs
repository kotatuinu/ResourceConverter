using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            Assert.IsTrue(result.Item1 == new PartsInfo.RESULT_LIST());
        }

        [TestMethod()]
        public void ConvertTest_DIALOG検出()
        {
            var info = new PartsInfoForm();

            var result = info.Convert("IDD_ABOUTBOX DIALOG 0, 0, 170, 62");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.FORM,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "IDD_ABOUTBOX", }},
                            {
                                "2",
                                new List<string>{ "DIALOG", }},
                            {
                                "size",
                                new List<string>{ "0", "0", "170", "62", }},
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_DIALOGEX検出()
        {
            var info = new PartsInfoForm();

            var result = info.Convert("IDD_ABOUTBOX DIALOGEX 0, 0, 170, 62");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.FORM,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "IDD_ABOUTBOX", } },
                            {
                                "2",
                                new List<string>{ "DIALOGEX", } },
                            {
                                "size",
                                new List<string>{ "0", "0", "170", "62", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1 == ans);
        }
    }
}