using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghete_Maria_Elena_L2.Data;
using Ghete_Maria_Elena_L2.Models;

namespace Ghete_Maria_Elena_L2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context _context;

        public IndexModel(Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b=>b.Publisher)
                .ToListAsync();
        }
    }
}
