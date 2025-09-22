using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetInstagramAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "defaultImg.png")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AvatarPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "defaultImg.png"),
                    FollowersCount = table.Column<long>(type: "bigint", nullable: false),
                    AnimalTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalProfiles_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "defaultImg.png"),
                    LikesCount = table.Column<long>(type: "bigint", nullable: false),
                    AnimalProfileId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalPhotos_AnimalProfiles_AnimalProfileId",
                        column: x => x.AnimalProfileId,
                        principalTable: "AnimalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalPhotos_AnimalProfileId",
                table: "AnimalPhotos",
                column: "AnimalProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalProfiles_AnimalTypeId",
                table: "AnimalProfiles",
                column: "AnimalTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalPhotos");

            migrationBuilder.DropTable(
                name: "AnimalProfiles");

            migrationBuilder.DropTable(
                name: "AnimalTypes");
        }
    }
}
