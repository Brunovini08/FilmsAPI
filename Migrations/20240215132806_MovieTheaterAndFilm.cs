using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI.Migrations
{
    /// <inheritdoc />
    public partial class MovieTheaterAndFilm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Films_FilmId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_MovieTheaters_MovieTheaterId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_FilmId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sections");

            migrationBuilder.AlterColumn<int>(
                name: "MovieTheaterId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                columns: new[] { "FilmId", "MovieTheaterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Films_FilmId",
                table: "Sections",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_MovieTheaters_MovieTheaterId",
                table: "Sections",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Films_FilmId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_MovieTheaters_MovieTheaterId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.AlterColumn<int>(
                name: "MovieTheaterId",
                table: "Sections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Sections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_FilmId",
                table: "Sections",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Films_FilmId",
                table: "Sections",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_MovieTheaters_MovieTheaterId",
                table: "Sections",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");
        }
    }
}
