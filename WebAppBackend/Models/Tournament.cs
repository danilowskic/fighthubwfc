using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Enums;

namespace WebAppBackend.Models;

public class Tournament : Event
{
    [Required]
    [Column(TypeName = "varchar(11)")]
    [EnumDataType(typeof(Belt))]
    public Belt Belt { get; set; }

    public override double GetPrize()
    {
        double basePrize = MoneyPrize;
        
        double beltBonus = Belt switch
        {
            Belt.WHITE_BELT => 0.05 * basePrize,
            Belt.YELLOW_BELT => 0.1 * basePrize,
            Belt.ORANGE_BELT => 0.15 * basePrize,
            Belt.GREEN_BELT => 0.2 * basePrize,
            Belt.BLUE_BELT => 0.3 * basePrize,
            Belt.PURPLE_BELT => 0.35 * basePrize,
            Belt.BROWN_BELT => 0.4 * basePrize,
            Belt.BLACK_BELT => 0.45 * basePrize,
            _ => 0
        };

        double totalPrize = basePrize + beltBonus;

        if (!string.IsNullOrWhiteSpace(ReasonOfCancel))
        {
            totalPrize *= 1.3; // 30% bonus if the fighter didn't quit
        }

        return totalPrize;
    }
}