using LegacyContributionAPI.DTO;
using LegacyContributionAPI.SERVICE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegacyContributionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionsController : ControllerBase
    {
        private readonly IContributionService _service;

        public ContributionsController(IContributionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Process(ContributionRequestDto dto)
        {
            try
            {
                await _service.ProcessContributionAsync(dto);
                return Ok(new { Message = "SUCCESS" });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
