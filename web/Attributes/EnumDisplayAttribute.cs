using System;

namespace web.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayAttribute : Attribute
    {
        public string Label { get; set; }

        bool _isVisible = true;
        public bool IsVisible {
            get { return _isVisible; }
            set { _isVisible = value; }
        }
    }
}