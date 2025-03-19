using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class InitialAdminTest10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acc_CR_D",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Acc_UP_D",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Acc_CR_D",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Acc_UP_D",
                table: "users",
                type: "int",
                nullable: true);
        }
    }
}
