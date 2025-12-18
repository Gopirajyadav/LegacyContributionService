namespace LegacyContributionAPI.DTO
{
    public class ContributionRequestDto
    {
        public string PolicyNumber { get; set; } = null!;
        public decimal PremiumAmount { get; set; }
        public DateTime ContributionDate { get; set; }
        public string TransactionRef { get; set; } = null!;

    }
}
