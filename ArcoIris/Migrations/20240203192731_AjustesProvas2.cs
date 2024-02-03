using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcoIris.Migrations
{
    /// <inheritdoc />
    public partial class AjustesProvas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeAcertos = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeErros = table.Column<int>(type: "INTEGER", nullable: false),
                    Nota = table.Column<decimal>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "QuestaoResposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProvaId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlternativaEscolhidaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Correta = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoResposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestaoResposta_Alternativas_AlternativaEscolhidaId",
                        column: x => x.AlternativaEscolhidaId,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestaoResposta_Provas_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "Provas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestaoResposta_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provas_AlunoId",
                table: "Provas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoResposta_AlternativaEscolhidaId",
                table: "QuestaoResposta",
                column: "AlternativaEscolhidaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoResposta_ProvaId",
                table: "QuestaoResposta",
                column: "ProvaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoResposta_QuestaoId",
                table: "QuestaoResposta",
                column: "QuestaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestaoResposta");

            migrationBuilder.DropTable(
                name: "Provas");
        }
    }
}
