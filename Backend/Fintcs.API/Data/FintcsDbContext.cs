
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Models;

namespace Fintcs.API.Data;

public class FintcsDbContext : DbContext
{
    public FintcsDbContext(DbContextOptions<FintcsDbContext> options) : base(options)
    {
    }

    public DbSet<SuperAdmin> SuperAdmins { get; set; }
    public DbSet<Society> Societies { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<LoanType> LoanTypes { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<VoucherLine> VoucherLines { get; set; }
    public DbSet<VoucherType> VoucherTypes { get; set; }
    public DbSet<MonthlyDemandHeader> MonthlyDemandHeaders { get; set; }
    public DbSet<MonthlyDemandRow> MonthlyDemandRows { get; set; }
    public DbSet<PendingEdit> PendingEdits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure decimal precision
        modelBuilder.Entity<Society>()
            .Property(s => s.DividendRate)
            .HasPrecision(18, 4);

        modelBuilder.Entity<Loan>()
            .Property(l => l.LoanAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Member>()
            .Property(m => m.OpeningBalance)
            .HasPrecision(18, 2);

        // Configure relationships
        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Society)
            .WithMany(s => s.Users)
            .HasForeignKey(u => u.SocietyId);

        modelBuilder.Entity<Member>()
            .HasOne(m => m.Society)
            .WithMany(s => s.Members)
            .HasForeignKey(m => m.SocietyId);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Member)
            .WithMany(m => m.Loans)
            .HasForeignKey(l => l.MemberId);

        modelBuilder.Entity<VoucherLine>()
            .HasOne(vl => vl.Voucher)
            .WithMany(v => v.VoucherLines)
            .HasForeignKey(vl => vl.VoucherId);

        // Seed data
        modelBuilder.Entity<LoanType>().HasData(
            new LoanType { Id = 1, Name = "General Loan", Code = "GL" },
            new LoanType { Id = 2, Name = "Emergency Loan", Code = "EL" },
            new LoanType { Id = 3, Name = "House Loan", Code = "HL" }
        );

        modelBuilder.Entity<Bank>().HasData(
            new Bank { Id = 1, Name = "HDFC Bank", Code = "HDFC" },
            new Bank { Id = 2, Name = "SBI", Code = "SBI" },
            new Bank { Id = 3, Name = "ICICI Bank", Code = "ICICI" }
        );

        modelBuilder.Entity<VoucherType>().HasData(
            new VoucherType { Id = 1, Name = "Payment", Code = "PAY" },
            new VoucherType { Id = 2, Name = "Receipt", Code = "RCP" },
            new VoucherType { Id = 3, Name = "Journal", Code = "JUR" },
            new VoucherType { Id = 4, Name = "Contra", Code = "CON" },
            new VoucherType { Id = 5, Name = "Adjustment", Code = "ADJ" },
            new VoucherType { Id = 6, Name = "Others", Code = "OTH" }
        );
    }
}
