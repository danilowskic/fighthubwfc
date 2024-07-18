using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppBackend.Enums;

namespace WebAppBackend.Models;

public class WorkerFanWorkerFanType
{
    [Required]
    public int WorkerFanId { get; set; }
    
    [ForeignKey("WorkerFanId")]
    public WorkerFan WorkerFan { get; set; }

    [Required]
    [Column(TypeName = "varchar(5)")]
    [EnumDataType(typeof(WorkerFanType))]
    public WorkerFanType WorkerFanType { get; set; }
}