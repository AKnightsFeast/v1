using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using web.Attributes;

namespace web.Models.Enums
{
    [Flags]
    public enum PackageType : short
    {
        Individual = 1,
        [EnumDisplay(Label = "Family Style")] Family = 2
    }
}