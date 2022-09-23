using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books_Spot.Data;
using Books_Spot.Models;

namespace Books_Spot.Pages.Books
{
    public class ReservationModel : PageModel
    {
        private readonly Books_Spot.Data.Books_SpotContext _context;

        public ReservationModel(Books_Spot.Data.Books_SpotContext context)
        {
            _context = context;
        }

        
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var dataToUpdate = await _context.Book.FindAsync(id);
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }
            if(dataToUpdate.BookStatus != "Available")
            {
                return RedirectToPage("./ReservationError");
            }

            var book =  await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int ID)
        {
            //Add CRUD Update for BookStatus
            var dataToUpdate = await _context.Book.FindAsync(ID);

            if (dataToUpdate == null)
            {
                return NotFound();
            }
            
            if (await TryUpdateModelAsync<Book>(
                dataToUpdate,
                "book",
                s => s.BookStatus, s => s.ReservedBy))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}
