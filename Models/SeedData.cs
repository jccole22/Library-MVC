using LibraryMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new LibraryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LibraryContext>>()))
            {
                //if there are already books, then return
                if (context.Book.Any())
                {
                    return;
                }
                // this will add default books when program starts
                // this is called 'seeding' data
                context.Book.AddRange(new Book { Title = "Clean Code", CallNumber = "SE 1.3 2008"}, // Robert Cecil Martin
                new Book { Title = "Head First Design Patterns", CallNumber = "SE 1.2 2004" }, // Kathy Sierra
                new Book { Title = "The Algorithm Design Manual", CallNumber = "SE 1.1 1997" }, // Steven Skiena
                new Book { Title = "Refactoring to Patterns", CallNumber = "SE 1.21 2004" }, // Joshua Kerievsky
                new Book { Title = "A Philosophy of Software Design", CallNumber = "SE 1.4 2018" }); // John Ousterhout

                context.SaveChanges();
            }
        }
    }
}
