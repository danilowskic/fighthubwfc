using System.ComponentModel.DataAnnotations;
using WebAppBackend.Models;

namespace WebAppBackend.Validators;

public class MinAgeAttribute : ValidationAttribute
{
    private readonly int _minAge;

    public MinAgeAttribute()
    {
        _minAge = Fighter.MinimalRequiredAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var user = (User)validationContext.ObjectInstance;
        
        if (user.Age < _minAge)
        {
            return new ValidationResult($"Fighter must be at least {_minAge} years old.");
        }

        return ValidationResult.Success;
    }
}