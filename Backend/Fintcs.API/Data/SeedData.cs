
using Microsoft.EntityFrameworkCore;
using Fintcs.API.Models;
using BCrypt.Net;

namespace Fintcs.API.Data;

public static class SeedData
{
    public static async Task Initialize(FintcsDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        // Seed SuperAdmin if not exists
        if (!await context.SuperAdmins.AnyAsync())
        {
            var superAdmin = new SuperAdmin
            {
                Username = "admin",
                PasswordHash = BCrypt.HashPassword("admin"),
                CreatedDate = DateTime.Now
            };

            context.SuperAdmins.Add(superAdmin);
            await context.SaveChangesAsync();
        }

        // Seed sample society if not exists
        if (!await context.Societies.AnyAsync())
        {
            var society = new Society
            {
                Name = "Sample Cooperative Society",
                Address = "123 Main Street",
                City = "Sample City",
                Phone = "123-456-7890",
                Email = "info@samplecoop.com",
                RegistrationNo = "REG001",
                DividendRate = 8.5m,
                ODRate = 12.0m,
                CDRate = 6.0m,
                LoanRate = 10.0m,
                EmergencyLoanRate = 12.0m,
                LASRate = 9.0m,
                ShareLimit = 100000m,
                LoanLimit = 500000m,
                EmergencyLoanLimit = 50000m,
                BounceChargeAmount = 500m,
                BounceChargeMode = "Cash",
                IsActive = true
            };

            context.Societies.Add(society);
            await context.SaveChangesAsync();

            // Seed sample society admin
            var societyAdmin = new AppUser
            {
                EDPNo = "EMP001",
                Name = "Society Administrator",
                Username = "societyadmin",
                PasswordHash = BCrypt.HashPassword("admin123"),
                Role = "SocietyAdmin",
                SocietyId = society.Id,
                Email = "admin@samplecoop.com",
                IsActive = true
            };

            context.AppUsers.Add(societyAdmin);
            await context.SaveChangesAsync();
        }
    }
}
