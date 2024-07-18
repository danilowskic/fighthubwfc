using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Enums;
using WebAppBackend.Validators;

namespace WebAppBackend.Models;

public class TrainingBootcamp
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [DateRange(nameof(EndDate))]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(11)")]
    [EnumDataType(typeof(Belt))]
    [MasterBeltValidation]
    public Belt Belt { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
    
    [Required]
    [StringLength(50)]
    public string MartialArtName { get; set; }
    
    public MartialArt MartialArt { get; set; }
    
    [Required]
    public int MasterId { get; set; }
    
    [ForeignKey("MasterId")]
    public Fighter Master { get; set; }
    
    public ICollection<Fighter> Students { get; set; }
    
    [Required]
    public int OrganizerId { get; set; }
    
    [ForeignKey("OrganizerId")]
    public WorkerFan WorkerFan { get; set; }
    
    public IEnumerable<Lesson> GetSortedLessons()
    {
        var copy = new List<Lesson>(Lessons);
        return copy.OrderBy(l => l.DateTime);
    }
}