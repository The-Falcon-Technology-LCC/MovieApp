using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DirectorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "DOB", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1967, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis", "Villeneuve" });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "DOB", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher", "Nolan" });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "DOB", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quentin", "Tarantino" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Thriller" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Drama" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Action" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Comedy" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "DirectorId", "Title" },
                values: new object[] { 1, "K, an officer with the Los Angeles Police Department, unearths a secret that could create chaos. He goes in search of a former blade runner who has been missing for over three decades.", 1, "Blade Runner 2049" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "DirectorId", "Title" },
                values: new object[] { 2, "During a dangerous mission to stop a drug cartel operating between the US and Mexico, Kate Macer, an FBI agent, is exposed to some harsh realities.", 1, "Sicario" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "DirectorId", "Title" },
                values: new object[] { 3, "Cobb steals information from his targets by entering their dreams. Saito offers to wipe clean Cobb's criminal history as payment for performing an inception on his sick competitor's son.", 2, "Inception" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "DirectorId", "Title" },
                values: new object[] { 4, "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.", 2, "Interstellar" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "DirectorId", "Title" },
                values: new object[] { 5, "In the realm of underworld, a series of incidents intertwines the lives of two Los Angeles mobsters, a gangster's wife, a boxer and two small-time criminals.", 3, "Pulp Fiction" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "DirectorId", "Title" },
                values: new object[] { 6, "Six criminals, hired to steal diamonds, do not know each other's true identity. While attempting the heist, the police ambushes them, leading them to believe that one of them is an undercover officer.", 3, "Reservoir Dogs" });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { 4, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MovieId",
                table: "GenreMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Director");
        }
    }
}
