using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ResourceConverter
{
    public class PartsInfoForm : PartsInfo
    {
        public PartsInfoForm()
        {
            currentPartsInfos_ = new List<PARTS_INFO>  {
                new PARTS_INFO(PARTSKIND.FORM, @"^\w+\s+DIALOG(EX){0,1}\s+", @"^(\w+)\s+(DIALOG(?:EX){0,1})\s+(\d+),\s*(\d+),\s*(\d+),\s*(\d+)$", RESOURCE_STATUE.FORM),
            };
        }
    }
}
