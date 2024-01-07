using System.Text.Json.Serialization;

namespace Database.Context
{
    public class Alternativa
    {
        public int Id { get; set; }
        public int QuestoId { get; set; }

        [JsonIgnore]
        public Questao? Questao { get; set; }
        public string? Descricao { get; set; }
        public bool Correta { get; set; }

    }
}
