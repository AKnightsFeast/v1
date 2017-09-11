using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using web.Attributes;

namespace web.Models.Enums
{
    [Flags]
    public enum ContainerType : short
    {
        [EnumDisplay(Label = "Microwave safe plastic")] Plastic = 1,
        [EnumDisplay(Label = "Freezer, oven, and microwafe safe Pyrex")] Pyrex = 2,
        [EnumDisplay(Label = "Theirs")] Own = 4
    }
}