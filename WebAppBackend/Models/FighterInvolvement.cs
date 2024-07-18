using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Enums;
using WebAppBackend.Validators;

namespace WebAppBackend.Models;

public class FighterInvolvement
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string NumberID { get; set; }
    
    [Required]
    [DateNotInFuture(ErrorMessage = "Date of registration cannot be from the future.")]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    [Range(0, int.MaxValue)]
    public int? Points { get; set; }

    [Range(0, int.MaxValue)]
    public int? EarnedPlace { get; set; }

    [Required]
    [Column(TypeName = "varchar(8)")]
    [EnumDataType(typeof(StatusType))]
    public StatusType Status { get; set; }

    [Required]
    public int FighterId { get; set; }
    
    [ForeignKey("FighterId")]
    public Fighter Fighter { get; set; }

    [Required]
    public int EventId { get; set; }
    
    [ForeignKey("EventId")]
    public Event Event { get; set; }
    
}