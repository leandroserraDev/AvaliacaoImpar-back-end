using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaliacaoImpar.Infra.Migrations
{
    public partial class Add_Cascade_relationship_card_photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Car_Id",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Car_Id",
                table: "Photo",
                column: "Id",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Car_Id",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Car_Id",
                table: "Photo",
                column: "Id",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
