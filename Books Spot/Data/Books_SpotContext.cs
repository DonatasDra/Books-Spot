using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Books_Spot.Models;

namespace Books_Spot.Data
{
    public class Books_SpotContext : DbContext
    {
        public Books_SpotContext (DbContextOptions<Books_SpotContext> options)
            : base(options)
        {
        }

        public DbSet<Books_Spot.Models.Book> Book { get; set; } = default!;
    }
}
