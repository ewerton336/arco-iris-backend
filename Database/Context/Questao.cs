namespace Database.Context
{
    public class Questao
    {
        public int Id { get; set; }
        public string? Enunciado { get; set; }
        public List<Alternativa>? Alternativas { get; set; }
    }
}
