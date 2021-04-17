using System;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DocUp.Dal.Context
{
    public sealed class DocUpContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<ClinicEntity> Clinics { get; set; }

        public DbSet<DeviceEntity> Devices { get; set; }

        public DbSet<DoctorEntity> Doctors { get; set; }

        public DbSet<IlnessEntity> Ilnesses { get; set; }

        public DbSet<PatientEntity> Patients { get; set; }

        public DbSet<PatientIlnessEntity> PatientIlnesses { get; set; }

        public DbSet<ReadingEntity> Readings { get; set; }

        public DbSet<VisitEntity> Visits { get; set; }


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
