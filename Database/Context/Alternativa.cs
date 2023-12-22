namespace Database.Context
{
    public class Alternativa
    {
        public int Id { get; set; }
        public int QuestoId { get; set; }
        public Questao? Questao { get; set; }
        public string? Descricao { get; set; }
        public bool Correta { get; set; }

    }
}
