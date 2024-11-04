using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_projet_net.Migrations
{
    public partial class addshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commandeItems");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.CreateTable(
                name: "shoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articleId = table.Column<int>(type: "int", nullable: false),
                    shoppingcartid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCartItems_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "articleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartItems_articleId",
                table: "shoppingCartItems",
                column: "articleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingCartItems");

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    commandeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    TotCommande = table.Column<double>(type: "float", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.commandeId);
                });

            migrationBuilder.CreateTable(
                name: "commandeItems",
                columns: table => new
                {
                    CommandeItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articleId = table.Column<int>(type: "int", nullable: false),
                    commandeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandeItems", x => x.CommandeItemId);
                    table.ForeignKey(
                        name: "FK_commandeItems_articles_articleId",
                        column: x => x.articleId,
                        principalTable: "articles",
                        principalColumn: "articleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commandeItems_Commandes_commandeId",
                        column: x => x.commandeId,
                        principalTable: "Commandes",
                        principalColumn: "commandeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commandeItems_articleId",
                table: "commandeItems",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_commandeItems_commandeId",
                table: "commandeItems",
                column: "commandeId");
        }
    }
}
