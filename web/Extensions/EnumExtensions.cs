using System;
using System.Linq;
using System.Text;

using web.Attributes;

namespace web.Extensions
{
    public static class EnumExtensions
    {
        public static string Join(this Enum enumValue, string delimeter)
        {
            var result = new StringBuilder();
            var enumType = enumValue.GetType();

            foreach (var enumItem in Enum.GetValues(enumType))
            {
                if (!enumValue.HasFlag((Enum)enumItem)) continue;

                var display = enumType.GetField(enumItem.ToString())
                    .GetCustomAttributes(typeof(EnumDisplayAttribute), true).FirstOrDefault() as EnumDisplayAttribute;

                if (display != null && !display.IsVisible) continue;
                if (result.Length > 0) result.Append(delimeter);

                result.Append(display != null && !string.IsNullOrEmpty(display.Label) ? display.Label : enumItem.ToString());
            }

            return (result.Length > 0) ? result.ToString() : string.Empty;
        }
    }
}