using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_projet_net.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commandeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_commandes",
                table: "commandes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "commandes");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "commandes");

            migrationBuilder.DropColumn(
                name: "TotCommande",
                table: "commandes");

            migrationBuilder.RenameTable(
                name: "commandes",
                newName: "Commandes");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Commandes",
                newName: "NumeroTelephone");

            migrationBuilder.RenameColumn(
                name: "CommandeId",
                table: "Commandes",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Commandes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PanierArts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanierArts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PanierArts_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "articleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PanierArts_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PanierArts_ArticleId",
                table: "PanierArts",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_PanierArts_CommandeId",
                table: "PanierArts",
                column: "CommandeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PanierArts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Commandes");

            migrationBuilder.RenameTable(
                name: "Commandes",
                newName: "commandes");

            migrationBuilder.RenameColumn(
                name: "NumeroTelephone",
                table: "commandes",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "commandes",
                newName: "CommandeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "commandes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "commandes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TotCommande",
                table: "commandes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_commandes",
                table: "commandes",
                column: "CommandeId");

            migrationBuilder.CreateTable(
                name: "commandeItems",
                columns: table => new
                {
                    CommandeItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandeItems", x => x.CommandeItemId);
                    table.ForeignKey(
                        name: "FK_commandeItems_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "articleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commandeItems_commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "commandes",
                        principalColumn: "CommandeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commandeItems_ArticleId",
                table: "commandeItems",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_commandeItems_CommandeId",
                table: "commandeItems",
                column: "CommandeId");
        }
    }
}
