using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceConverter.Tests
{
    [TestClass()]
    public class PartsInfoFormParamsTests
    {
        [TestMethod()]
        public void ConvertTest_空行()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert("");
            Assert.IsTrue(result.Item1.Count == 0);
        }

        [TestMethod()]
        public void ConvertTest_CAPTION()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"CAPTION ""バージョン情報 WindowsProject1""");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "CAPTION",
                "バージョン情報 WindowsProject1",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_STYLE()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"STYLE DS_SETFONT | DS_MODALFRAME | DS_FIXEDSYS | WS_POPUP | WS_CAPTION | WS_SYSMENU");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "STYLE",
                "DS_SETFONT",
                "DS_MODALFRAME",
                "DS_FIXEDSYS",
                "WS_POPUP",
                "WS_CAPTION",
                "WS_SYSMENU",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_FONT()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"FONT 9, ""MS UI Gothic"", 0, 0, 0x1");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "FONT",
                "9",
                "MS UI Gothic",
                "0",
                "0",
                "0x1",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_BEGIN()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"BEGIN");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "BEGIN",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }
    }
}