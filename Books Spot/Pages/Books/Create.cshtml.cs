using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Books_Spot.Data;
using Books_Spot.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Books_Spot.Pages.Books
{
    [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        private readonly Books_Spot.Data.Books_SpotContext _context;

        public CreateModel(Books_Spot.Data.Books_SpotContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
