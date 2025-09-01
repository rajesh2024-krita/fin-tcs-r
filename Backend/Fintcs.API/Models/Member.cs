
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models;

public class Member
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(20)]
    public string MemberNo { get; set; } // Auto-generated MEM_001, MEM_002
    
    [Required]
    [StringLength(200)]
    public string Name { get; set; }
    
    [StringLength(200)]
    public string FatherHusbandName { get; set; }
    
    [StringLength(500)]
    public string AddressOffice { get; set; }
    
    [StringLength(500)]
    public string AddressResidence { get; set; }
    
    [StringLength(100)]
    public string City { get; set; }
    
    [StringLength(20)]
    public string PhoneOffice { get; set; }
    
    [StringLength(20)]
    public string PhoneResidence { get; set; }
    
    [StringLength(20)]
    public string Mobile { get; set; }
    
    [StringLength(100)]
    public string Designation { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfJoiningSociety { get; set; }
    public DateTime? DateOfJoiningOrg { get; set; }
    public DateTime? DateOfRetirement { get; set; }
    
    [StringLength(200)]
    public string Nominee { get; set; }
    
    [StringLength(100)]
    public string NomineeRelation { get; set; }
    
    public decimal OpeningBalance { get; set; }
    public decimal ShareValue { get; set; }
    
    [StringLength(10)]
    public string BalanceType { get; set; } // Cr, Dr, CD
    
    // Bank Details
    [StringLength(100)]
    public string BankName { get; set; }
    
    [StringLength(100)]
    public string PayableAt { get; set; }
    
    [StringLength(50)]
    public string AccountNo { get; set; }
    
    [StringLength(10)]
    public string Status { get; set; } = "Active"; // Active, Deactive
    
    // Multi-select deductions (stored as comma-separated)
    public string Deductions { get; set; }
    
    // File uploads
    public string PhotoPath { get; set; }
    public string SignaturePath { get; set; }
    
    [Required]
    public int SocietyId { get; set; }
    public virtual Society Society { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    // Navigation properties
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
