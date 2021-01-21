﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShowCase.Data;

namespace ShowCase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ShowCase.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ShowCase.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 1",
                            Price = 126.29000000000001
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 2",
                            Price = 597.63999999999999
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 3",
                            Price = 361.05000000000001
                        },
                        new
                        {
                            Id = 4,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 4",
                            Price = 304.87
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 5",
                            Price = 311.93000000000001
                        },
                        new
                        {
                            Id = 6,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 6",
                            Price = 240.19
                        },
                        new
                        {
                            Id = 7,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 7",
                            Price = 431.11000000000001
                        },
                        new
                        {
                            Id = 8,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 8",
                            Price = 932.73000000000002
                        },
                        new
                        {
                            Id = 9,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 9",
                            Price = 866.86000000000001
                        },
                        new
                        {
                            Id = 10,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 10",
                            Price = 929.23000000000002
                        },
                        new
                        {
                            Id = 11,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 11",
                            Price = 977.44000000000005
                        },
                        new
                        {
                            Id = 12,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 2",
                            Price = 570.88
                        },
                        new
                        {
                            Id = 13,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 13",
                            Price = 74.480000000000004
                        },
                        new
                        {
                            Id = 14,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 14",
                            Price = 323.68000000000001
                        },
                        new
                        {
                            Id = 15,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 15",
                            Price = 103.22
                        },
                        new
                        {
                            Id = 16,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 16",
                            Price = 144.72
                        },
                        new
                        {
                            Id = 17,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 17",
                            Price = 382.97000000000003
                        },
                        new
                        {
                            Id = 18,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 18",
                            Price = 692.71000000000004
                        },
                        new
                        {
                            Id = 19,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 19",
                            Price = 997.29999999999995
                        },
                        new
                        {
                            Id = 20,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 20",
                            Price = 670.26999999999998
                        },
                        new
                        {
                            Id = 21,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 21",
                            Price = 771.0
                        },
                        new
                        {
                            Id = 22,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 22",
                            Price = 419.29000000000002
                        },
                        new
                        {
                            Id = 23,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 23",
                            Price = 454.25999999999999
                        },
                        new
                        {
                            Id = 24,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 24",
                            Price = 428.44999999999999
                        },
                        new
                        {
                            Id = 25,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 25",
                            Price = 565.10000000000002
                        });
                });

            modelBuilder.Entity("ShowCase.Models.ShoppingCart", b =>
                {
                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserID", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCart");
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
                    b.HasOne("ShowCase.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShowCase.Models.ApplicationUser", null)
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

                    b.HasOne("ShowCase.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShowCase.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShowCase.Models.ShoppingCart", b =>
                {
                    b.HasOne("ShowCase.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ApplicationUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShowCase.Models.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShowCase.Models.ApplicationUser", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("ShowCase.Models.Product", b =>
                {
                    b.Navigation("ShoppingCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
