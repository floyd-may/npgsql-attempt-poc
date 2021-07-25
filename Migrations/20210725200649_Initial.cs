using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pgsql_poc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Root",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Root", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intermediate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecordType = table.Column<string>(nullable: false),
                    RootId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intermediate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intermediate_Root_RootId",
                        column: x => x.RootId,
                        principalTable: "Root",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RootToLeaf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeafId = table.Column<int>(nullable: false),
                    Effective = table.Column<LocalDate>(nullable: false),
                    RootId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootToLeaf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootToLeaf_Leaf_LeafId",
                        column: x => x.LeafId,
                        principalTable: "Leaf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootToLeaf_Root_RootId",
                        column: x => x.RootId,
                        principalTable: "Root",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntermediateToLeaf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeafId = table.Column<int>(nullable: false),
                    Effective = table.Column<LocalDate>(nullable: false),
                    IntermediateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediateToLeaf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntermediateToLeaf_Intermediate_IntermediateId",
                        column: x => x.IntermediateId,
                        principalTable: "Intermediate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntermediateToLeaf_Leaf_LeafId",
                        column: x => x.LeafId,
                        principalTable: "Leaf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intermediate_RootId",
                table: "Intermediate",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateToLeaf_IntermediateId",
                table: "IntermediateToLeaf",
                column: "IntermediateId");

            migrationBuilder.CreateIndex(
                name: "IX_IntermediateToLeaf_LeafId",
                table: "IntermediateToLeaf",
                column: "LeafId");

            migrationBuilder.CreateIndex(
                name: "IX_RootToLeaf_LeafId",
                table: "RootToLeaf",
                column: "LeafId");

            migrationBuilder.CreateIndex(
                name: "IX_RootToLeaf_RootId",
                table: "RootToLeaf",
                column: "RootId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntermediateToLeaf");

            migrationBuilder.DropTable(
                name: "RootToLeaf");

            migrationBuilder.DropTable(
                name: "Intermediate");

            migrationBuilder.DropTable(
                name: "Leaf");

            migrationBuilder.DropTable(
                name: "Root");
        }
    }
}
