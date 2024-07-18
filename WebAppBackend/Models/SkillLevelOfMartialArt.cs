using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Enums;

namespace WebAppBackend.Models;

public class SkillLevelOfMartialArt
{
    [Required]
    public int FighterId { get; set; }
    
    [ForeignKey("FighterId")]
    public Fighter Fighter { get; set; }

    [Required]
    public int MartialArtId { get; set; }
    
    [ForeignKey("MartialArtId")]
    public MartialArt MartialArt { get; set; }

    [Required]
    [Column(TypeName = "varchar(11)")]
    [EnumDataType(typeof(Belt))]
    public Belt Belt { get; set; }
}