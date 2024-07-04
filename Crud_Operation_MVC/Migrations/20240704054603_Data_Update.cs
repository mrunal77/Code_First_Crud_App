using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Crud_Operation_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Data_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataEntities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monster" },
                    { 2, "Ghost" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataEntities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DataEntities",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
