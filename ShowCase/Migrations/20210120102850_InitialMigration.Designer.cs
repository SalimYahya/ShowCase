﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShowCase.Data;

namespace ShowCase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210120102850_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Price = 531.73000000000002
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 2",
                            Price = 688.15999999999997
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 3",
                            Price = 249.47
                        },
                        new
                        {
                            Id = 4,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 4",
                            Price = 246.88999999999999
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 5",
                            Price = 484.00999999999999
                        },
                        new
                        {
                            Id = 6,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 6",
                            Price = 228.46000000000001
                        },
                        new
                        {
                            Id = 7,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 7",
                            Price = 361.75
                        },
                        new
                        {
                            Id = 8,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 8",
                            Price = 670.92999999999995
                        },
                        new
                        {
                            Id = 9,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 9",
                            Price = 369.36000000000001
                        },
                        new
                        {
                            Id = 10,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 10",
                            Price = 739.28999999999996
                        },
                        new
                        {
                            Id = 11,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 11",
                            Price = 125.2
                        },
                        new
                        {
                            Id = 12,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 2",
                            Price = 882.62
                        },
                        new
                        {
                            Id = 13,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 13",
                            Price = 520.05999999999995
                        },
                        new
                        {
                            Id = 14,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 14",
                            Price = 922.40999999999997
                        },
                        new
                        {
                            Id = 15,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 15",
                            Price = 542.05999999999995
                        },
                        new
                        {
                            Id = 16,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 16",
                            Price = 472.39999999999998
                        },
                        new
                        {
                            Id = 17,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 17",
                            Price = 836.72000000000003
                        },
                        new
                        {
                            Id = 18,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 18",
                            Price = 584.13999999999999
                        },
                        new
                        {
                            Id = 19,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 19",
                            Price = 825.86000000000001
                        },
                        new
                        {
                            Id = 20,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 20",
                            Price = 946.91999999999996
                        },
                        new
                        {
                            Id = 21,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 21",
                            Price = 460.85000000000002
                        },
                        new
                        {
                            Id = 22,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 22",
                            Price = 657.52999999999997
                        },
                        new
                        {
                            Id = 23,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 23",
                            Price = 324.12
                        },
                        new
                        {
                            Id = 24,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 24",
                            Price = 126.92
                        },
                        new
                        {
                            Id = 25,
                            Description = "Lorem Ipsum is simply dummy text",
                            Name = "Item 25",
                            Price = 248.06999999999999
                        });
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
#pragma warning restore 612, 618
        }
    }
}