using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorseBase.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horses_photos_photosId",
                table: "horses");

            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropIndex(
                name: "IX_horses_photosId",
                table: "horses");

            migrationBuilder.DropColumn(
                name: "photosId",
                table: "horses");

            migrationBuilder.AddColumn<string>(
                name: "photoPath",
                table: "horses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoPath",
                table: "horses");

            migrationBuilder.AddColumn<int>(
                name: "photosId",
                table: "horses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_horses_photosId",
                table: "horses",
                column: "photosId");

            migrationBuilder.AddForeignKey(
                name: "FK_horses_photos_photosId",
                table: "horses",
                column: "photosId",
                principalTable: "photos",
                principalColumn: "Id");
        }
    }
}
