using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using WebAppBackend.Enums;

namespace WebAppBackend.Models;

public class Event
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateTime { get; set; }

    [Required]
    public AddressData Localization { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly RegistrationEndDate { get; set; }

    [Required]
    [Range(1, double.MaxValue)]
    public double MoneyPrize { get; set; }

    [StringLength(512)]
    public string ReasonOfCancel { get; set; }

    private int? _availablePlaces;
    
    [Range(1, int.MaxValue)]
    public int? AvailablePlaces
    {
        get
        {
            if (this.AudienceType != AudienceType.PUBLIC)
            {
                throw new ConstraintException("This event is not public");
            }

            return _availablePlaces;
        }
        set
        {
            if (this.AudienceType != AudienceType.PUBLIC)
            {
                throw new ConstraintException("This event is not public");
            }
            
            _availablePlaces = value;
        }
    }

    private double? _ticketPrice;

    [Range(0, double.MaxValue)]
    public double? TicketPrice
    {
        get
        {
            if (this.AudienceType != AudienceType.PRIVATE)
            {
                throw new ConstraintException("This event is not private");
            }

            return _ticketPrice;
        }
        set
        {
            if (this.AudienceType != AudienceType.PRIVATE)
            {
                throw new ConstraintException("This event is not private");
            }
            
            _ticketPrice = value;
        }
    }

    [Required]
    [Column(TypeName = "varchar(7)")]
    [EnumDataType(typeof(AudienceType))]
    public AudienceType AudienceType { get; set; }
    
    public ICollection<FighterInvolvement> FighterInvolvements { get; set; }
    public ICollection<FanInvolvement> FanInvolvements { get; set; }

    public virtual double GetPrize()
    {
        return MoneyPrize;
    }

    public static Event CreatePublicEvent(int id, string name, DateTime dateTime, AddressData addressData,
        DateOnly registrationEndDate, double moneyPrize, string reasonOfCancel, int availablePlaces)
    {
        var eEvent = new Event();
        
        eEvent.Id = id;
        eEvent.Name = name;
        eEvent.DateTime = dateTime;
        eEvent.Localization = addressData;
        eEvent.RegistrationEndDate = registrationEndDate;
        eEvent.MoneyPrize = moneyPrize;
        eEvent.ReasonOfCancel = reasonOfCancel;
        eEvent.AvailablePlaces = availablePlaces;
        eEvent.AudienceType = AudienceType.PUBLIC;
        
        return eEvent;
    }
    
    public static Event CreatePrivateEvent(int id, string name, DateTime dateTime, AddressData addressData,
        DateOnly registrationEndDate, double moneyPrize, string reasonOfCancel, int availablePlaces)
    {
        var eEvent = new Event();
        
        eEvent.Id = id;
        eEvent.Name = name;
        eEvent.DateTime = dateTime;
        eEvent.Localization = addressData;
        eEvent.RegistrationEndDate = registrationEndDate;
        eEvent.MoneyPrize = moneyPrize;
        eEvent.ReasonOfCancel = reasonOfCancel;
        eEvent.AvailablePlaces = availablePlaces;
        eEvent.AudienceType = AudienceType.PRIVATE;
        
        return eEvent;
    }
    
    [Required]
    public int OrganizerId { get; set; }
    
    [ForeignKey("OrganizerId")]
    public WorkerFan WorkerFan { get; set; }
}