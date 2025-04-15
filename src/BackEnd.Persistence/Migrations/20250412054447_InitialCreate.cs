using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.CreateTable(
                name: "calendars",
                columns: table => new
                {
                    calendarid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("calendars_pkey", x => x.calendarid);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    event1 = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Userid = table.Column<Guid>(type: "uuid", nullable: true),
                    calendarid = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Discriotion = table.Column<string>(type: "text", nullable: false),
                    Allday = table.Column<bool>(type: "boolean", nullable: true),
                    Startdate = table.Column<string>(type: "text", nullable: false),
                    Enddate = table.Column<string>(type: "text", nullable: false),
                    Participants = table.Column<List<string>>(type: "text[]", nullable: false),
                    Reminder = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_pkey", x => x.event1);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Passwordhash = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calendars");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
