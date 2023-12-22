using Database.Context;
using Database.Context.AppContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArcoIris.Controllers
{
    [Route("api/Questoes")]
    [ApiController]
    public class QuestaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Questao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questao>>> GetQuestoes()
        {
            return await _context.Questoes.ToListAsync();
        }

        // GET: api/Questao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Questao>> GetQuestao(int id)
        {
            var questao = await _context.Questoes.FindAsync(id);

            if (questao == null)
            {
                return NotFound();
            }

            return questao;
        }

        // POST: api/Questao
        [HttpPost]
        public async Task<ActionResult<Questao>> PostQuestao([FromBody] Questao questao)
        {
            _context.Questoes.Add(questao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestao), new { id = questao.Id }, questao);
        }

        // PUT: api/Questao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestao(int id, [FromBody] Questao questao)
        {
            if (id != questao.Id)
            {
                return BadRequest();
            }

            _context.Entry(questao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Questao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestao(int id)
        {
            var questao = await _context.Questoes.FindAsync(id);
            if (questao == null)
            {
                return NotFound();
            }

            _context.Questoes.Remove(questao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestaoExists(int id)
        {
            return _context.Questoes.Any(e => e.Id == id);
        }
    }
}
