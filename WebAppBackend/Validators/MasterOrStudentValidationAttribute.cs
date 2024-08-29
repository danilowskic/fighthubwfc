using System.ComponentModel.DataAnnotations;
using WebAppBackend.Models;

namespace WebAppBackend.Validators;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class MasterOrStudentValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var fighter = (Fighter)validationContext.ObjectInstance;
        var masterIds = fighter.TrainingBootcampsAsMaster.Select(b => b.Id).ToList();
        var studentIds = fighter.TrainingBootcampsAsStudent.Select(b => b.Id).ToList();

        var commonBootcamps = masterIds.Intersect(studentIds).Any();
        if (commonBootcamps)
        {
            return new ValidationResult("A fighter cannot be both a master and a student in the same bootcamp.");
        }

        return ValidationResult.Success;
    }
}