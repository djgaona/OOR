using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addeduniques : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Selections_MarketId",
                table: "Selections");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_MarketId_LineTypeId_TeamId_PlayerId",
                table: "Selections",
                columns: new[] { "MarketId", "LineTypeId", "TeamId", "PlayerId" },
                unique: true,
                filter: "\"TeamId\" IS NOT NULL AND \"PlayerId\" IS NOT NULL AND \"LineTypeId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LineTypes_Name",
                table: "LineTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Selections_MarketId_LineTypeId_TeamId_PlayerId",
                table: "Selections");

            migrationBuilder.DropIndex(
                name: "IX_LineTypes_Name",
                table: "LineTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_MarketId",
                table: "Selections",
                column: "MarketId");
        }
    }
}
