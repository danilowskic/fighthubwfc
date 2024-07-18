using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBackend.Models;

public class PhoneNumber
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone number must be 9 characters long.")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Phone number must be 9 digits.")]
    public string phoneNumber { get; set; }

    public ICollection<ContactData> ContactDatas { get; set; }
}