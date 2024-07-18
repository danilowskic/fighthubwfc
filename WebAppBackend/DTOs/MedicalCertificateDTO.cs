using System.ComponentModel.DataAnnotations;

namespace WebAppBackend.DTOs;

public class MedicalCertificateDTO
{
    public double Weight { get; set; }

    public double Height { get; set; }

    public string Description { get; set; } = "";

    public bool IsAccepted { get; set; }

    public int FighterId { get; set; }
    
    public int FighterInvolvementId { get; set; }
    
    public int EventId { get; set; }
}