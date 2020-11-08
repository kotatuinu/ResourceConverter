using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace ResourceConverter
{
    abstract class PartsInfo
    {
        public enum RESOURCE_STATUE
        {
            UNKNOWN,    // フォームを見つけるまで
            FORM,       // フォームのパラメタ取得
            FORMPARTS,  // フォームのパーツ取得
        }
        public enum PARTSKIND
        {
            UNKNOWN,
            FORM,
            FORMCAPTION,
            FORMSTYLE,
            FORMFONT,
            FORMBEGIN,
            CHECKBOX,
            COMBOBOX,
            CONTROL,
            CTEXT,
            DEFPUSHBUTTON,
            EDITTEXT,
            GROUPBOX,
            ICON,
            LISTBOX,
            LTEXT,
            RTEXT,
            TEXT,
            PUSHBUTTON,
            RADIOBUTTON,
            SCROLLBAR,
            FORMEND,
        }

        public struct PARTS_INFO
        {
            public PARTSKIND PartsKind
            {
                get;
                private set;
            }
            public Regex PickupRgx
            {
                get;
                private set;
            }
            public Regex Rgx
            {
                get;
                private set;
            }
            public RESOURCE_STATUE NextPartsKind
            {
                get;
                private set;
            }

            public PARTS_INFO(PARTSKIND partsKind, string pickupRgxText, string rgxText, RESOURCE_STATUE nextResourcekind)
            {
                PartsKind = partsKind;
                PickupRgx = new Regex(pickupRgxText); // 部品検出用正規表現
                Rgx = new Regex(rgxText);   // 部品パラメタ抽出用正規表現
                NextPartsKind = nextResourcekind;   // 部品パラメタ抽出時、次部品種別
            }
        }

        protected List<PARTS_INFO> currentPartsInfos_;

        private bool GetMatchPartsInfo(string line, out PARTS_INFO partsInfo)
        {
            var result = new List<string>();
            var rgx = currentPartsInfos_.GetEnumerator();

            while (rgx.MoveNext())
            {
                if (rgx.Current.PickupRgx.IsMatch(line))
                {
                    partsInfo = rgx.Current;
                    return true;
                }
            }
            partsInfo = new PARTS_INFO();
            return false;
        }

        public (List<string>, RESOURCE_STATUE) Convert(string line)
        {
            PARTS_INFO partsInfo;
            if (GetMatchPartsInfo(line, out partsInfo))
            {
                var result = Convert(line, partsInfo);
                return (result, partsInfo.NextPartsKind);
            }

            return (new List<string>(), RESOURCE_STATUE.UNKNOWN);
        }

        private List<string> Convert(string line, PARTS_INFO partsInfo)
        {
            var result = new List<string>();

            var match = partsInfo.Rgx.Match(line);
            for (int ctr = 1; ctr < match.Groups.Count; ctr++)
            {
                //Debug.Print("   Group {0}: '{1}'", ctr, match.Groups[ctr].Value);
                int capCtr = 0;
                foreach (Capture capture in match.Groups[ctr].Captures)
                {
                    Debug.Print("      Capture {0}: '{1}'", capCtr, capture.Value);
                    result.Add(capture.Value);
                    capCtr++;
                }
            }

            return result;
        }
    }
}