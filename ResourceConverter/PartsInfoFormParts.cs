using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceConverter
{
    public class PartsInfoFormParts : PartsInfo
    {
        public PartsInfoFormParts()
        {
            currentPartsInfos_ = new List<PARTS_INFO> {
                new PARTS_INFO(PARTSKIND.PUSHBUTTON, @"^\s*((?:DEF)*PUSHBUTTON)\s+", @"^\s*((?:DEF)*PUSHBUTTON)\s+""(.*?)"",(.+?),(\d+),(\d+),(\d+),(\d+)(?:,(?:(\w+)(?:\s+\|\s+))*(\w+\s+\w+|\w+)*)*$", RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.CONTROL, @"^\s*(CONTROL)\s+", @"^\s*(CONTROL)\s+""(.*?)"",(.+?),""(.+?)"",(?:(\w+\s+\w+|\w+)(?:\s+\|\s+))*(\w+\s+\w+|\w+),(\d+),(\d+),(\d+)(?:,(\d+))*(?:,*(?:(\w+\s+\w+|\w+)(?:\s+\|\s+))*(\w+\s+\w+|\w+)*)*$", RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.EDITTEXT, @"^\s*(EDITTEXT)\s+", @"^\s*(EDITTEXT)\s+(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)(?:,(\d+|\w+)\s*)*(?:,*(\w+\s*\w+)(?:\s*\|\s*)*)*$", RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.COMBOBOX,@"^\s*COMBOBOX\s+", @"^\s*(COMBOBOX)\s+(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)(?:,*(?:(\d+|\w+\s*\w+)(?:\s\|\s)*))*$", RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.CHECKBOX, @"^\s*CHECKBOX\s+", @"^\s*(CHECKBOX)\s+""(.+?)"",\s*(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)$", RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.ICON, @"^\s*ICON\s+", @"^\s*(ICON)\s+(.+?),\s*(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)$", RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.TEXT, @"^\s*((?:C|L|R)TEXT)\s+", @"^\s*((?:C|L|R)TEXT)\s+""(.*?)"",\s*(.+?),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+)(?:,(.+?))*$", RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.FORMEND, @"^END$",@"^(END)$", RESOURCE_STATUE.UNKNOWN),
            };
        }
    }
}
