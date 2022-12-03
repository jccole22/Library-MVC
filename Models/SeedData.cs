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
                context.Book.AddRange(new Book { Title = "Clean Code", Author= "Robert Cecil Martin", CallNumber = "SE 1.3 2008"},
                new Book { Title = "Head First Design Patterns", Author = "Kathy Sierra", CallNumber = "SE 1.2 2004" },
                new Book { Title = "The Algorithm Design Manual", Author = "Steven Skiena", CallNumber = "SE 1.1 1997" },
                new Book { Title = "Refactoring to Patterns", Author = "Joshua Kerievsky", CallNumber = "SE 1.21 2004" },
                new Book { Title = "A Philosophy of Software Design", Author = "John Ousterhout", CallNumber = "SE 1.4 2018" });

                context.SaveChanges();
            }
        }
    }
}
