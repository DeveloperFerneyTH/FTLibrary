using FT.Library.Core.entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FT.Library.Core
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
