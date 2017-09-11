using System;

using web.Attributes;

namespace web.Models.Enums
{
    [Flags]
    public enum ChickenPrepType
    {
        [EnumDisplay(Label = "Dark Meat")]
        DarkMeat = 1,
        [EnumDisplay(Label = "White Meat")]
        WhiteMeat = 2,
        [EnumDisplay(Label = "Bone In")]
        BoneIn = 4,
        Boneless = 16,
        [EnumDisplay(Label = "Whole Roasts")]
        WholeRoasts = 32,
        [EnumDisplay(IsVisible = false)]
        Any = DarkMeat | WhiteMeat | BoneIn | Boneless | WholeRoasts,
        [EnumDisplay(IsVisible = false)]
        All = DarkMeat & WhiteMeat & BoneIn & Boneless & WholeRoasts
    }
}