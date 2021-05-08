using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laba5.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblsTypeProduct",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsTypeProduct", x => x.gId);
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(nullable: false),
                    szPrice = table.Column<string>(nullable: false),
                    gTypeProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.gId);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblsTypeProduct_gTypeProductId",
                        column: x => x.gTypeProductId,
                        principalTable: "tblsTypeProduct",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblsStore",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(maxLength: 50, nullable: false),
                    szTypeStore = table.Column<string>(maxLength: 50, nullable: false),
                    bMainStore = table.Column<bool>(name: "bMain Store", nullable: false),
                    gProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsStore", x => x.gId);
                    table.ForeignKey(
                        name: "FK_tblsStore_tblProduct_gProductId",
                        column: x => x.gProductId,
                        principalTable: "tblProduct",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_gTypeProductId",
                table: "tblProduct",
                column: "gTypeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblsStore_gProductId",
                table: "tblsStore",
                column: "gProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblsStore");

            migrationBuilder.DropTable(
                name: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblsTypeProduct");
        }
    }
}
