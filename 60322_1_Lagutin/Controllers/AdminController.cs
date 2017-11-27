using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;
using _60322_1_Lagutin.DAL.Repositories;

namespace _60322_1_Lagutin.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Book> _repository;

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
                    imageUpload.InputStream.Read(book.Image, 0, (int) count);
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
            else
            {
                return View(book);
            }
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
                    imageUpload.InputStream.Read(book.Image, 0, (int) count);
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
            else
            {
                return View(book);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
