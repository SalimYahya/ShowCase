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
                    { 1, null, new DateTime(2021, 2, 15, 13, 37, 1, 566, DateTimeKind.Local).AddTicks(4167), "Lorem Ipsum is simply dummy text", "Item 1", 529.59000000000003, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(3798) },
                    { 23, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8782), "Lorem Ipsum is simply dummy text", "Item 23", 238.78, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8783) },
                    { 22, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8778), "Lorem Ipsum is simply dummy text", "Item 22", 828.02999999999997, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8779) },
                    { 21, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8775), "Lorem Ipsum is simply dummy text", "Item 21", 201.56, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8776) },
                    { 20, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8771), "Lorem Ipsum is simply dummy text", "Item 20", 60.270000000000003, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8772) },
                    { 19, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8767), "Lorem Ipsum is simply dummy text", "Item 19", 539.00999999999999, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8768) },
                    { 18, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8763), "Lorem Ipsum is simply dummy text", "Item 18", 228.41, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8764) },
                    { 17, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8758), "Lorem Ipsum is simply dummy text", "Item 17", 148.65000000000001, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8759) },
                    { 16, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8754), "Lorem Ipsum is simply dummy text", "Item 16", 514.40999999999997, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8755) },
                    { 15, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8750), "Lorem Ipsum is simply dummy text", "Item 15", 739.42999999999995, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8751) },
                    { 14, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8746), "Lorem Ipsum is simply dummy text", "Item 14", 285.42000000000002, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8747) },
                    { 24, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8787), "Lorem Ipsum is simply dummy text", "Item 24", 284.92000000000002, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8788) },
                    { 13, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8742), "Lorem Ipsum is simply dummy text", "Item 13", 957.25, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8743) },
                    { 11, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8734), "Lorem Ipsum is simply dummy text", "Item 11", 237.34, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8735) },
                    { 10, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8730), "Lorem Ipsum is simply dummy text", "Item 10", 109.73999999999999, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8731) },
                    { 9, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8725), "Lorem Ipsum is simply dummy text", "Item 9", 118.06, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8726) },
                    { 8, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8722), "Lorem Ipsum is simply dummy text", "Item 8", 496.82999999999998, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8723) },
                    { 7, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8718), "Lorem Ipsum is simply dummy text", "Item 7", 884.46000000000004, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8719) },
                    { 6, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8713), "Lorem Ipsum is simply dummy text", "Item 6", 68.010000000000005, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8715) },
                    { 5, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8700), "Lorem Ipsum is simply dummy text", "Item 5", 579.72000000000003, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8702) },
                    { 4, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8696), "Lorem Ipsum is simply dummy text", "Item 4", 526.46000000000004, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8698) },
                    { 3, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8690), "Lorem Ipsum is simply dummy text", "Item 3", 991.89999999999998, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8691) },
                    { 2, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8660), "Lorem Ipsum is simply dummy text", "Item 2", 969.70000000000005, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8672) },
                    { 12, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8738), "Lorem Ipsum is simply dummy text", "Item 2", 997.89999999999998, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8739) },
                    { 25, null, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8791), "Lorem Ipsum is simply dummy text", "Item 25", 89.069999999999993, new DateTime(2021, 2, 15, 13, 37, 1, 567, DateTimeKind.Local).AddTicks(8792) }
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
