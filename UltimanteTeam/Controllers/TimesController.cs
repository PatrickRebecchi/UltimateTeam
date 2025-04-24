using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltimanteTeam.Data;
using UltimanteTeam.Models;

namespace UltimanteTeam.Controllers;

[ApiController]
[Route("[controller]")]
public class TimesController : Controller
{
    private readonly AppDbContext _context;
    public TimesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Times
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Times>>> GetTimes()
    {   
        return await _context.Times.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Times>> GetTime(int id)
    {
        var time = await _context.Times
            .Include(t => t.Jogador)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (time == null)
        {
            return NotFound();
        }
        return time;
    }

    [HttpPost]
    public async Task<ActionResult<Times>> PostTime(Times time)
    {
        _context.Times.Add(time);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTime), new { id = time.Id }, time);
    }

}
