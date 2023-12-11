using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 12, 3, 20, 51, 761, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 13, 3, 20, 51, 761, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 14, 3, 20, 51, 761, DateTimeKind.Local).AddTicks(677));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 12, 3, 20, 40, 697, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 13, 3, 20, 40, 697, DateTimeKind.Local).AddTicks(645));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "PedidoId",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 14, 3, 20, 40, 697, DateTimeKind.Local).AddTicks(647));
        }
    }
}
