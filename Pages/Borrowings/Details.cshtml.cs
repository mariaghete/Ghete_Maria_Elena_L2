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
    public class DetailsModel : PageModel
    {
        private readonly Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context _context;

        public DetailsModel(Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
