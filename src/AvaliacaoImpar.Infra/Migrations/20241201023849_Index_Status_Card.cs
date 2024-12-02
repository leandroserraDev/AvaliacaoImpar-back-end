using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaliacaoImpar.Infra.Migrations
{
    public partial class Index_Status_Card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Car_Status",
                table: "Car",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Car_Status",
                table: "Car");
        }
    }
}
