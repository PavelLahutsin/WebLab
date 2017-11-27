using _60322_1_Lagutin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;

namespace _60322_1_Lagutin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        private readonly IRepository<Book> _repository;

        private readonly List<MenuItem> _items;

        public MenuController(IRepository<Book> repository)
        {
            _repository = repository;
            _items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home",
                Action="Index", Active=string.Empty},
                new MenuItem{Name="Каталог", Controller="Book",
                Action="List", Active=string.Empty},
                new MenuItem{Name="Администрирование", Controller="Admin",
                Action="Index", Active=string.Empty}
            };
        }
        
        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            try
            {
                _items.First(m => string.Equals(m.Controller, c, StringComparison.CurrentCultureIgnoreCase)).Active = "active";
                return PartialView(_items);
            }
            catch (Exception e)
            {
                return PartialView(_items);
            }
            
        }
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }
        public PartialViewResult Side()
        {
            var groups = _repository.GetAll().Select(d => d.Genre).Distinct();
            return PartialView(groups);
        }
        public PartialViewResult Map()
        {
            return PartialView(_items);
        }
    }
}