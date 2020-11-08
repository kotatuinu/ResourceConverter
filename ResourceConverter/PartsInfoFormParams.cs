using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceConverter
{
    class PartsInfoFormParams : PartsInfo
    {
        public PartsInfoFormParams()
        {
            currentPartsInfos_ = new List<PARTS_INFO> {
                new PARTS_INFO(PARTSKIND.FORMCAPTION, @"^CAPTION\s+",  @"^(CAPTION)\s+""(.+?)""$", RESOURCE_STATUE.FORM),
                new PARTS_INFO(PARTSKIND.FORMSTYLE, @"^(EX){0,1}STYLE\s+", @"^((?:EX){0,1}STYLE)\s+(?:(\w+)(?:\s+\|\s+))*(\w+)*$", RESOURCE_STATUE.FORM),
                new PARTS_INFO(PARTSKIND.FORMFONT, @"^FONT\s+", @"^(FONT)\s+(\d+),\s*""(.+?)""(?:,\s*(\d+),\s*(\d+),\s*(0x\d+))*$", RESOURCE_STATUE.FORM),
                new PARTS_INFO(PARTSKIND.FORMBEGIN, @"^BEGIN$", @"^(BEGIN)$", RESOURCE_STATUE.FORMPARTS),
            };
        }
    }
}
