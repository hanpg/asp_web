using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiKiemTra03_02.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TacGia",
                columns: table => new
                {
                    MaTacGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuocTich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamSinh = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGia", x => x.MaTacGia);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDeSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamXuatBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaTacGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Sach_TacGia_MaTacGia",
                        column: x => x.MaTacGia,
                        principalTable: "TacGia",
                        principalColumn: "MaTacGia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sach_MaTacGia",
                table: "Sach",
                column: "MaTacGia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "TacGia");
        }
    }
}
