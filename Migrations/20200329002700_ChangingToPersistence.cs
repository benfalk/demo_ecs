using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace demo_ecs.Migrations
{
    public partial class ChangingToPersistence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cords_Entities_EntityId",
                table: "Cords");

            migrationBuilder.DropForeignKey(
                name: "FK_Identities_Entities_EntityId",
                table: "Identities");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Identities_EntityId",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "IX_Cords_EntityId",
                table: "Cords");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Cords");

            migrationBuilder.AddColumn<int>(
                name: "PersistenceId",
                table: "Identities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersistenceId",
                table: "Cords",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persistences",
                columns: table => new
                {
                    PersistenceId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persistences", x => x.PersistenceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identities_PersistenceId",
                table: "Identities",
                column: "PersistenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cords_PersistenceId",
                table: "Cords",
                column: "PersistenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cords_Persistences_PersistenceId",
                table: "Cords",
                column: "PersistenceId",
                principalTable: "Persistences",
                principalColumn: "PersistenceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_Persistences_PersistenceId",
                table: "Identities",
                column: "PersistenceId",
                principalTable: "Persistences",
                principalColumn: "PersistenceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cords_Persistences_PersistenceId",
                table: "Cords");

            migrationBuilder.DropForeignKey(
                name: "FK_Identities_Persistences_PersistenceId",
                table: "Identities");

            migrationBuilder.DropTable(
                name: "Persistences");

            migrationBuilder.DropIndex(
                name: "IX_Identities_PersistenceId",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "IX_Cords_PersistenceId",
                table: "Cords");

            migrationBuilder.DropColumn(
                name: "PersistenceId",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "PersistenceId",
                table: "Cords");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Identities",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Cords",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identities_EntityId",
                table: "Identities",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cords_EntityId",
                table: "Cords",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cords_Entities_EntityId",
                table: "Cords",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_Entities_EntityId",
                table: "Identities",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
