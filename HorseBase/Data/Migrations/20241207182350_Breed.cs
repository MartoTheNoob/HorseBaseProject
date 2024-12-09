using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorseBase.Migrations
{
    /// <inheritdoc />
    public partial class Breed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horses_photos_photosId",
                table: "horses");

            migrationBuilder.AlterColumn<int>(
                name: "photosId",
                table: "horses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_horses_photos_photosId",
                table: "horses",
                column: "photosId",
                principalTable: "photos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horses_photos_photosId",
                table: "horses");

            migrationBuilder.AlterColumn<int>(
                name: "photosId",
                table: "horses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_horses_photos_photosId",
                table: "horses",
                column: "photosId",
                principalTable: "photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
