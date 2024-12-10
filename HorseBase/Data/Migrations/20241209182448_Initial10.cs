using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorseBase.Migrations
{
    /// <inheritdoc />
    public partial class Initial10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_horses_horseId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_users_userId",
                table: "reservations");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "middleName",
                table: "users",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "isAdmin",
                table: "users",
                newName: "IsAdmin");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "reservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "takeHour",
                table: "reservations",
                newName: "TakeHour");

            migrationBuilder.RenameColumn(
                name: "returnHour",
                table: "reservations",
                newName: "ReturnHour");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "reservations",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "horseId",
                table: "reservations",
                newName: "HorseId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_userId",
                table: "reservations",
                newName: "IX_reservations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_horseId",
                table: "reservations",
                newName: "IX_reservations_HorseId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "horses",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "photoPath",
                table: "horses",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "horses",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "horses",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "horses",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "BirhtYear",
                table: "horses",
                newName: "BirhtYear");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "breeds",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "breeds",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_horses_HorseId",
                table: "reservations",
                column: "HorseId",
                principalTable: "horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_users_UserId",
                table: "reservations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_horses_HorseId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_users_UserId",
                table: "reservations");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "users",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "users",
                newName: "middleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "IsAdmin",
                table: "users",
                newName: "isAdmin");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "users",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "reservations",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TakeHour",
                table: "reservations",
                newName: "takeHour");

            migrationBuilder.RenameColumn(
                name: "ReturnHour",
                table: "reservations",
                newName: "returnHour");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "reservations",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "HorseId",
                table: "reservations",
                newName: "horseId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_UserId",
                table: "reservations",
                newName: "IX_reservations_userId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_HorseId",
                table: "reservations",
                newName: "IX_reservations_horseId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "horses",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "horses",
                newName: "photoPath");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "horses",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "horses",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "horses",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "BirhtYear",
                table: "horses",
                newName: "BirhtYear");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "breeds",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "breeds",
                newName: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_horses_horseId",
                table: "reservations",
                column: "horseId",
                principalTable: "horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_users_userId",
                table: "reservations",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
