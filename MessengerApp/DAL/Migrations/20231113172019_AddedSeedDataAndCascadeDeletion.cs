using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataAndCascadeDeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_SenderId",
                table: "Dialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ResipientId",
                table: "Messages",
                newName: "RecipientId");

            migrationBuilder.AlterColumn<long>(
                name: "DialogId",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SenderId",
                table: "Dialogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_SenderId",
                table: "Dialogs",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages",
                column: "DialogId",
                principalTable: "Dialogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_SenderId",
                table: "Dialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5000L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5001L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5002L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5003L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5004L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5005L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5006L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5007L);

            migrationBuilder.DeleteData(
                table: "Dialogs",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Dialogs",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Dialogs",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Dialogs",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Dialogs",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Messages",
                newName: "ResipientId");

            migrationBuilder.AlterColumn<long>(
                name: "DialogId",
                table: "Messages",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SenderId",
                table: "Dialogs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_SenderId",
                table: "Dialogs",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Dialogs_DialogId",
                table: "Messages",
                column: "DialogId",
                principalTable: "Dialogs",
                principalColumn: "Id");
        }
    }
}
