using System.ComponentModel.DataAnnotations;

namespace WebAppBackend.DTOs;

public class MedicalCertificateDTO
{
    [Range(57.17, double.MaxValue, ErrorMessage = "Weight can't be  <57.17 kg")]
    public double Weight { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Height can't be <1 cm")]
    public double Height { get; set; }

    [StringLength(1024)]
    public string Description { get; set; } = "";

    public bool IsAccepted { get; set; }
    
    public int FighterId { get; set; }
    
    public int FighterInvolvementId { get; set; }
    
    public int EventId { get; set; }

}