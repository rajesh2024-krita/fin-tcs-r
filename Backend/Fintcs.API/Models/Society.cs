
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models;

public class Society
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Name { get; set; }
    
    [StringLength(500)]
    public string Address { get; set; }
    
    [StringLength(100)]
    public string City { get; set; }
    
    [StringLength(20)]
    public string Phone { get; set; }
    
    [StringLength(20)]
    public string Fax { get; set; }
    
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }
    
    [StringLength(200)]
    public string Website { get; set; }
    
    [StringLength(50)]
    public string RegistrationNo { get; set; }
    
    // Interest Rates
    public decimal DividendRate { get; set; }
    public decimal ODRate { get; set; }
    public decimal CDRate { get; set; }
    public decimal LoanRate { get; set; }
    public decimal EmergencyLoanRate { get; set; }
    public decimal LASRate { get; set; }
    
    // Limits
    public decimal ShareLimit { get; set; }
    public decimal LoanLimit { get; set; }
    public decimal EmergencyLoanLimit { get; set; }
    
    // Ch Bounce Charge
    public decimal BounceChargeAmount { get; set; }
    public string BounceChargeMode { get; set; } // Excess Provision, Cash, HDFC Bank, Inverter
    
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    // Navigation properties
    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
