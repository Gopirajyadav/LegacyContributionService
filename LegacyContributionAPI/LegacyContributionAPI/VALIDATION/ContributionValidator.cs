using LegacyContributionAPI.DTO;

namespace LegacyContributionAPI.VALIDATION
{
    public static class ContributionValidator
    {
        public static void Validate(ContributionRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.PolicyNumber))
                throw new ArgumentException("INVALID_POLICY");

            if (dto.PremiumAmount <= 0)
                throw new ArgumentException("INVALID_PREMIUM");

            if (dto.ContributionDate > DateTime.UtcNow)
                throw new ArgumentException("INVALID_DATE");
        }
    }
}
