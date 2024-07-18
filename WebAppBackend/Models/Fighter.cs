using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Enums;
using WebAppBackend.Validators;

namespace WebAppBackend.Models;

[MasterOrStudentValidation]
public class Fighter : User
{
    [Required]
    [Column(TypeName = "varchar(6)")]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required]
    [Range(52.17, double.MaxValue, ErrorMessage = "Weight cannot be less than 52.17.")]
    public double Weight { get; set; }

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Height cannot be less than 1.")]
    public double Height { get; set; }
    
    [Required]
    [MinAge]
    public override DateOnly BirthDate { get; set; }
    
    public ICollection<MedicalCertificate> MedicalCertificates { get; set; }
    
    public ICollection<SkillLevelOfMartialArt> SkillLevels { get; set; }
    
    public ICollection<TrainingBootcamp> TrainingBootcampsAsMaster { get; set; }
    
    public ICollection<TrainingBootcamp> TrainingBootcampsAsStudent { get; set; }
    
    public ICollection<FighterInvolvement> FighterInvolvements { get; set; }
    
    [NotMapped]
    public WeightScale WeightScale
    {
        get
        {
            var scale = WeightScale.FLYWEIGHT;
            switch (Weight)
            {
                case double w when (w > 52.16 && w <= 57.15):
                    scale = WeightScale.BANTAMWEIGHT;
                    break;
                case double w when (w > 57.15 && w <= 61.23):
                    scale = WeightScale.FEATHERWEIGHT;
                    break;
                case double w when (w > 61.23 && w <= 70.31):
                    scale = WeightScale.LIGHTWEIGHT;
                    break;
                case double w when (w > 70.31 && w <= 81.65):
                    scale = WeightScale.WELTERWEIGHT;
                    break;
                case double w when (w > 81.65 && w <= 97.52):
                    scale = WeightScale.MIDDLEWEIGHT;
                    break;
                case double w when (w > 97.52 && w <= 117.93):
                    scale = WeightScale.LIGHT_HEAVYWEIGHT;
                    break;
                case double w when (w > 117.93 && w <= 130.52):
                    scale = WeightScale.HEAVYWEIGHT;
                    break;
                default:
                    scale = WeightScale.SUPER_HEAVYWEIGHT;
                    break;
            }
    
            return scale;
        }
    }

    public static int MinimalRequiredAge => 20;
}