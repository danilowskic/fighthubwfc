using System.ComponentModel.DataAnnotations;

namespace WebAppBackend.Models;

public class AddressData
{
    [Required]
    [MaxLength(50)]
    public string Street { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Building number can't be <1.")]
    public int BuildingNumber { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Apartment number can't be <1.")]
    public int? ApartmentNumber { get; set; }

    [Required]
    [MaxLength(50)]
    public string City { get; set; }

    [Required]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "Zip code must be 6 characters long.")]
    [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Zip code must be in format XX-XXX, where X is a digit.")]
    public string ZipCode { get; set; }
}