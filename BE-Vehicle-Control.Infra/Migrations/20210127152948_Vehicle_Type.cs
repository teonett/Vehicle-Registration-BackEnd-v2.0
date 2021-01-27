using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Vehicle_Control.Infra.Migrations
{
    public partial class Vehicle_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeVehicle",
                table: "VehicleModel");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeVehicleId",
                table: "VehicleModel",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleTypeId",
                table: "VehicleModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleTypeId",
                table: "VehicleModel",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleTypeId",
                table: "VehicleModel",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModel_VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "TypeVehicleId",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.AddColumn<int>(
                name: "TypeVehicle",
                table: "VehicleModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
