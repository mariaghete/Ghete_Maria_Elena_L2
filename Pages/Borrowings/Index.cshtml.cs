using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghete_Maria_Elena_L2.Data;
using Ghete_Maria_Elena_L2.Models;

namespace Ghete_Maria_Elena_L2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context _context;

        public IndexModel(Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude (b=>b.Author)
                .Include(b => b.Member).ToListAsync();
        }
    }
}
