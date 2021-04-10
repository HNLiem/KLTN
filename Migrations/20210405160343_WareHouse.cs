using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class WareHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderDate = table.Column<DateTime>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    SenderPhoneNumber = table.Column<string>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: true),
                    ReceiverPhoneNumber = table.Column<string>(nullable: true),
                    ReceiverDate = table.Column<DateTime>(nullable: false),
                    Nature = table.Column<string>(nullable: true),
                    StatusOrder = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
