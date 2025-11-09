using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ghete_Maria_Elena_L2.Models;

namespace Ghete_Maria_Elena_L2.Data
{
    public class Ghete_Maria_Elena_L2Context : DbContext
    {
        public Ghete_Maria_Elena_L2Context (DbContextOptions<Ghete_Maria_Elena_L2Context> options)
            : base(options)
        {
        }

        public DbSet<Ghete_Maria_Elena_L2.Models.Book> Book { get; set; } = default!;
        public DbSet<Ghete_Maria_Elena_L2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Ghete_Maria_Elena_L2.Models.Author> Author { get; set; } = default!;
        public DbSet<Ghete_Maria_Elena_L2.Models.Category> Category { get; set; } = default!;
        public DbSet<Ghete_Maria_Elena_L2.Models.Member> Member { get; set; } = default!;
        public DbSet<Ghete_Maria_Elena_L2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
