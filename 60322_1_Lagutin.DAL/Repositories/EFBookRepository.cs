using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60322_1_Lagutin.DAL.Repositories
{
    public class EFBookRepository : IRepository<Book>
    {
        BookContext context;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name"> имя строки подключения </param>
        /// 
        public EFBookRepository(string name)
        {
            context = new BookContext(name);
        }
        public void Create(Book t)
        {
            context.Books.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = context.Books.Find(id);
            if (item != null)
                context.Books.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return context.Books.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }

        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book t)
        {
            context.Entry<Book>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
