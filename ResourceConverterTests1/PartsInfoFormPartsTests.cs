using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ResourceConverter.Tests
{
    [TestClass()]
    public class PartsInfoFormPartsTests
    {
        [TestMethod()]
        public void ConvertTest_空行()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert("");
            Assert.IsTrue(result.Item1 == new PartsInfo.RESULT_LIST());
        }

        [TestMethod()]
        public void ConvertTest_PUSHBUTTON()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    PUSHBUTTON      ""キャンセル"",IDCANCEL,520,466,50,14");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.PUSHBUTTON,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "PUSHBUTTON", } },
                            {
                                "2",
                                new List<string>{ "キャンセル", } },
                            {
                                "3",
                                new List<string>{ "IDCANCEL", } },
                            {
                                "size",
                                new List<string>{ "520", "466", "50", "14", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_DEFPUSHBUTTON()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    DEFPUSHBUTTON   ""OK"",IDOK,198,466,50,14");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.PUSHBUTTON,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "DEFPUSHBUTTON", }},
                            {
                                "2",
                                new List<string>{ "OK", } },
                            {
                                "3",
                                new List<string>{ "IDOK", } },
                            {
                                "size",
                                new List<string>{ "198", "466", "50", "14", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_CONTROL_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CONTROL         ""Button1"",IDC_BUTTON2,""Button"",BS_OWNERDRAW | BS_LEFT | BS_TOP | WS_DISABLED | WS_GROUP,15,39,50,14,WS_EX_DLGMODALFRAME | WS_EX_ACCEPTFILES | WS_EX_TRANSPARENT | WS_EX_CLIENTEDGE | WS_EX_RIGHT | WS_EX_RTLREADING | WS_EX_STATICEDGE,HIDC_BUTTON2");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.CONTROL,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "CONTROL", } },
                            {
                                "2",
                                new List<string>{ "Button1", } },
                            {
                                "3",
                                new List<string>{ "IDC_BUTTON2", } },
                            {
                                "4",
                                new List<string>{ "Button", } },
                            {
                                "size",
                                new List<string>{ "15", "39", "50", "14", } },
                            {
                                "param1",
                                new List<string>{
                                    "BS_OWNERDRAW",
                                    "BS_LEFT",
                                    "BS_TOP",
                                    "WS_DISABLED",
                                    "WS_GROUP", } },
                            {
                                "param2",
                                new List<string>{
                                    "WS_EX_DLGMODALFRAME",
                                    "WS_EX_ACCEPTFILES",
                                    "WS_EX_TRANSPARENT",
                                    "WS_EX_CLIENTEDGE",
                                    "WS_EX_RIGHT",
                                    "WS_EX_RTLREADING",
                                    "WS_EX_STATICEDGE",} },
                            {
                                "param3",
                                new List<string>{ "HIDC_BUTTON2", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_CONTROL_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CONTROL         ""Button1"",IDC_BUTTON7,""Button"",BS_OWNERDRAW | WS_TABSTOP,16,138,50,14");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.CONTROL,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "CONTROL", } },
                            {
                                "2",
                                new List<string>{ "Button1", } },
                            {
                                "3",
                                new List<string>{ "IDC_BUTTON7", } },
                            {
                                "4",
                                new List<string>{ "Button", } },
                            {
                                "param1",
                                new List<string>{
                                    "BS_OWNERDRAW",
                                    "WS_TABSTOP",} },
                            {
                                "size",
                                new List<string>{ "16", "138", "50", "14", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_CONTROL_3()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CONTROL         ""Check1"",IDC_CHECK16,""Button"",BS_AUTOCHECKBOX | WS_TABSTOP,140,34,39,10,WS_EX_CLIENTEDGE");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.CONTROL,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "CONTROL", } },
                            {
                                "2",
                                new List<string>{ "Check1", } },
                            {
                                "3",
                                new List<string>{ "IDC_CHECK16", } },
                            {
                                "4",
                                new List<string>{ "Button", } },
                            {
                                "param1",
                                new List<string>{
                                    "BS_AUTOCHECKBOX",
                                    "WS_TABSTOP",} },
                            {
                                "size",
                                new List<string>{ "140", "34", "39", "10", } },
                            {
                                "param2",
                                new List<string>{
                                    "WS_EX_CLIENTEDGE",} },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_EDITTEXT_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    EDITTEXT        IDC_EDIT23,215,61,40,14");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.EDITTEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "EDITTEXT", } },
                            {
                                "2",
                                new List<string>{ "IDC_EDIT23", } },
                            {
                                "size",
                                new List<string>{ "215", "61", "40", "14", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_EDITTEXT_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    EDITTEXT        IDC_EDIT1,22,18,40,14,ES_AUTOHSCROLL");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.EDITTEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "EDITTEXT", } },
                            {
                                "2",
                                new List<string>{ "IDC_EDIT1", } },
                            {
                                "size",
                                new List<string>{ "22", "18", "40", "14", } },
                            {
                                "param1",
                                new List<string>{ "ES_AUTOHSCROLL", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_EDITTEXT_3()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    EDITTEXT        IDC_EDIT2,20,38,40,14,ES_MULTILINE | ES_UPPERCASE | ES_AUTOVSCROLL | ES_NOHIDESEL | ES_OEMCONVERT | ES_READONLY | ES_WANTRETURN | ES_NUMBER | NOT WS_VISIBLE | WS_DISABLED | WS_VSCROLL | WS_HSCROLL | WS_GROUP | NOT WS_TABSTOP,WS_EX_DLGMODALFRAME | WS_EX_ACCEPTFILES | WS_EX_TRANSPARENT | WS_EX_CLIENTEDGE | WS_EX_RIGHT | WS_EX_RTLREADING | WS_EX_LEFTSCROLLBAR | WS_EX_STATICEDGE,HIDC_EDIT2");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.EDITTEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "EDITTEXT", } },
                            {
                                "2",
                                new List<string>{ "IDC_EDIT2", } },
                            {
                                "size",
                                new List<string>{ "20", "38", "40", "14", } },
                            {
                                "param1",
                                new List<string>{
                                    "ES_MULTILINE",
                                    "ES_UPPERCASE",
                                    "ES_AUTOVSCROLL",
                                    "ES_NOHIDESEL",
                                    "ES_OEMCONVERT",
                                    "ES_READONLY",
                                    "ES_WANTRETURN",
                                    "ES_NUMBER",
                                    "NOT WS_VISIBLE",
                                    "WS_DISABLED",
                                    "WS_VSCROLL",
                                    "WS_HSCROLL",
                                    "WS_GROUP",
                                    "NOT WS_TABSTOP",
                                } },
                            {
                                "param2",
                                new List<string>{
                                    "WS_EX_DLGMODALFRAME",
                                    "WS_EX_ACCEPTFILES",
                                    "WS_EX_TRANSPARENT",
                                    "WS_EX_CLIENTEDGE",
                                    "WS_EX_RIGHT",
                                    "WS_EX_RTLREADING",
                                    "WS_EX_LEFTSCROLLBAR",
                                    "WS_EX_STATICEDGE",
                            } },
                            {
                                "param3",
                                new List<string>{
                                    "HIDC_EDIT2",
                            } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_COMBOBOX_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    COMBOBOX        IDC_COMBO1,19,17,48,30,CBS_DROPDOWN | CBS_SORT | WS_VSCROLL | WS_TABSTOP");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.COMBOBOX,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "COMBOBOX", } },
                            {
                                "2",
                                new List<string>{ "IDC_COMBO1", } },
                            {
                                "size",
                                new List<string>{ "19", "17", "48", "30", } },
                            {
                                "param1",
                                new List<string>{
                                    "CBS_DROPDOWN",
                                    "CBS_SORT",
                                    "WS_VSCROLL",
                                    "WS_TABSTOP",
                                 } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_COMBOBOX_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    COMBOBOX        IDC_COMBO2,18,35,48,30,CBS_DROPDOWN | CBS_OWNERDRAWFIXED | CBS_AUTOHSCROLL | CBS_OEMCONVERT | CBS_NOINTEGRALHEIGHT | CBS_DISABLENOSCROLL | CBS_UPPERCASE | NOT WS_VISIBLE | WS_DISABLED | WS_GROUP,WS_EX_DLGMODALFRAME | WS_EX_ACCEPTFILES | WS_EX_TRANSPARENT | WS_EX_CLIENTEDGE | WS_EX_RIGHT | WS_EX_RTLREADING | WS_EX_STATICEDGE,HIDC_COMBO2");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.COMBOBOX,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "COMBOBOX", } },
                            {
                                "2",
                                new List<string>{ "IDC_COMBO2", } },
                            {
                                "size",
                                new List<string>{ "18", "35", "48", "30", } },
                            {
                                "param1",
                                new List<string>{
                                    "CBS_DROPDOWN",
                                    "CBS_OWNERDRAWFIXED",
                                    "CBS_AUTOHSCROLL",
                                    "CBS_OEMCONVERT",
                                    "CBS_NOINTEGRALHEIGHT",
                                    "CBS_DISABLENOSCROLL",
                                    "CBS_UPPERCASE",
                                    "NOT WS_VISIBLE",
                                    "WS_DISABLED",
                                    "WS_GROUP",
                                } },
                            {
                                "param2",
                                new List<string>{
                                    "WS_EX_DLGMODALFRAME",
                                    "WS_EX_ACCEPTFILES",
                                    "WS_EX_TRANSPARENT",
                                    "WS_EX_CLIENTEDGE",
                                    "WS_EX_RIGHT",
                                    "WS_EX_RTLREADING",
                                    "WS_EX_STATICEDGE", } },
                            {
                                "param3",
                                new List<string>{ "HIDC_COMBO2", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_CHECKBOX()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CHECKBOX        ""Check1"",IDC_CHECK4,23,62,39,10");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.CHECKBOX,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "CHECKBOX", } },
                            {
                                "2",
                                new List<string>{ "Check1", } },
                            {
                                "3",
                                new List<string>{ "IDC_CHECK4", } },
                            {
                                "size",
                                new List<string>{ "23", "62", "39", "10", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_ICON_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    ICON            IDR_MAINFRAME,IDC_STATIC,14,14,21,20");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.ICON,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "ICON", } },
                            {
                                "2",
                                new List<string>{ "IDR_MAINFRAME", }},
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "14", "14", "21", "20", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_ICON_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    ICON            "",IDC_STATIC,6,6,21,20,SS_NOTIFY | SS_CENTERIMAGE | SS_RIGHTJUST | SS_REALSIZEIMAGE | SS_SUNKEN | NOT WS_VISIBLE | WS_DISABLED | WS_BORDER | WS_GROUP | WS_TABSTOP,WS_EX_DLGMODALFRAME | WS_EX_ACCEPTFILES | WS_EX_TRANSPARENT | WS_EX_CLIENTEDGE | WS_EX_STATICEDGE,HIDC_STATIC");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.ICON,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "ICON", } },
                            {
                                "2",
                                new List<string>{ "\"", } },
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "6", "6", "21", "20"}},
                            {
                                "param1",
                                new List<string>{
                                    "SS_NOTIFY",
                                    "SS_CENTERIMAGE",
                                    "SS_RIGHTJUST",
                                    "SS_REALSIZEIMAGE",
                                    "SS_SUNKEN",
                                    "NOT WS_VISIBLE",
                                    "WS_DISABLED",
                                    "WS_BORDER",
                                    "WS_GROUP",
                                    "WS_TABSTOP", }},
                            {
                                "param2",
                                new List<string>{
                                    "WS_EX_DLGMODALFRAME",
                                    "WS_EX_ACCEPTFILES",
                                    "WS_EX_TRANSPARENT",
                                    "WS_EX_CLIENTEDGE",
                                    "WS_EX_STATICEDGE", }},
                            {
                                "param3",
                                new List<string>{
                                    "HIDC_STATIC", }},
                            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_CTEXT()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CTEXT           ""スタティック"",IDC_STATIC,18,264,33,8");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.TEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "CTEXT", } },
                            {
                                "2",
                                new List<string>{ "スタティック", } },
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "18", "264", "33", "8", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_LTEXT_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    LTEXT           ""スタティック"",IDC_STATIC,13,19,33,8");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.TEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "LTEXT", } },
                            {
                                "2",
                                new List<string>{ "スタティック", } },
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "13", "19", "33", "8", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_LTEXT_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    LTEXT           ""スタティック"",IDC_STATIC,16,52,33,8,NOT WS_GROUP");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.TEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "LTEXT", } },
                            {
                                "2",
                                new List<string>{ "スタティック", } },
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "16", "52", "33", "8", } },
                            {
                                "param1",
                                new List<string>{ "NOT WS_GROUP", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_LTEXT_3()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    LTEXT           ""スタティック"",IDC_STATIC,17,68,33,8,WS_TABSTOP");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.TEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "LTEXT", } },
                            {
                                "2",
                                new List<string>{ "スタティック", } },
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "17", "68", "33", "8", } },
                            {
                                "param1",
                                new List<string>{ "WS_TABSTOP", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_LTEXT_4()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    LTEXT           ""スタティック"",IDC_STATIC,18,116,33,8,0,0,HIDC_STATIC");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.TEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "LTEXT", } },
                            {
                                "2",
                                new List<string>{ "スタティック", } },
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "18", "116", "33", "8", } },
                            {
                                "param1",
                                new List<string>{ "0", } },
                            {
                                "param2",
                                new List<string>{ "0", } },
                            {
                                "param3",
                                new List<string>{ "HIDC_STATIC", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_RTEXT()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    RTEXT           ""スタティック"",IDC_STATIC,18,279,33,8");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.TEXT,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "RTEXT", } },
                            {
                                "2",
                                new List<string>{ "スタティック", } },
                            {
                                "3",
                                new List<string>{ "IDC_STATIC", } },
                            {
                                "size",
                                new List<string>{ "18", "279", "33", "8", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1 == ans);
        }

        [TestMethod()]
        public void ConvertTest_END()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"END");
            var ans = new PartsInfo.RESULT_LIST(
                        PartsInfo.PARTSKIND.FORMEND,
                        new Dictionary<string, List<string>>{
                            {
                                "1",
                                new List<string>{ "END", } },
            });
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.UNKNOWN);
            Assert.IsTrue(result.Item1 == ans);
        }
    }
}