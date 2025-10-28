using System;
using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;
        private readonly ILogger<SearchController> _logger;

        public SearchController(SearchService searchService, ILogger<SearchController> logger)
        {
            _searchService = searchService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string from, [FromQuery] string to, [FromQuery] DateTime? journeyDate)
        {
            _logger.LogInformation("Search called with from={From} to={To} journeyDate={JourneyDate}", from, to, journeyDate);

            if (!journeyDate.HasValue)
            {
                _logger.LogWarning("Missing journeyDate query parameter");
                return BadRequest("journeyDate query parameter is required");
            }

            // Always use the UTC date at midnight for consistency
            var utcDate = DateTime.SpecifyKind(journeyDate.Value.Date, DateTimeKind.Utc);
            _logger.LogInformation("Normalized journey date to UTC midnight: {UtcDate}", utcDate);

            var result = await _searchService.SearchAvailableBusesAsync(from, to, utcDate);
            return Ok(result);
        }
    }
}
