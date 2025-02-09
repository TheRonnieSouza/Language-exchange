using LanguageExchange.Application.Models.UserAdditionalInfoModels;
using LanguageExchange.Application.Services.AdditionalUserInformationServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [ApiController]
    [Route("api/users/additional-info")]
    public class AdditionalUserInformationController : ControllerBase
    {
        private readonly IAdditionalUserInformationService _additionalUserInformationService;

        public AdditionalUserInformationController(IAdditionalUserInformationService additionalUserInformationService)
        {
            _additionalUserInformationService = additionalUserInformationService;
        }
               
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAdditionalInfo(Guid userId)
        {
            var result = await _additionalUserInformationService.GetAdditionalInformation(userId);
            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
                
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAdditionalInfo(Guid userId,[FromBody] UpdateAdditionalUserInformationInputModel input)
        {
            var result = await _additionalUserInformationService.UpdateAdditionalInformation(userId, input);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateAdditionalInfo(Guid userId, [FromBody] CreateAdditionalUserInformationInputModel input)
        {
            var result = await _additionalUserInformationService.CreateAdditionalInformation(userId, input);
            if (!result.IsSuccess)
                return BadRequest(result);
          
                return CreatedAtAction(nameof(GetAdditionalInfo), new { userId = userId }, $"Additional information created with success. Id: {result.Data} ");
        }
    }

}
