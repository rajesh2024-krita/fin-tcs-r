
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models;

public class MonthlyDemandHeader
{
    public int Id { get; set; }
    
    [Required]
    public int Month { get; set; } // 1-12
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public int SocietyId { get; set; }
    public virtual Society Society { get; set; }
    
    public int MemberCount { get; set; }
    public decimal TotalAmount { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    // Navigation properties
    public virtual ICollection<MonthlyDemandRow> DemandRows { get; set; } = new List<MonthlyDemandRow>();
}

public class MonthlyDemandRow
{
    public int Id { get; set; }
    
    [Required]
    public int MonthlyDemandHeaderId { get; set; }
    public virtual MonthlyDemandHeader Header { get; set; }
    
    [Required]
    [StringLength(50)]
    public string EDPNo { get; set; }
    
    [Required]
    [StringLength(200)]
    public string MemberName { get; set; }
    
    public decimal LoanAmount { get; set; }
    public decimal CD { get; set; }
    public decimal Loan { get; set; }
    public decimal Interest { get; set; }
    public decimal ELoan { get; set; }
    public decimal ELoanInterest { get; set; }
    public decimal Net { get; set; }
    public decimal IntDue { get; set; }
    public decimal PInt { get; set; }
    public decimal PDed { get; set; }
    public decimal LAS { get; set; }
    public decimal LASInt { get; set; }
    public decimal LASIntDue { get; set; }
}
