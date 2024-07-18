using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Validators;

namespace WebAppBackend.Models;

public class FanInvolvement
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string TicketId { get; set; }
    
    [Required]
    [DateNotInFuture(ErrorMessage = "Date of buy cannot be from the future.")]
    public DateTime TicketBuyDate { get; set; } = DateTime.Now;
    
    [Required]
    public int FanId { get; set; }
    
    [ForeignKey("FanId")]
    public WorkerFan WorkerFan { get; set; }

    [Required]
    public int EventId { get; set; }
    
    [ForeignKey("EventId")]
    public Event Event { get; set; }
}