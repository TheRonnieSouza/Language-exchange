using LanguageExchange.Application.Models.SubscriptionPlanModels;
using LanguageExchange.Application.Services.SubscriptionPlanServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [Route("api/subscription-plans")]
    [ApiController]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _service;

        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionPlans()
        {
            var result = await _service.GetAllPlans();
            if(result == null) 
                return NotFound();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionPlanById(Guid id)
        {
            var result = await _service.GetPlanById(id);
            if (result == null)
                return NotFound();
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> CreateSubscriptionPlan(CreateSubscriptionPlanInputModel model)
        {
            var result = await _service.CreatePlan(model);
            if (result == null)
                return BadRequest();
            return CreatedAtAction(nameof(GetSubscriptionPlanById),new {id =result.Data},result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscriptionPlan(Guid id, UpdateSubscriptionPlanInputModel model)
        {
            var result = await _service.UpdateSubscriptionPlan(id,model);
            if (result == null)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionPlan(Guid id)
        {
            var result = await _service.DeleteSubscriptionPlan(id);
            if (result == null)
                return NotFound();
            return NoContent();
        }        
    }
}
