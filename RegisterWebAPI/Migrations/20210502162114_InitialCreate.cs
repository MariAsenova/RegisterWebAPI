﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RegisterWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    IdFamily = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetName = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.IdFamily);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Adults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdJob = table.Column<int>(type: "integer", nullable: false),
                    FamilyIdFamily = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    HairColor = table.Column<string>(type: "text", nullable: true),
                    EyeColor = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adults_Families_FamilyIdFamily",
                        column: x => x.FamilyIdFamily,
                        principalTable: "Families",
                        principalColumn: "IdFamily",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FamilyIdFamily = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    HairColor = table.Column<string>(type: "text", nullable: true),
                    EyeColor = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Child_Families_FamilyIdFamily",
                        column: x => x.FamilyIdFamily,
                        principalTable: "Families",
                        principalColumn: "IdFamily",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    IdJob = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<int>(type: "integer", nullable: false),
                    IdAdult = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.IdJob);
                    table.ForeignKey(
                        name: "FK_Jobs_Adults_IdAdult",
                        column: x => x.IdAdult,
                        principalTable: "Adults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    IdInterest = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ChildId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.IdInterest);
                    table.ForeignKey(
                        name: "FK_Interest_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Species = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: true),
                    FamilyIdFamily = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pet_Families_FamilyIdFamily",
                        column: x => x.FamilyIdFamily,
                        principalTable: "Families",
                        principalColumn: "IdFamily",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Adults",
                columns: new[] { "Id", "Age", "EyeColor", "FamilyIdFamily", "FirstName", "HairColor", "Height", "IdJob", "LastName", "Sex", "Weight" },
                values: new object[,]
                {
                    { 1, 24, "blue", null, "Maria", "Brown", 167, 1, "Asenova", "F", 56f },
                    { 2, 30, "Green", null, "Kasper", "Black", 168, 2, "Andersen", "F", 72f }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "IdJob", "IdAdult", "JobTitle", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "Project Manager", 45000 },
                    { 2, 2, "Head of Marketing", 36000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adults_FamilyIdFamily",
                table: "Adults",
                column: "FamilyIdFamily");

            migrationBuilder.CreateIndex(
                name: "IX_Child_FamilyIdFamily",
                table: "Child",
                column: "FamilyIdFamily");

            migrationBuilder.CreateIndex(
                name: "IX_Interest_ChildId",
                table: "Interest",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IdAdult",
                table: "Jobs",
                column: "IdAdult",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ChildId",
                table: "Pet",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_FamilyIdFamily",
                table: "Pet",
                column: "FamilyIdFamily");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Adults");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}