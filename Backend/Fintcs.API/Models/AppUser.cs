
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models;

public class AppUser
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string EDPNo { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Name { get; set; }
    
    [StringLength(500)]
    public string AddressOffice { get; set; }
    
    [StringLength(500)]
    public string AddressResidence { get; set; }
    
    [StringLength(100)]
    public string Designation { get; set; }
    
    [StringLength(20)]
    public string PhoneOffice { get; set; }
    
    [StringLength(20)]
    public string PhoneResidence { get; set; }
    
    [StringLength(20)]
    public string Mobile { get; set; }
    
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Username { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    
    [Required]
    public string Role { get; set; } // SuperAdmin, SocietyAdmin, User, Member
    
    public int? SocietyId { get; set; }
    public virtual Society Society { get; set; }
    
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
