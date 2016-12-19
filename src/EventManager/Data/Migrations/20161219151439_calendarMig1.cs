using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager.Data.Migrations
{
    public partial class calendarMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.AddColumn<string>(
                name: "UserCalendarId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCalendarId",
                table: "AspNetUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCalendarId",
                table: "AspNetUserClaims",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserCalendarId",
                table: "AspNetUserRoles",
                column: "UserCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserCalendarId",
                table: "AspNetUserLogins",
                column: "UserCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserCalendarId",
                table: "AspNetUserClaims",
                column: "UserCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_EventID",
                table: "Calendars",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Calendars_UserCalendarId",
                table: "AspNetUserClaims",
                column: "UserCalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Calendars_UserCalendarId",
                table: "AspNetUserLogins",
                column: "UserCalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Calendars_UserCalendarId",
                table: "AspNetUserRoles",
                column: "UserCalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Calendars_UserCalendarId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Calendars_UserCalendarId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Calendars_UserCalendarId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserCalendarId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_UserCalendarId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_UserCalendarId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "UserCalendarId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserCalendarId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "UserCalendarId",
                table: "AspNetUserClaims");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }
    }
}
