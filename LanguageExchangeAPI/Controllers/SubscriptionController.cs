using LanguageExchange.Application.Models.SubscriptionModels;
using LanguageExchange.Application.Models.SubscriptionPlanModels;
using LanguageExchange.Application.Services.SubscriptionServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpGet("{userId}/Subscription")]
        public async Task<IActionResult> GetCurrentSubscription(Guid userId)
        {
            var result = await _service.GetCurrentSubscription(userId);

            if (result == null) 
                return NotFound();
            return Ok(result);
        }
        [HttpGet("{userId}/Subscription")]
        public async Task<IActionResult> GetHistorySubscription(Guid userId)
        {
            var result = await _service.GetHistorySubscription(userId);

            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost("{userId}/Subscription")]
        public async Task<IActionResult> CreateSubscription(Guid userId, CreateSubscriptionInputModel model)
        {
            var result = await _service.CreateSubscription(userId, model);

            if (result == null)
                return NotFound();
            return CreatedAtAction(nameof(GetCurrentSubscription), new {id = result.Data},result);
        }
        [HttpPut("{userId}/Subscription")]
        public async Task<IActionResult> UpdateSubscription(Guid userId,UpdateSubscriptionInputModel model)
        {
            var result = await _service.UpdateSubscription(userId, model);

            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{userId}/Subscription")]
        public async Task<IActionResult> CancelSubscription(Guid userId)
        {
            var result = await _service.CancelSubscription(userId);

            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
