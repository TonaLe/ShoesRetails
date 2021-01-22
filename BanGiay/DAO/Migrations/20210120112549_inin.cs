using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class inin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BanGiay",
                columns: table => new
                {
                    ShoesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeName = table.Column<string>(nullable: true),
                    ShoeSize = table.Column<int>(nullable: false),
                    ShoeImg = table.Column<string>(nullable: true),
                    ShoeCateId = table.Column<string>(nullable: true),
                    ShoeDesc = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CreateId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdadeId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanGiay", x => x.ShoesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BanGiay");
        }
    }
}
