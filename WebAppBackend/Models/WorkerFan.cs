using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Validators;

namespace WebAppBackend.Models;

public class WorkerFan : User
{
    [Required]
    [DateNotInFuture(ErrorMessage = "Date of hirement cannot be from the future.")]
    public DateOnly DateOfHirement { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Income cannot be negative.")]
    public double Income { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Budget cannot be negative.")]
    public double Budget { get; set; }

    [StringLength(50)]
    public string DoctorLicenceID { get; set; }

    [Required]
    [StringLength(50)]
    public string FavouriteMartialArtName { get; set; }
    
    public ICollection<WorkerFanWorkerFanType> WorkerFanTypes { get; set; }
    
    public ICollection<MedicalCertificate> MedicalCertificates { get; set; }
    
    public ICollection<FanInvolvement> FanInvolvements { get; set; }
    
    public ICollection<Event> OrganizedEvents { get; set; }
    
    public ICollection<TrainingBootcamp> OrganizedTrainingBootcamps { get; set; }
}