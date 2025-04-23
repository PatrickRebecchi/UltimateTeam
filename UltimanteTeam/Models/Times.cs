namespace UltimanteTeam.Models;

public class Times
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Escudo { get; set; }
    public string Pais { get; set; }

    public List<Jogador> Jogador { get; set; }  
}
