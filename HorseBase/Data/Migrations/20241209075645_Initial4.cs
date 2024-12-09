using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorseBase.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horses_breeds_breedId",
                table: "horses");

            migrationBuilder.RenameColumn(
                name: "breedId",
                table: "horses",
                newName: "BreedId");

            migrationBuilder.RenameIndex(
                name: "IX_horses_breedId",
                table: "horses",
                newName: "IX_horses_BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_horses_breeds_BreedId",
                table: "horses",
                column: "BreedId",
                principalTable: "breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horses_breeds_BreedId",
                table: "horses");

            migrationBuilder.RenameColumn(
                name: "BreedId",
                table: "horses",
                newName: "breedId");

            migrationBuilder.RenameIndex(
                name: "IX_horses_BreedId",
                table: "horses",
                newName: "IX_horses_breedId");

            migrationBuilder.AddForeignKey(
                name: "FK_horses_breeds_breedId",
                table: "horses",
                column: "breedId",
                principalTable: "breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
