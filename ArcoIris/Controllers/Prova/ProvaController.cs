using ArcoIris.Context.AppContext.Database.Context;
using Database.Context;
using Database.Context.AppContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoIris.Controllers
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

        // GET: api/Prova
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prova>>> GetProvas()
        {
            return await _context.Provas
                                 .Include(p => p.Questoes)
                                 .ToListAsync();
        }

        // GET: api/Prova/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prova>> GetProva(int id)
        {
            var prova = await _context.Provas
                                      .Include(p => p.Questoes)
                                      .FirstOrDefaultAsync(p => p.Id == id);

            if (prova == null)
            {
                return NotFound();
            }

            return prova;
        }

        // POST: api/Prova
        [HttpPost]
        public async Task<ActionResult<Prova>> PostProva([FromBody] Prova prova)
        {
            // Calcula a quantidade de acertos
            prova.QuantidadeAcertos = CalcularAcertos(prova);

            _context.Provas.Add(prova);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProva), new { id = prova.Id }, prova);
        }

        // PUT: api/Prova/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProva(int id, [FromBody] Prova prova)
        {
            if (id != prova.Id)
            {
                return BadRequest();
            }

            prova.QuantidadeAcertos = CalcularAcertos(prova);

            _context.Entry(prova).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvaExists(id))
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

        // DELETE: api/Prova/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProva(int id)
        {
            var prova = await _context.Provas.FindAsync(id);
            if (prova == null)
            {
                return NotFound();
            }

            _context.Provas.Remove(prova);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvaExists(int id)
        {
            return _context.Provas.Any(e => e.Id == id);
        }

        private int CalcularAcertos(Prova prova)
        {
            int acertos = 0;

            foreach (var questao in prova.Questoes)
            {
                var alternativas = questao.Alternativas;
                 

                var alternativasBase = _context.Alternativas
                                               .Where(a => a.QuestaoId == questao.Id)
                                               .ToList();

                if (alternativasBase.Count(x=>x.Correta) == alternativas.Count(x=>x.Correta)
                    && alternativasBase.Count(x=>!x.Correta) == alternativas.Count(x=>!x.Correta))
                {
                    acertos++;
                }
            }

            return acertos;
        }

    }
}
