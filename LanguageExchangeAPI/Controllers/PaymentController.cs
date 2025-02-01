using LanguageExchange.Application.Models.PaymentModels;
using LanguageExchange.Application.Models.PaymentModelsModels;
using LanguageExchange.Application.Services.PaymentServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentInputModel payment)
        {
            var result = await _paymentService.CreatePayment(payment);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> CancelPayment(int id, CancelPaymentInputModel payment)
        {
            var result = await _paymentService.CancelPayment(id, payment);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{userId}/{paymentId}")]
        public async Task<IActionResult> GetPaymentStatus(int userId, int paymentId)
        {
            var result = await _paymentService.GetPaymentStatus(userId, paymentId);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
