using System;

namespace web.Models
{
    public class MonthlyMenuLink : IComparable
    {
        public string Text;
        public string FileName;

        int IComparable.CompareTo(object obj)
        {
            if (obj == null) return -1;
            if (obj.GetType() != typeof(MonthlyMenuLink)) return -1;

            return String.Compare(FileName, (obj as MonthlyMenuLink).FileName);
        }
    }
}