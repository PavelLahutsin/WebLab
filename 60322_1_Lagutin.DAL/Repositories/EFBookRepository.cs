using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;

namespace _60322_1_Lagutin.DAL.Repositories
{
    public class EfBookRepository : IRepository<Book>
    {
        readonly BookContext _context;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name"> имя строки подключения </param>
        /// 
        public EfBookRepository(string name)
        {
            _context = new BookContext(name);
        }
        public void Create(Book t)
        {
            _context.Books.Add(t);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Books.Find(id);
            if (item != null)
                _context.Books.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return _context.Books.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public void Update(Book t)
        {
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
