
using System.ComponentModel.DataAnnotations;

namespace Fintcs.API.Models;

public class Voucher
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string VoucherNo { get; set; }
    
    public DateTime VoucherDate { get; set; } = DateTime.Today;
    
    [Required]
    public int VoucherTypeId { get; set; }
    public virtual VoucherType VoucherType { get; set; }
    
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
    
    public bool IsBalanced => TotalDebit == TotalCredit;
    
    public string Narration { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    // Navigation properties
    public virtual ICollection<VoucherLine> VoucherLines { get; set; } = new List<VoucherLine>();
}

public class VoucherLine
{
    public int Id { get; set; }
    
    [Required]
    public int VoucherId { get; set; }
    public virtual Voucher Voucher { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Particulars { get; set; }
    
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    
    [StringLength(10)]
    public string Type { get; set; } // Db, Cr
    
    [StringLength(200)]
    public string Ibldbc { get; set; }
}

public class VoucherType
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [StringLength(10)]
    public string Code { get; set; }
    
    public bool IsActive { get; set; } = true;
}
