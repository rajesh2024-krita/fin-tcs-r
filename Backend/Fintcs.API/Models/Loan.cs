
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models;

public class Loan
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string LoanNo { get; set; }
    
    public DateTime LoanDate { get; set; } = DateTime.Today;
    
    [Required]
    public int LoanTypeId { get; set; }
    public virtual LoanType LoanType { get; set; }
    
    [Required]
    public int MemberId { get; set; }
    public virtual Member Member { get; set; }
    
    [Required]
    [StringLength(50)]
    public string EDPNo { get; set; }
    
    [Required]
    [StringLength(200)]
    public string MemberName { get; set; }
    
    public decimal LoanAmount { get; set; }
    public decimal PreviousLoan { get; set; }
    public decimal NetLoan { get; set; } // Auto: LoanAmount - PreviousLoan
    
    public int Installments { get; set; }
    public decimal InstallmentAmount { get; set; }
    
    [StringLength(1000)]
    public string Purpose { get; set; }
    
    [StringLength(200)]
    public string AuthorizedBy { get; set; }
    
    [Required]
    [StringLength(20)]
    public string PaymentMode { get; set; } // Cash, Cheque, Opening
    
    public int? BankId { get; set; }
    public virtual Bank Bank { get; set; }
    
    [StringLength(50)]
    public string ChequeNo { get; set; }
    
    public DateTime? ChequeDate { get; set; }
    
    public decimal Share { get; set; }
    public decimal CD { get; set; }
    public decimal LastSalary { get; set; }
    public decimal MWF { get; set; }
    public decimal PayAmount { get; set; }
    
    // Given/Taken tables (stored as JSON)
    public string GivenMembers { get; set; }
    public string TakenMembers { get; set; }
    
    public bool IsValidated { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

public class LoanType
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [StringLength(10)]
    public string Code { get; set; }
    
    public bool IsActive { get; set; } = true;
}

public class Bank
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [StringLength(10)]
    public string Code { get; set; }
    
    public bool IsActive { get; set; } = true;
}
