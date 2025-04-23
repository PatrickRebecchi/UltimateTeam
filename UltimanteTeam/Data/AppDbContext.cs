using Microsoft.EntityFrameworkCore;

namespace UltimanteTeam.Data;

public class AppDbContext : DbContext
{

    public DbSet<Models.Times> Times { get; set; }
    public DbSet<Models.Jogador> Jogadores { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }
    
}
