using Books_Spot.Data;
using Microsoft.EntityFrameworkCore;

namespace Books_Spot.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Books_SpotContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Books_SpotContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null Books_SpotContext");
                }

                // Look for any books.
                if (context.Book.Any())
                {
                    return;   // DB is already seeded
                }
                // If not seeded add books.
                context.Book.AddRange(
                    new Book
                    {
                        BookTitle = "The Republic",
                        Author = "Plato",
                        Publisher = "Digireads.com",
                        PublishingDate = DateTime.Parse("2008-01-1"),
                        Genre = "Political Philosophy",
                        ISBNCode = "1420931695",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "Fairy Tale",
                        Author = "Stephen King",
                        Publisher = "Scribner",
                        PublishingDate = DateTime.Parse("2022-09-6"),
                        Genre = "Horror",
                        ISBNCode = "1668002175",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "Anna Karenina",
                        Author = "Leo Tolstoy",
                        Publisher = "Signet",
                        PublishingDate = DateTime.Parse("2002-05-5"),
                        Genre = "Classics",
                        ISBNCode = "0451528611",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "The January 6 Report",
                        Author = "The January 6th Committee",
                        Publisher = "Harper Paperbacks",
                        PublishingDate = DateTime.Parse("2022-02-18"),
                        Genre = "Politics",
                        ISBNCode = "0063315505",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "Verity ",
                        Author = "Colleen Hoover",
                        Publisher = "Grand Central Publishing",
                        PublishingDate = DateTime.Parse("2021-09-26"),
                        Genre = "Psychological Thriller",
                        ISBNCode = "1538724731",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "The Divine Comedy",
                        Author = "Dante Alighieri",
                        Publisher = "Everyman's Library",
                        PublishingDate = DateTime.Parse("1995-02-1"),
                        Genre = "Classics",
                        ISBNCode = "0679433139",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "The Girl on the Train",
                        Author = "Paula Hawkins",
                        Publisher = "Riverhead Books",
                        PublishingDate = DateTime.Parse("2016-06-13"),
                        Genre = "Psychological Thriller",
                        ISBNCode = "1594634025",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "The Fault in Our Stars",
                        Author = "John Green",
                        Publisher = "Dutton",
                        PublishingDate = DateTime.Parse("2012-12-1"),
                        Genre = "Fiction",
                        ISBNCode = "9780525478812",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    },

                    new Book
                    {
                        BookTitle = "Divergent",
                        Author = "Veronica Roth",
                        Publisher = "Katherine Tegen Books",
                        PublishingDate = DateTime.Parse("2014-09-30"),
                        Genre = "Fiction",
                        ISBNCode = "0062387243",
                        BookStatus = "Available",
                        ReservedBy = "-",
                    }



                );
                context.SaveChanges();
            }
        }
    }
}
