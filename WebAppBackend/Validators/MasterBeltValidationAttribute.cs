using System.ComponentModel.DataAnnotations;
using WebAppBackend.Configurations;
using WebAppBackend.Models;

namespace WebAppBackend.Validators;

[AttributeUsage(AttributeTargets.Property)]
public class MasterBeltValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dbContext = (FightHubDbContext)validationContext.GetService(typeof(FightHubDbContext));
        var bootcamp = (TrainingBootcamp)validationContext.ObjectInstance;

        var maxBelt = dbContext.SkillLevelOfMartialArts
            .Where(sl => sl.FighterId == bootcamp.MasterId && sl.MartialArt.Name == bootcamp.MartialArtName)
            .Max(sl => sl.Belt);

        if (bootcamp.Belt > maxBelt)
        {
            return new ValidationResult($"Belt '{bootcamp.Belt}' exceeds the maximum belt '{maxBelt}' for the master.");
        }

        return ValidationResult.Success;
    }
}