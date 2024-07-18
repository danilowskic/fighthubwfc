using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBackend.Models;

public class MartialArt
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [StringLength(256)]
    public string Description { get; set; }
    
    [StringLength(50)]
    public string CountryOfOrigin { get; set; }
    
    public ICollection<TrainingBootcamp> TrainingBootcamps { get; set; }
    
    public ICollection<SkillLevelOfMartialArt> SkillLevels { get; set; }
}