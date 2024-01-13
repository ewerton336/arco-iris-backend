using Database.Context;
using System.Text.Json.Serialization;

namespace ArcoIris.Context.AppContext
{
    namespace Database.Context
    {
        public class Prova
        {
            public int Id { get; set; }
            public int AlunoId { get; set; }
            public Aluno? Aluno { get; set; }

            [JsonIgnore]
            public List<Questao>? Questoes { get; set; }

            public int QuantidadeAcertos { get; set; }
        }
    }

}
