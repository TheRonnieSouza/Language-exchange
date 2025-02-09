using LanguageExchange.Application.Models.SubscriptionModels;
using LanguageExchange.Application.Services.SubscriptionServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [Route("api/users/subscription")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpGet("{userId}/current")]
        public async Task<IActionResult> GetCurrentSubscription(Guid userId)
        {
            var result = await _service.GetCurrentSubscription(userId);

            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpGet("{userId}/history")]
        public async Task<IActionResult> GetHistorySubscription(Guid userId)
        {
            var result = await _service.GetHistorySubscription(userId);

            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateSubscription(Guid userId, CreateSubscriptionInputModel model)
        {
            var result = await _service.CreateSubscription(userId, model);

            if (!result.IsSuccess)
                return NotFound(result);
            return CreatedAtAction(nameof(GetCurrentSubscription), new { userId = userId },result);
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateSubscription(Guid userId,UpdateSubscriptionInputModel model)
        {
            var result = await _service.UpdateSubscription(userId, model);

            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpPut("{userId}/activate-subscription")]
        public async Task<IActionResult> ActivateSubscription(Guid userId)
        {
            var result = await _service.ActivateSubscription(userId);

            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpDelete("{userId}/cancel-subscription")]
        public async Task<IActionResult> CancelSubscription(Guid userId)
        {
            var result = await _service.CancelSubscription(userId);

            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
    }
}
