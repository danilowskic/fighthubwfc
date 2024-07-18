using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Validators;

namespace WebAppBackend.Models;

public class Lesson
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public AddressData Localization { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [DateWithinTrainingBootcamp]
    public DateTime DateTime { get; set; }

    [Required]
    [MaxLength(256)]
    public string LessonSubject { get; set; }

    [Required]
    [Range(1, 24)]
    public int DurationInHours { get; set; }

    [Required]
    [Editable(false)] // cannot be changed in views
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int TrainingBootcampId { get; set; }

    [ForeignKey("TrainingBootcampId")]
    public TrainingBootcamp TrainingBootcamp { get; set; }
}