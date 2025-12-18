
using InsuranceContribution.Domain.Entities;
using InsuranceContribution.Infrastructure.Data;

using LegacyContributionAPI.DTO;
using LegacyContributionAPI.SERVICE;
using LegacyContributionAPI.VALIDATION;
using Microsoft.EntityFrameworkCore;

namespace LegacyContributionAPI.Application.Services
{
    public class ContributionService : IContributionService
    {
        private readonly InsuranceDbContext _context;

        public ContributionService(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task ProcessContributionAsync(ContributionRequestDto dto)
        {
            try
            {
                // 1️⃣ Validate input
                ContributionValidator.Validate(dto);

                // 2️⃣ Check duplicate transaction reference
                bool duplicate = await _context.Contributions
                    .AnyAsync(c => c.TransactionRef == dto.TransactionRef);

                if (duplicate)
                    throw new ApplicationException("DUPLICATE_TRANSACTION");

                // 3️⃣ Get Policy (VERY IMPORTANT – FK)
                var policy = await _context.Policies
                    .FirstOrDefaultAsync(p => p.PolicyNumber == dto.PolicyNumber);

                if (policy == null)
                    throw new ApplicationException("POLICY_NOT_FOUND");

                // 4️⃣ Create contribution
                var contribution = new Contribution
                {
                    PolicyId = policy.PolicyId,       
                    PremiumAmount = dto.PremiumAmount,
                    ContributionDate = dto.ContributionDate,
                    TransactionRef = dto.TransactionRef,
                    CreatedAt = DateTime.UtcNow
                };

                // 5️⃣ Save
                _context.Contributions.Add(contribution);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                // Validation errors
                throw new ApplicationException($"VALIDATION_ERROR: {ex.Message}", ex);
            }
            catch (DbUpdateException ex)
            {
                // Database constraint errors
                throw new ApplicationException("DATABASE_ERROR", ex);
            }
            catch (Exception ex)
            {
                // Unexpected errors
                throw new ApplicationException("UNEXPECTED_ERROR", ex);
            }
        }

    }
}
