
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models;

public class SuperAdmin
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Username { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

public class PendingEdit
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string EntityType { get; set; } // Society, User, Member, etc.
    
    [Required]
    public int EntityId { get; set; }
    
    [Required]
    public string ChangeData { get; set; } // JSON of changes
    
    [Required]
    [StringLength(50)]
    public string RequestedBy { get; set; }
    
    public DateTime RequestedDate { get; set; } = DateTime.Now;
    
    [StringLength(10)]
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
    
    [StringLength(50)]
    public string ApprovedBy { get; set; }
    
    public DateTime? ApprovedDate { get; set; }
    
    [StringLength(500)]
    public string Comments { get; set; }
}
