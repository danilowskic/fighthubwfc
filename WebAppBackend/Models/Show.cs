using System.ComponentModel.DataAnnotations;
using WebAppBackend.Enums;

namespace WebAppBackend.Models;

public class Show : Event
{
    [Required]
    [StringLength(100)]
    public string Certificate { get; set; }
    
    public override double GetPrize()
    {
        double basePrize = MoneyPrize;
        double certificateBonus = 0.1 * basePrize; // 10% bonus for certificate

        // Bonus based on audience type
        double audienceBonus = AudienceType switch
        {
            AudienceType.PUBLIC => 0.1 * basePrize,
            AudienceType.PRIVATE => 0.05 * basePrize,
            _ => 0
        };

        double totalPrize = basePrize + certificateBonus + audienceBonus;

        if (!string.IsNullOrWhiteSpace(ReasonOfCancel))
        {
            totalPrize *= 1.2; // 20% bonus if the fighter didn't quit
        }

        return totalPrize;
    }
}