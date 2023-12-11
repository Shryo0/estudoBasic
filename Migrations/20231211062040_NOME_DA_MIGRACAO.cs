using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova.Migrations
{
    public partial class NOME_DA_MIGRACAO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Nome" },
                values: new object[] { 1, "João Silva" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Nome" },
                values: new object[] { 2, "Maria Oliveira" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Nome" },
                values: new object[] { 3, "José Santos" });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "PedidoId", "ClienteId", "CriadoEm", "Descricao", "Nome" },
                values: new object[] { 1, 1, new DateTime(2023, 12, 12, 3, 20, 40, 697, DateTimeKind.Local).AddTicks(635), "Descrição do Pedido 1", "Pedido 1" });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "PedidoId", "ClienteId", "CriadoEm", "Descricao", "Nome" },
                values: new object[] { 2, 2, new DateTime(2023, 12, 13, 3, 20, 40, 697, DateTimeKind.Local).AddTicks(645), "Descrição do Pedido 2", "Pedido 2" });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "PedidoId", "ClienteId", "CriadoEm", "Descricao", "Nome" },
                values: new object[] { 3, 3, new DateTime(2023, 12, 14, 3, 20, 40, 697, DateTimeKind.Local).AddTicks(647), "Descrição do Pedido 3", "Pedido 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
