using System.Data.Entity;

namespace _60322_1_Lagutin.DAL.Entities
{
    public class BookContext : DbContext
    {
        public BookContext(string name) : base(name)
        {
            Database.SetInitializer(new BookContextInitializer());
        }
        public DbSet<Book> Books { get; set; }
    }


}
