using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcoIris.Migrations
{
    /// <inheritdoc />
    public partial class entidadeProva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvaId",
                table: "Questoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Provas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeAcertos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_ProvaId",
                table: "Questoes",
                column: "ProvaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_AlunoId",
                table: "Provas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questoes_Provas_ProvaId",
                table: "Questoes",
                column: "ProvaId",
                principalTable: "Provas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questoes_Provas_ProvaId",
                table: "Questoes");

            migrationBuilder.DropTable(
                name: "Provas");

            migrationBuilder.DropIndex(
                name: "IX_Questoes_ProvaId",
                table: "Questoes");

            migrationBuilder.DropColumn(
                name: "ProvaId",
                table: "Questoes");
        }
    }
}
