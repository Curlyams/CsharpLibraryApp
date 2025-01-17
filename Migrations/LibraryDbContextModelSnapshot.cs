﻿// <auto-generated />
using System;
using LibrarySystems.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PractiveApplication_1.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("LibrarySystems.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BorrowDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibrarySystems.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibrarySystems.Models.Book", b =>
                {
                    b.HasOne("LibrarySystems.Models.Member", null)
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("LibrarySystems.Models.Member", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
