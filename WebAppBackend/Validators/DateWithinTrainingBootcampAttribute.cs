using System.ComponentModel.DataAnnotations;
using WebAppBackend.Configurations;
using WebAppBackend.Models;

namespace WebAppBackend.Validators;

/// <summary>
///     Validates that the DateTime of a Lesson is within the StartDate and EndDate of its associated TrainingBootcamp.
/// </summary>
public class DateWithinTrainingBootcampAttribute : ValidationAttribute
{
    public DateWithinTrainingBootcampAttribute()
    {
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("DateTime is required.");
        }

        var lesson = (Lesson)validationContext.ObjectInstance;
        var context = (FightHubDbContext)validationContext.GetService(typeof(FightHubDbContext));
        var trainingBootcamp = context.TrainingBootcamps.Find(lesson.TrainingBootcampId);

        if (trainingBootcamp == null)
        {
            return new ValidationResult("TrainingBootcamp not found.");
        }

        var lessonDateTime = (DateTime)value;

        if (lessonDateTime < trainingBootcamp.StartDate || lessonDateTime >= trainingBootcamp.EndDate)
        {
            return new ValidationResult($"DateTime must be within the TrainingBootcamp period from {trainingBootcamp.StartDate} to {trainingBootcamp.EndDate}.");
        }

        return ValidationResult.Success;
    }
}