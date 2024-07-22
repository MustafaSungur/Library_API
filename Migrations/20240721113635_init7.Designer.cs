﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using libAPI.Data;

#nullable disable

namespace libAPI.Migrations
{
    [DbContext(typeof(libAPIContext))]
    [Migration("20240721113635_init7")]
    partial class init7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("libAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("AddressCityId")
                        .HasColumnType("smallint");

                    b.Property<short>("AddressCountryId")
                        .HasColumnType("smallint");

                    b.Property<string>("ClearAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("AddressCityId");

                    b.HasIndex("AddressCountryId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("libAPI.Models.AddressCity", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AddressCity");
                });

            modelBuilder.Entity("libAPI.Models.AddressCountry", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AddressCountry");
                });

            modelBuilder.Entity("libAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("GenderId")
                        .HasColumnType("smallint");

                    b.Property<long>("IdNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("GenderId");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("libAPI.Models.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Biography")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<short?>("DeadYear")
                        .HasColumnType("smallint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("libAPI.Models.AuthorBook", b =>
                {
                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("libAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBM")
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<short>("PageCount")
                        .HasColumnType("smallint");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrintCount")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<short>("PublishingYear")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("libAPI.Models.BorrowBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("BorrowBooks");
                });

            modelBuilder.Entity("libAPI.Models.BorrowHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPenaltyApplied")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("BorrowHistories");
                });

            modelBuilder.Entity("libAPI.Models.Category", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("libAPI.Models.Department", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("libAPI.Models.EducationalDegree", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EducationalDegree");
                });

            modelBuilder.Entity("libAPI.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("DepartmentId")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("ShiftId")
                        .HasColumnType("smallint");

                    b.Property<short>("TitleId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("TitleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("libAPI.Models.EmployeeTitle", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTitle");
                });

            modelBuilder.Entity("libAPI.Models.Genre", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("libAPI.Models.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("libAPI.Models.LanguageBook", b =>
                {
                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("LanguageId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("LanguageBook");
                });

            modelBuilder.Entity("libAPI.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("libAPI.Models.Member", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("EducationalDegreeId")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("EndBannedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<short>("PenaltyPoint")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("EducationalDegreeId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("libAPI.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("libAPI.Models.Shift", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("libAPI.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableCopies")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("libAPI.Models.SubCategory", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<short>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("libAPI.Models.SubCategoryBook", b =>
                {
                    b.Property<short>("SubCategoryId")
                        .HasColumnType("smallint");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("SubCategoryId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("SubCategoryBook");
                });

            modelBuilder.Entity("libAPI.Models.Address", b =>
                {
                    b.HasOne("libAPI.Models.AddressCity", "City")
                        .WithMany()
                        .HasForeignKey("AddressCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.AddressCountry", "Country")
                        .WithMany()
                        .HasForeignKey("AddressCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("libAPI.Models.ApplicationUser", b =>
                {
                    b.HasOne("libAPI.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.Genre", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("libAPI.Models.AuthorBook", b =>
                {
                    b.HasOne("libAPI.Models.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("libAPI.Models.Book", b =>
                {
                    b.HasOne("libAPI.Models.Location", "Location")
                        .WithMany("Books")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("libAPI.Models.BorrowBooks", b =>
                {
                    b.HasOne("libAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("libAPI.Models.BorrowHistory", b =>
                {
                    b.HasOne("libAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.Member", "Member")
                        .WithOne("BorrowingHistory")
                        .HasForeignKey("libAPI.Models.BorrowHistory", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("libAPI.Models.Employee", b =>
                {
                    b.HasOne("libAPI.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.EmployeeTitle", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Department");

                    b.Navigation("Shift");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("libAPI.Models.LanguageBook", b =>
                {
                    b.HasOne("libAPI.Models.Book", "Book")
                        .WithMany("LanguageBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.Language", "Language")
                        .WithMany("LanguageBooks")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("libAPI.Models.Member", b =>
                {
                    b.HasOne("libAPI.Models.EducationalDegree", "EducationalDegree")
                        .WithMany()
                        .HasForeignKey("EducationalDegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("EducationalDegree");
                });

            modelBuilder.Entity("libAPI.Models.Stock", b =>
                {
                    b.HasOne("libAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("libAPI.Models.SubCategory", b =>
                {
                    b.HasOne("libAPI.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("libAPI.Models.SubCategoryBook", b =>
                {
                    b.HasOne("libAPI.Models.Book", "Book")
                        .WithMany("SubCategoryBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("libAPI.Models.SubCategory", "SubCategory")
                        .WithMany("SubCategoryBooks")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("libAPI.Models.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("libAPI.Models.Book", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("LanguageBooks");

                    b.Navigation("SubCategoryBooks");
                });

            modelBuilder.Entity("libAPI.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("libAPI.Models.Language", b =>
                {
                    b.Navigation("LanguageBooks");
                });

            modelBuilder.Entity("libAPI.Models.Location", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("libAPI.Models.Member", b =>
                {
                    b.Navigation("BorrowingHistory");
                });

            modelBuilder.Entity("libAPI.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("libAPI.Models.SubCategory", b =>
                {
                    b.Navigation("SubCategoryBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
