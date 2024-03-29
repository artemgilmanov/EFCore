﻿// <auto-generated />
using System;
using EFCore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Infrastructure.Migrations
{
  [DbContext(typeof(ApplicationDbContext))]
  partial class ApplicationDbContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
      modelBuilder
          .HasAnnotation("ProductVersion", "8.0.0")
          .HasAnnotation("Relational:MaxIdentifierLength", 128);

      SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

      modelBuilder.Entity("EFCore.Domain.AuthorEntity", builder =>
          {
            builder.Property<int>("Author_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Author_Id"));

            builder.Property<DateTime>("BirthDate")
                      .HasColumnType("datetime2");

            builder.Property<string>("FirstName")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar(50)");

            builder.Property<int>("LastName")
                      .HasColumnType("int");

            builder.HasKey("Author_Id");

            builder.ToTable("Authors", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.BookAuthorMap", builder =>
          {
            builder.Property<int>("Author_Id")
                      .HasColumnType("int");

            builder.Property<int>("Book_Id")
                      .HasColumnType("int");

            builder.HasKey("Author_Id", "Book_Id");

            builder.HasIndex("Book_Id");

            builder.ToTable("BookAuthorMap", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.BookDetailEntity", builder =>
          {
            builder.Property<int>("BookDetail_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("BookDetail_Id"));

            builder.Property<int>("Book_Id")
                      .HasColumnType("int");

            builder.Property<int>("NumberOfPages")
                      .HasColumnType("int");

            builder.Property<int>("NumberofChapters")
                      .HasColumnType("int");

            builder.Property<string>("Weight")
                      .HasColumnType("nvarchar(max)");

            builder.HasKey("BookDetail_Id");

            builder.HasIndex("Book_Id")
                      .IsUnique();

            builder.ToTable("BookDetails", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.BookEntity", builder =>
          {
            builder.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Id"));

            builder.Property<string>("Author")
                      .HasColumnType("nvarchar(max)");

            builder.Property<string>("Isbn")
                      .IsRequired()
                      .HasMaxLength(20)
                      .HasColumnType("nvarchar(20)");

            builder.Property<decimal>("Price")
                      .HasColumnType("decimal(18,2)");

            builder.Property<int>("Publisher_Id")
                      .HasColumnType("int");

            builder.Property<string>("Title")
                      .HasColumnType("nvarchar(max)");

            builder.HasKey("Id");

            builder.HasIndex("Publisher_Id");

            builder.ToTable("Books", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_AuthorEntity", builder =>
          {
            builder.Property<int>("Author_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Author_Id"));

            builder.Property<DateTime>("BirthDate")
                      .HasColumnType("datetime2");

            builder.Property<string>("FirstName")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar(50)");

            builder.Property<int>("LastName")
                      .HasColumnType("int");

            builder.HasKey("Author_Id");

            builder.ToTable("Fluent_Authors", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_BookAuthorMap", builder =>
          {
            builder.Property<int>("Book_Id")
                      .HasColumnType("int");

            builder.Property<int>("Author_Id")
                      .HasColumnType("int");

            builder.HasKey("Book_Id", "Author_Id");

            builder.HasIndex("Author_Id");

            builder.ToTable("Fluent_BookAuthorMap", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_BookDetailEntity", builder =>
          {
            builder.Property<int>("BookDetail_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("BookDetail_Id"));

            builder.Property<int>("Book_Id")
                      .HasColumnType("int");

            builder.Property<int>("NumberOfPages")
                      .HasColumnType("int");

            builder.Property<int>("NumberofChapters")
                      .HasColumnType("int");

            builder.Property<string>("Weight")
                      .HasColumnType("nvarchar(max)");

            builder.HasKey("BookDetail_Id");

            builder.HasIndex("Book_Id")
                      .IsUnique();

            builder.ToTable("Fluent_BookDetails", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_BookEntity", builder =>
          {
            builder.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Id"));

            builder.Property<string>("Author")
                      .HasColumnType("nvarchar(max)");

            builder.Property<string>("Isbn")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar(50)");

            builder.Property<decimal>("Price")
                      .HasPrecision(10, 5)
                      .HasColumnType("decimal(10,5)");

            builder.Property<int>("Publisher_Id")
                      .HasColumnType("int");

            builder.Property<string>("Title")
                      .HasColumnType("nvarchar(max)");

            builder.HasKey("Id");

            builder.HasIndex("Publisher_Id");

            builder.ToTable("Fluent_Books", (string)null);

            builder.HasData(
                      new
                  {
                    Id = 1,
                    Author = "George Orwell",
                    Isbn = "978-0451524935",
                    Price = 9.99m,
                    Publisher_Id = 0,
                    Title = "1984"
                  },
                      new
                  {
                    Id = 2,
                    Author = "Aldous Huxley",
                    Isbn = "978-0060850524",
                    Price = 9.99m,
                    Publisher_Id = 0,
                    Title = "Brave New World"
                  },
                      new
                  {
                    Id = 3,
                    Author = "Ray Bradbury",
                    Isbn = "978-1451673319",
                    Price = 9.99m,
                    Publisher_Id = 0,
                    Title = "Fahrenheit 451"
                  });
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_PublisherEntity", builder =>
          {
            builder.Property<int>("Publisher_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Publisher_Id"));

            builder.Property<string>("Location")
                      .HasColumnType("nvarchar(max)");

            builder.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            builder.HasKey("Publisher_Id");

            builder.ToTable("Fluent_Publishers", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_SubCategoryEntity", builder =>
          {
            builder.Property<int>("Publisher_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Publisher_Id"));

            builder.Property<string>("Name")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar(50)");

            builder.HasKey("Publisher_Id");

            builder.ToTable("Fluent_SubCategories", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.Fluent_GenreEntity", builder =>
          {
            builder.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Id"));

            builder.Property<int>("Display")
                      .HasColumnType("int");

            builder.Property<string>("Name")
                      .HasColumnType("nvarchar(max)");

            builder.HasKey("Id");

            builder.ToTable("Fluent_Genres", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.GenreEntity", builder =>
          {
            builder.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Id"));

            builder.Property<int>("Display")
                      .HasColumnType("int")
                      .HasColumnName("GenreDisplay");

            builder.Property<string>("Name")
                      .HasColumnType("nvarchar(max)")
                      .HasColumnName("GenreName");

            builder.HasKey("Id");

            builder.ToTable("Genres", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.PublisherEntity", builder =>
          {
            builder.Property<int>("Publisher_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Publisher_Id"));

            builder.Property<string>("Location")
                      .HasColumnType("nvarchar(max)");

            builder.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            builder.HasKey("Publisher_Id");

            builder.ToTable("Publishers", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.SubCategoryEntity", builder =>
          {
            builder.Property<int>("Publisher_Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Publisher_Id"));

            builder.Property<string>("Name")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("nvarchar(50)");

            builder.HasKey("Publisher_Id");

            builder.ToTable("SubCategories", (string)null);
          });

      modelBuilder.Entity("EFCore.Domain.BookAuthorMap", builder =>
          {
            builder.HasOne("EFCore.Domain.AuthorEntity", "Author")
                      .WithMany("BookAuthorMap")
                      .HasForeignKey("Author_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.HasOne("EFCore.Domain.BookEntity", "Book")
                      .WithMany("BookAuthorMap")
                      .HasForeignKey("Book_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.Navigation("Author");

            builder.Navigation("Book");
          });

      modelBuilder.Entity("EFCore.Domain.BookDetailEntity", builder =>
          {
            builder.HasOne("EFCore.Domain.BookEntity", "Book")
                      .WithOne("BookDetail")
                      .HasForeignKey("EFCore.Domain.BookDetailEntity", "Book_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.Navigation("Book");
          });

      modelBuilder.Entity("EFCore.Domain.BookEntity", builder =>
          {
            builder.HasOne("EFCore.Domain.PublisherEntity", "Publisher")
                      .WithMany("Books")
                      .HasForeignKey("Publisher_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.Navigation("Publisher");
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_BookAuthorMap", builder =>
          {
            builder.HasOne("EFCore.Domain.FluentEntities.Fluent_AuthorEntity", "Author")
                      .WithMany("BookAuthorMaps")
                      .HasForeignKey("Author_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.HasOne("EFCore.Domain.FluentEntities.Fluent_BookEntity", "Book")
                      .WithMany("BookAuthorMaps")
                      .HasForeignKey("Book_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.Navigation("Author");

            builder.Navigation("Book");
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_BookDetailEntity", builder =>
          {
            builder.HasOne("EFCore.Domain.FluentEntities.Fluent_BookEntity", "Book")
                      .WithOne("BookDetail")
                      .HasForeignKey("EFCore.Domain.FluentEntities.Fluent_BookDetailEntity", "Book_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.Navigation("Book");
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_BookEntity", builder =>
          {
            builder.HasOne("EFCore.Domain.FluentEntities.Fluent_PublisherEntity", "Publisher")
                      .WithMany("Books")
                      .HasForeignKey("Publisher_Id")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            builder.Navigation("Publisher");
          });

      modelBuilder.Entity("EFCore.Domain.AuthorEntity", builder =>
          {
            builder.Navigation("BookAuthorMap");
          });

      modelBuilder.Entity("EFCore.Domain.BookEntity", builder =>
          {
            builder.Navigation("BookAuthorMap");

            builder.Navigation("BookDetail");
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_AuthorEntity", builder =>
          {
            builder.Navigation("BookAuthorMaps");
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_BookEntity", builder =>
          {
            builder.Navigation("BookAuthorMaps");

            builder.Navigation("BookDetail");
          });

      modelBuilder.Entity("EFCore.Domain.FluentEntities.Fluent_PublisherEntity", builder =>
          {
            builder.Navigation("Books");
          });

      modelBuilder.Entity("EFCore.Domain.PublisherEntity", builder =>
          {
            builder.Navigation("Books");
          });
    }
  }
}
