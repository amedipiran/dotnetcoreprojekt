﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.Data;

#nullable disable

namespace Projekt.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Projekt.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Romantik"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Deckare"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            City = "Stockholm",
                            Name = "BookWorld",
                            PhoneNumber = "08-1234567",
                            PostalCode = "12345",
                            State = "Stockholm",
                            StreetAddress = "Läsargatan 5"
                        },
                        new
                        {
                            Id = 3,
                            City = "Göteborg",
                            Name = "Reader's Haven",
                            PhoneNumber = "031-7654321",
                            PostalCode = "54321",
                            State = "Västra Götaland",
                            StreetAddress = "Bokvägen 10"
                        });
                });

            modelBuilder.Entity("Projekt.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Projekt.Models.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Carrier")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderShipped")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("TEXT");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("PaymenDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("PaymenDueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("Projekt.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ListPrice")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<double?>("Price100")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<double?>("Price50")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Frank Herbert",
                            CategoryId = 1,
                            Description = "Dune är en science fiction-roman skriven av Frank Herbert. Den utspelar sig i en avlägsen framtid där människan har koloniserat flera planeter och strider om kontrollen över en ökenplanet vid namn Arrakis. Boken följer Paul Atreides, en ung adelsman, när han navigerar genom politik, religion och intriger på Arrakis.",
                            ImageUrl = "",
                            ListPrice = 90.0,
                            Price = 100.0,
                            Price100 = 70.0,
                            Price50 = 80.0,
                            Title = "Dune"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Frank Herbert",
                            CategoryId = 1,
                            Description = "Dune Messiah är uppföljaren till Frank Herberts roman Dune. Boken utforskar konsekvenserna av händelserna i den första boken och följer Paul Atreides, nu känd som Muad'Dib, när han navigerar genom politiska och religiösa utmaningar på Arrakis och i galaxen.",
                            ImageUrl = "",
                            ListPrice = 100.0,
                            Price = 110.0,
                            Price100 = 80.0,
                            Price50 = 90.0,
                            Title = "Dune Messiah"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Frank Herbert",
                            CategoryId = 1,
                            Description = "Children of Dune är den tredje boken i Frank Herberts Dune-serie. Handlingen kretsar kring Paul Atreides barn, Leto II och Ghanima, när de konfronterar hot från både yttre och inre fiender medan de navigerar genom sin roll i Atreides arv och på Arrakis.",
                            ImageUrl = "",
                            ListPrice = 110.0,
                            Price = 120.0,
                            Price100 = 90.0,
                            Price50 = 100.0,
                            Title = "Children of Dune"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Frank Herbert",
                            CategoryId = 1,
                            Description = "God Emperor of Dune är den fjärde boken i Frank Herberts Dune-serie. Handlingen äger rum tusentals år efter händelserna i de tidigare böckerna och fokuserar på Leto II, son till Paul Atreides, som nu styr över Arrakis som en gudlik kejsare.",
                            ImageUrl = "",
                            ListPrice = 120.0,
                            Price = 130.0,
                            Price100 = 100.0,
                            Price50 = 110.0,
                            Title = "God Emperor of Dune"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Frank Herbert",
                            CategoryId = 1,
                            Description = "Heretics of Dune är den femte boken i Frank Herberts Dune-serie. Handlingen följer en grupp rebeller och dissidenter som kämpar mot det etablerade imperiets tyranni och religiösa dogmer på Arrakis och i den omgivande galaxen.",
                            ImageUrl = "",
                            ListPrice = 130.0,
                            Price = 140.0,
                            Price100 = 110.0,
                            Price50 = 120.0,
                            Title = "Heretics of Dune"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Frank Herbert",
                            CategoryId = 1,
                            Description = "Chapterhouse: Dune är den sjätte och sista boken i Frank Herberts Dune-serie. Handlingen kretsar kring intrigerna och konflikterna mellan olika fraktioner som strävar efter kontroll över det sista återstående exemplaret av den heliga kryddan på planeten Chapterhouse.",
                            ImageUrl = "",
                            ListPrice = 140.0,
                            Price = 150.0,
                            Price100 = 120.0,
                            Price50 = 130.0,
                            Title = "Chapterhouse: Dune"
                        });
                });

            modelBuilder.Entity("Projekt.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Projekt.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("TEXT");

                    b.HasIndex("CompanyId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt.Models.OrderDetail", b =>
                {
                    b.HasOne("Projekt.Models.OrderHeader", "OrderHeader")
                        .WithMany()
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Projekt.Models.OrderHeader", b =>
                {
                    b.HasOne("Projekt.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Projekt.Models.Product", b =>
                {
                    b.HasOne("Projekt.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Projekt.Models.ShoppingCart", b =>
                {
                    b.HasOne("Projekt.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Projekt.Models.ApplicationUser", b =>
                {
                    b.HasOne("Projekt.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
