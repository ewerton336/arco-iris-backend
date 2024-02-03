using Database.Context;
using Database.Context.AppContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArcoIris.Controllers.Prova
{
    [Route("api/Provas")]
    [ApiController]
    public class ProvaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProvaController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Provas/IniciarProva
        [HttpPost("IniciarProva")]
        public async Task<ActionResult<Database.Context.Prova>> IniciarProva([FromBody] int alunoId)
        {
            try
            {
                var aluno = await _context.Alunos.FindAsync(alunoId);
                if (aluno == null)
                {
                    return NotFound("Aluno não encontrado.");
                }

                var questoes = await _context.Questoes.Include(q => q.Alternativas).ToListAsync();

                var prova = new Database.Context.Prova
                {
                    AlunoId = alunoId,
                    QuestoesRespostas = questoes.Select(q => new QuestaoResposta { QuestaoId = q.Id }).ToList()
                };

                _context.Provas.Add(prova);
                await _context.SaveChangesAsync();

                // Retorna as questões da prova sem as respostas corretas
                var provaParaAluno = new Database.Context.Prova
                {
                    Id = prova.Id,
                };

                return Ok(provaParaAluno);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("GetProva/{id}")]
        public async Task<ActionResult<Database.Context.Prova>> GetProva(int id)
        {
            try
            {
                var prova = await _context.Provas
             .Include(p => p.QuestoesRespostas)
                 .ThenInclude(qr => qr.Questao)
                     .ThenInclude(q => q.Alternativas)
             .FirstOrDefaultAsync(p => p.Id == id);

                if (prova == null)
                {
                    return NotFound($"Prova com ID {id} não encontrada.");
                }

                return Ok(prova);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        // POST: api/Provas/SubmeterProva
        [HttpPost("SubmeterProva")]
        public async Task<ActionResult> SubmeterProva([FromBody] Database.Context.Prova provaSubmetida)
        {
            var prova = await _context.Provas.Include(p => p.QuestoesRespostas)
                                              .ThenInclude(qr => qr.Questao)
                                              .ThenInclude(q => q.Alternativas)
                                              .FirstOrDefaultAsync(p => p.Id == provaSubmetida.Id);

            if (prova == null)
            {
                return NotFound("Prova não encontrada.");
            }

            int acertos = 0;
            foreach (var resposta in provaSubmetida.QuestoesRespostas)
            {
                var questaoCorreta = prova.QuestoesRespostas.FirstOrDefault(qr => qr.QuestaoId == resposta.QuestaoId)?.Questao.Alternativas.FirstOrDefault(a => a.Id == resposta.AlternativaEscolhidaId);
                if (questaoCorreta != null && questaoCorreta.Correta)
                {
                    acertos++;
                }
            }

            prova.QuantidadeAcertos = acertos;
            prova.QuantidadeErros = prova.QuestoesRespostas.Count - acertos;
            prova.Nota = (decimal)acertos / prova.QuestoesRespostas.Count * 10;

            await _context.SaveChangesAsync();

            return Ok(new { Nota = prova.Nota, QuantidadeAcertos = prova.QuantidadeAcertos, QuantidadeErros = prova.QuantidadeErros });
        }
    }
}