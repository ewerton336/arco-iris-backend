using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcoIris.Migrations
{
    /// <inheritdoc />
    public partial class AjustesAlternativas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestaoResposta_Alternativas_AlternativaEscolhidaId",
                table: "QuestaoResposta");

            migrationBuilder.AlterColumn<int>(
                name: "AlternativaEscolhidaId",
                table: "QuestaoResposta",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestaoResposta_Alternativas_AlternativaEscolhidaId",
                table: "QuestaoResposta",
                column: "AlternativaEscolhidaId",
                principalTable: "Alternativas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestaoResposta_Alternativas_AlternativaEscolhidaId",
                table: "QuestaoResposta");

            migrationBuilder.AlterColumn<int>(
                name: "AlternativaEscolhidaId",
                table: "QuestaoResposta",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestaoResposta_Alternativas_AlternativaEscolhidaId",
                table: "QuestaoResposta",
                column: "AlternativaEscolhidaId",
                principalTable: "Alternativas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
