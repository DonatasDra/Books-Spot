using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Books_Spot.Data;
using Books_Spot.Models;
using Microsoft.AspNetCore.Authorization;

namespace Books_Spot.Pages.Books
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Books_Spot.Data.Books_SpotContext _context;

        public DetailsModel(Books_Spot.Data.Books_SpotContext context)
        {
            _context = context;
        }

      public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
