using System.ComponentModel.DataAnnotations;

namespace WebAppBackend.Validators;


/// <summary>
///     Custom validation attribute to ensure that the <c>StartDate</c> is earlier than the <c>EndDate</c>.
/// </summary>
/// <remarks>
///     This attribute is used to validate date ranges. It checks if the specified
///     start date is earlier than the end date, as defined by the property name provided during initialization.
/// </remarks>
public class DateRangeAttribute : ValidationAttribute
{
    private readonly string _endDatePropertyName;

    public DateRangeAttribute(string endDatePropertyName)
    {
        _endDatePropertyName = endDatePropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var startDate = (DateTime)value;
        var endDateProperty = validationContext.ObjectType.GetProperty(_endDatePropertyName);

        if (endDateProperty == null)
        {
            return new ValidationResult($"Unknown property {_endDatePropertyName}");
        }

        var endDate = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance);

        if (startDate >= endDate)
        {
            return new ValidationResult("Start date must be earlier than end date.");
        }

        return ValidationResult.Success;
    }
}