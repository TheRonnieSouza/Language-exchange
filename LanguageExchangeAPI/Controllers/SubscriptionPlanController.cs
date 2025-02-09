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

        public SubscriptionPlanController (ISubscriptionPlanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionPlans()
        {
            var result = await _service.GetAllPlans();
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionPlanById(Guid id)
        {
            var result = await _service.GetPlanById(id);
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> CreateSubscriptionPlan(CreateSubscriptionPlanInputModel model)
        {
            var result = await _service.CreatePlan(model);
            if (!result.IsSuccess)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetSubscriptionPlanById),new {id =result.Data},$"Plano {model.Name} criado com sucesso. " +
                                                                                  $"Id: {result.Data}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscriptionPlan(Guid id, UpdateSubscriptionPlanInputModel model)
        {
            var result = await _service.UpdateSubscriptionPlan(id,model);
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionPlan(Guid id)
        {
            var result = await _service.DeleteSubscriptionPlan(id);
            if (!result.IsSuccess)
                return NotFound(result);
            return NoContent();
        }        
    }
}
