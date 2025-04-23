using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltimanteTeam.Data;
using UltimanteTeam.Models;

namespace UltimanteTeam.Controllers;

[ApiController]
[Route("[controller]")]
public class JogadoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public JogadoresController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Jogador>>> GetJogadores()
    {
        return await _context.Jogadores.ToListAsync();
    }

    // GET: api/jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Jogador>> GetJogador(int id)
    {
        var jogador = await _context.Jogadores.FindAsync(id);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/jogadores
    [HttpPost]
    public async Task<ActionResult<Jogador>> PostJogador(Jogador jogador)
    {
        _context.Jogadores.Add(jogador);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetJogador), new { id = jogador.Id }, jogador);
    }

    // PUT: api/jogadores/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJogador(int id, Jogador jogador)
    {
        if (id != jogador.Id)
        {
            return BadRequest();
        }

        _context.Entry(jogador).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JogadorExists(id))
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

    // DELETE: api/jogadores/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJogador(int id)
    {
        var jogador = await _context.Jogadores.FindAsync(id);
        if (jogador == null)
        {
            return NotFound();
        }

        _context.Jogadores.Remove(jogador);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool JogadorExists(int id)
    {
        return _context.Jogadores.Any(e => e.Id == id);
    }
}

