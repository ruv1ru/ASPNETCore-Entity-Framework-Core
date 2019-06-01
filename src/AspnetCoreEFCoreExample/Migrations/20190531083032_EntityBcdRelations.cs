using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AspnetCoreEFCoreExample.Migrations
{
    public partial class EntityBcdRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntityBeeId",
                table: "EntityDees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityBeeId",
                table: "EntityCees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityDees_EntityBeeId",
                table: "EntityDees",
                column: "EntityBeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCees_EntityBeeId",
                table: "EntityCees",
                column: "EntityBeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityCees_EntityBees_EntityBeeId",
                table: "EntityCees",
                column: "EntityBeeId",
                principalTable: "EntityBees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityDees_EntityBees_EntityBeeId",
                table: "EntityDees",
                column: "EntityBeeId",
                principalTable: "EntityBees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityCees_EntityBees_EntityBeeId",
                table: "EntityCees");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityDees_EntityBees_EntityBeeId",
                table: "EntityDees");

            migrationBuilder.DropIndex(
                name: "IX_EntityDees_EntityBeeId",
                table: "EntityDees");

            migrationBuilder.DropIndex(
                name: "IX_EntityCees_EntityBeeId",
                table: "EntityCees");

            migrationBuilder.DropColumn(
                name: "EntityBeeId",
                table: "EntityDees");

            migrationBuilder.DropColumn(
                name: "EntityBeeId",
                table: "EntityCees");
        }
    }
}
