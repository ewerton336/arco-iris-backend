using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcoIris.Migrations
{
    /// <inheritdoc />
    public partial class AjustesQuestoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Questoes_QuestoId",
                table: "Alternativas");

            migrationBuilder.RenameColumn(
                name: "QuestoId",
                table: "Alternativas",
                newName: "QuestaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alternativas_QuestoId",
                table: "Alternativas",
                newName: "IX_Alternativas_QuestaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas",
                column: "QuestaoId",
                principalTable: "Questoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas");

            migrationBuilder.RenameColumn(
                name: "QuestaoId",
                table: "Alternativas",
                newName: "QuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alternativas_QuestaoId",
                table: "Alternativas",
                newName: "IX_Alternativas_QuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Questoes_QuestoId",
                table: "Alternativas",
                column: "QuestoId",
                principalTable: "Questoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
