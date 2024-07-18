using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBackend.Models;

public class MedicalCertificate
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string NumberId { get; set; }
    
    [Required]
    public bool IsAccepted { get; set; }

    [StringLength(1024)]
    public string Description { get; set; }

    [Required]
    public DateTime DateTime { get; set; }
    
    [Required]
    public int FighterInvolvementId { get; set; }

    [ForeignKey("FighterInvolvementId")]
    public FighterInvolvement FighterInvolvement { get; set; }
    
    [Required]
    public int WorkerFanId { get; set; }

    [ForeignKey("WorkerFanId")]
    public WorkerFan WorkerFan { get; set; }
    
    [Required]
    public int FighterId { get; set; }

    [ForeignKey("FighterId")]
    public Fighter Fighter { get; set; }
}