﻿// <auto-generated />
using System;
using Familyregister.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RegisterWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Models.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("EyeColor")
                        .HasColumnType("text");

                    b.Property<int?>("FamilyIdFamily")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("HairColor")
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("IdJob")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FamilyIdFamily");

                    b.ToTable("Adults");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 24,
                            EyeColor = "blue",
                            FirstName = "Maria",
                            HairColor = "Brown",
                            Height = 167,
                            IdJob = 1,
                            LastName = "Asenova",
                            Sex = "F",
                            Weight = 56f
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            EyeColor = "Green",
                            FirstName = "Kasper",
                            HairColor = "Black",
                            Height = 168,
                            IdJob = 2,
                            LastName = "Andersen",
                            Sex = "F",
                            Weight = 72f
                        });
                });

            modelBuilder.Entity("Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("EyeColor")
                        .HasColumnType("text");

                    b.Property<int?>("FamilyIdFamily")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("HairColor")
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FamilyIdFamily");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("Models.Family", b =>
                {
                    b.Property<int>("IdFamily")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HouseNumber")
                        .HasColumnType("integer");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.HasKey("IdFamily");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Models.Interest", b =>
                {
                    b.Property<int>("IdInterest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ChildId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("IdInterest");

                    b.HasIndex("ChildId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("Models.Job", b =>
                {
                    b.Property<int>("IdJob")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdAdult")
                        .HasColumnType("integer");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<int>("Salary")
                        .HasColumnType("integer");

                    b.HasKey("IdJob");

                    b.HasIndex("IdAdult")
                        .IsUnique();

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            IdJob = 1,
                            IdAdult = 1,
                            JobTitle = "Project Manager",
                            Salary = 45000
                        },
                        new
                        {
                            IdJob = 2,
                            IdAdult = 2,
                            JobTitle = "Head of Marketing",
                            Salary = 36000
                        });
                });

            modelBuilder.Entity("Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int?>("ChildId")
                        .HasColumnType("integer");

                    b.Property<int?>("FamilyIdFamily")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Species")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyIdFamily");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Adult", b =>
                {
                    b.HasOne("Models.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyIdFamily");
                });

            modelBuilder.Entity("Models.Child", b =>
                {
                    b.HasOne("Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyIdFamily");
                });

            modelBuilder.Entity("Models.Interest", b =>
                {
                    b.HasOne("Models.Child", null)
                        .WithMany("Interests")
                        .HasForeignKey("ChildId");
                });

            modelBuilder.Entity("Models.Job", b =>
                {
                    b.HasOne("Models.Adult", "Adult")
                        .WithOne("JobTitle")
                        .HasForeignKey("Models.Job", "IdAdult")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adult");
                });

            modelBuilder.Entity("Models.Pet", b =>
                {
                    b.HasOne("Models.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("Models.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyIdFamily");
                });

            modelBuilder.Entity("Models.Adult", b =>
                {
                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("Models.Child", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Models.Family", b =>
                {
                    b.Navigation("Adults");

                    b.Navigation("Children");

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}