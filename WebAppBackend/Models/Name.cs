using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBackend.Models;

public class Name
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be from 2 to 20 charachters long")]
    [RegularExpression("^[A-Z][a-z]{1,19}$", ErrorMessage = "Name must start with one uppercase letter and the rest must be lowercase letters")]
    public string name { get; set; }

    public ICollection<User> Users { get; set; }
}