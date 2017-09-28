using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;
using _60322_1_Lagutin.Models;

namespace _60322_1_Lagutin.Controllers
{
    public class BookController : Controller
    {
        int pageSize = 3;
        IRepository<Book> repository;
        public BookController(IRepository<Book> repo)
        {
            repository = repo;
        }

        
        // GET: Book
        public ActionResult List(int page=1)
        {
            var lst = repository.GetAll().OrderBy(d => d.Price);
            return View(PageListViewModel<Book>.CreatePage(lst, page, pageSize));
        }
        
    }
}