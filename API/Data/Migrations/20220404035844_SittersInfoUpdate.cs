using Microsoft.EntityFrameworkCore.Migrations;

namespace PetSitting.Data.Migrations
{
    public partial class SittersInfoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_SitterId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "License",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "SitterId",
                table: "Pets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sitters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Ratings = table.Column<int>(type: "INTEGER", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    License = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SitterId",
                table: "Pets",
                column: "SitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Sitters_SitterId",
                table: "Pets",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Sitters_SitterId",
                table: "Review",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Sitters_SitterId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Sitters_SitterId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Sitters");

            migrationBuilder.DropIndex(
                name: "IX_Pets_SitterId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "SitterId",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "License",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ratings",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_SitterId",
                table: "Review",
                column: "SitterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
