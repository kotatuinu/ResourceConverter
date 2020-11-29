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
                new PARTS_INFO(PARTSKIND.PUSHBUTTON, @"^\s*((?:DEF)*PUSHBUTTON)\s+",
                    @"^\s*((?:DEF)*PUSHBUTTON)\s+""(.*?)"",(.+?)(?:,(?<size>\d+)){4}(?:,(?:(?<param1>\w+\s+\w+|\w+)(?:\s+\|\s+))*(?<param1>\w+\s+\w+|\w+)(?:,(?:(?<param2>\w+|\w+\s\w+)\s\|\s)*(?<param2>\w+|\w+\s\w+)(?:,(?<param3>\w+))?)?)?$",
                    RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.CONTROL, @"^\s*(CONTROL)\s+",
                    @"^\s*(CONTROL)\s+""(.*?)"",(.+?),""(.+?)"",(?:(?<param1>\w+\s+\w+|\w+)(?:\s+\|\s+))*(?<param1>\w+\s+\w+|\w+)(?:,(?<size>\d+)){4}(?:,(?:(?<param2>\w+|\w+\s\w+)\s\|\s)*(?<param2>\w+|\w+\s\w+)(?:,(?<param3>\w+))?)?$",
                    RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.EDITTEXT, @"^\s*(EDITTEXT)\s+",
                    @"^\s*(EDITTEXT)\s+(.+?)(?:,(?<size>\d+)){4}(?:,(?:(?<param1>\w+\s+\w+|\w+)(?:\s+\|\s+))*(?<param1>\w+\s+\w+|\w+)(?:,(?:(?<param2>\w+|\w+\s\w+)\s\|\s)*(?<param2>\w+|\w+\s\w+)(?:,(?<param3>\w+))?)?)?$",
                    RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.COMBOBOX, @"^\s*COMBOBOX\s+",
                    @"^\s*(COMBOBOX)\s+(.+?)(?:,(?<size>\d+)){4}(?:,(?:(?<param1>\w+|\w+\s\w+)\s\|\s)*(?<param1>\w+|\w+\s\w+)(?:,(?:(?<param2>\w+|\w+\s\w+)\s\|\s)*(?<param2>\w+|\w+\s\w+)(?:,(?<param3>\w+))?)?)?$",
                    RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.CHECKBOX, @"^\s*CHECKBOX\s+",
                    @"^\s*(CHECKBOX)\s+""(.+?)"",(\w+?)(?:,(?<size>\d+)){4}(?:,(?:(?<param1>\w+\s+\w+|\w+)(?:\s+\|\s+))*(?<param1>\w+\s+\w+|\w+)(?:,(?:(?<param2>\w+|\w+\s\w+)\s\|\s)*(?<param2>\w+|\w+\s\w+)(?:,(?<param3>\w+))?)?)?$",
                    RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.ICON, @"^\s*ICON\s+",
                    @"^\s*(ICON)\s+(.+?),(.+?)(?:,(?<size>\d+)){4}(?:,(?:(?<param1>\w+|\w+\s\w+)\s\|\s)*(?<param1>\w+|\w+\s\w+)(?:,(?:(?<param2>\w+|\w+\s\w+)\s\|\s)*(?<param2>\w+|\w+\s\w+)(?:,(?<param3>\w+))?)?)?$",
                    RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.TEXT, @"^\s*((?:C|L|R)TEXT)\s+",
                    @"^\s*((?:C|L|R)TEXT)\s+""(.*?)"",(.+?)(?:,(?<size>\d+)){4}(?:,(?:(?<param1>\w+\s+\w+|\w+)(?:\s+\|\s+))*(?<param1>\w+\s+\w+|\w+)(?:,(?:(?<param2>\w+|\w+\s\w+)\s\|\s)*(?<param2>\w+|\w+\s\w+)(?:,(?<param3>\w+))?)?)?$",
                    RESOURCE_STATUE.FORMPARTS),
                new PARTS_INFO(PARTSKIND.FORMEND, @"^END$", @"^(END)$", RESOURCE_STATUE.UNKNOWN),
            };
        }
    }
}
