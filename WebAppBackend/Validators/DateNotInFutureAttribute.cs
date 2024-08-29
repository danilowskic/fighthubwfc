using System.ComponentModel.DataAnnotations;

namespace WebAppBackend.Validators;

public class DateNotInFutureAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateOnly date)
        {
            return date <= DateOnly.FromDateTime(DateTime.Now);
        }
        
        return false;
    }
}