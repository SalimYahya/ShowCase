using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShowCase.Migrations
{
    public partial class InitialMigration : Migration
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
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 4, 3, 22, 37, 3, 434, DateTimeKind.Local).AddTicks(17), "Lorem Ipsum is simply dummy text", "Item 1", 327.54000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(30) },
                    { 659, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7575), "Lorem Ipsum is simply dummy text", "Item 659", 522.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7576) },
                    { 660, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7580), "Lorem Ipsum is simply dummy text", "Item 660", 434.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7581) },
                    { 661, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7584), "Lorem Ipsum is simply dummy text", "Item 661", 452.69, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7585) },
                    { 662, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7587), "Lorem Ipsum is simply dummy text", "Item 662", 618.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7588) },
                    { 663, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7590), "Lorem Ipsum is simply dummy text", "Item 663", 207.53, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7592) },
                    { 664, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7594), "Lorem Ipsum is simply dummy text", "Item 664", 898.26999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7595) },
                    { 665, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7598), "Lorem Ipsum is simply dummy text", "Item 665", 3.73, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7599) },
                    { 666, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7601), "Lorem Ipsum is simply dummy text", "Item 666", 967.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7602) },
                    { 667, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7605), "Lorem Ipsum is simply dummy text", "Item 667", 216.78, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7606) },
                    { 668, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7609), "Lorem Ipsum is simply dummy text", "Item 668", 743.69000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7610) },
                    { 669, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7613), "Lorem Ipsum is simply dummy text", "Item 669", 264.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7614) },
                    { 670, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7616), "Lorem Ipsum is simply dummy text", "Item 670", 645.95000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7618) },
                    { 671, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7620), "Lorem Ipsum is simply dummy text", "Item 671", 870.38999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7621) },
                    { 672, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7623), "Lorem Ipsum is simply dummy text", "Item 672", 957.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7624) },
                    { 673, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7627), "Lorem Ipsum is simply dummy text", "Item 673", 41.259999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7628) },
                    { 674, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7630), "Lorem Ipsum is simply dummy text", "Item 674", 709.83000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7631) },
                    { 675, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7633), "Lorem Ipsum is simply dummy text", "Item 675", 471.22000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7635) },
                    { 676, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7637), "Lorem Ipsum is simply dummy text", "Item 676", 571.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7638) },
                    { 677, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7640), "Lorem Ipsum is simply dummy text", "Item 677", 668.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7642) },
                    { 678, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7644), "Lorem Ipsum is simply dummy text", "Item 678", 448.17000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7645) },
                    { 679, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7647), "Lorem Ipsum is simply dummy text", "Item 679", 932.89999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7649) },
                    { 680, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7651), "Lorem Ipsum is simply dummy text", "Item 680", 746.45000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7652) },
                    { 681, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7654), "Lorem Ipsum is simply dummy text", "Item 681", 969.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7656) },
                    { 682, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7658), "Lorem Ipsum is simply dummy text", "Item 682", 263.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7659) },
                    { 683, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7661), "Lorem Ipsum is simply dummy text", "Item 683", 851.10000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7662) },
                    { 684, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7665), "Lorem Ipsum is simply dummy text", "Item 684", 589.79999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7666) },
                    { 685, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7669), "Lorem Ipsum is simply dummy text", "Item 685", 330.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7670) },
                    { 658, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7535), "Lorem Ipsum is simply dummy text", "Item 658", 27.07, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7536) },
                    { 686, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7672), "Lorem Ipsum is simply dummy text", "Item 686", 584.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7674) },
                    { 657, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7531), "Lorem Ipsum is simply dummy text", "Item 657", 53.43, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7532) },
                    { 655, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7524), "Lorem Ipsum is simply dummy text", "Item 655", 448.95999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7525) },
                    { 628, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7432), "Lorem Ipsum is simply dummy text", "Item 628", 740.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7433) },
                    { 629, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7436), "Lorem Ipsum is simply dummy text", "Item 629", 251.91999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7437) },
                    { 630, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7439), "Lorem Ipsum is simply dummy text", "Item 630", 47.649999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7440) },
                    { 631, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7443), "Lorem Ipsum is simply dummy text", "Item 631", 826.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7444) },
                    { 632, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7446), "Lorem Ipsum is simply dummy text", "Item 632", 92.069999999999993, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7447) },
                    { 633, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7449), "Lorem Ipsum is simply dummy text", "Item 633", 128.16999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7450) },
                    { 634, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7453), "Lorem Ipsum is simply dummy text", "Item 634", 148.68000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7454) },
                    { 635, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7457), "Lorem Ipsum is simply dummy text", "Item 635", 667.00999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7458) },
                    { 636, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7460), "Lorem Ipsum is simply dummy text", "Item 636", 120.03, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7462) },
                    { 637, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7464), "Lorem Ipsum is simply dummy text", "Item 637", 531.03999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7465) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 638, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7467), "Lorem Ipsum is simply dummy text", "Item 638", 58.719999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7468) },
                    { 639, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7471), "Lorem Ipsum is simply dummy text", "Item 639", 788.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7472) },
                    { 640, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7474), "Lorem Ipsum is simply dummy text", "Item 640", 654.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7475) },
                    { 641, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7477), "Lorem Ipsum is simply dummy text", "Item 641", 649.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7478) },
                    { 642, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7480), "Lorem Ipsum is simply dummy text", "Item 642", 315.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7482) },
                    { 643, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7484), "Lorem Ipsum is simply dummy text", "Item 643", 430.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7485) },
                    { 644, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7487), "Lorem Ipsum is simply dummy text", "Item 644", 941.12, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7488) },
                    { 645, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7491), "Lorem Ipsum is simply dummy text", "Item 645", 899.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7492) },
                    { 646, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7494), "Lorem Ipsum is simply dummy text", "Item 646", 75.459999999999994, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7495) },
                    { 647, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7498), "Lorem Ipsum is simply dummy text", "Item 647", 169.00999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7499) },
                    { 648, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7501), "Lorem Ipsum is simply dummy text", "Item 648", 153.87, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7502) },
                    { 649, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7504), "Lorem Ipsum is simply dummy text", "Item 649", 889.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7505) },
                    { 650, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7508), "Lorem Ipsum is simply dummy text", "Item 650", 662.12, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7509) },
                    { 651, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7511), "Lorem Ipsum is simply dummy text", "Item 651", 716.90999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7512) },
                    { 652, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7514), "Lorem Ipsum is simply dummy text", "Item 652", 241.69, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7516) },
                    { 653, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7518), "Lorem Ipsum is simply dummy text", "Item 653", 295.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7519) },
                    { 654, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7521), "Lorem Ipsum is simply dummy text", "Item 654", 827.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7522) },
                    { 656, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7528), "Lorem Ipsum is simply dummy text", "Item 656", 687.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7529) },
                    { 687, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7676), "Lorem Ipsum is simply dummy text", "Item 687", 796.80999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7677) },
                    { 688, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7679), "Lorem Ipsum is simply dummy text", "Item 688", 300.42000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7680) },
                    { 689, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7683), "Lorem Ipsum is simply dummy text", "Item 689", 699.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7684) },
                    { 722, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7820), "Lorem Ipsum is simply dummy text", "Item 722", 916.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7821) },
                    { 723, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7824), "Lorem Ipsum is simply dummy text", "Item 723", 43.960000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7825) },
                    { 724, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7827), "Lorem Ipsum is simply dummy text", "Item 724", 284.33999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7828) },
                    { 725, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7830), "Lorem Ipsum is simply dummy text", "Item 725", 579.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7832) },
                    { 726, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7834), "Lorem Ipsum is simply dummy text", "Item 726", 366.42000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7835) },
                    { 727, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7838), "Lorem Ipsum is simply dummy text", "Item 727", 421.27999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7839) },
                    { 728, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7841), "Lorem Ipsum is simply dummy text", "Item 728", 686.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7842) },
                    { 729, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7845), "Lorem Ipsum is simply dummy text", "Item 729", 508.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7846) },
                    { 730, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7849), "Lorem Ipsum is simply dummy text", "Item 730", 440.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7850) },
                    { 731, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7852), "Lorem Ipsum is simply dummy text", "Item 731", 463.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7853) },
                    { 732, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7855), "Lorem Ipsum is simply dummy text", "Item 732", 136.84999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7856) },
                    { 733, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7859), "Lorem Ipsum is simply dummy text", "Item 733", 510.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7860) },
                    { 734, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7862), "Lorem Ipsum is simply dummy text", "Item 734", 0.92000000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7863) },
                    { 735, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7865), "Lorem Ipsum is simply dummy text", "Item 735", 887.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7866) },
                    { 736, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7869), "Lorem Ipsum is simply dummy text", "Item 736", 544.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7870) },
                    { 737, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7872), "Lorem Ipsum is simply dummy text", "Item 737", 373.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7874) },
                    { 738, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7876), "Lorem Ipsum is simply dummy text", "Item 738", 608.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7877) },
                    { 739, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7879), "Lorem Ipsum is simply dummy text", "Item 739", 798.07000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7880) },
                    { 740, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7882), "Lorem Ipsum is simply dummy text", "Item 740", 571.08000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7884) },
                    { 741, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7886), "Lorem Ipsum is simply dummy text", "Item 741", 384.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7887) },
                    { 742, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7889), "Lorem Ipsum is simply dummy text", "Item 742", 211.40000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7891) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 743, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7893), "Lorem Ipsum is simply dummy text", "Item 743", 943.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7894) },
                    { 744, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7896), "Lorem Ipsum is simply dummy text", "Item 744", 822.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7897) },
                    { 745, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7900), "Lorem Ipsum is simply dummy text", "Item 745", 961.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7901) },
                    { 746, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7903), "Lorem Ipsum is simply dummy text", "Item 746", 461.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7904) },
                    { 747, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7907), "Lorem Ipsum is simply dummy text", "Item 747", 409.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7908) },
                    { 748, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7910), "Lorem Ipsum is simply dummy text", "Item 748", 759.67999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7912) },
                    { 721, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7817), "Lorem Ipsum is simply dummy text", "Item 721", 171.06999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7818) },
                    { 720, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7813), "Lorem Ipsum is simply dummy text", "Item 720", 419.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7815) },
                    { 719, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7810), "Lorem Ipsum is simply dummy text", "Item 719", 567.53999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7811) },
                    { 718, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7806), "Lorem Ipsum is simply dummy text", "Item 718", 617.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7808) },
                    { 690, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7686), "Lorem Ipsum is simply dummy text", "Item 690", 979.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7687) },
                    { 691, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7690), "Lorem Ipsum is simply dummy text", "Item 691", 66.599999999999994, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7691) },
                    { 692, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7693), "Lorem Ipsum is simply dummy text", "Item 692", 503.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7695) },
                    { 693, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7697), "Lorem Ipsum is simply dummy text", "Item 693", 535.98000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7698) },
                    { 694, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7700), "Lorem Ipsum is simply dummy text", "Item 694", 354.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7701) },
                    { 695, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7704), "Lorem Ipsum is simply dummy text", "Item 695", 201.83000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7705) },
                    { 696, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7707), "Lorem Ipsum is simply dummy text", "Item 696", 30.719999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7708) },
                    { 697, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7710), "Lorem Ipsum is simply dummy text", "Item 697", 107.95999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7712) },
                    { 698, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7714), "Lorem Ipsum is simply dummy text", "Item 698", 531.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7715) },
                    { 699, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7717), "Lorem Ipsum is simply dummy text", "Item 699", 937.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7719) },
                    { 700, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7721), "Lorem Ipsum is simply dummy text", "Item 700", 931.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7722) },
                    { 701, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7724), "Lorem Ipsum is simply dummy text", "Item 701", 858.67999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7725) },
                    { 702, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7727), "Lorem Ipsum is simply dummy text", "Item 702", 425.32999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7729) },
                    { 627, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7429), "Lorem Ipsum is simply dummy text", "Item 627", 417.08999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7430) },
                    { 703, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7731), "Lorem Ipsum is simply dummy text", "Item 703", 889.75999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7732) },
                    { 705, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7738), "Lorem Ipsum is simply dummy text", "Item 705", 791.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7739) },
                    { 706, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7742), "Lorem Ipsum is simply dummy text", "Item 706", 759.64999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7743) },
                    { 707, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7745), "Lorem Ipsum is simply dummy text", "Item 707", 200.44, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7746) },
                    { 708, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7771), "Lorem Ipsum is simply dummy text", "Item 708", 585.41999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7773) },
                    { 709, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7775), "Lorem Ipsum is simply dummy text", "Item 709", 356.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7777) },
                    { 710, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7779), "Lorem Ipsum is simply dummy text", "Item 710", 877.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7780) },
                    { 711, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7782), "Lorem Ipsum is simply dummy text", "Item 711", 18.640000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7784) },
                    { 712, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7786), "Lorem Ipsum is simply dummy text", "Item 712", 605.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7787) },
                    { 713, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7789), "Lorem Ipsum is simply dummy text", "Item 713", 94.180000000000007, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7790) },
                    { 714, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7793), "Lorem Ipsum is simply dummy text", "Item 714", 776.29999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7794) },
                    { 715, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7796), "Lorem Ipsum is simply dummy text", "Item 715", 464.39999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7797) },
                    { 716, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7799), "Lorem Ipsum is simply dummy text", "Item 716", 189.47, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7801) },
                    { 717, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7803), "Lorem Ipsum is simply dummy text", "Item 717", 767.67999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7804) },
                    { 704, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7734), "Lorem Ipsum is simply dummy text", "Item 704", 243.06, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7736) },
                    { 749, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7914), "Lorem Ipsum is simply dummy text", "Item 749", 890.09000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7915) },
                    { 626, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7425), "Lorem Ipsum is simply dummy text", "Item 626", 138.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7427) },
                    { 624, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7419), "Lorem Ipsum is simply dummy text", "Item 624", 832.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7420) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 534, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7007), "Lorem Ipsum is simply dummy text", "Item 534", 498.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7008) },
                    { 535, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7010), "Lorem Ipsum is simply dummy text", "Item 535", 771.42999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7011) },
                    { 536, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7013), "Lorem Ipsum is simply dummy text", "Item 536", 841.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7015) },
                    { 537, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7017), "Lorem Ipsum is simply dummy text", "Item 537", 438.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7018) },
                    { 538, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7021), "Lorem Ipsum is simply dummy text", "Item 538", 468.94999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7022) },
                    { 539, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7024), "Lorem Ipsum is simply dummy text", "Item 539", 983.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7025) },
                    { 540, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7028), "Lorem Ipsum is simply dummy text", "Item 540", 855.84000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7029) },
                    { 541, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7032), "Lorem Ipsum is simply dummy text", "Item 541", 152.24000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7032) },
                    { 542, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7035), "Lorem Ipsum is simply dummy text", "Item 542", 263.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7036) },
                    { 543, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7038), "Lorem Ipsum is simply dummy text", "Item 543", 548.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7039) },
                    { 544, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7041), "Lorem Ipsum is simply dummy text", "Item 544", 77.549999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7042) },
                    { 545, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7045), "Lorem Ipsum is simply dummy text", "Item 545", 998.09000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7046) },
                    { 546, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7048), "Lorem Ipsum is simply dummy text", "Item 546", 260.38999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7049) },
                    { 547, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7052), "Lorem Ipsum is simply dummy text", "Item 547", 603.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7053) },
                    { 548, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7055), "Lorem Ipsum is simply dummy text", "Item 548", 652.38999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7056) },
                    { 549, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7058), "Lorem Ipsum is simply dummy text", "Item 549", 586.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7060) },
                    { 550, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7062), "Lorem Ipsum is simply dummy text", "Item 550", 773.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7063) },
                    { 551, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7065), "Lorem Ipsum is simply dummy text", "Item 551", 371.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7066) },
                    { 552, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7068), "Lorem Ipsum is simply dummy text", "Item 552", 754.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7069) },
                    { 553, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7071), "Lorem Ipsum is simply dummy text", "Item 553", 774.90999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7073) },
                    { 554, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7075), "Lorem Ipsum is simply dummy text", "Item 554", 726.45000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7076) },
                    { 555, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7078), "Lorem Ipsum is simply dummy text", "Item 555", 727.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7079) },
                    { 556, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7081), "Lorem Ipsum is simply dummy text", "Item 556", 811.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7082) },
                    { 557, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7085), "Lorem Ipsum is simply dummy text", "Item 557", 421.56999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7086) },
                    { 558, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7088), "Lorem Ipsum is simply dummy text", "Item 558", 377.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7089) },
                    { 559, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7092), "Lorem Ipsum is simply dummy text", "Item 559", 383.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7093) },
                    { 560, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7095), "Lorem Ipsum is simply dummy text", "Item 560", 328.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7096) },
                    { 533, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7004), "Lorem Ipsum is simply dummy text", "Item 533", 102.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7005) },
                    { 561, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7099), "Lorem Ipsum is simply dummy text", "Item 561", 792.28999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7100) },
                    { 532, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7000), "Lorem Ipsum is simply dummy text", "Item 532", 549.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7001) },
                    { 530, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6994), "Lorem Ipsum is simply dummy text", "Item 530", 896.16999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6995) },
                    { 503, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6816), "Lorem Ipsum is simply dummy text", "Item 503", 859.92999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6817) },
                    { 504, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6819), "Lorem Ipsum is simply dummy text", "Item 504", 97.200000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6820) },
                    { 505, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6823), "Lorem Ipsum is simply dummy text", "Item 505", 494.50999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6824) },
                    { 506, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6826), "Lorem Ipsum is simply dummy text", "Item 506", 835.55999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6827) },
                    { 507, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6830), "Lorem Ipsum is simply dummy text", "Item 507", 409.64999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6831) },
                    { 508, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6833), "Lorem Ipsum is simply dummy text", "Item 508", 327.06, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6834) },
                    { 509, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6836), "Lorem Ipsum is simply dummy text", "Item 509", 784.82000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6837) },
                    { 510, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6839), "Lorem Ipsum is simply dummy text", "Item 510", 891.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6841) },
                    { 511, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6843), "Lorem Ipsum is simply dummy text", "Item 511", 211.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6844) },
                    { 512, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6847), "Lorem Ipsum is simply dummy text", "Item 512", 576.92999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6848) },
                    { 513, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6884), "Lorem Ipsum is simply dummy text", "Item 513", 659.03999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6886) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 514, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6935), "Lorem Ipsum is simply dummy text", "Item 514", 564.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6936) },
                    { 515, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6940), "Lorem Ipsum is simply dummy text", "Item 515", 84.269999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6941) },
                    { 516, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6943), "Lorem Ipsum is simply dummy text", "Item 516", 638.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6944) },
                    { 517, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6947), "Lorem Ipsum is simply dummy text", "Item 517", 971.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6948) },
                    { 518, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6950), "Lorem Ipsum is simply dummy text", "Item 518", 378.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6952) },
                    { 519, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6954), "Lorem Ipsum is simply dummy text", "Item 519", 171.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6955) },
                    { 520, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6958), "Lorem Ipsum is simply dummy text", "Item 520", 932.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6959) },
                    { 521, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6961), "Lorem Ipsum is simply dummy text", "Item 521", 161.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6962) },
                    { 522, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6965), "Lorem Ipsum is simply dummy text", "Item 522", 299.93000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6966) },
                    { 523, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6968), "Lorem Ipsum is simply dummy text", "Item 523", 154.18000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6969) },
                    { 524, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6972), "Lorem Ipsum is simply dummy text", "Item 524", 482.82999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6973) },
                    { 525, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6976), "Lorem Ipsum is simply dummy text", "Item 525", 713.24000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6977) },
                    { 526, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6979), "Lorem Ipsum is simply dummy text", "Item 526", 165.78, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6980) },
                    { 527, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6983), "Lorem Ipsum is simply dummy text", "Item 527", 43.259999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6984) },
                    { 528, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6986), "Lorem Ipsum is simply dummy text", "Item 528", 990.30999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6988) },
                    { 529, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6990), "Lorem Ipsum is simply dummy text", "Item 529", 135.21000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6991) },
                    { 531, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6997), "Lorem Ipsum is simply dummy text", "Item 531", 762.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6998) },
                    { 562, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7134), "Lorem Ipsum is simply dummy text", "Item 562", 419.33999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7136) },
                    { 563, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7139), "Lorem Ipsum is simply dummy text", "Item 563", 191.84999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7141) },
                    { 564, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7143), "Lorem Ipsum is simply dummy text", "Item 564", 888.65999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7145) },
                    { 597, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7258), "Lorem Ipsum is simply dummy text", "Item 597", 71.680000000000007, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7259) },
                    { 598, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7261), "Lorem Ipsum is simply dummy text", "Item 598", 659.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7262) },
                    { 599, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7264), "Lorem Ipsum is simply dummy text", "Item 599", 948.46000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7265) },
                    { 600, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7268), "Lorem Ipsum is simply dummy text", "Item 600", 336.05000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7269) },
                    { 601, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7272), "Lorem Ipsum is simply dummy text", "Item 601", 785.84000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7273) },
                    { 602, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7275), "Lorem Ipsum is simply dummy text", "Item 602", 442.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7277) },
                    { 603, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7279), "Lorem Ipsum is simply dummy text", "Item 603", 859.83000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7280) },
                    { 604, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7282), "Lorem Ipsum is simply dummy text", "Item 604", 344.63999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7284) },
                    { 605, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7286), "Lorem Ipsum is simply dummy text", "Item 605", 573.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7287) },
                    { 606, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7289), "Lorem Ipsum is simply dummy text", "Item 606", 869.77999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7291) },
                    { 607, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7293), "Lorem Ipsum is simply dummy text", "Item 607", 358.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7294) },
                    { 608, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7297), "Lorem Ipsum is simply dummy text", "Item 608", 459.44999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7298) },
                    { 609, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7301), "Lorem Ipsum is simply dummy text", "Item 609", 945.90999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7302) },
                    { 610, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7305), "Lorem Ipsum is simply dummy text", "Item 610", 829.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7306) },
                    { 611, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7370), "Lorem Ipsum is simply dummy text", "Item 611", 59.950000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7372) },
                    { 612, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7375), "Lorem Ipsum is simply dummy text", "Item 612", 344.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7377) },
                    { 613, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7379), "Lorem Ipsum is simply dummy text", "Item 613", 892.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7381) },
                    { 614, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7383), "Lorem Ipsum is simply dummy text", "Item 614", 931.12, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7384) },
                    { 615, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7387), "Lorem Ipsum is simply dummy text", "Item 615", 765.98000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7388) },
                    { 616, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7390), "Lorem Ipsum is simply dummy text", "Item 616", 401.43000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7391) },
                    { 617, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7394), "Lorem Ipsum is simply dummy text", "Item 617", 15.98, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7395) },
                    { 618, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7397), "Lorem Ipsum is simply dummy text", "Item 618", 829.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7399) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 619, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7401), "Lorem Ipsum is simply dummy text", "Item 619", 364.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7402) },
                    { 620, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7405), "Lorem Ipsum is simply dummy text", "Item 620", 120.70999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7406) },
                    { 621, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7408), "Lorem Ipsum is simply dummy text", "Item 621", 887.09000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7410) },
                    { 622, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7412), "Lorem Ipsum is simply dummy text", "Item 622", 98.609999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7413) },
                    { 623, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7415), "Lorem Ipsum is simply dummy text", "Item 623", 389.29000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7416) },
                    { 596, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7254), "Lorem Ipsum is simply dummy text", "Item 596", 732.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7255) },
                    { 595, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7251), "Lorem Ipsum is simply dummy text", "Item 595", 63.539999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7252) },
                    { 594, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7247), "Lorem Ipsum is simply dummy text", "Item 594", 655.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7249) },
                    { 593, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7244), "Lorem Ipsum is simply dummy text", "Item 593", 84.989999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7245) },
                    { 565, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7147), "Lorem Ipsum is simply dummy text", "Item 565", 129.09, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7148) },
                    { 566, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7150), "Lorem Ipsum is simply dummy text", "Item 566", 662.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7151) },
                    { 567, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7154), "Lorem Ipsum is simply dummy text", "Item 567", 474.54000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7155) },
                    { 568, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7157), "Lorem Ipsum is simply dummy text", "Item 568", 160.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7158) },
                    { 569, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7160), "Lorem Ipsum is simply dummy text", "Item 569", 792.57000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7161) },
                    { 570, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7164), "Lorem Ipsum is simply dummy text", "Item 570", 242.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7165) },
                    { 571, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7167), "Lorem Ipsum is simply dummy text", "Item 571", 200.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7168) },
                    { 572, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7170), "Lorem Ipsum is simply dummy text", "Item 572", 502.07999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7172) },
                    { 573, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7174), "Lorem Ipsum is simply dummy text", "Item 573", 395.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7175) },
                    { 574, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7177), "Lorem Ipsum is simply dummy text", "Item 574", 315.45999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7179) },
                    { 575, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7181), "Lorem Ipsum is simply dummy text", "Item 575", 780.53999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7182) },
                    { 576, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7185), "Lorem Ipsum is simply dummy text", "Item 576", 897.84000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7186) },
                    { 577, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7188), "Lorem Ipsum is simply dummy text", "Item 577", 751.66999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7189) },
                    { 625, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7422), "Lorem Ipsum is simply dummy text", "Item 625", 821.89999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7423) },
                    { 578, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7191), "Lorem Ipsum is simply dummy text", "Item 578", 76.629999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7192) },
                    { 580, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7198), "Lorem Ipsum is simply dummy text", "Item 580", 452.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7199) },
                    { 581, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7202), "Lorem Ipsum is simply dummy text", "Item 581", 562.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7203) },
                    { 582, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7205), "Lorem Ipsum is simply dummy text", "Item 582", 390.87, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7206) },
                    { 583, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7209), "Lorem Ipsum is simply dummy text", "Item 583", 403.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7210) },
                    { 584, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7212), "Lorem Ipsum is simply dummy text", "Item 584", 361.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7213) },
                    { 585, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7216), "Lorem Ipsum is simply dummy text", "Item 585", 524.29999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7217) },
                    { 586, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7219), "Lorem Ipsum is simply dummy text", "Item 586", 8.3800000000000008, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7221) },
                    { 587, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7224), "Lorem Ipsum is simply dummy text", "Item 587", 774.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7225) },
                    { 588, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7227), "Lorem Ipsum is simply dummy text", "Item 588", 375.93000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7228) },
                    { 589, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7231), "Lorem Ipsum is simply dummy text", "Item 589", 771.00999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7232) },
                    { 590, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7234), "Lorem Ipsum is simply dummy text", "Item 590", 959.80999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7235) },
                    { 591, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7237), "Lorem Ipsum is simply dummy text", "Item 591", 420.39999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7238) },
                    { 592, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7241), "Lorem Ipsum is simply dummy text", "Item 592", 61.380000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7242) },
                    { 579, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7195), "Lorem Ipsum is simply dummy text", "Item 579", 484.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7196) },
                    { 502, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6812), "Lorem Ipsum is simply dummy text", "Item 502", 575.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6813) },
                    { 750, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7918), "Lorem Ipsum is simply dummy text", "Item 750", 12.359999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7919) },
                    { 752, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7924), "Lorem Ipsum is simply dummy text", "Item 752", 490.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7925) },
                    { 909, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8616), "Lorem Ipsum is simply dummy text", "Item 909", 830.79999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8617) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 910, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8619), "Lorem Ipsum is simply dummy text", "Item 910", 865.89999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8621) },
                    { 911, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8623), "Lorem Ipsum is simply dummy text", "Item 911", 673.04999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8624) },
                    { 912, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8627), "Lorem Ipsum is simply dummy text", "Item 912", 48.850000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8628) },
                    { 913, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8630), "Lorem Ipsum is simply dummy text", "Item 913", 960.54999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8631) },
                    { 914, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8633), "Lorem Ipsum is simply dummy text", "Item 914", 460.16000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8635) },
                    { 915, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8637), "Lorem Ipsum is simply dummy text", "Item 915", 586.30999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8638) },
                    { 916, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8641), "Lorem Ipsum is simply dummy text", "Item 916", 71.340000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8642) },
                    { 917, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8644), "Lorem Ipsum is simply dummy text", "Item 917", 680.82000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8645) },
                    { 918, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8648), "Lorem Ipsum is simply dummy text", "Item 918", 996.21000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8649) },
                    { 919, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8651), "Lorem Ipsum is simply dummy text", "Item 919", 306.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8653) },
                    { 920, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8655), "Lorem Ipsum is simply dummy text", "Item 920", 702.03999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8656) },
                    { 921, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8658), "Lorem Ipsum is simply dummy text", "Item 921", 369.93000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8659) },
                    { 922, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8662), "Lorem Ipsum is simply dummy text", "Item 922", 502.07999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8663) },
                    { 923, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8667), "Lorem Ipsum is simply dummy text", "Item 923", 164.71000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8669) },
                    { 924, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8672), "Lorem Ipsum is simply dummy text", "Item 924", 308.54000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8674) },
                    { 925, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8676), "Lorem Ipsum is simply dummy text", "Item 925", 651.79999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8678) },
                    { 926, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8682), "Lorem Ipsum is simply dummy text", "Item 926", 23.940000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8684) },
                    { 927, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8688), "Lorem Ipsum is simply dummy text", "Item 927", 277.56, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8690) },
                    { 928, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8694), "Lorem Ipsum is simply dummy text", "Item 928", 131.63999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8696) },
                    { 929, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8698), "Lorem Ipsum is simply dummy text", "Item 929", 478.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8701) },
                    { 930, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8706), "Lorem Ipsum is simply dummy text", "Item 930", 58.32, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8707) },
                    { 931, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8710), "Lorem Ipsum is simply dummy text", "Item 931", 503.43000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8713) },
                    { 932, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8717), "Lorem Ipsum is simply dummy text", "Item 932", 400.26999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8718) },
                    { 933, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8722), "Lorem Ipsum is simply dummy text", "Item 933", 951.17999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8724) },
                    { 934, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8728), "Lorem Ipsum is simply dummy text", "Item 934", 17.190000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8730) },
                    { 935, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8735), "Lorem Ipsum is simply dummy text", "Item 935", 96.700000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8739) },
                    { 908, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8613), "Lorem Ipsum is simply dummy text", "Item 908", 624.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8614) },
                    { 936, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8744), "Lorem Ipsum is simply dummy text", "Item 936", 114.64, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8745) },
                    { 907, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8609), "Lorem Ipsum is simply dummy text", "Item 907", 269.70999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8610) },
                    { 905, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8603), "Lorem Ipsum is simply dummy text", "Item 905", 669.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8604) },
                    { 878, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8475), "Lorem Ipsum is simply dummy text", "Item 878", 414.44, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8476) },
                    { 879, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8478), "Lorem Ipsum is simply dummy text", "Item 879", 967.50999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8480) },
                    { 880, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8482), "Lorem Ipsum is simply dummy text", "Item 880", 753.33000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8483) },
                    { 881, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8485), "Lorem Ipsum is simply dummy text", "Item 881", 562.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8486) },
                    { 882, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8489), "Lorem Ipsum is simply dummy text", "Item 882", 816.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8490) },
                    { 883, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8492), "Lorem Ipsum is simply dummy text", "Item 883", 542.84000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8493) },
                    { 884, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8496), "Lorem Ipsum is simply dummy text", "Item 884", 207.80000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8497) },
                    { 885, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8500), "Lorem Ipsum is simply dummy text", "Item 885", 11.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8501) },
                    { 886, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8503), "Lorem Ipsum is simply dummy text", "Item 886", 273.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8504) },
                    { 887, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8507), "Lorem Ipsum is simply dummy text", "Item 887", 655.33000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8508) },
                    { 888, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8510), "Lorem Ipsum is simply dummy text", "Item 888", 844.69000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8511) },
                    { 889, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8513), "Lorem Ipsum is simply dummy text", "Item 889", 873.65999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8514) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 890, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8517), "Lorem Ipsum is simply dummy text", "Item 890", 486.05000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8518) },
                    { 891, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8520), "Lorem Ipsum is simply dummy text", "Item 891", 176.78999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8521) },
                    { 892, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8524), "Lorem Ipsum is simply dummy text", "Item 892", 862.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8525) },
                    { 893, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8527), "Lorem Ipsum is simply dummy text", "Item 893", 612.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8528) },
                    { 894, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8531), "Lorem Ipsum is simply dummy text", "Item 894", 150.84999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8532) },
                    { 895, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8534), "Lorem Ipsum is simply dummy text", "Item 895", 185.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8535) },
                    { 896, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8537), "Lorem Ipsum is simply dummy text", "Item 896", 79.170000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8539) },
                    { 897, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8541), "Lorem Ipsum is simply dummy text", "Item 897", 0.84999999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8542) },
                    { 898, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8544), "Lorem Ipsum is simply dummy text", "Item 898", 191.75999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8545) },
                    { 899, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8547), "Lorem Ipsum is simply dummy text", "Item 899", 463.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8548) },
                    { 900, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8551), "Lorem Ipsum is simply dummy text", "Item 900", 950.32000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8552) },
                    { 901, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8554), "Lorem Ipsum is simply dummy text", "Item 901", 656.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8555) },
                    { 902, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8590), "Lorem Ipsum is simply dummy text", "Item 902", 447.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8592) },
                    { 903, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8595), "Lorem Ipsum is simply dummy text", "Item 903", 604.00999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8597) },
                    { 904, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8599), "Lorem Ipsum is simply dummy text", "Item 904", 75.469999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8600) },
                    { 906, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8606), "Lorem Ipsum is simply dummy text", "Item 906", 262.82999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8607) },
                    { 937, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8748), "Lorem Ipsum is simply dummy text", "Item 937", 212.72, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8749) },
                    { 938, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8752), "Lorem Ipsum is simply dummy text", "Item 938", 467.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8753) },
                    { 939, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8755), "Lorem Ipsum is simply dummy text", "Item 939", 538.19000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8756) },
                    { 972, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8906), "Lorem Ipsum is simply dummy text", "Item 972", 213.44999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8907) },
                    { 973, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8910), "Lorem Ipsum is simply dummy text", "Item 973", 458.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8911) },
                    { 974, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8913), "Lorem Ipsum is simply dummy text", "Item 974", 557.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8914) },
                    { 975, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8916), "Lorem Ipsum is simply dummy text", "Item 975", 698.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8918) },
                    { 976, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8920), "Lorem Ipsum is simply dummy text", "Item 976", 339.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8921) },
                    { 977, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8924), "Lorem Ipsum is simply dummy text", "Item 977", 488.19999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8925) },
                    { 978, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8927), "Lorem Ipsum is simply dummy text", "Item 978", 156.94999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8928) },
                    { 979, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8930), "Lorem Ipsum is simply dummy text", "Item 979", 495.55000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8931) },
                    { 980, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8934), "Lorem Ipsum is simply dummy text", "Item 980", 523.87, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8935) },
                    { 981, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8937), "Lorem Ipsum is simply dummy text", "Item 981", 122.11, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8938) },
                    { 982, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8940), "Lorem Ipsum is simply dummy text", "Item 982", 124.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8941) },
                    { 983, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8943), "Lorem Ipsum is simply dummy text", "Item 983", 567.10000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8944) },
                    { 984, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8946), "Lorem Ipsum is simply dummy text", "Item 984", 363.88, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8948) },
                    { 985, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8950), "Lorem Ipsum is simply dummy text", "Item 985", 659.96000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8951) },
                    { 986, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8954), "Lorem Ipsum is simply dummy text", "Item 986", 498.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8955) },
                    { 987, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8957), "Lorem Ipsum is simply dummy text", "Item 987", 515.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8958) },
                    { 988, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8960), "Lorem Ipsum is simply dummy text", "Item 988", 189.96000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8962) },
                    { 989, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8964), "Lorem Ipsum is simply dummy text", "Item 989", 436.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8965) },
                    { 990, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8968), "Lorem Ipsum is simply dummy text", "Item 990", 942.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8969) },
                    { 991, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8971), "Lorem Ipsum is simply dummy text", "Item 991", 831.88, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8972) },
                    { 992, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8975), "Lorem Ipsum is simply dummy text", "Item 992", 917.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8976) },
                    { 993, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8978), "Lorem Ipsum is simply dummy text", "Item 993", 43.700000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8979) },
                    { 994, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8982), "Lorem Ipsum is simply dummy text", "Item 994", 892.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8983) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 995, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8986), "Lorem Ipsum is simply dummy text", "Item 995", 763.38999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8987) },
                    { 996, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8989), "Lorem Ipsum is simply dummy text", "Item 996", 865.71000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8990) },
                    { 997, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8993), "Lorem Ipsum is simply dummy text", "Item 997", 884.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8994) },
                    { 998, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8996), "Lorem Ipsum is simply dummy text", "Item 998", 241.41, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8997) },
                    { 971, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8903), "Lorem Ipsum is simply dummy text", "Item 971", 858.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8904) },
                    { 970, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8899), "Lorem Ipsum is simply dummy text", "Item 970", 471.67000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8900) },
                    { 969, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8896), "Lorem Ipsum is simply dummy text", "Item 969", 363.45999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8897) },
                    { 968, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8892), "Lorem Ipsum is simply dummy text", "Item 968", 943.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8893) },
                    { 940, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8758), "Lorem Ipsum is simply dummy text", "Item 940", 748.66999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8760) },
                    { 941, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8762), "Lorem Ipsum is simply dummy text", "Item 941", 3.7799999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8763) },
                    { 942, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8765), "Lorem Ipsum is simply dummy text", "Item 942", 30.57, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8767) },
                    { 943, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8769), "Lorem Ipsum is simply dummy text", "Item 943", 13.890000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8770) },
                    { 944, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8772), "Lorem Ipsum is simply dummy text", "Item 944", 7.7599999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8773) },
                    { 945, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8775), "Lorem Ipsum is simply dummy text", "Item 945", 812.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8777) },
                    { 946, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8779), "Lorem Ipsum is simply dummy text", "Item 946", 127.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8780) },
                    { 947, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8783), "Lorem Ipsum is simply dummy text", "Item 947", 901.83000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8784) },
                    { 948, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8786), "Lorem Ipsum is simply dummy text", "Item 948", 152.81, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8787) },
                    { 949, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8789), "Lorem Ipsum is simply dummy text", "Item 949", 564.53999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8790) },
                    { 950, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8792), "Lorem Ipsum is simply dummy text", "Item 950", 114.65000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8794) },
                    { 951, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8832), "Lorem Ipsum is simply dummy text", "Item 951", 398.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8833) },
                    { 952, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8836), "Lorem Ipsum is simply dummy text", "Item 952", 4.6399999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8837) },
                    { 877, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8472), "Lorem Ipsum is simply dummy text", "Item 877", 592.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8473) },
                    { 953, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8840), "Lorem Ipsum is simply dummy text", "Item 953", 885.24000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8841) },
                    { 955, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8847), "Lorem Ipsum is simply dummy text", "Item 955", 580.39999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8848) },
                    { 956, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8851), "Lorem Ipsum is simply dummy text", "Item 956", 154.53999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8852) },
                    { 957, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8855), "Lorem Ipsum is simply dummy text", "Item 957", 282.75999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8856) },
                    { 958, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8858), "Lorem Ipsum is simply dummy text", "Item 958", 295.45999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8859) },
                    { 959, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8861), "Lorem Ipsum is simply dummy text", "Item 959", 423.67000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8862) },
                    { 960, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8865), "Lorem Ipsum is simply dummy text", "Item 960", 645.66999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8866) },
                    { 961, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8868), "Lorem Ipsum is simply dummy text", "Item 961", 985.26999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8869) },
                    { 962, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8872), "Lorem Ipsum is simply dummy text", "Item 962", 138.06999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8873) },
                    { 963, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8875), "Lorem Ipsum is simply dummy text", "Item 963", 146.22, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8876) },
                    { 964, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8879), "Lorem Ipsum is simply dummy text", "Item 964", 772.48000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8880) },
                    { 965, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8882), "Lorem Ipsum is simply dummy text", "Item 965", 362.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8883) },
                    { 966, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8886), "Lorem Ipsum is simply dummy text", "Item 966", 272.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8887) },
                    { 967, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8889), "Lorem Ipsum is simply dummy text", "Item 967", 97.670000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8890) },
                    { 954, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8844), "Lorem Ipsum is simply dummy text", "Item 954", 761.22000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8845) },
                    { 751, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7921), "Lorem Ipsum is simply dummy text", "Item 751", 263.04000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7922) },
                    { 876, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8467), "Lorem Ipsum is simply dummy text", "Item 876", 504.29000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8469) },
                    { 874, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8460), "Lorem Ipsum is simply dummy text", "Item 874", 664.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8461) },
                    { 784, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8082), "Lorem Ipsum is simply dummy text", "Item 784", 495.63999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8083) },
                    { 785, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8086), "Lorem Ipsum is simply dummy text", "Item 785", 177.44999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8087) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 786, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8089), "Lorem Ipsum is simply dummy text", "Item 786", 973.39999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8090) },
                    { 787, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8092), "Lorem Ipsum is simply dummy text", "Item 787", 172.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8093) },
                    { 788, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8096), "Lorem Ipsum is simply dummy text", "Item 788", 992.66999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8097) },
                    { 789, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8099), "Lorem Ipsum is simply dummy text", "Item 789", 240.02000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8100) },
                    { 790, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8102), "Lorem Ipsum is simply dummy text", "Item 790", 945.44000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8103) },
                    { 791, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8106), "Lorem Ipsum is simply dummy text", "Item 791", 163.16, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8107) },
                    { 792, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8109), "Lorem Ipsum is simply dummy text", "Item 792", 768.04999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8110) },
                    { 793, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8112), "Lorem Ipsum is simply dummy text", "Item 793", 944.32000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8114) },
                    { 794, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8116), "Lorem Ipsum is simply dummy text", "Item 794", 372.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8118) },
                    { 795, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8120), "Lorem Ipsum is simply dummy text", "Item 795", 232.71000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8121) },
                    { 796, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8123), "Lorem Ipsum is simply dummy text", "Item 796", 870.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8125) },
                    { 797, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8127), "Lorem Ipsum is simply dummy text", "Item 797", 133.97999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8128) },
                    { 798, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8130), "Lorem Ipsum is simply dummy text", "Item 798", 27.859999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8131) },
                    { 799, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8133), "Lorem Ipsum is simply dummy text", "Item 799", 408.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8135) },
                    { 800, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8137), "Lorem Ipsum is simply dummy text", "Item 800", 79.349999999999994, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8138) },
                    { 801, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8141), "Lorem Ipsum is simply dummy text", "Item 801", 366.88, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8142) },
                    { 802, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8144), "Lorem Ipsum is simply dummy text", "Item 802", 316.54000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8145) },
                    { 803, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8148), "Lorem Ipsum is simply dummy text", "Item 803", 871.14999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8149) },
                    { 804, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8151), "Lorem Ipsum is simply dummy text", "Item 804", 970.21000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8153) },
                    { 805, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8189), "Lorem Ipsum is simply dummy text", "Item 805", 196.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8191) },
                    { 806, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8193), "Lorem Ipsum is simply dummy text", "Item 806", 103.40000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8195) },
                    { 807, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8197), "Lorem Ipsum is simply dummy text", "Item 807", 670.57000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8198) },
                    { 808, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8200), "Lorem Ipsum is simply dummy text", "Item 808", 967.75999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8201) },
                    { 809, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8204), "Lorem Ipsum is simply dummy text", "Item 809", 482.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8205) },
                    { 810, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8207), "Lorem Ipsum is simply dummy text", "Item 810", 801.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8209) },
                    { 783, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8079), "Lorem Ipsum is simply dummy text", "Item 783", 796.66999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8080) },
                    { 811, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8211), "Lorem Ipsum is simply dummy text", "Item 811", 969.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8213) },
                    { 782, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8075), "Lorem Ipsum is simply dummy text", "Item 782", 661.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8076) },
                    { 780, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8068), "Lorem Ipsum is simply dummy text", "Item 780", 118.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8069) },
                    { 753, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7927), "Lorem Ipsum is simply dummy text", "Item 753", 964.21000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7928) },
                    { 754, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7930), "Lorem Ipsum is simply dummy text", "Item 754", 518.12, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7931) },
                    { 755, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7934), "Lorem Ipsum is simply dummy text", "Item 755", 760.89999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7935) },
                    { 756, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7983), "Lorem Ipsum is simply dummy text", "Item 756", 942.33000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7985) },
                    { 757, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7989), "Lorem Ipsum is simply dummy text", "Item 757", 381.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7990) },
                    { 758, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7992), "Lorem Ipsum is simply dummy text", "Item 758", 605.41999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7994) },
                    { 759, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7996), "Lorem Ipsum is simply dummy text", "Item 759", 663.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7997) },
                    { 760, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(7999), "Lorem Ipsum is simply dummy text", "Item 760", 425.31, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8000) },
                    { 761, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8002), "Lorem Ipsum is simply dummy text", "Item 761", 338.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8003) },
                    { 762, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8006), "Lorem Ipsum is simply dummy text", "Item 762", 513.66999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8007) },
                    { 763, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8009), "Lorem Ipsum is simply dummy text", "Item 763", 77.409999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8010) },
                    { 764, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8013), "Lorem Ipsum is simply dummy text", "Item 764", 916.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8014) },
                    { 765, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8016), "Lorem Ipsum is simply dummy text", "Item 765", 413.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8017) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 766, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8019), "Lorem Ipsum is simply dummy text", "Item 766", 881.78999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8020) },
                    { 767, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8023), "Lorem Ipsum is simply dummy text", "Item 767", 94.469999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8024) },
                    { 768, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8026), "Lorem Ipsum is simply dummy text", "Item 768", 93.260000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8027) },
                    { 769, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8030), "Lorem Ipsum is simply dummy text", "Item 769", 888.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8031) },
                    { 770, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8033), "Lorem Ipsum is simply dummy text", "Item 770", 919.88, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8035) },
                    { 771, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8037), "Lorem Ipsum is simply dummy text", "Item 771", 816.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8038) },
                    { 772, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8041), "Lorem Ipsum is simply dummy text", "Item 772", 159.65000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8042) },
                    { 773, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8044), "Lorem Ipsum is simply dummy text", "Item 773", 819.65999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8045) },
                    { 774, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8048), "Lorem Ipsum is simply dummy text", "Item 774", 996.45000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8049) },
                    { 775, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8051), "Lorem Ipsum is simply dummy text", "Item 775", 35.229999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8052) },
                    { 776, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8054), "Lorem Ipsum is simply dummy text", "Item 776", 959.67999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8055) },
                    { 777, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8058), "Lorem Ipsum is simply dummy text", "Item 777", 972.46000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8059) },
                    { 778, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8061), "Lorem Ipsum is simply dummy text", "Item 778", 221.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8062) },
                    { 779, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8065), "Lorem Ipsum is simply dummy text", "Item 779", 323.19999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8066) },
                    { 781, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8072), "Lorem Ipsum is simply dummy text", "Item 781", 956.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8073) },
                    { 812, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8215), "Lorem Ipsum is simply dummy text", "Item 812", 159.75999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8216) },
                    { 813, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8218), "Lorem Ipsum is simply dummy text", "Item 813", 282.22000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8219) },
                    { 814, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8221), "Lorem Ipsum is simply dummy text", "Item 814", 545.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8222) },
                    { 847, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8334), "Lorem Ipsum is simply dummy text", "Item 847", 485.82999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8335) },
                    { 848, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8337), "Lorem Ipsum is simply dummy text", "Item 848", 398.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8338) },
                    { 849, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8341), "Lorem Ipsum is simply dummy text", "Item 849", 904.07000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8342) },
                    { 850, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8344), "Lorem Ipsum is simply dummy text", "Item 850", 555.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8346) },
                    { 851, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8348), "Lorem Ipsum is simply dummy text", "Item 851", 153.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8349) },
                    { 852, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8351), "Lorem Ipsum is simply dummy text", "Item 852", 552.21000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8352) },
                    { 853, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8387), "Lorem Ipsum is simply dummy text", "Item 853", 289.27999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8389) },
                    { 854, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8392), "Lorem Ipsum is simply dummy text", "Item 854", 968.28999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8393) },
                    { 855, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8395), "Lorem Ipsum is simply dummy text", "Item 855", 370.19, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8396) },
                    { 856, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8399), "Lorem Ipsum is simply dummy text", "Item 856", 265.07999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8400) },
                    { 857, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8402), "Lorem Ipsum is simply dummy text", "Item 857", 463.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8404) },
                    { 858, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8406), "Lorem Ipsum is simply dummy text", "Item 858", 928.05999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8407) },
                    { 859, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8410), "Lorem Ipsum is simply dummy text", "Item 859", 213.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8411) },
                    { 860, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8413), "Lorem Ipsum is simply dummy text", "Item 860", 148.41999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8414) },
                    { 861, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8416), "Lorem Ipsum is simply dummy text", "Item 861", 888.07000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8417) },
                    { 862, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8420), "Lorem Ipsum is simply dummy text", "Item 862", 223.66, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8421) },
                    { 863, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8423), "Lorem Ipsum is simply dummy text", "Item 863", 204.02000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8424) },
                    { 864, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8426), "Lorem Ipsum is simply dummy text", "Item 864", 318.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8427) },
                    { 865, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8430), "Lorem Ipsum is simply dummy text", "Item 865", 975.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8431) },
                    { 866, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8433), "Lorem Ipsum is simply dummy text", "Item 866", 25.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8434) },
                    { 867, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8437), "Lorem Ipsum is simply dummy text", "Item 867", 346.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8438) },
                    { 868, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8440), "Lorem Ipsum is simply dummy text", "Item 868", 38.369999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8441) },
                    { 869, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8443), "Lorem Ipsum is simply dummy text", "Item 869", 794.59000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8445) },
                    { 870, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8447), "Lorem Ipsum is simply dummy text", "Item 870", 828.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8448) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 871, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8450), "Lorem Ipsum is simply dummy text", "Item 871", 886.33000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8451) },
                    { 872, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8453), "Lorem Ipsum is simply dummy text", "Item 872", 890.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8455) },
                    { 873, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8457), "Lorem Ipsum is simply dummy text", "Item 873", 282.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8458) },
                    { 846, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8330), "Lorem Ipsum is simply dummy text", "Item 846", 3.3999999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8331) },
                    { 845, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8326), "Lorem Ipsum is simply dummy text", "Item 845", 975.58000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8328) },
                    { 844, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8323), "Lorem Ipsum is simply dummy text", "Item 844", 438.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8324) },
                    { 843, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8320), "Lorem Ipsum is simply dummy text", "Item 843", 509.77999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8321) },
                    { 815, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8224), "Lorem Ipsum is simply dummy text", "Item 815", 468.69, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8225) },
                    { 816, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8227), "Lorem Ipsum is simply dummy text", "Item 816", 676.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8229) },
                    { 817, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8231), "Lorem Ipsum is simply dummy text", "Item 817", 717.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8232) },
                    { 818, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8234), "Lorem Ipsum is simply dummy text", "Item 818", 581.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8235) },
                    { 819, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8237), "Lorem Ipsum is simply dummy text", "Item 819", 738.58000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8238) },
                    { 820, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8240), "Lorem Ipsum is simply dummy text", "Item 820", 440.32999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8241) },
                    { 821, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8244), "Lorem Ipsum is simply dummy text", "Item 821", 709.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8245) },
                    { 822, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8247), "Lorem Ipsum is simply dummy text", "Item 822", 101.8, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8248) },
                    { 823, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8251), "Lorem Ipsum is simply dummy text", "Item 823", 853.24000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8252) },
                    { 824, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8254), "Lorem Ipsum is simply dummy text", "Item 824", 943.09000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8255) },
                    { 825, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8257), "Lorem Ipsum is simply dummy text", "Item 825", 756.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8258) },
                    { 826, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8261), "Lorem Ipsum is simply dummy text", "Item 826", 47.939999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8262) },
                    { 827, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8264), "Lorem Ipsum is simply dummy text", "Item 827", 215.33000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8266) },
                    { 875, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8464), "Lorem Ipsum is simply dummy text", "Item 875", 137.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8465) },
                    { 828, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8268), "Lorem Ipsum is simply dummy text", "Item 828", 446.91000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8269) },
                    { 830, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8275), "Lorem Ipsum is simply dummy text", "Item 830", 164.87, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8276) },
                    { 831, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8278), "Lorem Ipsum is simply dummy text", "Item 831", 825.70000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8280) },
                    { 832, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8282), "Lorem Ipsum is simply dummy text", "Item 832", 944.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8283) },
                    { 833, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8285), "Lorem Ipsum is simply dummy text", "Item 833", 812.98000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8286) },
                    { 834, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8289), "Lorem Ipsum is simply dummy text", "Item 834", 243.84999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8290) },
                    { 835, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8292), "Lorem Ipsum is simply dummy text", "Item 835", 751.12, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8293) },
                    { 836, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8296), "Lorem Ipsum is simply dummy text", "Item 836", 640.09000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8297) },
                    { 837, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8299), "Lorem Ipsum is simply dummy text", "Item 837", 790.45000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8300) },
                    { 838, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8303), "Lorem Ipsum is simply dummy text", "Item 838", 826.46000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8304) },
                    { 839, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8306), "Lorem Ipsum is simply dummy text", "Item 839", 299.27999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8307) },
                    { 840, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8309), "Lorem Ipsum is simply dummy text", "Item 840", 74.060000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8311) },
                    { 841, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8313), "Lorem Ipsum is simply dummy text", "Item 841", 302.83999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8314) },
                    { 842, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8317), "Lorem Ipsum is simply dummy text", "Item 842", 204.87, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8318) },
                    { 829, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8271), "Lorem Ipsum is simply dummy text", "Item 829", 763.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(8272) },
                    { 501, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6808), "Lorem Ipsum is simply dummy text", "Item 501", 111.55, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6809) },
                    { 500, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6804), "Lorem Ipsum is simply dummy text", "Item 500", 889.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6806) },
                    { 499, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6801), "Lorem Ipsum is simply dummy text", "Item 499", 659.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6802) },
                    { 158, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5291), "Lorem Ipsum is simply dummy text", "Item 158", 252.71000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5292) },
                    { 159, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5294), "Lorem Ipsum is simply dummy text", "Item 159", 976.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5295) },
                    { 160, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5298), "Lorem Ipsum is simply dummy text", "Item 160", 426.64999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5299) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 161, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5301), "Lorem Ipsum is simply dummy text", "Item 161", 927.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5302) },
                    { 162, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5305), "Lorem Ipsum is simply dummy text", "Item 162", 957.29999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5306) },
                    { 163, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5309), "Lorem Ipsum is simply dummy text", "Item 163", 325.45999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5310) },
                    { 164, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5312), "Lorem Ipsum is simply dummy text", "Item 164", 486.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5313) },
                    { 165, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5315), "Lorem Ipsum is simply dummy text", "Item 165", 886.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5317) },
                    { 166, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5319), "Lorem Ipsum is simply dummy text", "Item 166", 484.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5320) },
                    { 167, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5323), "Lorem Ipsum is simply dummy text", "Item 167", 538.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5324) },
                    { 168, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5326), "Lorem Ipsum is simply dummy text", "Item 168", 271.29000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5327) },
                    { 169, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5330), "Lorem Ipsum is simply dummy text", "Item 169", 164.31, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5331) },
                    { 170, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5334), "Lorem Ipsum is simply dummy text", "Item 170", 473.44, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5335) },
                    { 171, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5337), "Lorem Ipsum is simply dummy text", "Item 171", 658.29999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5338) },
                    { 172, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5341), "Lorem Ipsum is simply dummy text", "Item 172", 630.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5342) },
                    { 173, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5344), "Lorem Ipsum is simply dummy text", "Item 173", 902.32000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5346) },
                    { 174, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5349), "Lorem Ipsum is simply dummy text", "Item 174", 503.92000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5350) },
                    { 175, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5352), "Lorem Ipsum is simply dummy text", "Item 175", 876.14999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5354) },
                    { 176, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5356), "Lorem Ipsum is simply dummy text", "Item 176", 496.80000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5357) },
                    { 177, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5359), "Lorem Ipsum is simply dummy text", "Item 177", 614.58000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5361) },
                    { 178, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5363), "Lorem Ipsum is simply dummy text", "Item 178", 313.95999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5364) },
                    { 179, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5366), "Lorem Ipsum is simply dummy text", "Item 179", 483.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5367) },
                    { 180, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5369), "Lorem Ipsum is simply dummy text", "Item 180", 316.95999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5370) },
                    { 181, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5373), "Lorem Ipsum is simply dummy text", "Item 181", 290.91000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5374) },
                    { 182, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5376), "Lorem Ipsum is simply dummy text", "Item 182", 21.489999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5377) },
                    { 183, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5380), "Lorem Ipsum is simply dummy text", "Item 183", 285.81, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5381) },
                    { 184, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5383), "Lorem Ipsum is simply dummy text", "Item 184", 410.06999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5384) },
                    { 157, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5287), "Lorem Ipsum is simply dummy text", "Item 157", 352.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5288) },
                    { 185, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5387), "Lorem Ipsum is simply dummy text", "Item 185", 594.39999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5388) },
                    { 156, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5284), "Lorem Ipsum is simply dummy text", "Item 156", 943.95000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5285) },
                    { 154, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5277), "Lorem Ipsum is simply dummy text", "Item 154", 193.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5278) },
                    { 127, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5144), "Lorem Ipsum is simply dummy text", "Item 127", 778.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5145) },
                    { 128, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5148), "Lorem Ipsum is simply dummy text", "Item 128", 881.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5149) },
                    { 129, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5151), "Lorem Ipsum is simply dummy text", "Item 129", 760.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5152) },
                    { 130, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5158), "Lorem Ipsum is simply dummy text", "Item 130", 924.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5160) },
                    { 131, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5162), "Lorem Ipsum is simply dummy text", "Item 131", 163.41, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5163) },
                    { 132, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5166), "Lorem Ipsum is simply dummy text", "Item 132", 185.72999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5167) },
                    { 133, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5170), "Lorem Ipsum is simply dummy text", "Item 133", 760.24000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5171) },
                    { 134, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5173), "Lorem Ipsum is simply dummy text", "Item 134", 527.46000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5174) },
                    { 135, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5177), "Lorem Ipsum is simply dummy text", "Item 135", 347.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5178) },
                    { 136, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5180), "Lorem Ipsum is simply dummy text", "Item 136", 706.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5182) },
                    { 137, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5184), "Lorem Ipsum is simply dummy text", "Item 137", 912.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5185) },
                    { 138, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5187), "Lorem Ipsum is simply dummy text", "Item 138", 909.41999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5189) },
                    { 139, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5190), "Lorem Ipsum is simply dummy text", "Item 139", 969.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5191) },
                    { 140, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5193), "Lorem Ipsum is simply dummy text", "Item 140", 348.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5195) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 141, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5197), "Lorem Ipsum is simply dummy text", "Item 141", 606.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5198) },
                    { 142, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5200), "Lorem Ipsum is simply dummy text", "Item 142", 274.19999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5201) },
                    { 143, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5204), "Lorem Ipsum is simply dummy text", "Item 143", 107.45, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5205) },
                    { 144, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5207), "Lorem Ipsum is simply dummy text", "Item 144", 983.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5208) },
                    { 145, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5211), "Lorem Ipsum is simply dummy text", "Item 145", 205.22999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5212) },
                    { 146, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5214), "Lorem Ipsum is simply dummy text", "Item 146", 930.96000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5215) },
                    { 147, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5218), "Lorem Ipsum is simply dummy text", "Item 147", 584.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5219) },
                    { 148, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5221), "Lorem Ipsum is simply dummy text", "Item 148", 757.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5222) },
                    { 149, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5259), "Lorem Ipsum is simply dummy text", "Item 149", 595.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5261) },
                    { 150, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5264), "Lorem Ipsum is simply dummy text", "Item 150", 350.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5265) },
                    { 151, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5267), "Lorem Ipsum is simply dummy text", "Item 151", 330.54000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5268) },
                    { 152, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5270), "Lorem Ipsum is simply dummy text", "Item 152", 935.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5271) },
                    { 153, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5273), "Lorem Ipsum is simply dummy text", "Item 153", 272.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5274) },
                    { 155, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5280), "Lorem Ipsum is simply dummy text", "Item 155", 43.649999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5282) },
                    { 186, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5390), "Lorem Ipsum is simply dummy text", "Item 186", 228.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5391) },
                    { 187, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5393), "Lorem Ipsum is simply dummy text", "Item 187", 912.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5395) },
                    { 188, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5397), "Lorem Ipsum is simply dummy text", "Item 188", 566.29999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5398) },
                    { 221, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5549), "Lorem Ipsum is simply dummy text", "Item 221", 571.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5550) },
                    { 222, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5553), "Lorem Ipsum is simply dummy text", "Item 222", 971.71000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5554) },
                    { 223, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5556), "Lorem Ipsum is simply dummy text", "Item 223", 787.48000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5558) },
                    { 224, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5560), "Lorem Ipsum is simply dummy text", "Item 224", 760.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5561) },
                    { 225, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5564), "Lorem Ipsum is simply dummy text", "Item 225", 119.81, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5565) },
                    { 226, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5567), "Lorem Ipsum is simply dummy text", "Item 226", 998.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5568) },
                    { 227, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5571), "Lorem Ipsum is simply dummy text", "Item 227", 697.45000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5572) },
                    { 228, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5574), "Lorem Ipsum is simply dummy text", "Item 228", 359.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5576) },
                    { 229, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5578), "Lorem Ipsum is simply dummy text", "Item 229", 82.689999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5579) },
                    { 230, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5581), "Lorem Ipsum is simply dummy text", "Item 230", 227.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5582) },
                    { 231, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5584), "Lorem Ipsum is simply dummy text", "Item 231", 548.07000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5585) },
                    { 232, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5587), "Lorem Ipsum is simply dummy text", "Item 232", 993.48000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5588) },
                    { 233, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5591), "Lorem Ipsum is simply dummy text", "Item 233", 217.69, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5592) },
                    { 234, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5594), "Lorem Ipsum is simply dummy text", "Item 234", 762.50999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5595) },
                    { 235, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5598), "Lorem Ipsum is simply dummy text", "Item 235", 924.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5599) },
                    { 236, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5601), "Lorem Ipsum is simply dummy text", "Item 236", 977.45000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5603) },
                    { 237, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5605), "Lorem Ipsum is simply dummy text", "Item 237", 428.66000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5606) },
                    { 238, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5609), "Lorem Ipsum is simply dummy text", "Item 238", 163.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5610) },
                    { 239, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5612), "Lorem Ipsum is simply dummy text", "Item 239", 717.58000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5614) },
                    { 240, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5616), "Lorem Ipsum is simply dummy text", "Item 240", 894.59000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5617) },
                    { 241, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5619), "Lorem Ipsum is simply dummy text", "Item 241", 195.41, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5620) },
                    { 242, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5622), "Lorem Ipsum is simply dummy text", "Item 242", 143.91, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5623) },
                    { 243, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5626), "Lorem Ipsum is simply dummy text", "Item 243", 248.52000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5627) },
                    { 244, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5629), "Lorem Ipsum is simply dummy text", "Item 244", 936.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5630) },
                    { 245, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5633), "Lorem Ipsum is simply dummy text", "Item 245", 74.159999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5634) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 246, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5674), "Lorem Ipsum is simply dummy text", "Item 246", 314.94999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5676) },
                    { 247, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5679), "Lorem Ipsum is simply dummy text", "Item 247", 890.42999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5681) },
                    { 220, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5545), "Lorem Ipsum is simply dummy text", "Item 220", 658.48000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5547) },
                    { 219, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5542), "Lorem Ipsum is simply dummy text", "Item 219", 891.95000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5543) },
                    { 218, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5538), "Lorem Ipsum is simply dummy text", "Item 218", 915.39999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5540) },
                    { 217, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5535), "Lorem Ipsum is simply dummy text", "Item 217", 671.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5536) },
                    { 189, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5400), "Lorem Ipsum is simply dummy text", "Item 189", 483.81, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5402) },
                    { 190, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5404), "Lorem Ipsum is simply dummy text", "Item 190", 403.54000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5405) },
                    { 191, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5407), "Lorem Ipsum is simply dummy text", "Item 191", 353.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5409) },
                    { 192, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5411), "Lorem Ipsum is simply dummy text", "Item 192", 660.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5412) },
                    { 193, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5414), "Lorem Ipsum is simply dummy text", "Item 193", 933.27999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5416) },
                    { 194, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5418), "Lorem Ipsum is simply dummy text", "Item 194", 542.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5419) },
                    { 195, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5421), "Lorem Ipsum is simply dummy text", "Item 195", 421.22000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5422) },
                    { 196, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5425), "Lorem Ipsum is simply dummy text", "Item 196", 648.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5427) },
                    { 197, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5430), "Lorem Ipsum is simply dummy text", "Item 197", 948.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5431) },
                    { 198, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5467), "Lorem Ipsum is simply dummy text", "Item 198", 621.10000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5469) },
                    { 199, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5471), "Lorem Ipsum is simply dummy text", "Item 199", 96.280000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5473) },
                    { 200, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5475), "Lorem Ipsum is simply dummy text", "Item 200", 720.48000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5476) },
                    { 201, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5478), "Lorem Ipsum is simply dummy text", "Item 201", 392.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5480) },
                    { 126, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5141), "Lorem Ipsum is simply dummy text", "Item 126", 875.65999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5142) },
                    { 202, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5482), "Lorem Ipsum is simply dummy text", "Item 202", 313.45999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5483) },
                    { 204, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5489), "Lorem Ipsum is simply dummy text", "Item 204", 122.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5490) },
                    { 205, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5493), "Lorem Ipsum is simply dummy text", "Item 205", 692.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5494) },
                    { 206, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5496), "Lorem Ipsum is simply dummy text", "Item 206", 699.80999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5497) },
                    { 207, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5500), "Lorem Ipsum is simply dummy text", "Item 207", 32.840000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5501) },
                    { 208, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5504), "Lorem Ipsum is simply dummy text", "Item 208", 768.95000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5505) },
                    { 209, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5508), "Lorem Ipsum is simply dummy text", "Item 209", 317.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5509) },
                    { 210, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5511), "Lorem Ipsum is simply dummy text", "Item 210", 546.84000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5512) },
                    { 211, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5515), "Lorem Ipsum is simply dummy text", "Item 211", 329.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5516) },
                    { 212, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5518), "Lorem Ipsum is simply dummy text", "Item 212", 38.670000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5520) },
                    { 213, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5522), "Lorem Ipsum is simply dummy text", "Item 213", 769.71000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5523) },
                    { 214, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5525), "Lorem Ipsum is simply dummy text", "Item 214", 659.17999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5526) },
                    { 215, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5528), "Lorem Ipsum is simply dummy text", "Item 215", 135.74000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5529) },
                    { 216, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5532), "Lorem Ipsum is simply dummy text", "Item 216", 906.27999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5533) },
                    { 203, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5486), "Lorem Ipsum is simply dummy text", "Item 203", 592.83000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5487) },
                    { 248, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5683), "Lorem Ipsum is simply dummy text", "Item 248", 274.08999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5684) },
                    { 125, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5137), "Lorem Ipsum is simply dummy text", "Item 125", 247.91999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5138) },
                    { 123, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5130), "Lorem Ipsum is simply dummy text", "Item 123", 296.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5131) },
                    { 33, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4640), "Lorem Ipsum is simply dummy text", "Item 33", 725.64999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4641) },
                    { 34, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4648), "Lorem Ipsum is simply dummy text", "Item 34", 53.200000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4649) },
                    { 35, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4652), "Lorem Ipsum is simply dummy text", "Item 35", 857.67999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4653) },
                    { 36, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4655), "Lorem Ipsum is simply dummy text", "Item 36", 963.92999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4657) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 37, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4659), "Lorem Ipsum is simply dummy text", "Item 37", 524.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4660) },
                    { 38, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4662), "Lorem Ipsum is simply dummy text", "Item 38", 794.19000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4663) },
                    { 39, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4666), "Lorem Ipsum is simply dummy text", "Item 39", 311.18000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4667) },
                    { 40, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4669), "Lorem Ipsum is simply dummy text", "Item 40", 346.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4670) },
                    { 41, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4673), "Lorem Ipsum is simply dummy text", "Item 41", 544.32000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4674) },
                    { 42, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4676), "Lorem Ipsum is simply dummy text", "Item 42", 949.21000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4677) },
                    { 43, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4680), "Lorem Ipsum is simply dummy text", "Item 43", 34.07, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4681) },
                    { 44, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4683), "Lorem Ipsum is simply dummy text", "Item 44", 603.70000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4685) },
                    { 45, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4687), "Lorem Ipsum is simply dummy text", "Item 45", 946.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4688) },
                    { 46, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4691), "Lorem Ipsum is simply dummy text", "Item 46", 906.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4692) },
                    { 47, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4694), "Lorem Ipsum is simply dummy text", "Item 47", 979.70000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4695) },
                    { 48, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4697), "Lorem Ipsum is simply dummy text", "Item 48", 504.87, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4698) },
                    { 49, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4701), "Lorem Ipsum is simply dummy text", "Item 49", 701.20000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4702) },
                    { 50, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4704), "Lorem Ipsum is simply dummy text", "Item 50", 561.48000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4706) },
                    { 51, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4708), "Lorem Ipsum is simply dummy text", "Item 51", 753.95000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4709) },
                    { 52, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4711), "Lorem Ipsum is simply dummy text", "Item 52", 496.42000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4712) },
                    { 53, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4714), "Lorem Ipsum is simply dummy text", "Item 53", 769.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4715) },
                    { 54, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4717), "Lorem Ipsum is simply dummy text", "Item 54", 206.91, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4719) },
                    { 55, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4721), "Lorem Ipsum is simply dummy text", "Item 55", 20.059999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4722) },
                    { 56, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4725), "Lorem Ipsum is simply dummy text", "Item 56", 981.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4726) },
                    { 57, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4728), "Lorem Ipsum is simply dummy text", "Item 57", 734.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4729) },
                    { 58, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4732), "Lorem Ipsum is simply dummy text", "Item 58", 140.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4733) },
                    { 59, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4735), "Lorem Ipsum is simply dummy text", "Item 59", 525.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4736) },
                    { 32, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4636), "Lorem Ipsum is simply dummy text", "Item 32", 129.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4637) },
                    { 60, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4739), "Lorem Ipsum is simply dummy text", "Item 60", 535.54999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4740) },
                    { 31, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4633), "Lorem Ipsum is simply dummy text", "Item 31", 941.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4634) },
                    { 29, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4626), "Lorem Ipsum is simply dummy text", "Item 29", 832.82000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4628) },
                    { 2, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4407), "Lorem Ipsum is simply dummy text", "Item 2", 774.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4423) },
                    { 3, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4463), "Lorem Ipsum is simply dummy text", "Item 3", 429.13, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4464) },
                    { 4, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4472), "Lorem Ipsum is simply dummy text", "Item 4", 445.44999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4473) },
                    { 5, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4476), "Lorem Ipsum is simply dummy text", "Item 5", 871.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4477) },
                    { 6, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4487), "Lorem Ipsum is simply dummy text", "Item 6", 783.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4488) },
                    { 7, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4491), "Lorem Ipsum is simply dummy text", "Item 7", 508.31, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4492) },
                    { 8, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4495), "Lorem Ipsum is simply dummy text", "Item 8", 975.50999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4496) },
                    { 9, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4498), "Lorem Ipsum is simply dummy text", "Item 9", 717.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4499) },
                    { 10, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4503), "Lorem Ipsum is simply dummy text", "Item 10", 869.08000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4504) },
                    { 11, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4507), "Lorem Ipsum is simply dummy text", "Item 11", 261.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4508) },
                    { 12, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4511), "Lorem Ipsum is simply dummy text", "Item 12", 966.40999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4512) },
                    { 13, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4514), "Lorem Ipsum is simply dummy text", "Item 13", 383.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4515) },
                    { 14, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4518), "Lorem Ipsum is simply dummy text", "Item 14", 421.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4519) },
                    { 15, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4521), "Lorem Ipsum is simply dummy text", "Item 15", 441.06999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4522) },
                    { 16, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4525), "Lorem Ipsum is simply dummy text", "Item 16", 783.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4526) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 17, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4529), "Lorem Ipsum is simply dummy text", "Item 17", 841.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4530) },
                    { 18, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4534), "Lorem Ipsum is simply dummy text", "Item 18", 968.55999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4535) },
                    { 19, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4537), "Lorem Ipsum is simply dummy text", "Item 19", 29.68, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4538) },
                    { 20, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4541), "Lorem Ipsum is simply dummy text", "Item 20", 339.94999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4542) },
                    { 21, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4544), "Lorem Ipsum is simply dummy text", "Item 21", 919.13, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4545) },
                    { 22, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4548), "Lorem Ipsum is simply dummy text", "Item 22", 345.56999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4549) },
                    { 23, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4551), "Lorem Ipsum is simply dummy text", "Item 23", 40.170000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4552) },
                    { 24, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4555), "Lorem Ipsum is simply dummy text", "Item 24", 288.26999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4556) },
                    { 25, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4611), "Lorem Ipsum is simply dummy text", "Item 25", 920.19000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4613) },
                    { 26, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4616), "Lorem Ipsum is simply dummy text", "Item 26", 335.56, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4617) },
                    { 27, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4619), "Lorem Ipsum is simply dummy text", "Item 27", 358.66000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4621) },
                    { 28, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4623), "Lorem Ipsum is simply dummy text", "Item 28", 834.67999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4624) },
                    { 30, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4630), "Lorem Ipsum is simply dummy text", "Item 30", 809.34000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4631) },
                    { 61, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4742), "Lorem Ipsum is simply dummy text", "Item 61", 424.94999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4744) },
                    { 62, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4746), "Lorem Ipsum is simply dummy text", "Item 62", 673.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4747) },
                    { 63, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4749), "Lorem Ipsum is simply dummy text", "Item 63", 142.69999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4750) },
                    { 96, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4929), "Lorem Ipsum is simply dummy text", "Item 96", 870.69000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4930) },
                    { 97, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4932), "Lorem Ipsum is simply dummy text", "Item 97", 806.50999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4934) },
                    { 98, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4936), "Lorem Ipsum is simply dummy text", "Item 98", 125.77, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4937) },
                    { 99, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4939), "Lorem Ipsum is simply dummy text", "Item 99", 676.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4941) },
                    { 100, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4943), "Lorem Ipsum is simply dummy text", "Item 100", 814.64999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4945) },
                    { 101, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4947), "Lorem Ipsum is simply dummy text", "Item 101", 665.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4949) },
                    { 102, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4952), "Lorem Ipsum is simply dummy text", "Item 102", 649.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4953) },
                    { 103, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4955), "Lorem Ipsum is simply dummy text", "Item 103", 940.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4957) },
                    { 104, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4959), "Lorem Ipsum is simply dummy text", "Item 104", 224.06, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4961) },
                    { 105, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4963), "Lorem Ipsum is simply dummy text", "Item 105", 302.31, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4964) },
                    { 106, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4966), "Lorem Ipsum is simply dummy text", "Item 106", 706.38999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4967) },
                    { 107, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4969), "Lorem Ipsum is simply dummy text", "Item 107", 839.03999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4971) },
                    { 108, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4973), "Lorem Ipsum is simply dummy text", "Item 108", 86.310000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4974) },
                    { 109, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4977), "Lorem Ipsum is simply dummy text", "Item 109", 411.29000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4978) },
                    { 110, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4980), "Lorem Ipsum is simply dummy text", "Item 110", 50.140000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4981) },
                    { 111, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4984), "Lorem Ipsum is simply dummy text", "Item 111", 670.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4985) },
                    { 112, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4987), "Lorem Ipsum is simply dummy text", "Item 112", 298.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4988) },
                    { 113, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5092), "Lorem Ipsum is simply dummy text", "Item 113", 798.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5094) },
                    { 114, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5097), "Lorem Ipsum is simply dummy text", "Item 114", 511.80000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5098) },
                    { 115, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5101), "Lorem Ipsum is simply dummy text", "Item 115", 179.69, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5102) },
                    { 116, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5104), "Lorem Ipsum is simply dummy text", "Item 116", 571.14999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5105) },
                    { 117, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5107), "Lorem Ipsum is simply dummy text", "Item 117", 540.14999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5109) },
                    { 118, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5111), "Lorem Ipsum is simply dummy text", "Item 118", 871.35000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5113) },
                    { 119, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5115), "Lorem Ipsum is simply dummy text", "Item 119", 852.90999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5117) },
                    { 120, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5119), "Lorem Ipsum is simply dummy text", "Item 120", 482.29000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5120) },
                    { 121, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5123), "Lorem Ipsum is simply dummy text", "Item 121", 771.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5124) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 122, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5126), "Lorem Ipsum is simply dummy text", "Item 122", 722.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5127) },
                    { 95, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4925), "Lorem Ipsum is simply dummy text", "Item 95", 921.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4926) },
                    { 94, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4921), "Lorem Ipsum is simply dummy text", "Item 94", 775.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4922) },
                    { 93, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4918), "Lorem Ipsum is simply dummy text", "Item 93", 268.93000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4919) },
                    { 92, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4915), "Lorem Ipsum is simply dummy text", "Item 92", 383.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4916) },
                    { 64, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4753), "Lorem Ipsum is simply dummy text", "Item 64", 908.29999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4754) },
                    { 65, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4756), "Lorem Ipsum is simply dummy text", "Item 65", 927.48000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4758) },
                    { 66, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4822), "Lorem Ipsum is simply dummy text", "Item 66", 131.50999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4824) },
                    { 67, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4828), "Lorem Ipsum is simply dummy text", "Item 67", 240.75999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4829) },
                    { 68, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4831), "Lorem Ipsum is simply dummy text", "Item 68", 330.10000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4833) },
                    { 69, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4835), "Lorem Ipsum is simply dummy text", "Item 69", 563.92999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4836) },
                    { 70, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4838), "Lorem Ipsum is simply dummy text", "Item 70", 477.13, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4839) },
                    { 71, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4842), "Lorem Ipsum is simply dummy text", "Item 71", 259.17000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4843) },
                    { 72, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4845), "Lorem Ipsum is simply dummy text", "Item 72", 47.560000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4847) },
                    { 73, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4849), "Lorem Ipsum is simply dummy text", "Item 73", 657.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4850) },
                    { 74, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4852), "Lorem Ipsum is simply dummy text", "Item 74", 682.79999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4853) },
                    { 75, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4855), "Lorem Ipsum is simply dummy text", "Item 75", 795.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4856) },
                    { 76, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4859), "Lorem Ipsum is simply dummy text", "Item 76", 969.91999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4860) },
                    { 124, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5133), "Lorem Ipsum is simply dummy text", "Item 124", 688.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5134) },
                    { 77, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4862), "Lorem Ipsum is simply dummy text", "Item 77", 311.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4864) },
                    { 79, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4870), "Lorem Ipsum is simply dummy text", "Item 79", 342.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4871) },
                    { 80, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4873), "Lorem Ipsum is simply dummy text", "Item 80", 13.460000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4875) },
                    { 81, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4877), "Lorem Ipsum is simply dummy text", "Item 81", 355.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4878) },
                    { 82, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4880), "Lorem Ipsum is simply dummy text", "Item 82", 853.78999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4882) },
                    { 83, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4884), "Lorem Ipsum is simply dummy text", "Item 83", 133.47999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4885) },
                    { 84, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4887), "Lorem Ipsum is simply dummy text", "Item 84", 271.33999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4888) },
                    { 85, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4891), "Lorem Ipsum is simply dummy text", "Item 85", 55.390000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4892) },
                    { 86, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4894), "Lorem Ipsum is simply dummy text", "Item 86", 445.18000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4895) },
                    { 87, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4897), "Lorem Ipsum is simply dummy text", "Item 87", 360.50999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4898) },
                    { 88, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4900), "Lorem Ipsum is simply dummy text", "Item 88", 518.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4902) },
                    { 89, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4904), "Lorem Ipsum is simply dummy text", "Item 89", 33.140000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4905) },
                    { 90, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4907), "Lorem Ipsum is simply dummy text", "Item 90", 875.71000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4908) },
                    { 91, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4911), "Lorem Ipsum is simply dummy text", "Item 91", 229.21000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4912) },
                    { 78, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4866), "Lorem Ipsum is simply dummy text", "Item 78", 436.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(4867) },
                    { 249, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5686), "Lorem Ipsum is simply dummy text", "Item 249", 406.63999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5688) },
                    { 250, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5690), "Lorem Ipsum is simply dummy text", "Item 250", 514.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5692) },
                    { 251, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5694), "Lorem Ipsum is simply dummy text", "Item 251", 977.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5696) },
                    { 409, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6387), "Lorem Ipsum is simply dummy text", "Item 409", 649.28999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6388) },
                    { 410, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6390), "Lorem Ipsum is simply dummy text", "Item 410", 127.73, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6392) },
                    { 411, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6394), "Lorem Ipsum is simply dummy text", "Item 411", 216.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6395) },
                    { 412, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6398), "Lorem Ipsum is simply dummy text", "Item 412", 989.98000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6399) },
                    { 413, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6401), "Lorem Ipsum is simply dummy text", "Item 413", 878.92999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6403) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 414, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6405), "Lorem Ipsum is simply dummy text", "Item 414", 610.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6406) },
                    { 415, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6408), "Lorem Ipsum is simply dummy text", "Item 415", 726.39999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6410) },
                    { 416, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6469), "Lorem Ipsum is simply dummy text", "Item 416", 736.80999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6471) },
                    { 417, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6474), "Lorem Ipsum is simply dummy text", "Item 417", 923.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6475) },
                    { 418, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6478), "Lorem Ipsum is simply dummy text", "Item 418", 834.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6479) },
                    { 419, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6481), "Lorem Ipsum is simply dummy text", "Item 419", 896.59000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6483) },
                    { 420, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6485), "Lorem Ipsum is simply dummy text", "Item 420", 119.13, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6486) },
                    { 421, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6489), "Lorem Ipsum is simply dummy text", "Item 421", 885.19000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6490) },
                    { 422, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6492), "Lorem Ipsum is simply dummy text", "Item 422", 304.94999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6494) },
                    { 423, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6496), "Lorem Ipsum is simply dummy text", "Item 423", 915.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6497) },
                    { 424, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6499), "Lorem Ipsum is simply dummy text", "Item 424", 28.93, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6500) },
                    { 425, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6503), "Lorem Ipsum is simply dummy text", "Item 425", 627.55999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6504) },
                    { 426, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6506), "Lorem Ipsum is simply dummy text", "Item 426", 116.68000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6507) },
                    { 427, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6510), "Lorem Ipsum is simply dummy text", "Item 427", 851.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6511) },
                    { 428, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6513), "Lorem Ipsum is simply dummy text", "Item 428", 213.91, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6515) },
                    { 429, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6517), "Lorem Ipsum is simply dummy text", "Item 429", 400.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6519) },
                    { 430, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6521), "Lorem Ipsum is simply dummy text", "Item 430", 786.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6522) },
                    { 431, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6524), "Lorem Ipsum is simply dummy text", "Item 431", 633.07000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6525) },
                    { 432, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6527), "Lorem Ipsum is simply dummy text", "Item 432", 464.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6529) },
                    { 433, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6531), "Lorem Ipsum is simply dummy text", "Item 433", 356.95999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6532) },
                    { 434, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6534), "Lorem Ipsum is simply dummy text", "Item 434", 755.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6535) },
                    { 435, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6538), "Lorem Ipsum is simply dummy text", "Item 435", 917.91999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6539) },
                    { 408, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6384), "Lorem Ipsum is simply dummy text", "Item 408", 257.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6385) },
                    { 436, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6541), "Lorem Ipsum is simply dummy text", "Item 436", 175.84999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6542) },
                    { 407, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6380), "Lorem Ipsum is simply dummy text", "Item 407", 751.09000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6381) },
                    { 405, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6373), "Lorem Ipsum is simply dummy text", "Item 405", 618.67999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6374) },
                    { 378, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6278), "Lorem Ipsum is simply dummy text", "Item 378", 499.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6279) },
                    { 379, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6282), "Lorem Ipsum is simply dummy text", "Item 379", 427.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6283) },
                    { 380, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6285), "Lorem Ipsum is simply dummy text", "Item 380", 930.79999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6286) },
                    { 381, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6289), "Lorem Ipsum is simply dummy text", "Item 381", 429.88, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6290) },
                    { 382, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6292), "Lorem Ipsum is simply dummy text", "Item 382", 384.80000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6293) },
                    { 383, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6296), "Lorem Ipsum is simply dummy text", "Item 383", 737.91999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6297) },
                    { 384, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6299), "Lorem Ipsum is simply dummy text", "Item 384", 791.89999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6300) },
                    { 385, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6303), "Lorem Ipsum is simply dummy text", "Item 385", 137.59999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6304) },
                    { 386, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6306), "Lorem Ipsum is simply dummy text", "Item 386", 631.16999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6307) },
                    { 387, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6309), "Lorem Ipsum is simply dummy text", "Item 387", 247.66999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6311) },
                    { 388, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6313), "Lorem Ipsum is simply dummy text", "Item 388", 458.18000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6314) },
                    { 389, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6316), "Lorem Ipsum is simply dummy text", "Item 389", 281.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6317) },
                    { 390, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6320), "Lorem Ipsum is simply dummy text", "Item 390", 858.00999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6321) },
                    { 391, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6323), "Lorem Ipsum is simply dummy text", "Item 391", 734.54999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6324) },
                    { 392, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6327), "Lorem Ipsum is simply dummy text", "Item 392", 577.88, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6328) },
                    { 393, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6330), "Lorem Ipsum is simply dummy text", "Item 393", 163.44999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6332) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 394, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6334), "Lorem Ipsum is simply dummy text", "Item 394", 374.16000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6335) },
                    { 395, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6337), "Lorem Ipsum is simply dummy text", "Item 395", 659.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6338) },
                    { 396, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6341), "Lorem Ipsum is simply dummy text", "Item 396", 18.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6342) },
                    { 397, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6344), "Lorem Ipsum is simply dummy text", "Item 397", 905.91999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6345) },
                    { 398, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6348), "Lorem Ipsum is simply dummy text", "Item 398", 770.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6349) },
                    { 399, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6352), "Lorem Ipsum is simply dummy text", "Item 399", 143.00999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6353) },
                    { 400, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6355), "Lorem Ipsum is simply dummy text", "Item 400", 671.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6357) },
                    { 401, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6359), "Lorem Ipsum is simply dummy text", "Item 401", 12.890000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6360) },
                    { 402, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6363), "Lorem Ipsum is simply dummy text", "Item 402", 254.03, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6364) },
                    { 403, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6366), "Lorem Ipsum is simply dummy text", "Item 403", 75.829999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6367) },
                    { 404, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6369), "Lorem Ipsum is simply dummy text", "Item 404", 74.540000000000006, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6370) },
                    { 406, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6377), "Lorem Ipsum is simply dummy text", "Item 406", 788.33000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6378) },
                    { 437, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6545), "Lorem Ipsum is simply dummy text", "Item 437", 308.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6546) },
                    { 438, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6548), "Lorem Ipsum is simply dummy text", "Item 438", 663.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6549) },
                    { 439, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6552), "Lorem Ipsum is simply dummy text", "Item 439", 173.22, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6553) },
                    { 472, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6706), "Lorem Ipsum is simply dummy text", "Item 472", 259.64999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6707) },
                    { 473, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6709), "Lorem Ipsum is simply dummy text", "Item 473", 661.52999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6711) },
                    { 474, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6713), "Lorem Ipsum is simply dummy text", "Item 474", 547.32000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6714) },
                    { 475, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6716), "Lorem Ipsum is simply dummy text", "Item 475", 239.06, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6717) },
                    { 476, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6719), "Lorem Ipsum is simply dummy text", "Item 476", 895.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6720) },
                    { 477, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6723), "Lorem Ipsum is simply dummy text", "Item 477", 496.05000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6724) },
                    { 478, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6726), "Lorem Ipsum is simply dummy text", "Item 478", 761.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6727) },
                    { 479, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6729), "Lorem Ipsum is simply dummy text", "Item 479", 387.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6731) },
                    { 480, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6733), "Lorem Ipsum is simply dummy text", "Item 480", 882.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6734) },
                    { 481, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6737), "Lorem Ipsum is simply dummy text", "Item 481", 417.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6738) },
                    { 482, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6740), "Lorem Ipsum is simply dummy text", "Item 482", 298.43000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6741) },
                    { 483, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6743), "Lorem Ipsum is simply dummy text", "Item 483", 566.14999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6744) },
                    { 484, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6747), "Lorem Ipsum is simply dummy text", "Item 484", 478.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6748) },
                    { 485, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6751), "Lorem Ipsum is simply dummy text", "Item 485", 691.38999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6752) },
                    { 486, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6756), "Lorem Ipsum is simply dummy text", "Item 486", 561.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6757) },
                    { 487, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6759), "Lorem Ipsum is simply dummy text", "Item 487", 590.59000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6760) },
                    { 488, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6762), "Lorem Ipsum is simply dummy text", "Item 488", 333.07999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6763) },
                    { 489, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6765), "Lorem Ipsum is simply dummy text", "Item 489", 969.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6766) },
                    { 490, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6769), "Lorem Ipsum is simply dummy text", "Item 490", 209.97, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6770) },
                    { 491, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6772), "Lorem Ipsum is simply dummy text", "Item 491", 837.30999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6774) },
                    { 492, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6776), "Lorem Ipsum is simply dummy text", "Item 492", 262.06999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6777) },
                    { 493, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6779), "Lorem Ipsum is simply dummy text", "Item 493", 216.38999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6781) },
                    { 494, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6783), "Lorem Ipsum is simply dummy text", "Item 494", 671.22000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6784) },
                    { 495, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6787), "Lorem Ipsum is simply dummy text", "Item 495", 412.10000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6788) },
                    { 496, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6790), "Lorem Ipsum is simply dummy text", "Item 496", 342.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6792) },
                    { 497, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6795), "Lorem Ipsum is simply dummy text", "Item 497", 132.84999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6796) },
                    { 498, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6798), "Lorem Ipsum is simply dummy text", "Item 498", 946.20000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6799) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 471, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6702), "Lorem Ipsum is simply dummy text", "Item 471", 427.83999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6703) },
                    { 470, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6699), "Lorem Ipsum is simply dummy text", "Item 470", 550.54999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6700) },
                    { 469, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6696), "Lorem Ipsum is simply dummy text", "Item 469", 692.79999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6697) },
                    { 468, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6692), "Lorem Ipsum is simply dummy text", "Item 468", 123.2, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6693) },
                    { 440, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6555), "Lorem Ipsum is simply dummy text", "Item 440", 349.26999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6557) },
                    { 441, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6559), "Lorem Ipsum is simply dummy text", "Item 441", 880.07000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6560) },
                    { 442, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6562), "Lorem Ipsum is simply dummy text", "Item 442", 989.96000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6564) },
                    { 443, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6566), "Lorem Ipsum is simply dummy text", "Item 443", 808.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6567) },
                    { 444, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6569), "Lorem Ipsum is simply dummy text", "Item 444", 153.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6570) },
                    { 445, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6573), "Lorem Ipsum is simply dummy text", "Item 445", 641.08000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6574) },
                    { 446, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6576), "Lorem Ipsum is simply dummy text", "Item 446", 744.57000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6577) },
                    { 447, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6579), "Lorem Ipsum is simply dummy text", "Item 447", 698.95000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6580) },
                    { 448, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6583), "Lorem Ipsum is simply dummy text", "Item 448", 552.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6584) },
                    { 449, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6586), "Lorem Ipsum is simply dummy text", "Item 449", 647.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6587) },
                    { 450, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6589), "Lorem Ipsum is simply dummy text", "Item 450", 922.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6590) },
                    { 451, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6593), "Lorem Ipsum is simply dummy text", "Item 451", 95.209999999999994, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6594) },
                    { 452, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6597), "Lorem Ipsum is simply dummy text", "Item 452", 71.180000000000007, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6598) },
                    { 377, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6275), "Lorem Ipsum is simply dummy text", "Item 377", 235.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6276) },
                    { 453, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6601), "Lorem Ipsum is simply dummy text", "Item 453", 874.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6602) },
                    { 455, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6608), "Lorem Ipsum is simply dummy text", "Item 455", 786.70000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6609) },
                    { 456, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6611), "Lorem Ipsum is simply dummy text", "Item 456", 707.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6612) },
                    { 457, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6614), "Lorem Ipsum is simply dummy text", "Item 457", 338.54000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6616) },
                    { 458, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6618), "Lorem Ipsum is simply dummy text", "Item 458", 46.899999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6619) },
                    { 459, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6621), "Lorem Ipsum is simply dummy text", "Item 459", 446.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6622) },
                    { 460, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6624), "Lorem Ipsum is simply dummy text", "Item 460", 502.0, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6626) },
                    { 461, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6628), "Lorem Ipsum is simply dummy text", "Item 461", 937.16999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6629) },
                    { 462, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6631), "Lorem Ipsum is simply dummy text", "Item 462", 537.17999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6632) },
                    { 463, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6635), "Lorem Ipsum is simply dummy text", "Item 463", 857.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6636) },
                    { 464, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6638), "Lorem Ipsum is simply dummy text", "Item 464", 862.69000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6639) },
                    { 465, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6681), "Lorem Ipsum is simply dummy text", "Item 465", 494.66000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6682) },
                    { 466, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6685), "Lorem Ipsum is simply dummy text", "Item 466", 751.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6686) },
                    { 467, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6689), "Lorem Ipsum is simply dummy text", "Item 467", 633.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6690) },
                    { 454, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6604), "Lorem Ipsum is simply dummy text", "Item 454", 23.879999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6605) },
                    { 376, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6271), "Lorem Ipsum is simply dummy text", "Item 376", 538.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6273) },
                    { 375, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6268), "Lorem Ipsum is simply dummy text", "Item 375", 804.85000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6269) },
                    { 374, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6265), "Lorem Ipsum is simply dummy text", "Item 374", 59.770000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6266) },
                    { 284, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5870), "Lorem Ipsum is simply dummy text", "Item 284", 567.75, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5872) },
                    { 285, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5874), "Lorem Ipsum is simply dummy text", "Item 285", 249.94, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5875) },
                    { 286, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5877), "Lorem Ipsum is simply dummy text", "Item 286", 514.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5878) },
                    { 287, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5881), "Lorem Ipsum is simply dummy text", "Item 287", 264.33999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5882) },
                    { 288, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5884), "Lorem Ipsum is simply dummy text", "Item 288", 779.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5885) },
                    { 289, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5887), "Lorem Ipsum is simply dummy text", "Item 289", 613.91999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5888) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 290, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5891), "Lorem Ipsum is simply dummy text", "Item 290", 502.79000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5892) },
                    { 291, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5895), "Lorem Ipsum is simply dummy text", "Item 291", 451.47000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5896) },
                    { 292, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5898), "Lorem Ipsum is simply dummy text", "Item 292", 596.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5899) },
                    { 293, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5902), "Lorem Ipsum is simply dummy text", "Item 293", 160.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5903) },
                    { 294, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5905), "Lorem Ipsum is simply dummy text", "Item 294", 23.25, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5906) },
                    { 295, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5909), "Lorem Ipsum is simply dummy text", "Item 295", 892.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5910) },
                    { 296, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5912), "Lorem Ipsum is simply dummy text", "Item 296", 522.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5913) },
                    { 297, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5916), "Lorem Ipsum is simply dummy text", "Item 297", 457.66000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5917) },
                    { 298, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5919), "Lorem Ipsum is simply dummy text", "Item 298", 158.03, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5920) },
                    { 299, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5922), "Lorem Ipsum is simply dummy text", "Item 299", 938.19000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5924) },
                    { 300, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5926), "Lorem Ipsum is simply dummy text", "Item 300", 738.26999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5927) },
                    { 301, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5930), "Lorem Ipsum is simply dummy text", "Item 301", 493.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5931) },
                    { 302, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5933), "Lorem Ipsum is simply dummy text", "Item 302", 883.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5934) },
                    { 303, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5938), "Lorem Ipsum is simply dummy text", "Item 303", 538.92999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5939) },
                    { 304, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5941), "Lorem Ipsum is simply dummy text", "Item 304", 248.34, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5942) },
                    { 305, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5945), "Lorem Ipsum is simply dummy text", "Item 305", 37.310000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5946) },
                    { 306, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5949), "Lorem Ipsum is simply dummy text", "Item 306", 469.18000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5950) },
                    { 307, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5952), "Lorem Ipsum is simply dummy text", "Item 307", 835.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5954) },
                    { 308, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5956), "Lorem Ipsum is simply dummy text", "Item 308", 731.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5957) },
                    { 309, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5960), "Lorem Ipsum is simply dummy text", "Item 309", 974.73000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5961) },
                    { 310, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5964), "Lorem Ipsum is simply dummy text", "Item 310", 720.62, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5965) },
                    { 283, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5867), "Lorem Ipsum is simply dummy text", "Item 283", 953.30999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5868) },
                    { 282, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5863), "Lorem Ipsum is simply dummy text", "Item 282", 423.36000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5864) },
                    { 281, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5860), "Lorem Ipsum is simply dummy text", "Item 281", 107.73, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5861) },
                    { 280, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5857), "Lorem Ipsum is simply dummy text", "Item 280", 804.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5858) },
                    { 252, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5698), "Lorem Ipsum is simply dummy text", "Item 252", 33.340000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5699) },
                    { 253, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5702), "Lorem Ipsum is simply dummy text", "Item 253", 729.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5703) },
                    { 254, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5705), "Lorem Ipsum is simply dummy text", "Item 254", 437.80000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5707) },
                    { 255, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5709), "Lorem Ipsum is simply dummy text", "Item 255", 148.59, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5710) },
                    { 256, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5713), "Lorem Ipsum is simply dummy text", "Item 256", 421.23000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5714) },
                    { 257, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5716), "Lorem Ipsum is simply dummy text", "Item 257", 525.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5717) },
                    { 258, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5723), "Lorem Ipsum is simply dummy text", "Item 258", 832.05999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5724) },
                    { 259, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5726), "Lorem Ipsum is simply dummy text", "Item 259", 2.6899999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5727) },
                    { 260, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5730), "Lorem Ipsum is simply dummy text", "Item 260", 694.33000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5731) },
                    { 261, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5733), "Lorem Ipsum is simply dummy text", "Item 261", 2.3500000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5734) },
                    { 262, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5737), "Lorem Ipsum is simply dummy text", "Item 262", 672.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5738) },
                    { 263, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5741), "Lorem Ipsum is simply dummy text", "Item 263", 686.25999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5742) },
                    { 264, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5744), "Lorem Ipsum is simply dummy text", "Item 264", 90.480000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5745) },
                    { 311, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5967), "Lorem Ipsum is simply dummy text", "Item 311", 698.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5969) },
                    { 265, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5747), "Lorem Ipsum is simply dummy text", "Item 265", 998.77999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5749) },
                    { 267, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5754), "Lorem Ipsum is simply dummy text", "Item 267", 820.98000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5756) },
                    { 268, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5758), "Lorem Ipsum is simply dummy text", "Item 268", 7.2000000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5759) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 269, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5762), "Lorem Ipsum is simply dummy text", "Item 269", 735.16999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5763) },
                    { 270, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5809), "Lorem Ipsum is simply dummy text", "Item 270", 158.30000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5811) },
                    { 271, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5814), "Lorem Ipsum is simply dummy text", "Item 271", 477.63, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5815) },
                    { 272, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5818), "Lorem Ipsum is simply dummy text", "Item 272", 508.18000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5819) },
                    { 273, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5822), "Lorem Ipsum is simply dummy text", "Item 273", 197.81999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5823) },
                    { 274, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5826), "Lorem Ipsum is simply dummy text", "Item 274", 997.37, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5827) },
                    { 275, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5830), "Lorem Ipsum is simply dummy text", "Item 275", 463.06999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5832) },
                    { 276, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5835), "Lorem Ipsum is simply dummy text", "Item 276", 427.98000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5836) },
                    { 277, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5840), "Lorem Ipsum is simply dummy text", "Item 277", 723.20000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5842) },
                    { 278, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5845), "Lorem Ipsum is simply dummy text", "Item 278", 850.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5849) },
                    { 279, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5853), "Lorem Ipsum is simply dummy text", "Item 279", 686.61000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5854) },
                    { 266, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5751), "Lorem Ipsum is simply dummy text", "Item 266", 335.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5752) },
                    { 999, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(9037), "Lorem Ipsum is simply dummy text", "Item 999", 645.28999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(9039) },
                    { 312, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5971), "Lorem Ipsum is simply dummy text", "Item 312", 675.46000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5972) },
                    { 314, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5978), "Lorem Ipsum is simply dummy text", "Item 314", 197.83000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5979) },
                    { 347, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6135), "Lorem Ipsum is simply dummy text", "Item 347", 451.14999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6136) },
                    { 348, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6138), "Lorem Ipsum is simply dummy text", "Item 348", 962.77999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6139) },
                    { 349, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6141), "Lorem Ipsum is simply dummy text", "Item 349", 436.64999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6142) },
                    { 350, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6145), "Lorem Ipsum is simply dummy text", "Item 350", 313.24000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6146) },
                    { 351, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6148), "Lorem Ipsum is simply dummy text", "Item 351", 802.94000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6149) },
                    { 352, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6152), "Lorem Ipsum is simply dummy text", "Item 352", 339.14999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6153) },
                    { 353, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6155), "Lorem Ipsum is simply dummy text", "Item 353", 317.49000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6156) },
                    { 354, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6159), "Lorem Ipsum is simply dummy text", "Item 354", 454.13999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6160) },
                    { 355, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6162), "Lorem Ipsum is simply dummy text", "Item 355", 666.72000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6163) },
                    { 356, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6166), "Lorem Ipsum is simply dummy text", "Item 356", 452.87, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6167) },
                    { 357, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6169), "Lorem Ipsum is simply dummy text", "Item 357", 489.94999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6170) },
                    { 358, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6172), "Lorem Ipsum is simply dummy text", "Item 358", 306.55000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6173) },
                    { 359, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6176), "Lorem Ipsum is simply dummy text", "Item 359", 541.51999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6177) },
                    { 360, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6179), "Lorem Ipsum is simply dummy text", "Item 360", 156.28, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6180) },
                    { 361, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6183), "Lorem Ipsum is simply dummy text", "Item 361", 121.59999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6184) },
                    { 362, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6186), "Lorem Ipsum is simply dummy text", "Item 362", 660.96000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6188) },
                    { 363, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6190), "Lorem Ipsum is simply dummy text", "Item 363", 626.63999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6191) },
                    { 364, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6193), "Lorem Ipsum is simply dummy text", "Item 364", 34.189999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6194) },
                    { 365, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6197), "Lorem Ipsum is simply dummy text", "Item 365", 750.29999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6198) },
                    { 366, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6200), "Lorem Ipsum is simply dummy text", "Item 366", 132.86000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6201) },
                    { 367, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6238), "Lorem Ipsum is simply dummy text", "Item 367", 763.13, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6239) },
                    { 368, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6244), "Lorem Ipsum is simply dummy text", "Item 368", 197.11000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6245) },
                    { 369, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6247), "Lorem Ipsum is simply dummy text", "Item 369", 886.95000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6248) },
                    { 370, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6251), "Lorem Ipsum is simply dummy text", "Item 370", 362.10000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6252) },
                    { 371, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6254), "Lorem Ipsum is simply dummy text", "Item 371", 694.55999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6255) },
                    { 372, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6258), "Lorem Ipsum is simply dummy text", "Item 372", 14.609999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6259) },
                    { 373, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6261), "Lorem Ipsum is simply dummy text", "Item 373", 588.05999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6262) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 346, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6131), "Lorem Ipsum is simply dummy text", "Item 346", 776.01999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6132) },
                    { 345, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6128), "Lorem Ipsum is simply dummy text", "Item 345", 804.75999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6129) },
                    { 344, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6124), "Lorem Ipsum is simply dummy text", "Item 344", 893.30999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6125) },
                    { 343, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6120), "Lorem Ipsum is simply dummy text", "Item 343", 805.15999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6121) },
                    { 315, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5981), "Lorem Ipsum is simply dummy text", "Item 315", 586.60000000000002, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5982) },
                    { 316, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5985), "Lorem Ipsum is simply dummy text", "Item 316", 578.99000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5986) },
                    { 317, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5988), "Lorem Ipsum is simply dummy text", "Item 317", 719.58000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5990) },
                    { 318, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5992), "Lorem Ipsum is simply dummy text", "Item 318", 118.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5993) },
                    { 319, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6036), "Lorem Ipsum is simply dummy text", "Item 319", 840.53999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6037) },
                    { 320, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6040), "Lorem Ipsum is simply dummy text", "Item 320", 484.05000000000001, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6042) },
                    { 321, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6044), "Lorem Ipsum is simply dummy text", "Item 321", 71.549999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6045) },
                    { 322, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6047), "Lorem Ipsum is simply dummy text", "Item 322", 41.090000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6048) },
                    { 323, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6051), "Lorem Ipsum is simply dummy text", "Item 323", 393.27999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6052) },
                    { 324, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6054), "Lorem Ipsum is simply dummy text", "Item 324", 232.38, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6055) },
                    { 325, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6058), "Lorem Ipsum is simply dummy text", "Item 325", 706.82000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6059) },
                    { 326, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6061), "Lorem Ipsum is simply dummy text", "Item 326", 881.02999999999997, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6062) },
                    { 327, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6064), "Lorem Ipsum is simply dummy text", "Item 327", 347.56999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6066) },
                    { 313, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5973), "Lorem Ipsum is simply dummy text", "Item 313", 145.44999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(5975) },
                    { 328, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6068), "Lorem Ipsum is simply dummy text", "Item 328", 174.56999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6069) },
                    { 330, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6075), "Lorem Ipsum is simply dummy text", "Item 330", 940.53999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6076) },
                    { 331, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6078), "Lorem Ipsum is simply dummy text", "Item 331", 970.32000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6079) },
                    { 332, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6081), "Lorem Ipsum is simply dummy text", "Item 332", 565.16999999999996, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6082) },
                    { 333, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6085), "Lorem Ipsum is simply dummy text", "Item 333", 912.33000000000004, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6086) },
                    { 334, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6088), "Lorem Ipsum is simply dummy text", "Item 334", 948.34000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6089) },
                    { 335, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6092), "Lorem Ipsum is simply dummy text", "Item 335", 310.88999999999999, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6093) },
                    { 336, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6095), "Lorem Ipsum is simply dummy text", "Item 336", 224.5, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6097) },
                    { 337, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6099), "Lorem Ipsum is simply dummy text", "Item 337", 884.42999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6100) },
                    { 338, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6102), "Lorem Ipsum is simply dummy text", "Item 338", 704.97000000000003, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6103) },
                    { 339, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6107), "Lorem Ipsum is simply dummy text", "Item 339", 530.44000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6108) },
                    { 340, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6110), "Lorem Ipsum is simply dummy text", "Item 340", 780.76999999999998, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6112) },
                    { 341, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6114), "Lorem Ipsum is simply dummy text", "Item 341", 679.20000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6115) },
                    { 342, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6117), "Lorem Ipsum is simply dummy text", "Item 342", 532.55999999999995, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6118) },
                    { 329, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6072), "Lorem Ipsum is simply dummy text", "Item 329", 105.13, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(6073) },
                    { 1000, null, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(9042), "Lorem Ipsum is simply dummy text", "Item 1000", 540.20000000000005, new DateTime(2021, 4, 3, 22, 37, 3, 435, DateTimeKind.Local).AddTicks(9043) }
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
        }
    }
}
