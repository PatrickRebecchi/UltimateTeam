using System.Text.Json.Serialization;

namespace UltimanteTeam.Models;

public class Jogador    
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Posicao { get; set; }
    public string Nacionalidade { get; set; }
    public string Imagem { get; set; }


    public int TimeId { get; set; }

    [JsonIgnore]
    public Times Time { get; set; }
}

