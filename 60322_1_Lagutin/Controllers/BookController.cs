using System.Linq;
using System.Web.Mvc;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;
using _60322_1_Lagutin.Models;

namespace _60322_1_Lagutin.Controllers
{
    public class BookController : Controller
    {
        int pageSize = 3;
        readonly IRepository<Book> _repository;
        public BookController(IRepository<Book> repo)
        {
            _repository = repo;
        }


        // GET: Book
        public ActionResult List(string group, int page = 1)
        {
            var lst = _repository.GetAll()
                .Where(d => group == null || d.Genre.Equals(group))
                .OrderBy(d => d.Author);

            var model = PageListViewModel<Book>.CreatePage(lst, page,
                pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPatial", model);
            }
            return View(model);
            
        }

       
    }
}