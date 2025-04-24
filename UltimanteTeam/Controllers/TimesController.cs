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
}
