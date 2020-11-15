using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceConverter;
using System;
using System.Collections.Generic;
using System.Text;

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
            Assert.IsTrue(result.Item1.Count == 0);
        }

        [TestMethod()]
        public void ConvertTest_PUSHBUTTON()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    PUSHBUTTON      ""キャンセル"",IDCANCEL,520,466,50,14");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "PUSHBUTTON",
                "キャンセル",
                "IDCANCEL",
                "520",
                "466",
                "50",
                "14",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_DEFPUSHBUTTON()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    DEFPUSHBUTTON   ""OK"",IDOK,198,466,50,14");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "DEFPUSHBUTTON",
                "OK",
                "IDOK",
                "198",
                "466",
                "50",
                "14",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_CONTROL_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CONTROL         ""Button1"",IDC_BUTTON2,""Button"",BS_OWNERDRAW | BS_LEFT | BS_TOP | WS_DISABLED | WS_GROUP,15,39,50,14,WS_EX_DLGMODALFRAME | WS_EX_ACCEPTFILES | WS_EX_TRANSPARENT | WS_EX_CLIENTEDGE | WS_EX_RIGHT | WS_EX_RTLREADING | WS_EX_STATICEDGE,HIDC_BUTTON2");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "CONTROL",
                "Button1",
                "IDC_BUTTON2",
                "Button",
                "BS_OWNERDRAW",
                "BS_LEFT",
                "BS_TOP",
                "WS_DISABLED",
                "WS_GROUP",
                "15",
                "39",
                "50",
                "14",
                "WS_EX_DLGMODALFRAME",
                "WS_EX_ACCEPTFILES",
                "WS_EX_TRANSPARENT",
                "WS_EX_CLIENTEDGE",
                "WS_EX_RIGHT",
                "WS_EX_RTLREADING",
                "WS_EX_STATICEDGE",
                "HIDC_BUTTON2",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_CONTROL_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CONTROL         ""Button1"",IDC_BUTTON7,""Button"",BS_OWNERDRAW | WS_TABSTOP,16,138,50,14");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "CONTROL",
                "Button1",
                "IDC_BUTTON7",
                "Button",
                "BS_OWNERDRAW",
                "WS_TABSTOP",
                "16",
                "138",
                "50",
                "14",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_CONTROL_3()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CONTROL         ""Check1"",IDC_CHECK16,""Button"",BS_AUTOCHECKBOX | WS_TABSTOP,140,34,39,10,WS_EX_CLIENTEDGE");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "CONTROL",
                "Check1",
                "IDC_CHECK16",
                "Button",
                "BS_AUTOCHECKBOX",
                "WS_TABSTOP",
                "140",
                "34",
                "39",
                "10",
                "WS_EX_CLIENTEDGE",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_EDITTEXT_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    EDITTEXT        IDC_EDIT23,215,61,40,14");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "EDITTEXT",
                "IDC_EDIT23",
                "215",
                "61",
                "40",
                "14",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_EDITTEXT_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    EDITTEXT        IDC_EDIT1,22,18,40,14,ES_AUTOHSCROLL");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "EDITTEXT",
                "IDC_EDIT1",
                "22",
                "18",
                "40",
                "14",
                "ES_AUTOHSCROLL",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_EDITTEXT_3()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    EDITTEXT        IDC_EDIT2,20,38,40,14,ES_MULTILINE | ES_UPPERCASE | ES_AUTOVSCROLL | ES_NOHIDESEL | ES_OEMCONVERT | ES_READONLY | ES_WANTRETURN | ES_NUMBER | NOT WS_VISIBLE | WS_DISABLED | WS_VSCROLL | WS_HSCROLL | WS_GROUP | NOT WS_TABSTOP,WS_EX_DLGMODALFRAME | WS_EX_ACCEPTFILES | WS_EX_TRANSPARENT | WS_EX_CLIENTEDGE | WS_EX_RIGHT | WS_EX_RTLREADING | WS_EX_LEFTSCROLLBAR | WS_EX_STATICEDGE,HIDC_EDIT2");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "EDITTEXT",
                "IDC_EDIT2",
                "20",
                "38",
                "40",
                "14",
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
                "WS_EX_DLGMODALFRAME",
                "WS_EX_ACCEPTFILES",
                "WS_EX_TRANSPARENT",
                "WS_EX_CLIENTEDGE",
                "WS_EX_RIGHT",
                "WS_EX_RTLREADING",
                "WS_EX_LEFTSCROLLBAR",
                "WS_EX_STATICEDGE",
                "HIDC_EDIT2",
                };

            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_COMBOBOX_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    COMBOBOX        IDC_COMBO1,19,17,48,30,CBS_DROPDOWN | CBS_SORT | WS_VSCROLL | WS_TABSTOP");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "COMBOBOX",
                "IDC_COMBO1",
                "19",
                "17",
                "48",
                "30",
                "CBS_DROPDOWN",
                "CBS_SORT",
                "WS_VSCROLL",
                "WS_TABSTOP",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_COMBOBOX_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    COMBOBOX        IDC_COMBO2,18,35,48,30,CBS_DROPDOWN | CBS_OWNERDRAWFIXED | CBS_AUTOHSCROLL | CBS_OEMCONVERT | CBS_NOINTEGRALHEIGHT | CBS_DISABLENOSCROLL | CBS_UPPERCASE | NOT WS_VISIBLE | WS_DISABLED | WS_GROUP,WS_EX_DLGMODALFRAME | WS_EX_ACCEPTFILES | WS_EX_TRANSPARENT | WS_EX_CLIENTEDGE | WS_EX_RIGHT | WS_EX_RTLREADING | WS_EX_STATICEDGE,HIDC_COMBO2");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "COMBOBOX",
                "IDC_COMBO2",
                "18",
                "35",
                "48",
                "30",
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
                "WS_EX_DLGMODALFRAME",
                "WS_EX_ACCEPTFILES",
                "WS_EX_TRANSPARENT",
                "WS_EX_CLIENTEDGE",
                "WS_EX_RIGHT",
                "WS_EX_RTLREADING",
                "WS_EX_STATICEDGE",
                "HIDC_COMBO2",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_CHECKBOX()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CHECKBOX        ""Check1"",IDC_CHECK4,23,62,39,10");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "CHECKBOX",
                "Check1",
                "IDC_CHECK4",
                "23",
                "62",
                "39",
                "10",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_ICON()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    ICON            IDR_MAINFRAME,IDC_STATIC,14,14,21,20");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string> {
                "ICON",
                "IDR_MAINFRAME",
                "IDC_STATIC",
                "14",
                "14",
                "21",
                "20",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_CTEXT()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    CTEXT           ""スタティック"",IDC_STATIC,18,264,33,8");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "CTEXT",
                "スタティック",
                "IDC_STATIC",
                "18",
                "264",
                "33",
                "8",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_LTEXT_1()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    LTEXT           ""スタティック"",IDC_STATIC,13,19,33,8");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "LTEXT",
                "スタティック",
                "IDC_STATIC",
                "13",
                "19",
                "33",
                "8",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_LTEXT_2()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    LTEXT           ""スタティック"",IDC_STATIC,16,52,33,8,NOT WS_GROUP");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "LTEXT",
                "スタティック",
                "IDC_STATIC",
                "16",
                "52",
                "33",
                "8",
                "NOT WS_GROUP",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_LTEXT_3()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    LTEXT           ""スタティック"",IDC_STATIC,17,68,33,8,WS_TABSTOP");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "LTEXT",
                "スタティック",
                "IDC_STATIC",
                "17",
                "68",
                "33",
                "8",
                "WS_TABSTOP",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_RTEXT()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"    RTEXT           ""スタティック"",IDC_STATIC,18,279,33,8");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "RTEXT",
                "スタティック",
                "IDC_STATIC",
                "18",
                "279",
                "33",
                "8",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.FORMPARTS);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }

        [TestMethod()]
        public void ConvertTest_END()
        {
            var info = new PartsInfoFormParts();

            var result = info.Convert(@"END");
            var iteResult = result.Item1.GetEnumerator();
            var ansList = new List<string>
            {
                "END",
            };
            Assert.IsTrue(result.Item2 == PartsInfo.RESOURCE_STATUE.UNKNOWN);
            Assert.IsTrue(result.Item1.Count == ansList.Count);
            ansList.ForEach(item =>
            {
                Assert.IsTrue(iteResult.MoveNext());
                Assert.IsTrue(item == iteResult.Current);
            });
        }
    }
}