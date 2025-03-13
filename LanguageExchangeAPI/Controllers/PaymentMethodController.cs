using LanguageExchange.Application.Models.PaymentMethodModels;
using LanguageExchange.Application.Services.PaymentMethodServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [Route("api/users/payment-method")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodController(IPaymentMethodService paymentService)
        {
            _paymentMethodService = paymentService;
        }

        [HttpGet("{userId}/payment-methods")]
        public async Task<IActionResult> GetPaymentMethod(Guid userId)
        {
            var result = await _paymentMethodService.GetPaymentMethod(userId);
            if (result == null) 
                return NotFound();

            return Ok(result);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreatePaymentMethod(Guid userId, [FromBody] CreatePaymentMethodInputModel model)
        {
            var result = await _paymentMethodService.CreatePaymentMethod(userId, model);
            if (result == null)
                return NotFound();

            return CreatedAtAction(nameof(GetPaymentMethod), result);
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdatePaymentMethod(Guid userId, [FromBody] UpdatePaymentMethodInputModel model)
        {
            var result = await _paymentMethodService.UpdatePaymentMethod(userId, model);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(Guid id, Guid userId)
        {
            var result = await _paymentMethodService.CancelPaymentMethod(id, userId);
            if (result == null)
                return BadRequest();

            return NoContent();
        }
    }
}
