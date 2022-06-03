
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                new Book
                {
                     //Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,
                    AuthorId = 2,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                 new Book
                 {
                      //Id = 2,
                     Title = "Herland",
                     GenreId = 2,
                     AuthorId = 3,
                     PageCount = 250,
                     PublishDate = new DateTime(2010, 05, 23)
                 },
                 new Book
                 {
                      //Id = 3,
                     Title = "Dune",
                     GenreId = 2,
                     AuthorId = 1,
                     PageCount = 540,
                     PublishDate = new DateTime(2001, 12, 21)
                 }

             );
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"

                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = " Romance",
                    }


              );

               
                context.Authors.AddRange(

                    new Author
                    {
                        Name = "Furkan",
                        Surname = "Korkmaz",
                        BirthDate = new DateTime(1982,6,12),
                      
                    },

                    new Author
                    {
                        Name = "Selin",
                        Surname = "Demirel",
                        BirthDate = new DateTime(1975,3,11),
                       
                    },

                    new Author
                    {
                        Name = "Mehmet Ateş",
                        Surname = "Özateş",
                        BirthDate = new DateTime(1988,5,10),
                       

                    }


                    );

                context.SaveChanges();
            }

        }
    }
}
