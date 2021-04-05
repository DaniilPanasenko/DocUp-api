﻿// <auto-generated />
using System;
using DocUp.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DocUp.Dal.Migrations
{
    [DbContext(typeof(DocUpContext))]
    [Migration("20210405225545_DB2")]
    partial class DB2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DocUp.Dal.Entities.AccountEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.ClinicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Place")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.DeviceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IlnessId")
                        .HasColumnType("integer");

                    b.Property<int?>("PatientIlnessId")
                        .HasColumnType("integer");

                    b.Property<int>("Seria")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IlnessId");

                    b.HasIndex("PatientIlnessId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.DoctorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("ClinicId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Position")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Surname")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClinicId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.IlnessEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClinicCall")
                        .HasColumnType("integer");

                    b.Property<int>("DoctorCall")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WatcherCall")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Ilnesses");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.PatientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Surname")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("WatcherName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("WatcherPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("WatcherSurname")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.PatientIlnessEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<int>("IlnessId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("IlnessId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientIlnesses");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.ReadingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Percent")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Readings");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.VisitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.ClinicEntity", b =>
                {
                    b.HasOne("DocUp.Dal.Entities.AccountEntity", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.DeviceEntity", b =>
                {
                    b.HasOne("DocUp.Dal.Entities.IlnessEntity", "Ilness")
                        .WithMany()
                        .HasForeignKey("IlnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocUp.Dal.Entities.PatientIlnessEntity", "PatientIlness")
                        .WithMany()
                        .HasForeignKey("PatientIlnessId");

                    b.Navigation("Ilness");

                    b.Navigation("PatientIlness");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.DoctorEntity", b =>
                {
                    b.HasOne("DocUp.Dal.Entities.AccountEntity", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocUp.Dal.Entities.ClinicEntity", "Clinic")
                        .WithMany("Doctors")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.PatientEntity", b =>
                {
                    b.HasOne("DocUp.Dal.Entities.AccountEntity", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocUp.Dal.Entities.DoctorEntity", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.PatientIlnessEntity", b =>
                {
                    b.HasOne("DocUp.Dal.Entities.DeviceEntity", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.HasOne("DocUp.Dal.Entities.IlnessEntity", "Ilness")
                        .WithMany()
                        .HasForeignKey("IlnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocUp.Dal.Entities.PatientEntity", "Patient")
                        .WithMany("Ilnesses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Ilness");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.VisitEntity", b =>
                {
                    b.HasOne("DocUp.Dal.Entities.PatientEntity", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.ClinicEntity", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.DoctorEntity", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("DocUp.Dal.Entities.PatientEntity", b =>
                {
                    b.Navigation("Ilnesses");
                });
#pragma warning restore 612, 618
        }
    }
}
