using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShowCase.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Vat = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalExcludeVat = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    TotalIncludeVat = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CVCCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProduct",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProduct", x => new { x.InvoiceId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSolds",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SoldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSolds", x => new { x.ProductId, x.SoldId });
                    table.ForeignKey(
                        name: "FK_ProductSolds_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSolds_Solds_SoldId",
                        column: x => x.SoldId,
                        principalTable: "Solds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nike" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adidas" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skechers" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puma" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clarcks" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 668, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6527), "Lorem Ipsum is simply dummy text", "Item 668", 355.20999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6528) },
                    { 667, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6525), "Lorem Ipsum is simply dummy text", "Item 667", 760.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6525) },
                    { 666, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6522), "Lorem Ipsum is simply dummy text", "Item 666", 868.28999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6523) },
                    { 665, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6520), "Lorem Ipsum is simply dummy text", "Item 665", 207.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6521) },
                    { 664, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6518), "Lorem Ipsum is simply dummy text", "Item 664", 542.42999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6519) },
                    { 661, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6511), "Lorem Ipsum is simply dummy text", "Item 661", 251.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6512) },
                    { 662, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6513), "Lorem Ipsum is simply dummy text", "Item 662", 113.65000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6514) },
                    { 669, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6529), "Lorem Ipsum is simply dummy text", "Item 669", 622.57000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6530) },
                    { 660, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6509), "Lorem Ipsum is simply dummy text", "Item 660", 596.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6510) },
                    { 659, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6507), "Lorem Ipsum is simply dummy text", "Item 659", 539.0, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6507) },
                    { 658, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6504), "Lorem Ipsum is simply dummy text", "Item 658", 845.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6505) },
                    { 663, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6516), "Lorem Ipsum is simply dummy text", "Item 663", 295.54000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6516) },
                    { 670, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6532), "Lorem Ipsum is simply dummy text", "Item 670", 548.46000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6532) },
                    { 673, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6538), "Lorem Ipsum is simply dummy text", "Item 673", 304.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6539) },
                    { 672, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6536), "Lorem Ipsum is simply dummy text", "Item 672", 987.07000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6537) },
                    { 657, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6502), "Lorem Ipsum is simply dummy text", "Item 657", 592.83000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6503) },
                    { 674, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6540), "Lorem Ipsum is simply dummy text", "Item 674", 461.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6541) },
                    { 675, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6543), "Lorem Ipsum is simply dummy text", "Item 675", 337.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6543) },
                    { 676, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6545), "Lorem Ipsum is simply dummy text", "Item 676", 359.93000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6546) },
                    { 677, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6547), "Lorem Ipsum is simply dummy text", "Item 677", 827.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6548) },
                    { 678, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6549), "Lorem Ipsum is simply dummy text", "Item 678", 980.80999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6550) },
                    { 679, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6552), "Lorem Ipsum is simply dummy text", "Item 679", 776.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6552) },
                    { 680, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6554), "Lorem Ipsum is simply dummy text", "Item 680", 580.71000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6555) },
                    { 681, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6556), "Lorem Ipsum is simply dummy text", "Item 681", 335.06, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6557) },
                    { 682, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6559), "Lorem Ipsum is simply dummy text", "Item 682", 147.06999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6560) },
                    { 683, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6561), "Lorem Ipsum is simply dummy text", "Item 683", 35.170000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6562) },
                    { 684, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6563), "Lorem Ipsum is simply dummy text", "Item 684", 45.189999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6564) },
                    { 671, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6534), "Lorem Ipsum is simply dummy text", "Item 671", 731.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6534) },
                    { 656, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6500), "Lorem Ipsum is simply dummy text", "Item 656", 877.80999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6501) },
                    { 653, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6493), "Lorem Ipsum is simply dummy text", "Item 653", 812.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6494) },
                    { 654, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6496), "Lorem Ipsum is simply dummy text", "Item 654", 529.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6496) },
                    { 627, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6404), "Lorem Ipsum is simply dummy text", "Item 627", 573.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6405) },
                    { 628, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6406), "Lorem Ipsum is simply dummy text", "Item 628", 494.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6407) },
                    { 629, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6408), "Lorem Ipsum is simply dummy text", "Item 629", 497.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6409) },
                    { 630, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6411), "Lorem Ipsum is simply dummy text", "Item 630", 655.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6412) },
                    { 631, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6413), "Lorem Ipsum is simply dummy text", "Item 631", 948.29999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6414) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 632, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6415), "Lorem Ipsum is simply dummy text", "Item 632", 393.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6416) },
                    { 633, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6418), "Lorem Ipsum is simply dummy text", "Item 633", 167.41999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6418) },
                    { 634, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6420), "Lorem Ipsum is simply dummy text", "Item 634", 160.18000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6421) },
                    { 635, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6422), "Lorem Ipsum is simply dummy text", "Item 635", 394.42000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6423) },
                    { 636, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6424), "Lorem Ipsum is simply dummy text", "Item 636", 379.83999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6425) },
                    { 637, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6427), "Lorem Ipsum is simply dummy text", "Item 637", 433.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6427) },
                    { 638, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6429), "Lorem Ipsum is simply dummy text", "Item 638", 532.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6430) },
                    { 639, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6431), "Lorem Ipsum is simply dummy text", "Item 639", 469.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6432) },
                    { 640, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6434), "Lorem Ipsum is simply dummy text", "Item 640", 562.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6434) },
                    { 641, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6436), "Lorem Ipsum is simply dummy text", "Item 641", 432.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6437) },
                    { 642, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6438), "Lorem Ipsum is simply dummy text", "Item 642", 805.94000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6439) },
                    { 643, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6440), "Lorem Ipsum is simply dummy text", "Item 643", 94.120000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6441) },
                    { 644, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6443), "Lorem Ipsum is simply dummy text", "Item 644", 884.42999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6443) },
                    { 645, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6445), "Lorem Ipsum is simply dummy text", "Item 645", 153.19, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6446) },
                    { 646, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6447), "Lorem Ipsum is simply dummy text", "Item 646", 283.94999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6448) },
                    { 647, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6480), "Lorem Ipsum is simply dummy text", "Item 647", 915.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6481) },
                    { 648, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6482), "Lorem Ipsum is simply dummy text", "Item 648", 426.82999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6483) },
                    { 649, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6484), "Lorem Ipsum is simply dummy text", "Item 649", 459.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6485) },
                    { 650, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6487), "Lorem Ipsum is simply dummy text", "Item 650", 451.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6487) },
                    { 651, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6489), "Lorem Ipsum is simply dummy text", "Item 651", 203.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6490) },
                    { 652, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6491), "Lorem Ipsum is simply dummy text", "Item 652", 355.69999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6492) },
                    { 685, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6565), "Lorem Ipsum is simply dummy text", "Item 685", 451.42000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6566) },
                    { 655, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6498), "Lorem Ipsum is simply dummy text", "Item 655", 684.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6499) },
                    { 686, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6567), "Lorem Ipsum is simply dummy text", "Item 686", 592.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6568) },
                    { 689, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6574), "Lorem Ipsum is simply dummy text", "Item 689", 475.63999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6575) },
                    { 688, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6572), "Lorem Ipsum is simply dummy text", "Item 688", 638.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6573) },
                    { 721, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6661), "Lorem Ipsum is simply dummy text", "Item 721", 287.80000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6661) },
                    { 722, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6663), "Lorem Ipsum is simply dummy text", "Item 722", 122.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6664) },
                    { 723, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6665), "Lorem Ipsum is simply dummy text", "Item 723", 879.57000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6666) },
                    { 724, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6667), "Lorem Ipsum is simply dummy text", "Item 724", 105.95999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6668) },
                    { 725, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6669), "Lorem Ipsum is simply dummy text", "Item 725", 761.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6670) },
                    { 726, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6671), "Lorem Ipsum is simply dummy text", "Item 726", 142.80000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6672) },
                    { 727, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6674), "Lorem Ipsum is simply dummy text", "Item 727", 993.10000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6674) },
                    { 728, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6676), "Lorem Ipsum is simply dummy text", "Item 728", 430.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6677) },
                    { 729, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6678), "Lorem Ipsum is simply dummy text", "Item 729", 151.19, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6679) },
                    { 730, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6680), "Lorem Ipsum is simply dummy text", "Item 730", 18.640000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6681) },
                    { 731, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6682), "Lorem Ipsum is simply dummy text", "Item 731", 849.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6683) },
                    { 732, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6685), "Lorem Ipsum is simply dummy text", "Item 732", 275.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6685) },
                    { 733, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6687), "Lorem Ipsum is simply dummy text", "Item 733", 303.76999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6687) },
                    { 734, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6689), "Lorem Ipsum is simply dummy text", "Item 734", 491.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6689) },
                    { 735, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6691), "Lorem Ipsum is simply dummy text", "Item 735", 57.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6692) },
                    { 736, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6731), "Lorem Ipsum is simply dummy text", "Item 736", 774.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6732) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 737, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6734), "Lorem Ipsum is simply dummy text", "Item 737", 342.80000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6735) },
                    { 738, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6736), "Lorem Ipsum is simply dummy text", "Item 738", 124.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6737) },
                    { 739, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6738), "Lorem Ipsum is simply dummy text", "Item 739", 324.44999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6739) },
                    { 740, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6741), "Lorem Ipsum is simply dummy text", "Item 740", 234.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6741) },
                    { 741, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6743), "Lorem Ipsum is simply dummy text", "Item 741", 541.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6743) },
                    { 742, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6745), "Lorem Ipsum is simply dummy text", "Item 742", 229.55000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6746) },
                    { 743, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6747), "Lorem Ipsum is simply dummy text", "Item 743", 446.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6748) },
                    { 744, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6749), "Lorem Ipsum is simply dummy text", "Item 744", 151.03, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6750) },
                    { 745, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6751), "Lorem Ipsum is simply dummy text", "Item 745", 466.32999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6752) },
                    { 746, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6754), "Lorem Ipsum is simply dummy text", "Item 746", 174.97999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6754) },
                    { 747, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6756), "Lorem Ipsum is simply dummy text", "Item 747", 519.07000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6757) },
                    { 720, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6658), "Lorem Ipsum is simply dummy text", "Item 720", 614.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6659) },
                    { 719, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6656), "Lorem Ipsum is simply dummy text", "Item 719", 91.010000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6657) },
                    { 718, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6654), "Lorem Ipsum is simply dummy text", "Item 718", 250.34, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6655) },
                    { 717, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6652), "Lorem Ipsum is simply dummy text", "Item 717", 78.480000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6653) },
                    { 626, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6401), "Lorem Ipsum is simply dummy text", "Item 626", 250.41999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6402) },
                    { 690, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6576), "Lorem Ipsum is simply dummy text", "Item 690", 516.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6577) },
                    { 691, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6578), "Lorem Ipsum is simply dummy text", "Item 691", 787.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6579) },
                    { 692, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6596), "Lorem Ipsum is simply dummy text", "Item 692", 588.25999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6597) },
                    { 693, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6599), "Lorem Ipsum is simply dummy text", "Item 693", 993.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6600) },
                    { 694, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6601), "Lorem Ipsum is simply dummy text", "Item 694", 873.17999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6602) },
                    { 695, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6603), "Lorem Ipsum is simply dummy text", "Item 695", 310.42000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6604) },
                    { 696, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6606), "Lorem Ipsum is simply dummy text", "Item 696", 319.16000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6606) },
                    { 697, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6608), "Lorem Ipsum is simply dummy text", "Item 697", 510.41000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6608) },
                    { 698, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6610), "Lorem Ipsum is simply dummy text", "Item 698", 551.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6611) },
                    { 699, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6612), "Lorem Ipsum is simply dummy text", "Item 699", 677.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6613) },
                    { 700, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6614), "Lorem Ipsum is simply dummy text", "Item 700", 284.91000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6615) },
                    { 701, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6617), "Lorem Ipsum is simply dummy text", "Item 701", 523.21000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6617) },
                    { 687, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6570), "Lorem Ipsum is simply dummy text", "Item 687", 580.49000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6570) },
                    { 702, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6619), "Lorem Ipsum is simply dummy text", "Item 702", 560.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6620) },
                    { 704, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6623), "Lorem Ipsum is simply dummy text", "Item 704", 911.04999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6624) },
                    { 705, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6626), "Lorem Ipsum is simply dummy text", "Item 705", 720.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6627) },
                    { 706, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6628), "Lorem Ipsum is simply dummy text", "Item 706", 216.53999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6629) },
                    { 707, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6630), "Lorem Ipsum is simply dummy text", "Item 707", 51.579999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6631) },
                    { 708, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6632), "Lorem Ipsum is simply dummy text", "Item 708", 350.93000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6633) },
                    { 709, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6635), "Lorem Ipsum is simply dummy text", "Item 709", 191.55000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6635) },
                    { 710, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6637), "Lorem Ipsum is simply dummy text", "Item 710", 324.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6637) },
                    { 711, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6639), "Lorem Ipsum is simply dummy text", "Item 711", 50.270000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6640) },
                    { 712, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6641), "Lorem Ipsum is simply dummy text", "Item 712", 612.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6642) },
                    { 713, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6643), "Lorem Ipsum is simply dummy text", "Item 713", 69.200000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6644) },
                    { 714, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6645), "Lorem Ipsum is simply dummy text", "Item 714", 958.28999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6646) },
                    { 715, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6648), "Lorem Ipsum is simply dummy text", "Item 715", 261.56999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6648) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 716, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6650), "Lorem Ipsum is simply dummy text", "Item 716", 104.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6650) },
                    { 703, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6621), "Lorem Ipsum is simply dummy text", "Item 703", 804.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6622) },
                    { 625, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6399), "Lorem Ipsum is simply dummy text", "Item 625", 864.65999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6400) },
                    { 622, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6392), "Lorem Ipsum is simply dummy text", "Item 622", 921.65999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6393) },
                    { 623, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6394), "Lorem Ipsum is simply dummy text", "Item 623", 865.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6395) },
                    { 533, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6139), "Lorem Ipsum is simply dummy text", "Item 533", 867.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6140) },
                    { 534, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6141), "Lorem Ipsum is simply dummy text", "Item 534", 273.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6142) },
                    { 535, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6144), "Lorem Ipsum is simply dummy text", "Item 535", 905.35000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6144) },
                    { 536, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6146), "Lorem Ipsum is simply dummy text", "Item 536", 607.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6147) },
                    { 537, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6148), "Lorem Ipsum is simply dummy text", "Item 537", 956.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6149) },
                    { 538, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6150), "Lorem Ipsum is simply dummy text", "Item 538", 654.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6151) },
                    { 539, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6153), "Lorem Ipsum is simply dummy text", "Item 539", 154.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6153) },
                    { 540, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6155), "Lorem Ipsum is simply dummy text", "Item 540", 989.0, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6155) },
                    { 541, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6157), "Lorem Ipsum is simply dummy text", "Item 541", 180.34, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6158) },
                    { 542, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6159), "Lorem Ipsum is simply dummy text", "Item 542", 220.41, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6160) },
                    { 543, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6161), "Lorem Ipsum is simply dummy text", "Item 543", 248.66999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6162) },
                    { 544, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6163), "Lorem Ipsum is simply dummy text", "Item 544", 111.73, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6164) },
                    { 545, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6166), "Lorem Ipsum is simply dummy text", "Item 545", 614.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6166) },
                    { 546, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6168), "Lorem Ipsum is simply dummy text", "Item 546", 12.699999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6169) },
                    { 547, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6170), "Lorem Ipsum is simply dummy text", "Item 547", 363.41000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6171) },
                    { 548, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6172), "Lorem Ipsum is simply dummy text", "Item 548", 118.26000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6173) },
                    { 549, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6174), "Lorem Ipsum is simply dummy text", "Item 549", 480.44999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6175) },
                    { 550, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6177), "Lorem Ipsum is simply dummy text", "Item 550", 528.22000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6177) },
                    { 551, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6179), "Lorem Ipsum is simply dummy text", "Item 551", 843.55999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6180) },
                    { 552, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6181), "Lorem Ipsum is simply dummy text", "Item 552", 490.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6182) },
                    { 553, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6183), "Lorem Ipsum is simply dummy text", "Item 553", 905.94000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6184) },
                    { 554, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6185), "Lorem Ipsum is simply dummy text", "Item 554", 576.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6186) },
                    { 555, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6188), "Lorem Ipsum is simply dummy text", "Item 555", 233.62, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6188) },
                    { 556, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6190), "Lorem Ipsum is simply dummy text", "Item 556", 490.83999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6191) },
                    { 557, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6192), "Lorem Ipsum is simply dummy text", "Item 557", 395.56999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6193) },
                    { 558, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6223), "Lorem Ipsum is simply dummy text", "Item 558", 526.0, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6224) },
                    { 559, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6225), "Lorem Ipsum is simply dummy text", "Item 559", 210.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6226) },
                    { 532, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6137), "Lorem Ipsum is simply dummy text", "Item 532", 504.42000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6138) },
                    { 560, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6228), "Lorem Ipsum is simply dummy text", "Item 560", 766.21000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6228) },
                    { 531, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6135), "Lorem Ipsum is simply dummy text", "Item 531", 531.95000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6136) },
                    { 529, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6130), "Lorem Ipsum is simply dummy text", "Item 529", 845.07000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6131) },
                    { 502, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5998), "Lorem Ipsum is simply dummy text", "Item 502", 974.70000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5999) },
                    { 503, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6000), "Lorem Ipsum is simply dummy text", "Item 503", 151.38, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6001) },
                    { 504, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6003), "Lorem Ipsum is simply dummy text", "Item 504", 417.47000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6003) },
                    { 505, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6005), "Lorem Ipsum is simply dummy text", "Item 505", 967.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6006) },
                    { 506, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6007), "Lorem Ipsum is simply dummy text", "Item 506", 698.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6008) },
                    { 507, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6009), "Lorem Ipsum is simply dummy text", "Item 507", 873.76999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6010) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 508, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6012), "Lorem Ipsum is simply dummy text", "Item 508", 935.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6012) },
                    { 509, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6014), "Lorem Ipsum is simply dummy text", "Item 509", 643.92999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6015) },
                    { 510, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6016), "Lorem Ipsum is simply dummy text", "Item 510", 343.70999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6017) },
                    { 511, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6018), "Lorem Ipsum is simply dummy text", "Item 511", 268.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6019) },
                    { 512, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6021), "Lorem Ipsum is simply dummy text", "Item 512", 80.959999999999994, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6021) },
                    { 513, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6023), "Lorem Ipsum is simply dummy text", "Item 513", 179.08000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6024) },
                    { 514, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6097), "Lorem Ipsum is simply dummy text", "Item 514", 249.11000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6098) },
                    { 515, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6100), "Lorem Ipsum is simply dummy text", "Item 515", 684.48000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6101) },
                    { 516, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6102), "Lorem Ipsum is simply dummy text", "Item 516", 637.91999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6103) },
                    { 517, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6104), "Lorem Ipsum is simply dummy text", "Item 517", 672.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6105) },
                    { 518, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6106), "Lorem Ipsum is simply dummy text", "Item 518", 36.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6107) },
                    { 519, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6109), "Lorem Ipsum is simply dummy text", "Item 519", 102.39, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6109) },
                    { 520, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6111), "Lorem Ipsum is simply dummy text", "Item 520", 559.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6112) },
                    { 521, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6113), "Lorem Ipsum is simply dummy text", "Item 521", 298.33999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6114) },
                    { 522, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6115), "Lorem Ipsum is simply dummy text", "Item 522", 478.19, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6116) },
                    { 523, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6117), "Lorem Ipsum is simply dummy text", "Item 523", 579.13, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6118) },
                    { 524, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6119), "Lorem Ipsum is simply dummy text", "Item 524", 625.38, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6120) },
                    { 525, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6122), "Lorem Ipsum is simply dummy text", "Item 525", 206.59, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6122) },
                    { 526, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6124), "Lorem Ipsum is simply dummy text", "Item 526", 201.31999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6125) },
                    { 527, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6126), "Lorem Ipsum is simply dummy text", "Item 527", 326.27999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6127) },
                    { 528, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6128), "Lorem Ipsum is simply dummy text", "Item 528", 417.08999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6129) },
                    { 530, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6133), "Lorem Ipsum is simply dummy text", "Item 530", 231.77000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6133) },
                    { 561, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6230), "Lorem Ipsum is simply dummy text", "Item 561", 372.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6231) },
                    { 562, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6232), "Lorem Ipsum is simply dummy text", "Item 562", 456.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6233) },
                    { 563, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6234), "Lorem Ipsum is simply dummy text", "Item 563", 90.780000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6235) },
                    { 596, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6306), "Lorem Ipsum is simply dummy text", "Item 596", 723.65999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6307) },
                    { 597, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6308), "Lorem Ipsum is simply dummy text", "Item 597", 129.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6309) },
                    { 598, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6310), "Lorem Ipsum is simply dummy text", "Item 598", 836.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6311) },
                    { 599, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6313), "Lorem Ipsum is simply dummy text", "Item 599", 299.98000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6313) },
                    { 600, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6315), "Lorem Ipsum is simply dummy text", "Item 600", 850.41999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6316) },
                    { 601, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6317), "Lorem Ipsum is simply dummy text", "Item 601", 799.47000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6318) },
                    { 602, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6319), "Lorem Ipsum is simply dummy text", "Item 602", 458.06999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6320) },
                    { 603, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6349), "Lorem Ipsum is simply dummy text", "Item 603", 774.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6350) },
                    { 604, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6352), "Lorem Ipsum is simply dummy text", "Item 604", 403.67000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6353) },
                    { 605, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6354), "Lorem Ipsum is simply dummy text", "Item 605", 847.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6355) },
                    { 606, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6356), "Lorem Ipsum is simply dummy text", "Item 606", 825.84000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6357) },
                    { 607, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6359), "Lorem Ipsum is simply dummy text", "Item 607", 608.33000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6360) },
                    { 608, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6361), "Lorem Ipsum is simply dummy text", "Item 608", 792.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6362) },
                    { 609, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6363), "Lorem Ipsum is simply dummy text", "Item 609", 197.46000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6364) },
                    { 610, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6366), "Lorem Ipsum is simply dummy text", "Item 610", 155.69, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6366) },
                    { 611, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6368), "Lorem Ipsum is simply dummy text", "Item 611", 261.31, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6369) },
                    { 612, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6370), "Lorem Ipsum is simply dummy text", "Item 612", 928.16999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6371) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 613, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6372), "Lorem Ipsum is simply dummy text", "Item 613", 515.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6373) },
                    { 614, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6374), "Lorem Ipsum is simply dummy text", "Item 614", 16.98, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6375) },
                    { 615, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6377), "Lorem Ipsum is simply dummy text", "Item 615", 928.29999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6377) },
                    { 616, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6379), "Lorem Ipsum is simply dummy text", "Item 616", 164.58000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6380) },
                    { 617, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6381), "Lorem Ipsum is simply dummy text", "Item 617", 520.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6382) },
                    { 618, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6383), "Lorem Ipsum is simply dummy text", "Item 618", 773.92999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6384) },
                    { 619, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6386), "Lorem Ipsum is simply dummy text", "Item 619", 23.960000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6386) },
                    { 620, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6388), "Lorem Ipsum is simply dummy text", "Item 620", 770.62, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6388) },
                    { 621, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6390), "Lorem Ipsum is simply dummy text", "Item 621", 165.88, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6391) },
                    { 748, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6758), "Lorem Ipsum is simply dummy text", "Item 748", 35.68, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6759) },
                    { 595, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6304), "Lorem Ipsum is simply dummy text", "Item 595", 616.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6305) },
                    { 594, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6302), "Lorem Ipsum is simply dummy text", "Item 594", 387.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6302) },
                    { 593, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6299), "Lorem Ipsum is simply dummy text", "Item 593", 443.81999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6300) },
                    { 592, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6297), "Lorem Ipsum is simply dummy text", "Item 592", 430.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6298) },
                    { 564, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6236), "Lorem Ipsum is simply dummy text", "Item 564", 412.16000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6237) },
                    { 565, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6238), "Lorem Ipsum is simply dummy text", "Item 565", 811.75999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6239) },
                    { 566, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6241), "Lorem Ipsum is simply dummy text", "Item 566", 764.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6241) },
                    { 567, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6243), "Lorem Ipsum is simply dummy text", "Item 567", 213.22999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6243) },
                    { 568, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6245), "Lorem Ipsum is simply dummy text", "Item 568", 905.35000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6246) },
                    { 569, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6247), "Lorem Ipsum is simply dummy text", "Item 569", 343.75999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6248) },
                    { 570, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6249), "Lorem Ipsum is simply dummy text", "Item 570", 76.790000000000006, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6250) },
                    { 571, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6252), "Lorem Ipsum is simply dummy text", "Item 571", 681.16999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6252) },
                    { 572, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6254), "Lorem Ipsum is simply dummy text", "Item 572", 17.719999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6254) },
                    { 573, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6256), "Lorem Ipsum is simply dummy text", "Item 573", 882.49000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6257) },
                    { 574, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6258), "Lorem Ipsum is simply dummy text", "Item 574", 113.40000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6259) },
                    { 575, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6260), "Lorem Ipsum is simply dummy text", "Item 575", 378.69, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6261) },
                    { 576, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6262), "Lorem Ipsum is simply dummy text", "Item 576", 77.930000000000007, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6263) },
                    { 624, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6397), "Lorem Ipsum is simply dummy text", "Item 624", 929.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6397) },
                    { 577, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6265), "Lorem Ipsum is simply dummy text", "Item 577", 229.53, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6265) },
                    { 579, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6269), "Lorem Ipsum is simply dummy text", "Item 579", 10.6, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6270) },
                    { 580, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6271), "Lorem Ipsum is simply dummy text", "Item 580", 193.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6272) },
                    { 581, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6273), "Lorem Ipsum is simply dummy text", "Item 581", 837.90999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6274) },
                    { 582, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6276), "Lorem Ipsum is simply dummy text", "Item 582", 208.02000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6276) },
                    { 583, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6278), "Lorem Ipsum is simply dummy text", "Item 583", 936.63999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6278) },
                    { 584, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6280), "Lorem Ipsum is simply dummy text", "Item 584", 316.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6281) },
                    { 585, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6282), "Lorem Ipsum is simply dummy text", "Item 585", 388.19999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6283) },
                    { 586, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6284), "Lorem Ipsum is simply dummy text", "Item 586", 41.140000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6285) },
                    { 587, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6286), "Lorem Ipsum is simply dummy text", "Item 587", 598.48000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6287) },
                    { 588, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6289), "Lorem Ipsum is simply dummy text", "Item 588", 291.57999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6289) },
                    { 589, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6291), "Lorem Ipsum is simply dummy text", "Item 589", 40.119999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6291) },
                    { 590, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6293), "Lorem Ipsum is simply dummy text", "Item 590", 414.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6294) },
                    { 591, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6295), "Lorem Ipsum is simply dummy text", "Item 591", 212.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6296) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 578, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6267), "Lorem Ipsum is simply dummy text", "Item 578", 467.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6268) },
                    { 749, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6760), "Lorem Ipsum is simply dummy text", "Item 749", 611.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6761) },
                    { 752, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6767), "Lorem Ipsum is simply dummy text", "Item 752", 260.06999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6768) },
                    { 751, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6765), "Lorem Ipsum is simply dummy text", "Item 751", 240.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6766) },
                    { 909, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7330), "Lorem Ipsum is simply dummy text", "Item 909", 159.94999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7330) },
                    { 910, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7332), "Lorem Ipsum is simply dummy text", "Item 910", 984.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7333) },
                    { 911, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7334), "Lorem Ipsum is simply dummy text", "Item 911", 986.28999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7335) },
                    { 912, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7337), "Lorem Ipsum is simply dummy text", "Item 912", 328.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7337) },
                    { 913, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7365), "Lorem Ipsum is simply dummy text", "Item 913", 579.90999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7366) },
                    { 914, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7368), "Lorem Ipsum is simply dummy text", "Item 914", 482.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7368) },
                    { 915, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7370), "Lorem Ipsum is simply dummy text", "Item 915", 794.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7371) },
                    { 916, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7372), "Lorem Ipsum is simply dummy text", "Item 916", 738.07000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7373) },
                    { 917, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7375), "Lorem Ipsum is simply dummy text", "Item 917", 767.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7375) },
                    { 918, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7377), "Lorem Ipsum is simply dummy text", "Item 918", 660.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7377) },
                    { 919, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7379), "Lorem Ipsum is simply dummy text", "Item 919", 800.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7380) },
                    { 920, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7381), "Lorem Ipsum is simply dummy text", "Item 920", 657.65999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7382) },
                    { 921, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7383), "Lorem Ipsum is simply dummy text", "Item 921", 797.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7384) },
                    { 922, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7385), "Lorem Ipsum is simply dummy text", "Item 922", 637.16999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7386) },
                    { 923, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7387), "Lorem Ipsum is simply dummy text", "Item 923", 895.91999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7388) },
                    { 924, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7390), "Lorem Ipsum is simply dummy text", "Item 924", 923.63999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7390) },
                    { 925, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7392), "Lorem Ipsum is simply dummy text", "Item 925", 445.83999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7393) },
                    { 926, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7394), "Lorem Ipsum is simply dummy text", "Item 926", 512.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7395) },
                    { 927, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7397), "Lorem Ipsum is simply dummy text", "Item 927", 145.08000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7397) },
                    { 928, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7399), "Lorem Ipsum is simply dummy text", "Item 928", 575.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7399) },
                    { 929, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7401), "Lorem Ipsum is simply dummy text", "Item 929", 718.15999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7402) },
                    { 930, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7403), "Lorem Ipsum is simply dummy text", "Item 930", 529.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7404) },
                    { 931, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7405), "Lorem Ipsum is simply dummy text", "Item 931", 297.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7406) },
                    { 932, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7408), "Lorem Ipsum is simply dummy text", "Item 932", 395.81999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7408) },
                    { 933, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7410), "Lorem Ipsum is simply dummy text", "Item 933", 884.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7411) },
                    { 934, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7412), "Lorem Ipsum is simply dummy text", "Item 934", 700.33000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7413) },
                    { 935, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7414), "Lorem Ipsum is simply dummy text", "Item 935", 7.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7415) },
                    { 908, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7327), "Lorem Ipsum is simply dummy text", "Item 908", 975.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7328) },
                    { 936, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7416), "Lorem Ipsum is simply dummy text", "Item 936", 56.899999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7417) },
                    { 907, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7325), "Lorem Ipsum is simply dummy text", "Item 907", 23.780000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7326) },
                    { 905, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7321), "Lorem Ipsum is simply dummy text", "Item 905", 301.91000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7322) },
                    { 878, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7260), "Lorem Ipsum is simply dummy text", "Item 878", 528.79999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7260) },
                    { 879, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7262), "Lorem Ipsum is simply dummy text", "Item 879", 311.17000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7263) },
                    { 880, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7264), "Lorem Ipsum is simply dummy text", "Item 880", 250.08000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7265) },
                    { 881, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7266), "Lorem Ipsum is simply dummy text", "Item 881", 531.75999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7267) },
                    { 882, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7269), "Lorem Ipsum is simply dummy text", "Item 882", 568.41999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7270) },
                    { 883, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7271), "Lorem Ipsum is simply dummy text", "Item 883", 387.10000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7272) },
                    { 884, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7274), "Lorem Ipsum is simply dummy text", "Item 884", 99.299999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7274) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 885, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7276), "Lorem Ipsum is simply dummy text", "Item 885", 34.259999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7277) },
                    { 886, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7278), "Lorem Ipsum is simply dummy text", "Item 886", 252.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7279) },
                    { 887, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7280), "Lorem Ipsum is simply dummy text", "Item 887", 523.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7281) },
                    { 888, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7283), "Lorem Ipsum is simply dummy text", "Item 888", 262.27999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7283) },
                    { 889, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7285), "Lorem Ipsum is simply dummy text", "Item 889", 215.03999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7286) },
                    { 890, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7287), "Lorem Ipsum is simply dummy text", "Item 890", 919.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7288) },
                    { 891, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7290), "Lorem Ipsum is simply dummy text", "Item 891", 825.66999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7290) },
                    { 892, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7292), "Lorem Ipsum is simply dummy text", "Item 892", 931.44000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7293) },
                    { 893, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7294), "Lorem Ipsum is simply dummy text", "Item 893", 961.80999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7295) },
                    { 894, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7296), "Lorem Ipsum is simply dummy text", "Item 894", 176.28, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7297) },
                    { 895, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7299), "Lorem Ipsum is simply dummy text", "Item 895", 185.15000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7300) },
                    { 896, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7301), "Lorem Ipsum is simply dummy text", "Item 896", 100.48999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7302) },
                    { 897, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7303), "Lorem Ipsum is simply dummy text", "Item 897", 450.79000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7304) },
                    { 898, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7305), "Lorem Ipsum is simply dummy text", "Item 898", 417.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7306) },
                    { 899, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7308), "Lorem Ipsum is simply dummy text", "Item 899", 644.78999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7308) },
                    { 900, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7310), "Lorem Ipsum is simply dummy text", "Item 900", 610.84000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7311) },
                    { 901, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7312), "Lorem Ipsum is simply dummy text", "Item 901", 242.81999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7313) },
                    { 902, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7314), "Lorem Ipsum is simply dummy text", "Item 902", 474.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7315) },
                    { 903, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7316), "Lorem Ipsum is simply dummy text", "Item 903", 568.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7317) },
                    { 904, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7319), "Lorem Ipsum is simply dummy text", "Item 904", 520.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7320) },
                    { 906, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7323), "Lorem Ipsum is simply dummy text", "Item 906", 12.199999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7324) },
                    { 937, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7419), "Lorem Ipsum is simply dummy text", "Item 937", 0.40000000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7419) },
                    { 938, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7421), "Lorem Ipsum is simply dummy text", "Item 938", 866.32000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7422) },
                    { 939, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7423), "Lorem Ipsum is simply dummy text", "Item 939", 797.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7424) },
                    { 972, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7525), "Lorem Ipsum is simply dummy text", "Item 972", 901.37, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7525) },
                    { 973, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7527), "Lorem Ipsum is simply dummy text", "Item 973", 863.15999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7528) },
                    { 974, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7529), "Lorem Ipsum is simply dummy text", "Item 974", 778.82000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7530) },
                    { 975, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7531), "Lorem Ipsum is simply dummy text", "Item 975", 428.69999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7532) },
                    { 976, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7534), "Lorem Ipsum is simply dummy text", "Item 976", 249.34999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7534) },
                    { 977, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7536), "Lorem Ipsum is simply dummy text", "Item 977", 534.84000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7537) },
                    { 978, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7538), "Lorem Ipsum is simply dummy text", "Item 978", 664.94000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7539) },
                    { 979, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7540), "Lorem Ipsum is simply dummy text", "Item 979", 990.17999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7541) },
                    { 980, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7543), "Lorem Ipsum is simply dummy text", "Item 980", 948.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7543) },
                    { 981, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7545), "Lorem Ipsum is simply dummy text", "Item 981", 160.53999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7546) },
                    { 982, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7547), "Lorem Ipsum is simply dummy text", "Item 982", 665.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7548) },
                    { 983, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7550), "Lorem Ipsum is simply dummy text", "Item 983", 193.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7551) },
                    { 984, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7552), "Lorem Ipsum is simply dummy text", "Item 984", 271.07999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7553) },
                    { 985, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7554), "Lorem Ipsum is simply dummy text", "Item 985", 197.08000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7555) },
                    { 986, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7556), "Lorem Ipsum is simply dummy text", "Item 986", 507.56, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7557) },
                    { 987, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7559), "Lorem Ipsum is simply dummy text", "Item 987", 778.79999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7559) },
                    { 988, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7561), "Lorem Ipsum is simply dummy text", "Item 988", 896.88, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7562) },
                    { 989, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7563), "Lorem Ipsum is simply dummy text", "Item 989", 887.38, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7564) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 990, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7565), "Lorem Ipsum is simply dummy text", "Item 990", 401.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7566) },
                    { 991, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7567), "Lorem Ipsum is simply dummy text", "Item 991", 477.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7568) },
                    { 992, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7570), "Lorem Ipsum is simply dummy text", "Item 992", 356.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7570) },
                    { 993, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7572), "Lorem Ipsum is simply dummy text", "Item 993", 791.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7573) },
                    { 994, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7574), "Lorem Ipsum is simply dummy text", "Item 994", 7.54, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7575) },
                    { 995, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7576), "Lorem Ipsum is simply dummy text", "Item 995", 154.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7577) },
                    { 996, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7579), "Lorem Ipsum is simply dummy text", "Item 996", 780.84000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7579) },
                    { 997, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7581), "Lorem Ipsum is simply dummy text", "Item 997", 291.33999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7582) },
                    { 998, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7583), "Lorem Ipsum is simply dummy text", "Item 998", 472.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7584) },
                    { 971, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7522), "Lorem Ipsum is simply dummy text", "Item 971", 737.66999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7523) },
                    { 970, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7520), "Lorem Ipsum is simply dummy text", "Item 970", 737.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7521) },
                    { 969, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7517), "Lorem Ipsum is simply dummy text", "Item 969", 475.25999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7518) },
                    { 968, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7515), "Lorem Ipsum is simply dummy text", "Item 968", 879.58000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7516) },
                    { 940, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7425), "Lorem Ipsum is simply dummy text", "Item 940", 22.059999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7426) },
                    { 941, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7427), "Lorem Ipsum is simply dummy text", "Item 941", 228.96000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7428) },
                    { 942, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7429), "Lorem Ipsum is simply dummy text", "Item 942", 548.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7430) },
                    { 943, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7432), "Lorem Ipsum is simply dummy text", "Item 943", 102.33, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7433) },
                    { 944, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7434), "Lorem Ipsum is simply dummy text", "Item 944", 230.97999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7435) },
                    { 945, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7436), "Lorem Ipsum is simply dummy text", "Item 945", 933.46000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7437) },
                    { 946, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7439), "Lorem Ipsum is simply dummy text", "Item 946", 497.44, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7439) },
                    { 947, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7441), "Lorem Ipsum is simply dummy text", "Item 947", 351.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7442) },
                    { 948, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7443), "Lorem Ipsum is simply dummy text", "Item 948", 479.30000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7444) },
                    { 949, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7445), "Lorem Ipsum is simply dummy text", "Item 949", 382.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7446) },
                    { 950, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7448), "Lorem Ipsum is simply dummy text", "Item 950", 447.07999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7448) },
                    { 951, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7450), "Lorem Ipsum is simply dummy text", "Item 951", 332.79000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7451) },
                    { 952, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7452), "Lorem Ipsum is simply dummy text", "Item 952", 790.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7453) },
                    { 877, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7257), "Lorem Ipsum is simply dummy text", "Item 877", 813.71000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7258) },
                    { 953, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7454), "Lorem Ipsum is simply dummy text", "Item 953", 617.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7455) },
                    { 955, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7459), "Lorem Ipsum is simply dummy text", "Item 955", 812.95000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7459) },
                    { 956, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7461), "Lorem Ipsum is simply dummy text", "Item 956", 605.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7461) },
                    { 957, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7463), "Lorem Ipsum is simply dummy text", "Item 957", 578.92999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7464) },
                    { 958, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7492), "Lorem Ipsum is simply dummy text", "Item 958", 644.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7493) },
                    { 959, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7495), "Lorem Ipsum is simply dummy text", "Item 959", 74.939999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7495) },
                    { 960, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7497), "Lorem Ipsum is simply dummy text", "Item 960", 789.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7498) },
                    { 961, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7499), "Lorem Ipsum is simply dummy text", "Item 961", 867.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7500) },
                    { 962, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7502), "Lorem Ipsum is simply dummy text", "Item 962", 448.13, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7502) },
                    { 963, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7504), "Lorem Ipsum is simply dummy text", "Item 963", 257.19999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7505) },
                    { 964, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7506), "Lorem Ipsum is simply dummy text", "Item 964", 630.08000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7507) },
                    { 965, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7508), "Lorem Ipsum is simply dummy text", "Item 965", 686.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7509) },
                    { 966, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7511), "Lorem Ipsum is simply dummy text", "Item 966", 590.47000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7512) },
                    { 967, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7513), "Lorem Ipsum is simply dummy text", "Item 967", 444.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7514) },
                    { 954, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7456), "Lorem Ipsum is simply dummy text", "Item 954", 987.13, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7457) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 876, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7255), "Lorem Ipsum is simply dummy text", "Item 876", 748.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7256) },
                    { 875, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7253), "Lorem Ipsum is simply dummy text", "Item 875", 630.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7254) },
                    { 874, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7251), "Lorem Ipsum is simply dummy text", "Item 874", 903.29999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7251) },
                    { 784, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6930), "Lorem Ipsum is simply dummy text", "Item 784", 945.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6942) },
                    { 785, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6950), "Lorem Ipsum is simply dummy text", "Item 785", 777.96000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6952) },
                    { 786, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6955), "Lorem Ipsum is simply dummy text", "Item 786", 589.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6956) },
                    { 787, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6958), "Lorem Ipsum is simply dummy text", "Item 787", 815.17999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6959) },
                    { 788, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6962), "Lorem Ipsum is simply dummy text", "Item 788", 241.52000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6963) },
                    { 789, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6965), "Lorem Ipsum is simply dummy text", "Item 789", 494.05000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6966) },
                    { 790, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6969), "Lorem Ipsum is simply dummy text", "Item 790", 656.98000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6970) },
                    { 791, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6973), "Lorem Ipsum is simply dummy text", "Item 791", 94.319999999999993, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6974) },
                    { 792, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6976), "Lorem Ipsum is simply dummy text", "Item 792", 644.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6977) },
                    { 793, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6978), "Lorem Ipsum is simply dummy text", "Item 793", 974.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6979) },
                    { 794, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6980), "Lorem Ipsum is simply dummy text", "Item 794", 746.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6981) },
                    { 795, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6983), "Lorem Ipsum is simply dummy text", "Item 795", 11.43, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6983) },
                    { 796, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6985), "Lorem Ipsum is simply dummy text", "Item 796", 920.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6986) },
                    { 797, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6987), "Lorem Ipsum is simply dummy text", "Item 797", 29.809999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6988) },
                    { 798, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6989), "Lorem Ipsum is simply dummy text", "Item 798", 273.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6990) },
                    { 799, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6991), "Lorem Ipsum is simply dummy text", "Item 799", 675.94000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6992) },
                    { 800, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6994), "Lorem Ipsum is simply dummy text", "Item 800", 691.90999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6994) },
                    { 801, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6996), "Lorem Ipsum is simply dummy text", "Item 801", 866.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6997) },
                    { 802, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6998), "Lorem Ipsum is simply dummy text", "Item 802", 941.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6999) },
                    { 803, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7000), "Lorem Ipsum is simply dummy text", "Item 803", 134.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7001) },
                    { 804, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7002), "Lorem Ipsum is simply dummy text", "Item 804", 124.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7003) },
                    { 805, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7005), "Lorem Ipsum is simply dummy text", "Item 805", 443.47000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7005) },
                    { 806, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7007), "Lorem Ipsum is simply dummy text", "Item 806", 286.31999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7008) },
                    { 807, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7009), "Lorem Ipsum is simply dummy text", "Item 807", 334.18000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7010) },
                    { 808, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7011), "Lorem Ipsum is simply dummy text", "Item 808", 604.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7012) },
                    { 809, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7013), "Lorem Ipsum is simply dummy text", "Item 809", 988.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7014) },
                    { 810, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7016), "Lorem Ipsum is simply dummy text", "Item 810", 938.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7016) },
                    { 783, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6922), "Lorem Ipsum is simply dummy text", "Item 783", 819.34000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6924) },
                    { 782, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6919), "Lorem Ipsum is simply dummy text", "Item 782", 957.41999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6920) },
                    { 781, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6914), "Lorem Ipsum is simply dummy text", "Item 781", 623.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6915) },
                    { 780, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6903), "Lorem Ipsum is simply dummy text", "Item 780", 586.47000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6908) },
                    { 501, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5996), "Lorem Ipsum is simply dummy text", "Item 501", 969.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5997) },
                    { 753, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6769), "Lorem Ipsum is simply dummy text", "Item 753", 460.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6770) },
                    { 754, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6772), "Lorem Ipsum is simply dummy text", "Item 754", 62.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6772) },
                    { 755, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6774), "Lorem Ipsum is simply dummy text", "Item 755", 997.10000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6775) },
                    { 756, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6776), "Lorem Ipsum is simply dummy text", "Item 756", 400.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6777) },
                    { 757, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6778), "Lorem Ipsum is simply dummy text", "Item 757", 680.58000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6779) },
                    { 758, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6781), "Lorem Ipsum is simply dummy text", "Item 758", 698.30999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6781) },
                    { 759, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6783), "Lorem Ipsum is simply dummy text", "Item 759", 149.59, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6784) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 760, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6785), "Lorem Ipsum is simply dummy text", "Item 760", 577.95000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6786) },
                    { 761, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6788), "Lorem Ipsum is simply dummy text", "Item 761", 223.44, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6788) },
                    { 762, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6790), "Lorem Ipsum is simply dummy text", "Item 762", 620.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6791) },
                    { 763, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6792), "Lorem Ipsum is simply dummy text", "Item 763", 199.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6793) },
                    { 764, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6794), "Lorem Ipsum is simply dummy text", "Item 764", 172.91, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6795) },
                    { 811, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7018), "Lorem Ipsum is simply dummy text", "Item 811", 724.35000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7019) },
                    { 765, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6796), "Lorem Ipsum is simply dummy text", "Item 765", 475.08999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6797) },
                    { 767, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6801), "Lorem Ipsum is simply dummy text", "Item 767", 308.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6802) },
                    { 768, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6804), "Lorem Ipsum is simply dummy text", "Item 768", 578.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6805) },
                    { 769, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6808), "Lorem Ipsum is simply dummy text", "Item 769", 900.78999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6809) },
                    { 770, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6811), "Lorem Ipsum is simply dummy text", "Item 770", 486.67000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6813) },
                    { 771, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6815), "Lorem Ipsum is simply dummy text", "Item 771", 762.07000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6816) },
                    { 772, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6819), "Lorem Ipsum is simply dummy text", "Item 772", 954.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6820) },
                    { 773, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6822), "Lorem Ipsum is simply dummy text", "Item 773", 925.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6823) },
                    { 774, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6826), "Lorem Ipsum is simply dummy text", "Item 774", 856.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6827) },
                    { 775, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6830), "Lorem Ipsum is simply dummy text", "Item 775", 73.760000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6831) },
                    { 776, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6833), "Lorem Ipsum is simply dummy text", "Item 776", 58.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6834) },
                    { 777, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6836), "Lorem Ipsum is simply dummy text", "Item 777", 676.16999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6838) },
                    { 778, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6840), "Lorem Ipsum is simply dummy text", "Item 778", 728.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6841) },
                    { 779, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6843), "Lorem Ipsum is simply dummy text", "Item 779", 639.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6844) },
                    { 766, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6799), "Lorem Ipsum is simply dummy text", "Item 766", 774.41999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6799) },
                    { 750, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6763), "Lorem Ipsum is simply dummy text", "Item 750", 205.53999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(6763) },
                    { 812, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7020), "Lorem Ipsum is simply dummy text", "Item 812", 952.04999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7021) },
                    { 814, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7024), "Lorem Ipsum is simply dummy text", "Item 814", 563.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7025) },
                    { 847, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7162), "Lorem Ipsum is simply dummy text", "Item 847", 585.82000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7163) },
                    { 848, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7164), "Lorem Ipsum is simply dummy text", "Item 848", 411.41000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7165) },
                    { 849, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7167), "Lorem Ipsum is simply dummy text", "Item 849", 792.28999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7167) },
                    { 850, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7169), "Lorem Ipsum is simply dummy text", "Item 850", 745.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7170) },
                    { 851, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7171), "Lorem Ipsum is simply dummy text", "Item 851", 119.09999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7172) },
                    { 852, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7173), "Lorem Ipsum is simply dummy text", "Item 852", 775.70000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7174) },
                    { 853, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7176), "Lorem Ipsum is simply dummy text", "Item 853", 878.65999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7177) },
                    { 854, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7178), "Lorem Ipsum is simply dummy text", "Item 854", 790.30999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7179) },
                    { 855, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7180), "Lorem Ipsum is simply dummy text", "Item 855", 732.66999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7181) },
                    { 856, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7182), "Lorem Ipsum is simply dummy text", "Item 856", 800.0, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7183) },
                    { 857, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7184), "Lorem Ipsum is simply dummy text", "Item 857", 857.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7185) },
                    { 858, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7187), "Lorem Ipsum is simply dummy text", "Item 858", 891.09000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7187) },
                    { 859, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7189), "Lorem Ipsum is simply dummy text", "Item 859", 732.59000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7190) },
                    { 860, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7191), "Lorem Ipsum is simply dummy text", "Item 860", 325.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7192) },
                    { 861, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7193), "Lorem Ipsum is simply dummy text", "Item 861", 306.49000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7194) },
                    { 862, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7195), "Lorem Ipsum is simply dummy text", "Item 862", 154.78999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7196) },
                    { 863, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7198), "Lorem Ipsum is simply dummy text", "Item 863", 759.84000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7198) },
                    { 864, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7200), "Lorem Ipsum is simply dummy text", "Item 864", 835.13, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7201) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 865, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7202), "Lorem Ipsum is simply dummy text", "Item 865", 910.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7203) },
                    { 866, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7204), "Lorem Ipsum is simply dummy text", "Item 866", 321.79000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7205) },
                    { 867, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7207), "Lorem Ipsum is simply dummy text", "Item 867", 899.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7207) },
                    { 868, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7209), "Lorem Ipsum is simply dummy text", "Item 868", 110.95999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7209) },
                    { 869, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7239), "Lorem Ipsum is simply dummy text", "Item 869", 843.38, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7240) },
                    { 870, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7242), "Lorem Ipsum is simply dummy text", "Item 870", 271.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7242) },
                    { 871, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7244), "Lorem Ipsum is simply dummy text", "Item 871", 443.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7245) },
                    { 872, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7246), "Lorem Ipsum is simply dummy text", "Item 872", 106.90000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7247) },
                    { 873, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7248), "Lorem Ipsum is simply dummy text", "Item 873", 751.92999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7249) },
                    { 846, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7160), "Lorem Ipsum is simply dummy text", "Item 846", 142.27000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7161) },
                    { 845, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7158), "Lorem Ipsum is simply dummy text", "Item 845", 932.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7158) },
                    { 844, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7155), "Lorem Ipsum is simply dummy text", "Item 844", 555.20000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7156) },
                    { 843, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7153), "Lorem Ipsum is simply dummy text", "Item 843", 253.02000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7154) },
                    { 815, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7027), "Lorem Ipsum is simply dummy text", "Item 815", 954.22000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7027) },
                    { 816, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7029), "Lorem Ipsum is simply dummy text", "Item 816", 266.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7030) },
                    { 817, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7031), "Lorem Ipsum is simply dummy text", "Item 817", 801.29999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7032) },
                    { 818, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7033), "Lorem Ipsum is simply dummy text", "Item 818", 254.09999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7034) },
                    { 819, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7036), "Lorem Ipsum is simply dummy text", "Item 819", 394.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7036) },
                    { 820, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7038), "Lorem Ipsum is simply dummy text", "Item 820", 885.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7038) },
                    { 821, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7040), "Lorem Ipsum is simply dummy text", "Item 821", 959.24000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7041) },
                    { 822, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7042), "Lorem Ipsum is simply dummy text", "Item 822", 66.730000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7043) },
                    { 823, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7044), "Lorem Ipsum is simply dummy text", "Item 823", 83.989999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7045) },
                    { 824, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7110), "Lorem Ipsum is simply dummy text", "Item 824", 243.80000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7111) },
                    { 825, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7114), "Lorem Ipsum is simply dummy text", "Item 825", 392.35000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7114) },
                    { 826, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7116), "Lorem Ipsum is simply dummy text", "Item 826", 117.58, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7117) },
                    { 827, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7118), "Lorem Ipsum is simply dummy text", "Item 827", 979.83000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7119) },
                    { 813, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7022), "Lorem Ipsum is simply dummy text", "Item 813", 58.68, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7023) },
                    { 828, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7120), "Lorem Ipsum is simply dummy text", "Item 828", 179.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7121) },
                    { 830, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7125), "Lorem Ipsum is simply dummy text", "Item 830", 153.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7126) },
                    { 831, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7127), "Lorem Ipsum is simply dummy text", "Item 831", 28.449999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7128) },
                    { 832, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7129), "Lorem Ipsum is simply dummy text", "Item 832", 402.56, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7130) },
                    { 833, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7132), "Lorem Ipsum is simply dummy text", "Item 833", 52.590000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7133) },
                    { 834, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7134), "Lorem Ipsum is simply dummy text", "Item 834", 947.71000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7135) },
                    { 835, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7136), "Lorem Ipsum is simply dummy text", "Item 835", 719.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7137) },
                    { 836, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7138), "Lorem Ipsum is simply dummy text", "Item 836", 682.70000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7139) },
                    { 837, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7140), "Lorem Ipsum is simply dummy text", "Item 837", 822.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7141) },
                    { 838, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7143), "Lorem Ipsum is simply dummy text", "Item 838", 694.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7143) },
                    { 839, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7145), "Lorem Ipsum is simply dummy text", "Item 839", 502.17000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7145) },
                    { 840, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7147), "Lorem Ipsum is simply dummy text", "Item 840", 491.63999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7147) },
                    { 841, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7149), "Lorem Ipsum is simply dummy text", "Item 841", 255.28, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7150) },
                    { 842, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7151), "Lorem Ipsum is simply dummy text", "Item 842", 210.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7152) },
                    { 829, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7123), "Lorem Ipsum is simply dummy text", "Item 829", 844.70000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7124) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 500, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5994), "Lorem Ipsum is simply dummy text", "Item 500", 531.96000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5995) },
                    { 497, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5987), "Lorem Ipsum is simply dummy text", "Item 497", 527.30999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5988) },
                    { 498, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5989), "Lorem Ipsum is simply dummy text", "Item 498", 8.3300000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5990) },
                    { 157, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4725), "Lorem Ipsum is simply dummy text", "Item 157", 727.57000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4726) },
                    { 158, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4727), "Lorem Ipsum is simply dummy text", "Item 158", 740.59000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4728) },
                    { 159, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4730), "Lorem Ipsum is simply dummy text", "Item 159", 451.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4730) },
                    { 160, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4732), "Lorem Ipsum is simply dummy text", "Item 160", 14.84, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4733) },
                    { 161, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4734), "Lorem Ipsum is simply dummy text", "Item 161", 73.900000000000006, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4735) },
                    { 162, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4736), "Lorem Ipsum is simply dummy text", "Item 162", 480.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4737) },
                    { 163, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4739), "Lorem Ipsum is simply dummy text", "Item 163", 955.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4739) },
                    { 164, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4741), "Lorem Ipsum is simply dummy text", "Item 164", 89.569999999999993, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4742) },
                    { 165, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4743), "Lorem Ipsum is simply dummy text", "Item 165", 77.230000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4744) },
                    { 166, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4745), "Lorem Ipsum is simply dummy text", "Item 166", 975.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4746) },
                    { 167, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4748), "Lorem Ipsum is simply dummy text", "Item 167", 283.66000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4748) },
                    { 168, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4750), "Lorem Ipsum is simply dummy text", "Item 168", 35.07, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4750) },
                    { 169, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4752), "Lorem Ipsum is simply dummy text", "Item 169", 922.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4753) },
                    { 170, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4754), "Lorem Ipsum is simply dummy text", "Item 170", 219.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4755) },
                    { 171, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4756), "Lorem Ipsum is simply dummy text", "Item 171", 587.44000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4757) },
                    { 172, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4758), "Lorem Ipsum is simply dummy text", "Item 172", 397.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4759) },
                    { 173, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4761), "Lorem Ipsum is simply dummy text", "Item 173", 709.17999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4761) },
                    { 174, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4763), "Lorem Ipsum is simply dummy text", "Item 174", 624.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4764) },
                    { 175, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4765), "Lorem Ipsum is simply dummy text", "Item 175", 114.22, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4766) },
                    { 176, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4767), "Lorem Ipsum is simply dummy text", "Item 176", 346.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4768) },
                    { 177, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4769), "Lorem Ipsum is simply dummy text", "Item 177", 703.41999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4770) },
                    { 178, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4772), "Lorem Ipsum is simply dummy text", "Item 178", 379.62, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4772) },
                    { 179, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4774), "Lorem Ipsum is simply dummy text", "Item 179", 585.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4775) },
                    { 180, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4776), "Lorem Ipsum is simply dummy text", "Item 180", 368.22000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4777) },
                    { 181, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4805), "Lorem Ipsum is simply dummy text", "Item 181", 528.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4806) },
                    { 182, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4808), "Lorem Ipsum is simply dummy text", "Item 182", 67.939999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4809) },
                    { 183, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4811), "Lorem Ipsum is simply dummy text", "Item 183", 793.70000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4811) },
                    { 156, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4723), "Lorem Ipsum is simply dummy text", "Item 156", 135.72999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4724) },
                    { 184, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4813), "Lorem Ipsum is simply dummy text", "Item 184", 295.55000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4842) },
                    { 155, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4721), "Lorem Ipsum is simply dummy text", "Item 155", 404.56, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4722) },
                    { 153, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4716), "Lorem Ipsum is simply dummy text", "Item 153", 75.010000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4717) },
                    { 126, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4628), "Lorem Ipsum is simply dummy text", "Item 126", 690.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4629) },
                    { 127, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4630), "Lorem Ipsum is simply dummy text", "Item 127", 577.37, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4631) },
                    { 128, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4633), "Lorem Ipsum is simply dummy text", "Item 128", 65.439999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4633) },
                    { 129, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4635), "Lorem Ipsum is simply dummy text", "Item 129", 984.13, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4636) },
                    { 130, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4638), "Lorem Ipsum is simply dummy text", "Item 130", 343.57999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4639) },
                    { 131, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4641), "Lorem Ipsum is simply dummy text", "Item 131", 646.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4642) },
                    { 132, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4643), "Lorem Ipsum is simply dummy text", "Item 132", 35.259999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4644) },
                    { 133, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4645), "Lorem Ipsum is simply dummy text", "Item 133", 46.130000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4646) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 134, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4647), "Lorem Ipsum is simply dummy text", "Item 134", 464.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4648) },
                    { 135, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4650), "Lorem Ipsum is simply dummy text", "Item 135", 898.19000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4650) },
                    { 136, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4652), "Lorem Ipsum is simply dummy text", "Item 136", 110.34999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4653) },
                    { 137, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4681), "Lorem Ipsum is simply dummy text", "Item 137", 331.19999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4682) },
                    { 138, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4684), "Lorem Ipsum is simply dummy text", "Item 138", 54.890000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4684) },
                    { 139, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4686), "Lorem Ipsum is simply dummy text", "Item 139", 347.44999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4686) },
                    { 140, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4688), "Lorem Ipsum is simply dummy text", "Item 140", 565.57000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4689) },
                    { 141, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4690), "Lorem Ipsum is simply dummy text", "Item 141", 104.81999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4691) },
                    { 142, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4692), "Lorem Ipsum is simply dummy text", "Item 142", 469.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4693) },
                    { 143, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4694), "Lorem Ipsum is simply dummy text", "Item 143", 834.82000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4695) },
                    { 144, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4697), "Lorem Ipsum is simply dummy text", "Item 144", 417.76999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4697) },
                    { 145, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4699), "Lorem Ipsum is simply dummy text", "Item 145", 615.83000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4699) },
                    { 146, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4701), "Lorem Ipsum is simply dummy text", "Item 146", 614.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4702) },
                    { 147, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4703), "Lorem Ipsum is simply dummy text", "Item 147", 161.15000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4704) },
                    { 148, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4705), "Lorem Ipsum is simply dummy text", "Item 148", 509.43000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4706) },
                    { 149, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4707), "Lorem Ipsum is simply dummy text", "Item 149", 271.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4708) },
                    { 150, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4710), "Lorem Ipsum is simply dummy text", "Item 150", 688.58000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4711) },
                    { 151, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4712), "Lorem Ipsum is simply dummy text", "Item 151", 761.88, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4713) },
                    { 152, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4714), "Lorem Ipsum is simply dummy text", "Item 152", 984.83000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4715) },
                    { 154, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4719), "Lorem Ipsum is simply dummy text", "Item 154", 528.24000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4719) },
                    { 185, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4844), "Lorem Ipsum is simply dummy text", "Item 185", 581.70000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4845) },
                    { 186, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4847), "Lorem Ipsum is simply dummy text", "Item 186", 661.21000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4847) },
                    { 187, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4849), "Lorem Ipsum is simply dummy text", "Item 187", 960.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4849) },
                    { 220, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4967), "Lorem Ipsum is simply dummy text", "Item 220", 416.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4968) },
                    { 221, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4969), "Lorem Ipsum is simply dummy text", "Item 221", 15.619999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4970) },
                    { 222, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4972), "Lorem Ipsum is simply dummy text", "Item 222", 765.76999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4973) },
                    { 223, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4974), "Lorem Ipsum is simply dummy text", "Item 223", 974.88, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4975) },
                    { 224, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4976), "Lorem Ipsum is simply dummy text", "Item 224", 160.15000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4977) },
                    { 225, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4979), "Lorem Ipsum is simply dummy text", "Item 225", 836.96000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4979) },
                    { 226, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5010), "Lorem Ipsum is simply dummy text", "Item 226", 996.82000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5011) },
                    { 227, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5013), "Lorem Ipsum is simply dummy text", "Item 227", 794.41999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5013) },
                    { 228, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5015), "Lorem Ipsum is simply dummy text", "Item 228", 376.56999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5016) },
                    { 229, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5017), "Lorem Ipsum is simply dummy text", "Item 229", 132.56, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5018) },
                    { 230, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5019), "Lorem Ipsum is simply dummy text", "Item 230", 489.54000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5020) },
                    { 231, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5021), "Lorem Ipsum is simply dummy text", "Item 231", 832.38, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5022) },
                    { 232, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5024), "Lorem Ipsum is simply dummy text", "Item 232", 958.16999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5024) },
                    { 233, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5026), "Lorem Ipsum is simply dummy text", "Item 233", 39.090000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5027) },
                    { 234, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5028), "Lorem Ipsum is simply dummy text", "Item 234", 945.82000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5029) },
                    { 235, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5030), "Lorem Ipsum is simply dummy text", "Item 235", 37.149999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5031) },
                    { 236, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5033), "Lorem Ipsum is simply dummy text", "Item 236", 402.81999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5033) },
                    { 237, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5035), "Lorem Ipsum is simply dummy text", "Item 237", 481.11000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5036) },
                    { 238, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5037), "Lorem Ipsum is simply dummy text", "Item 238", 741.70000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5038) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 239, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5039), "Lorem Ipsum is simply dummy text", "Item 239", 194.41, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5040) },
                    { 240, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5042), "Lorem Ipsum is simply dummy text", "Item 240", 217.44999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5042) },
                    { 241, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5044), "Lorem Ipsum is simply dummy text", "Item 241", 385.56, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5045) },
                    { 242, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5046), "Lorem Ipsum is simply dummy text", "Item 242", 509.48000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5047) },
                    { 243, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5048), "Lorem Ipsum is simply dummy text", "Item 243", 103.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5049) },
                    { 244, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5051), "Lorem Ipsum is simply dummy text", "Item 244", 1.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5051) },
                    { 245, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5053), "Lorem Ipsum is simply dummy text", "Item 245", 330.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5054) },
                    { 246, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5055), "Lorem Ipsum is simply dummy text", "Item 246", 34.829999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5056) },
                    { 219, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4965), "Lorem Ipsum is simply dummy text", "Item 219", 507.86000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4966) },
                    { 218, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4917), "Lorem Ipsum is simply dummy text", "Item 218", 659.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4963) },
                    { 217, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4915), "Lorem Ipsum is simply dummy text", "Item 217", 686.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4916) },
                    { 216, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4913), "Lorem Ipsum is simply dummy text", "Item 216", 5.96, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4913) },
                    { 188, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4851), "Lorem Ipsum is simply dummy text", "Item 188", 517.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4852) },
                    { 189, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4853), "Lorem Ipsum is simply dummy text", "Item 189", 60.189999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4854) },
                    { 190, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4855), "Lorem Ipsum is simply dummy text", "Item 190", 762.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4856) },
                    { 191, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4858), "Lorem Ipsum is simply dummy text", "Item 191", 382.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4858) },
                    { 192, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4860), "Lorem Ipsum is simply dummy text", "Item 192", 590.62, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4861) },
                    { 193, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4862), "Lorem Ipsum is simply dummy text", "Item 193", 603.21000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4863) },
                    { 194, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4864), "Lorem Ipsum is simply dummy text", "Item 194", 332.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4865) },
                    { 195, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4867), "Lorem Ipsum is simply dummy text", "Item 195", 491.67000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4867) },
                    { 196, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4869), "Lorem Ipsum is simply dummy text", "Item 196", 624.66999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4870) },
                    { 197, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4871), "Lorem Ipsum is simply dummy text", "Item 197", 513.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4872) },
                    { 198, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4873), "Lorem Ipsum is simply dummy text", "Item 198", 745.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4874) },
                    { 199, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4875), "Lorem Ipsum is simply dummy text", "Item 199", 340.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4876) },
                    { 200, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4877), "Lorem Ipsum is simply dummy text", "Item 200", 639.96000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4878) },
                    { 125, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4625), "Lorem Ipsum is simply dummy text", "Item 125", 982.95000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4626) },
                    { 201, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4880), "Lorem Ipsum is simply dummy text", "Item 201", 331.06999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4880) },
                    { 203, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4884), "Lorem Ipsum is simply dummy text", "Item 203", 586.83000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4885) },
                    { 204, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4886), "Lorem Ipsum is simply dummy text", "Item 204", 52.0, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4887) },
                    { 205, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4888), "Lorem Ipsum is simply dummy text", "Item 205", 101.14, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4889) },
                    { 206, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4890), "Lorem Ipsum is simply dummy text", "Item 206", 364.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4891) },
                    { 207, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4893), "Lorem Ipsum is simply dummy text", "Item 207", 275.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4893) },
                    { 208, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4895), "Lorem Ipsum is simply dummy text", "Item 208", 450.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4896) },
                    { 209, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4897), "Lorem Ipsum is simply dummy text", "Item 209", 414.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4898) },
                    { 210, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4899), "Lorem Ipsum is simply dummy text", "Item 210", 58.439999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4900) },
                    { 211, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4901), "Lorem Ipsum is simply dummy text", "Item 211", 432.31999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4902) },
                    { 212, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4904), "Lorem Ipsum is simply dummy text", "Item 212", 347.94999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4905) },
                    { 213, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4906), "Lorem Ipsum is simply dummy text", "Item 213", 154.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4907) },
                    { 214, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4908), "Lorem Ipsum is simply dummy text", "Item 214", 83.459999999999994, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4909) },
                    { 215, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4910), "Lorem Ipsum is simply dummy text", "Item 215", 485.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4911) },
                    { 202, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4882), "Lorem Ipsum is simply dummy text", "Item 202", 126.08, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4883) },
                    { 247, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5057), "Lorem Ipsum is simply dummy text", "Item 247", 435.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5058) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 124, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4623), "Lorem Ipsum is simply dummy text", "Item 124", 201.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4624) },
                    { 122, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4618), "Lorem Ipsum is simply dummy text", "Item 122", 538.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4619) },
                    { 32, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4322), "Lorem Ipsum is simply dummy text", "Item 32", 939.58000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4323) },
                    { 33, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4324), "Lorem Ipsum is simply dummy text", "Item 33", 259.10000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4325) },
                    { 34, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4327), "Lorem Ipsum is simply dummy text", "Item 34", 551.80999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4328) },
                    { 35, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4330), "Lorem Ipsum is simply dummy text", "Item 35", 938.15999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4331) },
                    { 36, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4332), "Lorem Ipsum is simply dummy text", "Item 36", 67.719999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4333) },
                    { 37, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4335), "Lorem Ipsum is simply dummy text", "Item 37", 845.37, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4335) },
                    { 38, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4337), "Lorem Ipsum is simply dummy text", "Item 38", 723.15999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4337) },
                    { 39, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4339), "Lorem Ipsum is simply dummy text", "Item 39", 567.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4340) },
                    { 40, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4341), "Lorem Ipsum is simply dummy text", "Item 40", 799.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4342) },
                    { 41, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4344), "Lorem Ipsum is simply dummy text", "Item 41", 156.44999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4344) },
                    { 42, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4346), "Lorem Ipsum is simply dummy text", "Item 42", 150.41, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4347) },
                    { 43, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4348), "Lorem Ipsum is simply dummy text", "Item 43", 671.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4349) },
                    { 44, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4350), "Lorem Ipsum is simply dummy text", "Item 44", 616.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4351) },
                    { 45, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4353), "Lorem Ipsum is simply dummy text", "Item 45", 443.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4353) },
                    { 46, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4355), "Lorem Ipsum is simply dummy text", "Item 46", 480.16000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4356) },
                    { 47, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4357), "Lorem Ipsum is simply dummy text", "Item 47", 463.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4358) },
                    { 48, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4359), "Lorem Ipsum is simply dummy text", "Item 48", 770.76999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4360) },
                    { 49, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4361), "Lorem Ipsum is simply dummy text", "Item 49", 362.11000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4362) },
                    { 50, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4364), "Lorem Ipsum is simply dummy text", "Item 50", 55.899999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4364) },
                    { 51, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4366), "Lorem Ipsum is simply dummy text", "Item 51", 558.86000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4366) },
                    { 52, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4368), "Lorem Ipsum is simply dummy text", "Item 52", 212.86000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4369) },
                    { 53, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4370), "Lorem Ipsum is simply dummy text", "Item 53", 530.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4371) },
                    { 54, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4372), "Lorem Ipsum is simply dummy text", "Item 54", 991.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4373) },
                    { 55, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4374), "Lorem Ipsum is simply dummy text", "Item 55", 410.76999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4375) },
                    { 56, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4377), "Lorem Ipsum is simply dummy text", "Item 56", 311.19999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4377) },
                    { 57, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4379), "Lorem Ipsum is simply dummy text", "Item 57", 123.2, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4380) },
                    { 58, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4381), "Lorem Ipsum is simply dummy text", "Item 58", 184.40000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4382) },
                    { 31, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4319), "Lorem Ipsum is simply dummy text", "Item 31", 863.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4320) },
                    { 59, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4383), "Lorem Ipsum is simply dummy text", "Item 59", 392.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4384) },
                    { 30, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4317), "Lorem Ipsum is simply dummy text", "Item 30", 775.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4318) },
                    { 28, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4313), "Lorem Ipsum is simply dummy text", "Item 28", 851.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4313) },
                    { 1, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 680, DateTimeKind.Local).AddTicks(4217), "Lorem Ipsum is simply dummy text", "Item 1", 282.70999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(1402) },
                    { 2, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4190), "Lorem Ipsum is simply dummy text", "Item 2", 533.34000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4196) },
                    { 3, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4209), "Lorem Ipsum is simply dummy text", "Item 3", 312.75999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4210) },
                    { 4, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4212), "Lorem Ipsum is simply dummy text", "Item 4", 445.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4213) },
                    { 5, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4214), "Lorem Ipsum is simply dummy text", "Item 5", 64.109999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4215) },
                    { 6, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4219), "Lorem Ipsum is simply dummy text", "Item 6", 236.21000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4220) },
                    { 7, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4222), "Lorem Ipsum is simply dummy text", "Item 7", 793.67999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4223) },
                    { 8, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4224), "Lorem Ipsum is simply dummy text", "Item 8", 217.19, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4225) },
                    { 9, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4226), "Lorem Ipsum is simply dummy text", "Item 9", 182.33000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4227) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4229), "Lorem Ipsum is simply dummy text", "Item 10", 732.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4230) },
                    { 11, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4232), "Lorem Ipsum is simply dummy text", "Item 11", 163.53, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4233) },
                    { 12, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4235), "Lorem Ipsum is simply dummy text", "Item 12", 65.299999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4235) },
                    { 13, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4237), "Lorem Ipsum is simply dummy text", "Item 13", 490.24000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4238) },
                    { 14, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4239), "Lorem Ipsum is simply dummy text", "Item 14", 766.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4240) },
                    { 15, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4242), "Lorem Ipsum is simply dummy text", "Item 15", 995.19000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4242) },
                    { 16, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4244), "Lorem Ipsum is simply dummy text", "Item 16", 196.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4245) },
                    { 17, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4246), "Lorem Ipsum is simply dummy text", "Item 17", 630.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4247) },
                    { 18, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4249), "Lorem Ipsum is simply dummy text", "Item 18", 234.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4250) },
                    { 19, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4252), "Lorem Ipsum is simply dummy text", "Item 19", 390.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4253) },
                    { 20, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4254), "Lorem Ipsum is simply dummy text", "Item 20", 714.42999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4255) },
                    { 21, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4257), "Lorem Ipsum is simply dummy text", "Item 21", 837.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4257) },
                    { 22, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4259), "Lorem Ipsum is simply dummy text", "Item 22", 971.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4260) },
                    { 23, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4261), "Lorem Ipsum is simply dummy text", "Item 23", 410.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4262) },
                    { 24, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4303), "Lorem Ipsum is simply dummy text", "Item 24", 128.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4304) },
                    { 25, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4306), "Lorem Ipsum is simply dummy text", "Item 25", 52.310000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4307) },
                    { 26, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4308), "Lorem Ipsum is simply dummy text", "Item 26", 98.709999999999994, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4309) },
                    { 27, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4310), "Lorem Ipsum is simply dummy text", "Item 27", 44.170000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4311) },
                    { 29, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4315), "Lorem Ipsum is simply dummy text", "Item 29", 108.23, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4316) },
                    { 60, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4385), "Lorem Ipsum is simply dummy text", "Item 60", 965.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4386) },
                    { 61, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4388), "Lorem Ipsum is simply dummy text", "Item 61", 192.05000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4388) },
                    { 62, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4390), "Lorem Ipsum is simply dummy text", "Item 62", 942.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4391) },
                    { 95, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4493), "Lorem Ipsum is simply dummy text", "Item 95", 607.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4494) },
                    { 96, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4496), "Lorem Ipsum is simply dummy text", "Item 96", 214.40000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4496) },
                    { 97, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4498), "Lorem Ipsum is simply dummy text", "Item 97", 41.450000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4499) },
                    { 98, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4500), "Lorem Ipsum is simply dummy text", "Item 98", 264.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4501) },
                    { 99, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4502), "Lorem Ipsum is simply dummy text", "Item 99", 747.27999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4503) },
                    { 100, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4505), "Lorem Ipsum is simply dummy text", "Item 100", 219.83000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4506) },
                    { 101, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4507), "Lorem Ipsum is simply dummy text", "Item 101", 673.96000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4508) },
                    { 102, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4510), "Lorem Ipsum is simply dummy text", "Item 102", 524.96000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4510) },
                    { 103, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4512), "Lorem Ipsum is simply dummy text", "Item 103", 942.19000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4512) },
                    { 104, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4577), "Lorem Ipsum is simply dummy text", "Item 104", 434.63, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4578) },
                    { 105, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4580), "Lorem Ipsum is simply dummy text", "Item 105", 704.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4581) },
                    { 106, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4582), "Lorem Ipsum is simply dummy text", "Item 106", 651.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4583) },
                    { 107, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4584), "Lorem Ipsum is simply dummy text", "Item 107", 545.59000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4585) },
                    { 108, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4587), "Lorem Ipsum is simply dummy text", "Item 108", 939.53999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4587) },
                    { 109, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4589), "Lorem Ipsum is simply dummy text", "Item 109", 433.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4590) },
                    { 110, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4591), "Lorem Ipsum is simply dummy text", "Item 110", 723.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4592) },
                    { 111, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4593), "Lorem Ipsum is simply dummy text", "Item 111", 11.130000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4594) },
                    { 112, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4596), "Lorem Ipsum is simply dummy text", "Item 112", 329.79000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4597) },
                    { 113, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4598), "Lorem Ipsum is simply dummy text", "Item 113", 499.81999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4599) },
                    { 114, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4600), "Lorem Ipsum is simply dummy text", "Item 114", 820.78999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4601) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 115, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4602), "Lorem Ipsum is simply dummy text", "Item 115", 330.08999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4603) },
                    { 116, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4605), "Lorem Ipsum is simply dummy text", "Item 116", 918.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4606) },
                    { 117, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4607), "Lorem Ipsum is simply dummy text", "Item 117", 452.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4608) },
                    { 118, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4609), "Lorem Ipsum is simply dummy text", "Item 118", 56.619999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4610) },
                    { 119, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4612), "Lorem Ipsum is simply dummy text", "Item 119", 189.80000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4613) },
                    { 120, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4614), "Lorem Ipsum is simply dummy text", "Item 120", 219.03999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4615) },
                    { 121, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4616), "Lorem Ipsum is simply dummy text", "Item 121", 815.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4617) },
                    { 94, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4491), "Lorem Ipsum is simply dummy text", "Item 94", 601.83000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4492) },
                    { 93, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4489), "Lorem Ipsum is simply dummy text", "Item 93", 330.22000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4489) },
                    { 92, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4486), "Lorem Ipsum is simply dummy text", "Item 92", 660.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4487) },
                    { 91, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4484), "Lorem Ipsum is simply dummy text", "Item 91", 944.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4485) },
                    { 63, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4392), "Lorem Ipsum is simply dummy text", "Item 63", 108.95999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4393) },
                    { 64, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4394), "Lorem Ipsum is simply dummy text", "Item 64", 406.63999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4395) },
                    { 65, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4424), "Lorem Ipsum is simply dummy text", "Item 65", 869.46000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4425) },
                    { 66, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4428), "Lorem Ipsum is simply dummy text", "Item 66", 223.96000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4429) },
                    { 67, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4431), "Lorem Ipsum is simply dummy text", "Item 67", 806.20000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4431) },
                    { 68, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4433), "Lorem Ipsum is simply dummy text", "Item 68", 938.42999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4434) },
                    { 69, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4435), "Lorem Ipsum is simply dummy text", "Item 69", 828.57000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4436) },
                    { 70, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4437), "Lorem Ipsum is simply dummy text", "Item 70", 927.47000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4438) },
                    { 71, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4439), "Lorem Ipsum is simply dummy text", "Item 71", 351.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4440) },
                    { 72, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4442), "Lorem Ipsum is simply dummy text", "Item 72", 907.59000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4443) },
                    { 73, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4444), "Lorem Ipsum is simply dummy text", "Item 73", 667.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4445) },
                    { 74, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4446), "Lorem Ipsum is simply dummy text", "Item 74", 591.35000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4447) },
                    { 75, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4448), "Lorem Ipsum is simply dummy text", "Item 75", 557.99000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4449) },
                    { 123, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4621), "Lorem Ipsum is simply dummy text", "Item 123", 797.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4621) },
                    { 76, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4451), "Lorem Ipsum is simply dummy text", "Item 76", 687.49000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4451) },
                    { 78, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4455), "Lorem Ipsum is simply dummy text", "Item 78", 793.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4456) },
                    { 79, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4457), "Lorem Ipsum is simply dummy text", "Item 79", 684.58000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4458) },
                    { 80, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4460), "Lorem Ipsum is simply dummy text", "Item 80", 572.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4460) },
                    { 81, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4462), "Lorem Ipsum is simply dummy text", "Item 81", 635.30999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4463) },
                    { 82, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4464), "Lorem Ipsum is simply dummy text", "Item 82", 273.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4465) },
                    { 83, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4466), "Lorem Ipsum is simply dummy text", "Item 83", 489.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4467) },
                    { 84, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4469), "Lorem Ipsum is simply dummy text", "Item 84", 52.329999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4469) },
                    { 85, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4471), "Lorem Ipsum is simply dummy text", "Item 85", 216.84, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4472) },
                    { 86, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4473), "Lorem Ipsum is simply dummy text", "Item 86", 650.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4474) },
                    { 87, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4475), "Lorem Ipsum is simply dummy text", "Item 87", 408.69, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4476) },
                    { 88, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4477), "Lorem Ipsum is simply dummy text", "Item 88", 267.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4478) },
                    { 89, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4480), "Lorem Ipsum is simply dummy text", "Item 89", 141.03999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4480) },
                    { 90, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4482), "Lorem Ipsum is simply dummy text", "Item 90", 626.96000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4482) },
                    { 77, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4453), "Lorem Ipsum is simply dummy text", "Item 77", 300.06999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(4454) },
                    { 248, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5059), "Lorem Ipsum is simply dummy text", "Item 248", 519.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5060) },
                    { 249, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5061), "Lorem Ipsum is simply dummy text", "Item 249", 846.65999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5062) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 250, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5064), "Lorem Ipsum is simply dummy text", "Item 250", 485.72000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5064) },
                    { 408, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5694), "Lorem Ipsum is simply dummy text", "Item 408", 990.91999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5695) },
                    { 409, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5696), "Lorem Ipsum is simply dummy text", "Item 409", 870.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5697) },
                    { 410, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5698), "Lorem Ipsum is simply dummy text", "Item 410", 123.06999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5699) },
                    { 411, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5700), "Lorem Ipsum is simply dummy text", "Item 411", 557.91999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5701) },
                    { 412, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5703), "Lorem Ipsum is simply dummy text", "Item 412", 655.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5703) },
                    { 413, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5705), "Lorem Ipsum is simply dummy text", "Item 413", 892.99000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5705) },
                    { 414, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5707), "Lorem Ipsum is simply dummy text", "Item 414", 174.03999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5708) },
                    { 415, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5709), "Lorem Ipsum is simply dummy text", "Item 415", 477.79000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5710) },
                    { 416, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5712), "Lorem Ipsum is simply dummy text", "Item 416", 271.08999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5712) },
                    { 417, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5714), "Lorem Ipsum is simply dummy text", "Item 417", 184.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5714) },
                    { 418, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5716), "Lorem Ipsum is simply dummy text", "Item 418", 13.83, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5717) },
                    { 419, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5718), "Lorem Ipsum is simply dummy text", "Item 419", 923.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5719) },
                    { 420, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5720), "Lorem Ipsum is simply dummy text", "Item 420", 8.2899999999999991, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5721) },
                    { 421, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5722), "Lorem Ipsum is simply dummy text", "Item 421", 744.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5723) },
                    { 422, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5725), "Lorem Ipsum is simply dummy text", "Item 422", 311.35000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5725) },
                    { 423, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5727), "Lorem Ipsum is simply dummy text", "Item 423", 751.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5728) },
                    { 424, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5729), "Lorem Ipsum is simply dummy text", "Item 424", 792.25, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5730) },
                    { 425, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5799), "Lorem Ipsum is simply dummy text", "Item 425", 214.21000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5800) },
                    { 426, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5802), "Lorem Ipsum is simply dummy text", "Item 426", 591.65999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5803) },
                    { 427, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5805), "Lorem Ipsum is simply dummy text", "Item 427", 768.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5805) },
                    { 428, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5807), "Lorem Ipsum is simply dummy text", "Item 428", 789.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5808) },
                    { 429, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5809), "Lorem Ipsum is simply dummy text", "Item 429", 832.88, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5810) },
                    { 430, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5811), "Lorem Ipsum is simply dummy text", "Item 430", 80.420000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5812) },
                    { 431, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5814), "Lorem Ipsum is simply dummy text", "Item 431", 509.92000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5814) },
                    { 432, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5816), "Lorem Ipsum is simply dummy text", "Item 432", 103.31999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5817) },
                    { 433, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5818), "Lorem Ipsum is simply dummy text", "Item 433", 284.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5819) },
                    { 434, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5820), "Lorem Ipsum is simply dummy text", "Item 434", 858.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5821) },
                    { 407, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5692), "Lorem Ipsum is simply dummy text", "Item 407", 534.46000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5692) },
                    { 435, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5822), "Lorem Ipsum is simply dummy text", "Item 435", 665.09000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5823) },
                    { 406, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5687), "Lorem Ipsum is simply dummy text", "Item 406", 514.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5688) },
                    { 404, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5680), "Lorem Ipsum is simply dummy text", "Item 404", 337.69999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5681) },
                    { 377, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5500), "Lorem Ipsum is simply dummy text", "Item 377", 973.75999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5501) },
                    { 378, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5502), "Lorem Ipsum is simply dummy text", "Item 378", 684.24000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5503) },
                    { 379, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5504), "Lorem Ipsum is simply dummy text", "Item 379", 5.9900000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5505) },
                    { 380, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5507), "Lorem Ipsum is simply dummy text", "Item 380", 757.98000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5507) },
                    { 381, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5548), "Lorem Ipsum is simply dummy text", "Item 381", 12.65, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5549) },
                    { 382, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5552), "Lorem Ipsum is simply dummy text", "Item 382", 304.31, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5553) },
                    { 383, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5555), "Lorem Ipsum is simply dummy text", "Item 383", 828.54999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5556) },
                    { 384, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5559), "Lorem Ipsum is simply dummy text", "Item 384", 290.33999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5560) },
                    { 385, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5562), "Lorem Ipsum is simply dummy text", "Item 385", 426.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5563) },
                    { 386, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5577), "Lorem Ipsum is simply dummy text", "Item 386", 795.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5581) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 387, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5586), "Lorem Ipsum is simply dummy text", "Item 387", 676.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5588) },
                    { 388, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5591), "Lorem Ipsum is simply dummy text", "Item 388", 669.28999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5592) },
                    { 389, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5594), "Lorem Ipsum is simply dummy text", "Item 389", 871.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5595) },
                    { 390, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5598), "Lorem Ipsum is simply dummy text", "Item 390", 544.48000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5599) },
                    { 391, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5601), "Lorem Ipsum is simply dummy text", "Item 391", 994.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5604) },
                    { 392, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5610), "Lorem Ipsum is simply dummy text", "Item 392", 902.25999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5612) },
                    { 393, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5617), "Lorem Ipsum is simply dummy text", "Item 393", 834.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5620) },
                    { 394, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5622), "Lorem Ipsum is simply dummy text", "Item 394", 195.52000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5623) },
                    { 395, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5626), "Lorem Ipsum is simply dummy text", "Item 395", 982.44000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5627) },
                    { 396, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5629), "Lorem Ipsum is simply dummy text", "Item 396", 577.03999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5630) },
                    { 397, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5633), "Lorem Ipsum is simply dummy text", "Item 397", 469.63999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5634) },
                    { 398, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5636), "Lorem Ipsum is simply dummy text", "Item 398", 870.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5639) },
                    { 399, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5645), "Lorem Ipsum is simply dummy text", "Item 399", 399.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5658) },
                    { 400, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5665), "Lorem Ipsum is simply dummy text", "Item 400", 147.58000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5666) },
                    { 401, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5669), "Lorem Ipsum is simply dummy text", "Item 401", 92.890000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5670) },
                    { 402, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5673), "Lorem Ipsum is simply dummy text", "Item 402", 835.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5674) },
                    { 403, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5676), "Lorem Ipsum is simply dummy text", "Item 403", 777.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5677) },
                    { 405, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5684), "Lorem Ipsum is simply dummy text", "Item 405", 858.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5685) },
                    { 436, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5824), "Lorem Ipsum is simply dummy text", "Item 436", 177.53999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5825) },
                    { 437, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5827), "Lorem Ipsum is simply dummy text", "Item 437", 527.27999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5827) },
                    { 438, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5829), "Lorem Ipsum is simply dummy text", "Item 438", 490.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5830) },
                    { 471, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5929), "Lorem Ipsum is simply dummy text", "Item 471", 743.82000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5930) },
                    { 472, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5931), "Lorem Ipsum is simply dummy text", "Item 472", 693.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5932) },
                    { 473, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5933), "Lorem Ipsum is simply dummy text", "Item 473", 582.02999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5934) },
                    { 474, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5936), "Lorem Ipsum is simply dummy text", "Item 474", 11.199999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5936) },
                    { 475, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5938), "Lorem Ipsum is simply dummy text", "Item 475", 747.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5938) },
                    { 476, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5940), "Lorem Ipsum is simply dummy text", "Item 476", 59.259999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5941) },
                    { 477, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5942), "Lorem Ipsum is simply dummy text", "Item 477", 512.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5943) },
                    { 478, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5944), "Lorem Ipsum is simply dummy text", "Item 478", 2.9100000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5945) },
                    { 479, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5947), "Lorem Ipsum is simply dummy text", "Item 479", 805.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5947) },
                    { 480, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5949), "Lorem Ipsum is simply dummy text", "Item 480", 874.38, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5950) },
                    { 481, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5951), "Lorem Ipsum is simply dummy text", "Item 481", 582.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5952) },
                    { 482, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5954), "Lorem Ipsum is simply dummy text", "Item 482", 108.13, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5954) },
                    { 483, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5956), "Lorem Ipsum is simply dummy text", "Item 483", 72.159999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5957) },
                    { 484, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5958), "Lorem Ipsum is simply dummy text", "Item 484", 121.54000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5959) },
                    { 485, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5960), "Lorem Ipsum is simply dummy text", "Item 485", 687.88, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5961) },
                    { 486, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5962), "Lorem Ipsum is simply dummy text", "Item 486", 54.119999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5963) },
                    { 487, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5965), "Lorem Ipsum is simply dummy text", "Item 487", 156.25999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5966) },
                    { 488, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5967), "Lorem Ipsum is simply dummy text", "Item 488", 892.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5968) },
                    { 489, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5969), "Lorem Ipsum is simply dummy text", "Item 489", 455.44, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5970) },
                    { 490, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5971), "Lorem Ipsum is simply dummy text", "Item 490", 883.55999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5972) },
                    { 491, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5974), "Lorem Ipsum is simply dummy text", "Item 491", 93.659999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5974) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 492, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5976), "Lorem Ipsum is simply dummy text", "Item 492", 542.5, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5977) },
                    { 493, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5978), "Lorem Ipsum is simply dummy text", "Item 493", 367.37, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5979) },
                    { 494, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5981), "Lorem Ipsum is simply dummy text", "Item 494", 164.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5981) },
                    { 495, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5983), "Lorem Ipsum is simply dummy text", "Item 495", 166.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5984) },
                    { 496, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5985), "Lorem Ipsum is simply dummy text", "Item 496", 515.98000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5986) },
                    { 999, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7585), "Lorem Ipsum is simply dummy text", "Item 999", 544.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7586) },
                    { 470, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5927), "Lorem Ipsum is simply dummy text", "Item 470", 300.25999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5927) },
                    { 469, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5897), "Lorem Ipsum is simply dummy text", "Item 469", 508.94, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5898) },
                    { 468, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5895), "Lorem Ipsum is simply dummy text", "Item 468", 34.57, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5896) },
                    { 467, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5893), "Lorem Ipsum is simply dummy text", "Item 467", 370.79000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5893) },
                    { 439, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5831), "Lorem Ipsum is simply dummy text", "Item 439", 431.81, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5832) },
                    { 440, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5833), "Lorem Ipsum is simply dummy text", "Item 440", 912.19000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5834) },
                    { 441, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5836), "Lorem Ipsum is simply dummy text", "Item 441", 260.55000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5836) },
                    { 442, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5838), "Lorem Ipsum is simply dummy text", "Item 442", 685.35000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5839) },
                    { 443, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5840), "Lorem Ipsum is simply dummy text", "Item 443", 798.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5841) },
                    { 444, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5842), "Lorem Ipsum is simply dummy text", "Item 444", 748.33000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5843) },
                    { 445, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5844), "Lorem Ipsum is simply dummy text", "Item 445", 986.55999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5845) },
                    { 446, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5846), "Lorem Ipsum is simply dummy text", "Item 446", 339.82999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5847) },
                    { 447, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5849), "Lorem Ipsum is simply dummy text", "Item 447", 9.2699999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5850) },
                    { 448, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5851), "Lorem Ipsum is simply dummy text", "Item 448", 660.32000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5852) },
                    { 449, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5853), "Lorem Ipsum is simply dummy text", "Item 449", 717.73000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5854) },
                    { 450, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5855), "Lorem Ipsum is simply dummy text", "Item 450", 711.34000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5856) },
                    { 451, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5858), "Lorem Ipsum is simply dummy text", "Item 451", 392.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5858) },
                    { 376, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5498), "Lorem Ipsum is simply dummy text", "Item 376", 979.55999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5498) },
                    { 452, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5860), "Lorem Ipsum is simply dummy text", "Item 452", 455.80000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5860) },
                    { 454, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5864), "Lorem Ipsum is simply dummy text", "Item 454", 391.67000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5865) },
                    { 455, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5866), "Lorem Ipsum is simply dummy text", "Item 455", 402.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5867) },
                    { 456, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5868), "Lorem Ipsum is simply dummy text", "Item 456", 781.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5869) },
                    { 457, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5870), "Lorem Ipsum is simply dummy text", "Item 457", 83.870000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5871) },
                    { 458, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5873), "Lorem Ipsum is simply dummy text", "Item 458", 984.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5873) },
                    { 459, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5875), "Lorem Ipsum is simply dummy text", "Item 459", 123.48999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5876) },
                    { 460, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5877), "Lorem Ipsum is simply dummy text", "Item 460", 266.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5878) },
                    { 461, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5879), "Lorem Ipsum is simply dummy text", "Item 461", 746.04999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5880) },
                    { 462, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5881), "Lorem Ipsum is simply dummy text", "Item 462", 744.57000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5882) },
                    { 463, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5884), "Lorem Ipsum is simply dummy text", "Item 463", 158.03999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5885) },
                    { 464, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5886), "Lorem Ipsum is simply dummy text", "Item 464", 790.26999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5887) },
                    { 465, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5888), "Lorem Ipsum is simply dummy text", "Item 465", 613.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5889) },
                    { 466, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5891), "Lorem Ipsum is simply dummy text", "Item 466", 454.60000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5891) },
                    { 453, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5862), "Lorem Ipsum is simply dummy text", "Item 453", 947.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5862) },
                    { 375, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5496), "Lorem Ipsum is simply dummy text", "Item 375", 657.45000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5496) },
                    { 374, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5493), "Lorem Ipsum is simply dummy text", "Item 374", 815.32000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5494) },
                    { 373, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5491), "Lorem Ipsum is simply dummy text", "Item 373", 985.40999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5492) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 283, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5166), "Lorem Ipsum is simply dummy text", "Item 283", 529.90999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5167) },
                    { 284, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5168), "Lorem Ipsum is simply dummy text", "Item 284", 646.84000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5169) },
                    { 285, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5170), "Lorem Ipsum is simply dummy text", "Item 285", 551.32000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5171) },
                    { 286, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5173), "Lorem Ipsum is simply dummy text", "Item 286", 978.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5173) },
                    { 287, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5175), "Lorem Ipsum is simply dummy text", "Item 287", 720.77999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5176) },
                    { 288, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5177), "Lorem Ipsum is simply dummy text", "Item 288", 114.58, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5178) },
                    { 289, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5179), "Lorem Ipsum is simply dummy text", "Item 289", 321.48000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5180) },
                    { 290, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5182), "Lorem Ipsum is simply dummy text", "Item 290", 471.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5182) },
                    { 291, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5184), "Lorem Ipsum is simply dummy text", "Item 291", 251.61000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5185) },
                    { 292, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5267), "Lorem Ipsum is simply dummy text", "Item 292", 54.43, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5268) },
                    { 293, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5270), "Lorem Ipsum is simply dummy text", "Item 293", 526.66999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5271) },
                    { 294, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5272), "Lorem Ipsum is simply dummy text", "Item 294", 90.099999999999994, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5273) },
                    { 295, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5274), "Lorem Ipsum is simply dummy text", "Item 295", 647.62, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5275) },
                    { 296, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5277), "Lorem Ipsum is simply dummy text", "Item 296", 486.48000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5278) },
                    { 297, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5279), "Lorem Ipsum is simply dummy text", "Item 297", 191.25999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5280) },
                    { 298, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5281), "Lorem Ipsum is simply dummy text", "Item 298", 179.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5282) },
                    { 299, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5284), "Lorem Ipsum is simply dummy text", "Item 299", 775.69000000000005, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5284) },
                    { 300, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5286), "Lorem Ipsum is simply dummy text", "Item 300", 855.99000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5287) },
                    { 301, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5288), "Lorem Ipsum is simply dummy text", "Item 301", 725.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5289) },
                    { 302, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5290), "Lorem Ipsum is simply dummy text", "Item 302", 226.81999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5291) },
                    { 303, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5293), "Lorem Ipsum is simply dummy text", "Item 303", 473.44, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5293) },
                    { 304, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5295), "Lorem Ipsum is simply dummy text", "Item 304", 763.52999999999997, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5296) },
                    { 305, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5297), "Lorem Ipsum is simply dummy text", "Item 305", 960.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5298) },
                    { 306, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5300), "Lorem Ipsum is simply dummy text", "Item 306", 993.48000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5300) },
                    { 307, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5302), "Lorem Ipsum is simply dummy text", "Item 307", 388.41000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5303) },
                    { 308, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5304), "Lorem Ipsum is simply dummy text", "Item 308", 946.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5305) },
                    { 309, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5306), "Lorem Ipsum is simply dummy text", "Item 309", 894.05999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5307) },
                    { 282, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5163), "Lorem Ipsum is simply dummy text", "Item 282", 274.67000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5164) },
                    { 281, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5161), "Lorem Ipsum is simply dummy text", "Item 281", 561.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5162) },
                    { 280, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5159), "Lorem Ipsum is simply dummy text", "Item 280", 802.13, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5160) },
                    { 279, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5157), "Lorem Ipsum is simply dummy text", "Item 279", 830.00999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5157) },
                    { 251, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5066), "Lorem Ipsum is simply dummy text", "Item 251", 938.23000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5066) },
                    { 252, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5068), "Lorem Ipsum is simply dummy text", "Item 252", 853.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5069) },
                    { 253, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5070), "Lorem Ipsum is simply dummy text", "Item 253", 237.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5071) },
                    { 254, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5072), "Lorem Ipsum is simply dummy text", "Item 254", 924.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5073) },
                    { 255, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5074), "Lorem Ipsum is simply dummy text", "Item 255", 624.34000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5075) },
                    { 256, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5077), "Lorem Ipsum is simply dummy text", "Item 256", 565.29999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5077) },
                    { 257, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5079), "Lorem Ipsum is simply dummy text", "Item 257", 151.19999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5079) },
                    { 258, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5109), "Lorem Ipsum is simply dummy text", "Item 258", 426.68000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5110) },
                    { 259, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5112), "Lorem Ipsum is simply dummy text", "Item 259", 215.03, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5112) },
                    { 260, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5114), "Lorem Ipsum is simply dummy text", "Item 260", 104.31, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5115) },
                    { 261, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5116), "Lorem Ipsum is simply dummy text", "Item 261", 569.83000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5117) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 262, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5118), "Lorem Ipsum is simply dummy text", "Item 262", 899.08000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5119) },
                    { 263, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5120), "Lorem Ipsum is simply dummy text", "Item 263", 318.22000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5121) },
                    { 310, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5309), "Lorem Ipsum is simply dummy text", "Item 310", 118.2, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5309) },
                    { 264, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5123), "Lorem Ipsum is simply dummy text", "Item 264", 924.47000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5124) },
                    { 266, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5127), "Lorem Ipsum is simply dummy text", "Item 266", 474.14999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5128) },
                    { 267, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5129), "Lorem Ipsum is simply dummy text", "Item 267", 308.86000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5130) },
                    { 268, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5132), "Lorem Ipsum is simply dummy text", "Item 268", 208.99000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5132) },
                    { 269, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5134), "Lorem Ipsum is simply dummy text", "Item 269", 46.310000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5135) },
                    { 270, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5136), "Lorem Ipsum is simply dummy text", "Item 270", 83.129999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5137) },
                    { 271, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5138), "Lorem Ipsum is simply dummy text", "Item 271", 524.85000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5139) },
                    { 272, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5141), "Lorem Ipsum is simply dummy text", "Item 272", 944.75, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5142) },
                    { 273, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5143), "Lorem Ipsum is simply dummy text", "Item 273", 465.45999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5144) },
                    { 274, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5145), "Lorem Ipsum is simply dummy text", "Item 274", 290.41000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5146) },
                    { 275, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5148), "Lorem Ipsum is simply dummy text", "Item 275", 30.460000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5148) },
                    { 276, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5150), "Lorem Ipsum is simply dummy text", "Item 276", 506.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5151) },
                    { 277, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5152), "Lorem Ipsum is simply dummy text", "Item 277", 661.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5153) },
                    { 278, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5154), "Lorem Ipsum is simply dummy text", "Item 278", 973.12, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5155) },
                    { 265, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5125), "Lorem Ipsum is simply dummy text", "Item 265", 226.06, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5126) },
                    { 499, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5992), "Lorem Ipsum is simply dummy text", "Item 499", 135.18000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5992) },
                    { 311, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5311), "Lorem Ipsum is simply dummy text", "Item 311", 903.38999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5312) },
                    { 313, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5315), "Lorem Ipsum is simply dummy text", "Item 313", 596.66999999999996, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5316) },
                    { 346, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5431), "Lorem Ipsum is simply dummy text", "Item 346", 73.530000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5432) },
                    { 347, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5434), "Lorem Ipsum is simply dummy text", "Item 347", 457.75999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5435) },
                    { 348, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5436), "Lorem Ipsum is simply dummy text", "Item 348", 113.77, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5437) },
                    { 349, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5438), "Lorem Ipsum is simply dummy text", "Item 349", 546.79999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5439) },
                    { 350, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5440), "Lorem Ipsum is simply dummy text", "Item 350", 352.45999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5441) },
                    { 351, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5442), "Lorem Ipsum is simply dummy text", "Item 351", 117.3, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5443) },
                    { 352, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5445), "Lorem Ipsum is simply dummy text", "Item 352", 519.87, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5445) },
                    { 353, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5447), "Lorem Ipsum is simply dummy text", "Item 353", 806.24000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5448) },
                    { 354, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5449), "Lorem Ipsum is simply dummy text", "Item 354", 528.13999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5450) },
                    { 355, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5451), "Lorem Ipsum is simply dummy text", "Item 355", 102.62, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5452) },
                    { 356, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5454), "Lorem Ipsum is simply dummy text", "Item 356", 531.67999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5454) },
                    { 357, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5456), "Lorem Ipsum is simply dummy text", "Item 357", 339.30000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5457) },
                    { 358, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5458), "Lorem Ipsum is simply dummy text", "Item 358", 898.98000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5459) },
                    { 359, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5460), "Lorem Ipsum is simply dummy text", "Item 359", 932.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5461) },
                    { 360, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5463), "Lorem Ipsum is simply dummy text", "Item 360", 490.44999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5463) },
                    { 361, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5465), "Lorem Ipsum is simply dummy text", "Item 361", 575.39999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5465) },
                    { 362, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5467), "Lorem Ipsum is simply dummy text", "Item 362", 13.06, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5468) },
                    { 363, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5469), "Lorem Ipsum is simply dummy text", "Item 363", 304.17000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5470) },
                    { 364, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5471), "Lorem Ipsum is simply dummy text", "Item 364", 350.06999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5472) },
                    { 365, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5473), "Lorem Ipsum is simply dummy text", "Item 365", 803.30999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5474) },
                    { 366, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5476), "Lorem Ipsum is simply dummy text", "Item 366", 420.88, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5476) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "BrandId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 367, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5478), "Lorem Ipsum is simply dummy text", "Item 367", 980.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5478) },
                    { 368, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5480), "Lorem Ipsum is simply dummy text", "Item 368", 622.64999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5481) },
                    { 369, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5482), "Lorem Ipsum is simply dummy text", "Item 369", 336.74000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5483) },
                    { 370, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5484), "Lorem Ipsum is simply dummy text", "Item 370", 209.09999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5485) },
                    { 371, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5487), "Lorem Ipsum is simply dummy text", "Item 371", 493.92000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5488) },
                    { 372, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5489), "Lorem Ipsum is simply dummy text", "Item 372", 602.79999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5490) },
                    { 345, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5429), "Lorem Ipsum is simply dummy text", "Item 345", 568.46000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5430) },
                    { 344, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5427), "Lorem Ipsum is simply dummy text", "Item 344", 203.28, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5428) },
                    { 343, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5425), "Lorem Ipsum is simply dummy text", "Item 343", 220.52000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5425) },
                    { 342, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5422), "Lorem Ipsum is simply dummy text", "Item 342", 773.80999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5423) },
                    { 314, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5318), "Lorem Ipsum is simply dummy text", "Item 314", 412.89999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5318) },
                    { 315, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5320), "Lorem Ipsum is simply dummy text", "Item 315", 543.29999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5321) },
                    { 316, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5322), "Lorem Ipsum is simply dummy text", "Item 316", 295.16000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5323) },
                    { 317, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5325), "Lorem Ipsum is simply dummy text", "Item 317", 369.18000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5325) },
                    { 318, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5327), "Lorem Ipsum is simply dummy text", "Item 318", 671.38, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5328) },
                    { 319, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5329), "Lorem Ipsum is simply dummy text", "Item 319", 373.16000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5330) },
                    { 320, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5331), "Lorem Ipsum is simply dummy text", "Item 320", 247.55000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5332) },
                    { 321, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5334), "Lorem Ipsum is simply dummy text", "Item 321", 753.37, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5334) },
                    { 322, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5336), "Lorem Ipsum is simply dummy text", "Item 322", 194.28, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5337) },
                    { 323, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5338), "Lorem Ipsum is simply dummy text", "Item 323", 887.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5339) },
                    { 324, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5340), "Lorem Ipsum is simply dummy text", "Item 324", 574.46000000000004, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5341) },
                    { 325, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5343), "Lorem Ipsum is simply dummy text", "Item 325", 831.51999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5343) },
                    { 326, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5345), "Lorem Ipsum is simply dummy text", "Item 326", 470.42000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5346) },
                    { 312, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5313), "Lorem Ipsum is simply dummy text", "Item 312", 178.08000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5314) },
                    { 327, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5347), "Lorem Ipsum is simply dummy text", "Item 327", 418.07999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5348) },
                    { 329, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5351), "Lorem Ipsum is simply dummy text", "Item 329", 642.79999999999995, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5352) },
                    { 330, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5354), "Lorem Ipsum is simply dummy text", "Item 330", 543.98000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5354) },
                    { 331, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5356), "Lorem Ipsum is simply dummy text", "Item 331", 314.88999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5357) },
                    { 332, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5358), "Lorem Ipsum is simply dummy text", "Item 332", 482.50999999999999, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5359) },
                    { 333, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5360), "Lorem Ipsum is simply dummy text", "Item 333", 197.43000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5361) },
                    { 334, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5363), "Lorem Ipsum is simply dummy text", "Item 334", 974.01999999999998, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5363) },
                    { 335, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5365), "Lorem Ipsum is simply dummy text", "Item 335", 76.170000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5366) },
                    { 336, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5408), "Lorem Ipsum is simply dummy text", "Item 336", 334.19, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5409) },
                    { 337, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5411), "Lorem Ipsum is simply dummy text", "Item 337", 801.24000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5412) },
                    { 338, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5413), "Lorem Ipsum is simply dummy text", "Item 338", 766.37, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5414) },
                    { 339, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5416), "Lorem Ipsum is simply dummy text", "Item 339", 685.97000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5416) },
                    { 340, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5418), "Lorem Ipsum is simply dummy text", "Item 340", 557.84000000000003, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5419) },
                    { 341, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5420), "Lorem Ipsum is simply dummy text", "Item 341", 590.10000000000002, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5421) },
                    { 328, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5349), "Lorem Ipsum is simply dummy text", "Item 328", 375.36000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(5350) },
                    { 1000, null, null, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7588), "Lorem Ipsum is simply dummy text", "Item 1000", 342.99000000000001, new DateTime(2021, 6, 14, 17, 4, 0, 681, DateTimeKind.Local).AddTicks(7588) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProduct_ProductId",
                table: "InvoiceProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApplicationUserId",
                table: "Invoices",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSolds_SoldId",
                table: "ProductSolds",
                column: "SoldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InvoiceProduct");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ProductSolds");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Solds");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
