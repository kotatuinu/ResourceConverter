using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ResourceConverter
{
    class ConvertFormPartsInfo
    {
        public enum RESOURCE_KIND
        {
            UNKNOWN,
            FORM,
            FORMPARTS,
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

        private struct PARTS_INFO
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
            public RESOURCE_KIND NextPartsKind
            {
                get;
                private set;
            }

            public PARTS_INFO(PARTSKIND partsKind, string pickupRgxText, string rgxText, RESOURCE_KIND nextResourcekind)
            {
                PartsKind = partsKind;
                PickupRgx = new Regex(pickupRgxText); // 部品検出用正規表現
                Rgx = new Regex(rgxText);   // 部品パラメタ抽出用正規表現
                NextPartsKind = nextResourcekind;   // 部品パラメタ抽出時、次部品種別
            }
        }

        private List<PARTS_INFO> PARTS_UNKNOWN = new List<PARTS_INFO>  {
            new PARTS_INFO(PARTSKIND.FORM, @"^\w+\s+DIALOG(EX){0,1}\s+", @"^(\w+)\s+(DIALOG(?:EX){0,1})\s+(\d+),\s*(\d+),\s*(\d+),\s*(\d+)$", RESOURCE_KIND.FORM),
        };

        private List<PARTS_INFO> PARTS_FORMPARAM = new List<PARTS_INFO>  {
            new PARTS_INFO(PARTSKIND.FORMCAPTION, @"^CAPTION\s+",  @"^(CAPTION)\s+""(.+?)""$", RESOURCE_KIND.FORM),
            new PARTS_INFO(PARTSKIND.FORMSTYLE, @"^(EX){0,1}STYLE\s+", @"^((?:EX){0,1}STYLE)\s+(?:(\w+)(?:\s+\|\s+))*(\w+)*$", RESOURCE_KIND.FORM),
            new PARTS_INFO(PARTSKIND.FORMFONT, @"^FONT\s+", @"^(FONT)\s+(\d+),\s*""(.+?)""(?:,\s*(\d+),\s*(\d+),\s*(0x\d+))*$", RESOURCE_KIND.FORM),
            new PARTS_INFO(PARTSKIND.FORMBEGIN, @"^BEGIN$", @"^(BEGIN)$", RESOURCE_KIND.FORMPARTS),
        };
        private List<PARTS_INFO> PARTS_FORMPARTS = new List<PARTS_INFO>
        {
            new PARTS_INFO(PARTSKIND.PUSHBUTTON, @"^\s*((?:DEF)*PUSHBUTTON)\s+", @"^\s*((?:DEF)*PUSHBUTTON)\s+""(.*?)"",(.+?),(\d+),(\d+),(\d+),(\d+)(?:,(?:(\w+)(?:\s+\|\s+))*(\w+\s+\w+|\w+)*)*$", RESOURCE_KIND.FORMPARTS),
            new PARTS_INFO(PARTSKIND.CONTROL, @"^\s*(CONTROL)\s+", @"^\s*(CONTROL)\s+""(.*?)"",(.+?),""(.+?)"",(?:(\w+\s+\w+|\w+)(?:\s+\|\s+))*(\w+\s+\w+|\w+),(\d+),(\d+),(\d+)(?:,(\d+))*(?:,*(?:(\w+\s+\w+|\w+)(?:\s+\|\s+))*(\w+\s+\w+|\w+)*)*$", RESOURCE_KIND.FORMPARTS),
            new PARTS_INFO(PARTSKIND.EDITTEXT, @"^\s*(EDITTEXT)\s+", @"^\s*(EDITTEXT)\s+(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)(?:,(\d+|\w+)\s*)*(?:,*(\w+\s*\w+)(?:\s*\|\s*)*)*$", RESOURCE_KIND.FORMPARTS),
            new PARTS_INFO(PARTSKIND.COMBOBOX,@"^\s*COMBOBOX\s+", @"^\s*(COMBOBOX)\s+(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)(?:,*((\d+|\w+\s*\w+)(?:\s\|\s)*))*$", RESOURCE_KIND.FORMPARTS),
            new PARTS_INFO(PARTSKIND.CHECKBOX, @"^\s*CHECKBOX\s+", @"^\s*(CHECKBOX)\s+""(.+?)"",\s*(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)$", RESOURCE_KIND.FORMPARTS),
            new PARTS_INFO(PARTSKIND.ICON, @"^\s*ICON\s+", @"^\s*(ICON)\s+(.+?),\s*(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)$", RESOURCE_KIND.FORMPARTS),
            new PARTS_INFO(PARTSKIND.TEXT, @"^\s*((?:C|L|R)TEXT)\s+", @"^\s*((?:C|L|R)TEXT)\s+""(.*?)"",\s*(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)(?:,(.+?))*$", RESOURCE_KIND.FORMPARTS),
            new PARTS_INFO(PARTSKIND.FORMEND, @"^END$",@"^(END)$", RESOURCE_KIND.UNKNOWN),
        };

        private List<PARTS_INFO> currentPartsInfos_;

        public ConvertFormPartsInfo() => currentPartsInfos_ = PARTS_UNKNOWN;

        public List<string> convert(string line)
        {
            var result = new List<string>();
            var rgx = currentPartsInfos_.GetEnumerator();

            while (rgx.MoveNext())
            {

                if (rgx.Current.PickupRgx.IsMatch(line))
                {
                    Match match = rgx.Current.Rgx.Match(line);
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
                    switch (rgx.Current.NextPartsKind)
                    {
                        case RESOURCE_KIND.UNKNOWN:
                            currentPartsInfos_ = PARTS_UNKNOWN;
                            break;

                        case RESOURCE_KIND.FORM:
                            currentPartsInfos_ = PARTS_FORMPARAM;
                            break;

                        case RESOURCE_KIND.FORMPARTS:
                            currentPartsInfos_ = PARTS_FORMPARTS;
                            break;

                        default:
                            currentPartsInfos_ = PARTS_UNKNOWN;
                            break;
                    }
                }
            }

            return result;
        }

    }
}
