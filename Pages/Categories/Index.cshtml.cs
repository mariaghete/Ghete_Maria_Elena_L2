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

namespace Ghete_Maria_Elena_L2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context _context;

        public IndexModel(Ghete_Maria_Elena_L2.Data.Ghete_Maria_Elena_L2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = CategoryData.Categories
                    .Where(c => c.ID == id.Value)
                    .Single();

                CategoryData.Books = selectedCategory.BookCategories
                    .Select(bc => bc.Book);
            }
        }
    }
}
