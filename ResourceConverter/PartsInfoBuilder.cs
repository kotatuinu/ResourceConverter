using System.Collections.Generic;

namespace ResourceConverter
{
    class PartsInfoBuilder
    {
        readonly Dictionary<PartsInfo.RESOURCE_STATUE, PartsInfo> ResourceKind2PartsInfo_ = new Dictionary<PartsInfo.RESOURCE_STATUE, PartsInfo> {
                    { PartsInfo.RESOURCE_STATUE.UNKNOWN, new PartsInfoForm() },
                    { PartsInfo.RESOURCE_STATUE.FORM, new PartsInfoFormParams() },
                    { PartsInfo.RESOURCE_STATUE.FORMPARTS, new PartsInfoFormParts() },
                };
        public PartsInfo GetPartsInfo()
        {
            return ResourceKind2PartsInfo_[PartsInfo.RESOURCE_STATUE.UNKNOWN];
        }

        public PartsInfo GetPartsInfo(PartsInfo.RESOURCE_STATUE kind)
        {
            return ResourceKind2PartsInfo_[kind];
        }

    }
}
