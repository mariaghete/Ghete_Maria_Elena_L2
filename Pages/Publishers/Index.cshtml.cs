using Ghete_Maria_Elena_L2.Data;
using Ghete_Maria_Elena_L2.Models;
using Ghete_Maria_Elena_L2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghete_Maria_Elena_L2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context _context;

        public IndexModel(Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context context)
        {
            _context = context;
        }

        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            PublisherData = new PublisherIndexData();

            PublisherData.Publishers = await _context.Publisher
                .Include(p => p.Books)
                    .ThenInclude(b => b.Author)
                .OrderBy(p => p.PublisherName)
                .ToListAsync();

            if (id != null)
            {
                PublisherID = id.Value;
                var publisher = PublisherData.Publishers
                    .Where(p => p.ID == id.Value)
                    .Single();

                PublisherData.Books = publisher.Books;
            }
        }
    }
}