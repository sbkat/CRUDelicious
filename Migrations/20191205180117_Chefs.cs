using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDelicious.Migrations
{
    public partial class Chefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    chefId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    dateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.chefId);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dishName = table.Column<string>(nullable: false),
                    calories = table.Column<int>(nullable: false),
                    tastiness = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    chefId = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_Dish_Chef_chefId",
                        column: x => x.chefId,
                        principalTable: "Chef",
                        principalColumn: "chefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_chefId",
                table: "Dish",
                column: "chefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Chef");
        }
    }
}
