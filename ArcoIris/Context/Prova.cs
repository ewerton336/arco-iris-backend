
namespace Database.Context
{
    public class Prova
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual List<QuestaoResposta> QuestoesRespostas { get; set; }
        public int QuantidadeAcertos { get; set; }
        public int QuantidadeErros { get; set; }
        public decimal Nota { get; set; }
    }
}
