using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbzExtractor.constant;
using MbzExtractor.dto.inner;

namespace MbzExtractor.utils
{
    internal class MbzUtils
    {

        public static EnumTypeActivity GetTypeActivity(ActivityFull activityFull)
        {
            if (activityFull.Resource != null) return EnumTypeActivity.Resource;
            if (activityFull.Assign != null) return EnumTypeActivity.Assign;
            if (activityFull.Label != null) return EnumTypeActivity.Label;
            if (activityFull.Folder != null) return EnumTypeActivity.Folder;
            if (activityFull.Url != null) return EnumTypeActivity.Url;
            if (activityFull.Page != null) return EnumTypeActivity.Page;

            return EnumTypeActivity.Unknown;
        }

    }
}
