using System;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DocUp.Dal.Context
{
    public sealed class DocUpContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }

        public DocUpContext(DbContextOptions<DocUpContext> options)
            : base(options)
        {
            NpgsqlConnection.ClearAllPools();
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
