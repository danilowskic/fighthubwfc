using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBackend.Models;

public abstract class User
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public ICollection<Name> Names { get; set; }

    [Required]
    [RegularExpression("^[A-Z][a-z]{1,49}$", ErrorMessage = "Surname must start with an uppercase letter, followed by lowercase letters, max 50 characters long.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "String must be minimum 2 and can be max 50 characters long.")]
    public string Surname { get; set; }

    [Required]
    [Editable(false)] // cannot be changed in views
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "PESEL must be 11 characters long.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must be 11 digits.")]
    public string PESEL { get; set; }

    [Required]
    public virtual DateOnly BirthDate { get; set; }
    
    [Required]
    public AddressData AddressData { get; set; }
    
    [Required]
    public ContactData ContactData { get; set; }
    
    [Required] 
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Login must be at least 5 characters long and max 20 characters long.")]
    [RegularExpression("^[A-Za-z0-9]{2,20}$", ErrorMessage = "Login can contains uppercase and lowercase letters and digits")]
    public string Login { get; set; }
    
    [Required] 
    [StringLength(512, MinimumLength = 1, ErrorMessage = "Encrypted password max length is 512 characters logn, and must be at least 1 characters long")]
    public string EncryptedPassword { get; set; }
    
    [NotMapped]
    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var age = today.Year - BirthDate.Year;

            if (BirthDate > today.AddYears(-age))
            {
                age--;
            }
            
            return age;
        }
    }
}