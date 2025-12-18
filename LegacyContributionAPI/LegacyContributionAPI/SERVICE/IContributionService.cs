using LegacyContributionAPI.DTO;

namespace LegacyContributionAPI.SERVICE
{
    public interface IContributionService
    {
        Task ProcessContributionAsync(ContributionRequestDto dto);
    }
}
