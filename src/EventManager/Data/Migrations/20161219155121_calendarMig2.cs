using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager.Data.Migrations
{
    public partial class calendarMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Events_EventID",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_EventID",
                table: "Calendars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Calendars_EventID",
                table: "Calendars",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Events_EventID",
                table: "Calendars",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
