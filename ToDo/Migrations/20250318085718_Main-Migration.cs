using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class MainMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminUsers",
                columns: table => new
                {
                    AdminUser_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminUser_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminUser_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminUserAcc_CR_D = table.Column<int>(type: "int", nullable: false),
                    AdminUserAcc_UP_D = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminUsers", x => x.AdminUser_Id);
                });

            migrationBuilder.CreateTable(
                name: "taskList",
                columns: table => new
                {
                    List_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    List_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    List_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creation_Date = table.Column<int>(type: "int", nullable: false),
                    Update_Date = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskList", x => x.List_Id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    Task_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Due_Date = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<int>(type: "int", nullable: false),
                    Update_Date = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.Task_Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acc_CR_D = table.Column<int>(type: "int", nullable: true),
                    Acc_UP_D = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.User_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminUsers");

            migrationBuilder.DropTable(
                name: "taskList");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
