using Microsoft.EntityFrameworkCore.Migrations;

namespace ShowCase.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum is simply dummy text", "Item 1", 65.859999999999999 },
                    { 23, "Lorem Ipsum is simply dummy text", "Item 23", 50.829999999999998 },
                    { 22, "Lorem Ipsum is simply dummy text", "Item 22", 62.810000000000002 },
                    { 21, "Lorem Ipsum is simply dummy text", "Item 21", 35.100000000000001 },
                    { 20, "Lorem Ipsum is simply dummy text", "Item 20", 32.740000000000002 },
                    { 19, "Lorem Ipsum is simply dummy text", "Item 19", 13.5 },
                    { 18, "Lorem Ipsum is simply dummy text", "Item 18", 55.649999999999999 },
                    { 17, "Lorem Ipsum is simply dummy text", "Item 17", 17.629999999999999 },
                    { 16, "Lorem Ipsum is simply dummy text", "Item 16", 64.319999999999993 },
                    { 15, "Lorem Ipsum is simply dummy text", "Item 15", 30.170000000000002 },
                    { 14, "Lorem Ipsum is simply dummy text", "Item 14", 70.980000000000004 },
                    { 24, "Lorem Ipsum is simply dummy text", "Item 24", 47.600000000000001 },
                    { 13, "Lorem Ipsum is simply dummy text", "Item 13", 12.56 },
                    { 11, "Lorem Ipsum is simply dummy text", "Item 11", 58.57 },
                    { 10, "Lorem Ipsum is simply dummy text", "Item 10", 79.109999999999999 },
                    { 9, "Lorem Ipsum is simply dummy text", "Item 9", 45.200000000000003 },
                    { 8, "Lorem Ipsum is simply dummy text", "Item 8", 35.950000000000003 },
                    { 7, "Lorem Ipsum is simply dummy text", "Item 7", 41.640000000000001 },
                    { 6, "Lorem Ipsum is simply dummy text", "Item 6", 85.310000000000002 },
                    { 5, "Lorem Ipsum is simply dummy text", "Item 5", 52.549999999999997 },
                    { 4, "Lorem Ipsum is simply dummy text", "Item 4", 86.180000000000007 },
                    { 3, "Lorem Ipsum is simply dummy text", "Item 3", 55.57 },
                    { 2, "Lorem Ipsum is simply dummy text", "Item 2", 12.51 },
                    { 12, "Lorem Ipsum is simply dummy text", "Item 2", 82.170000000000002 },
                    { 25, "Lorem Ipsum is simply dummy text", "Item 25", 14.59 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
