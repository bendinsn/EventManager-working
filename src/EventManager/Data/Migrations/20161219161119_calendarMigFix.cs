using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.Data.Migrations
{
    public partial class calendarMigFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Calendars");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Calendars",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Calendars",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Calendars",
                newName: "Id");

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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Calendars",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Calendars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Calendars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Calendars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Calendars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Calendars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Calendars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Calendars",
                nullable: true);

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
    }
}
