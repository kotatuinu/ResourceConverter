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
            Assert.IsTrue(result.Item1 == new PartsInfo.RESULT_LIST());
        }

        [TestMethod()]
        public void ConvertTest_CAPTION()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"CAPTION ""バージョン情報 WindowsProject1""");
            var ans = new PartsInfo.RESULT_LIST(
                    PartsInfo.PARTSKIND.FORMCAPTION,
                        new Dictionary<string, List<string>> {
                            { "1",
                                new List<string> {
                                    "CAPTION", }},
                            { "2",
                                new List<string> {
                                    "バージョン情報 WindowsProject1", } }
                        });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_STYLE()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"STYLE DS_SETFONT | DS_MODALFRAME | DS_FIXEDSYS | WS_POPUP | WS_CAPTION | WS_SYSMENU");
            var ans = new PartsInfo.RESULT_LIST(
                    PartsInfo.PARTSKIND.FORMSTYLE,
                       new Dictionary<string, List<string>>{
                           { "1",
                            new List<string>{"STYLE"} },
                           { "param1",
                            new List<string>{
                                "DS_SETFONT",
                                "DS_MODALFRAME",
                                "DS_FIXEDSYS",
                                "WS_POPUP",
                                "WS_CAPTION",
                                "WS_SYSMENU",} },
                    } );
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_FONT()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"FONT 9, ""MS UI Gothic"", 0, 0, 0x1");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.FORMFONT,
                            new Dictionary<string, List<string>> {
                                { "1",
                                new List<string>{"FONT",} },
                                { "2",
                                new List<string>{"9",} },
                                { "3",
                                new List<string>{ "MS UI Gothic",} },
                                { "4",
                                new List<string>{ "0",} },
                                { "5",
                                new List<string>{ "0",} },
                                { "6",
                                new List<string>{ "0x1",} },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORM);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_BEGIN()
        {
            var info = new PartsInfoFormParams();

            var result = info.Convert(@"BEGIN");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.FORMBEGIN,
                            new Dictionary<string, List<string>>{
                                { "1",
                                new List<string>{ "BEGIN", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }
    }
}