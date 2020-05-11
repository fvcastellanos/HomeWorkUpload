using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace HomeWorkUpload.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assigment",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    copy_email = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assigment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "homework",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    assigment_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homework", x => x.id);
                    table.ForeignKey(
                        name: "FK_homework_assigment_assigment_id",
                        column: x => x.assigment_id,
                        principalTable: "assigment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "homework_detail",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    image_url = table.Column<string>(nullable: false),
                    homework_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homework_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_homework_detail_homework_homework_id",
                        column: x => x.homework_id,
                        principalTable: "homework",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_homework_assigment_id",
                table: "homework",
                column: "assigment_id");

            migrationBuilder.CreateIndex(
                name: "IX_homework_detail_homework_id",
                table: "homework_detail",
                column: "homework_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "homework_detail");

            migrationBuilder.DropTable(
                name: "homework");

            migrationBuilder.DropTable(
                name: "assigment");
        }
    }
}
