using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace demo_ecs.Migrations
{
    public partial class AlterPKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Identities",
                table: "Identities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cords",
                table: "Cords");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "CordId",
                table: "Cords");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Identities",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cords",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identities",
                table: "Identities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cords",
                table: "Cords",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Identities",
                table: "Identities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cords",
                table: "Cords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cords");

            migrationBuilder.AddColumn<int>(
                name: "IdentityId",
                table: "Identities",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CordId",
                table: "Cords",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identities",
                table: "Identities",
                column: "IdentityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cords",
                table: "Cords",
                column: "CordId");
        }
    }
}
