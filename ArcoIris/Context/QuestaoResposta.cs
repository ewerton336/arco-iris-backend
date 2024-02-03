namespace Database.Context
{
    public class QuestaoResposta
    {
        
        public int Id { get; set; }
        public int ProvaId { get; set; }
        public virtual Prova Prova { get; set; }
        public int QuestaoId { get; set; }
        public virtual Questao Questao { get; set; }
        public int? AlternativaEscolhidaId { get; set; }
        public virtual Alternativa AlternativaEscolhida { get; set; }
        public bool Correta { get; set; }
    }
}
