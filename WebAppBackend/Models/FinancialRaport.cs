using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBackend.Models;

public class FinancialRaport
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string NumberId { get; set; }
    
    [Required]
    [Column(TypeName = "Date")]
    public DateTime StartDate { get; set; }
    
    [Required]
    [Column(TypeName = "Date")]
    public DateTime EndDate { get; set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Income must be a non-negative number.")]
    public double Income { get; set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Expenditure must be a non-negative number.")]
    public double Expenditure { get; set; }
    
    [NotMapped]
    public double Profit => Income - Expenditure;
}