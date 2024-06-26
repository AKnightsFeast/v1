﻿using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

using System.Web;
using System.Web.Mvc;

using web.Models;

namespace web.Controllers
{
    public class MenusController : Controller
    {
        static SortedDictionary<int, List<MonthlyMenuLink>> MonthlyMenus;

        public ActionResult Freezer() { return View(); }
        public ActionResult Personal() { return View(); }
        public ActionResult Special() { return View(); }
        public ActionResult ThemedEvents() { return View(); }
        public ActionResult Monthly() { return View(GetMonthlyMenus()); }

        private SortedDictionary<int, List<MonthlyMenuLink>> GetMonthlyMenus()
        {
            if (MonthlyMenus == null)
            {
                MonthlyMenus = new SortedDictionary<int, List<MonthlyMenuLink>>(new DescendingComparer<int>());

                foreach (var file in Directory.GetFiles(Server.MapPath("~/Content/media/menus")))
                {
                    var fileName = Path.GetFileName(file);
                    var fileYear = int.Parse(fileName.Substring(0, 4));
                    var fileMonth = int.Parse(fileName.Substring(4, 2));

                    if (!MonthlyMenus.ContainsKey(fileYear)) MonthlyMenus.Add(fileYear, new List<MonthlyMenuLink>());

                    var linkText = new DateTime(fileYear, fileMonth, 1).ToString("MMM", CultureInfo.InvariantCulture);

                    if (fileName.Length > 10)
                    {
                        var menuType = fileName.Replace(".pdf", string.Empty).Substring(6);

                        switch (menuType.ToLower())
                        {
                            case "keto":
                                linkText += " - Keto";
                                break;
                            case "paleo":
                                linkText += " - Paleo";
                                break;
                            case "veg":
                                linkText += " - Vegetarian/Vegan";
                                break;
                            default:
                                linkText += " - " + menuType.Replace("_", " ");
                                break;
                        }
                    }

                    MonthlyMenus[fileYear].Add(new MonthlyMenuLink()
                    {
                        FileName = fileName,
                        Text = linkText
                    });
                }

                foreach (var link in MonthlyMenus.Values)
                {
                    link.Sort();
                }
            }
            
            return MonthlyMenus;
        }

        class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return y.CompareTo(x);
            }
        }
    }
}