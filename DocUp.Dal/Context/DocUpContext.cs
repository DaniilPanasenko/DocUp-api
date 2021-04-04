using System;
using Microsoft.EntityFrameworkCore;

namespace DocUp.Dal.Context
{
    public sealed class DocUpContext : DbContext
    {

        public DocUpContext(DbContextOptions<DocUpContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
