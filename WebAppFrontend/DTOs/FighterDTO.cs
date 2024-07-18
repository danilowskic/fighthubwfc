namespace WebAppBackend.DTOs;

public class FighterDTO
{
    public int Id { get; set; }
    public ICollection<string> Names { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public int Age { get; set; }
    public string WeightScale { get; set; }
}