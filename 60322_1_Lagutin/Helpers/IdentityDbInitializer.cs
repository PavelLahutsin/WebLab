using System.Data.Entity;
using _60322_1_Lagutin.Models;

namespace _60322_1_Lagutin.Helpers
{
    public class IdentityDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        { }
    }
}