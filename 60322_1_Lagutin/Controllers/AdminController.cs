using System.Web;
using System.Web.Mvc;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;

namespace _60322_1_Lagutin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Book> _repository;

        public AdminController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

       

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Book());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, count);
                    book.MimeType = imageUpload.ContentType;
                }
                try
                {
                    _repository.Create(book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(book);
                }
            }
            return View(book);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, count);
                    book.MimeType = imageUpload.ContentType;
                }

                try
                {
                    _repository.Update(book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(book);
                }
            }
            return View(book);
        }

        
    }
}
