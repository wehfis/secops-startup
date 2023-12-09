using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dialogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dialogs_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dialogs_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DialogId = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SenderId = table.Column<long>(type: "bigint", nullable: true),
                    RecipientId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Dialogs_DialogId",
                        column: x => x.DialogId,
                        principalTable: "Dialogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1L, "sifjokasfp212", 2, "William" },
                    { 2L, "12312sadads", 2, "John" },
                    { 3L, "asjdgukah19091", 0, "Alex" },
                    { 4L, "sasfjguahs21", 1, "Jane" }
                });

            migrationBuilder.InsertData(
                table: "Dialogs",
                columns: new[] { "Id", "RecipientId", "SenderId" },
                values: new object[,]
                {
                    { 100L, 2L, 1L },
                    { 101L, 3L, 1L },
                    { 102L, 4L, 1L },
                    { 103L, 4L, 3L },
                    { 104L, 2L, 3L }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "DialogId", "RecipientId", "SenderId", "Time" },
                values: new object[,]
                {
                    { 5000L, "Hi there John!", 100L, null, null, new DateTime(2020, 3, 15, 7, 1, 0, 0, DateTimeKind.Unspecified) },
                    { 5001L, "Hi there!", 101L, null, null, new DateTime(2020, 3, 15, 7, 2, 0, 0, DateTimeKind.Unspecified) },
                    { 5002L, "Hi there!", 102L, null, null, new DateTime(2020, 3, 15, 7, 3, 0, 0, DateTimeKind.Unspecified) },
                    { 5003L, "Hi there!", 103L, null, null, new DateTime(2020, 3, 15, 7, 4, 0, 0, DateTimeKind.Unspecified) },
                    { 5004L, "Hi there!", 104L, null, null, new DateTime(2020, 3, 15, 7, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 5005L, "Hi there!", 102L, null, null, new DateTime(2020, 3, 15, 7, 6, 0, 0, DateTimeKind.Unspecified) },
                    { 5006L, "Hi there!", 104L, null, null, new DateTime(2020, 3, 15, 7, 7, 0, 0, DateTimeKind.Unspecified) },
                    { 5007L, "Hi there!", 100L, null, null, new DateTime(2020, 3, 15, 7, 8, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_RecipientId",
                table: "Dialogs",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_SenderId",
                table: "Dialogs",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DialogId",
                table: "Messages",
                column: "DialogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Dialogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
