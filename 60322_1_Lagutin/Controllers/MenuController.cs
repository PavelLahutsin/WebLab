using _60322_1_Lagutin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _60322_1_Lagutin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu

        List<MenuItem> items;
        public MenuController()
        {
            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home",
                Action="Index", Active=string.Empty},
                new MenuItem{Name="Каталог", Controller="Book",
                Action="List", Active=string.Empty},
                new MenuItem{Name="Администрирование", Controller="Admin",
                Action="Index", Active=string.Empty},
            };
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            items.First(m => m.Controller == c).Active = "active";
            return PartialView(items);
        }
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }
        public string Side()
        {
            return "Боковая панель";
        }
        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}