using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Books_Spot.Data;
using Books_Spot.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books_Spot.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Books_Spot.Data.Books_SpotContext _context;

        public IndexModel(Books_Spot.Data.Books_SpotContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? BookTitle { get; set; }

        public IList<Book> Authors { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? Author { get; set; }

        public IList<Book> Publishers { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? Publisher { get; set; }

        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? BookGenre { get; set; }

        public IList<Book> PublishingDates { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? PublishingDate { get; set; }

        public IList<Book> ISBNCodes { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? ISBNCode { get; set; }

        public SelectList? BookStatuses { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? BookStatus { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                var books = from m in _context.Book
                            select m;



                IQueryable<string> genreQuery = from m in _context.Book
                                                orderby m.Genre
                                                select m.Genre;


                IQueryable<string> genreQuery2 = from m in _context.Book
                                                 orderby m.BookStatus
                                                 select m.BookStatus;

                if (!string.IsNullOrEmpty(BookTitle))
                {
                    books = books.Where(s => s.BookTitle.Contains(BookTitle));
                }

                if (!string.IsNullOrEmpty(Author))
                {
                    books = books.Where(s => s.Author.Contains(Author));
                }

                if (!string.IsNullOrEmpty(Publisher))
                {
                    books = books.Where(s => s.Publisher.Contains(Publisher));
                }
                if (!string.IsNullOrEmpty(PublishingDate))
                {
                    books = books.Where(s => s.PublishingDate.ToString().Contains(PublishingDate));
                }

                if (!string.IsNullOrEmpty(ISBNCode))
                {
                    books = books.Where(s => s.ISBNCode.Contains(ISBNCode));
                }


                if (!string.IsNullOrEmpty(BookStatus))
                {
                    books = books.Where(x => x.BookStatus == BookStatus);
                }
                BookStatuses = new SelectList(await genreQuery2.Distinct().ToListAsync());

                if (!string.IsNullOrEmpty(BookGenre))
                {
                    books = books.Where(x => x.Genre == BookGenre);
                }
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
                Book = await books.ToListAsync();
            }
        }
    }
}
