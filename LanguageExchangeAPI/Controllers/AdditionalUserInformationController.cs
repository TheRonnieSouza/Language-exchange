using LanguageExchange.Application.Models.UserAdditionalInfoModels;
using LanguageExchange.Application.Services.AdditionalUserInformationServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/additional-info")]
    public class AdditionalUserInformationController : ControllerBase
    {
        private readonly IAdditionalUserInformationService _additionalUserInformationService;

        public AdditionalUserInformationController(IAdditionalUserInformationService additionalUserInformationService)
        {
            _additionalUserInformationService = additionalUserInformationService;
        }
               
        [HttpGet]
        public async Task<IActionResult> GetAdditionalInfo(Guid userId)
        {
            var result = await _additionalUserInformationService.GetAdditionalInformation(userId);
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }
                
        [HttpPut]
        public async Task<IActionResult> UpdateAdditionalInfo(Guid userId,[FromBody] UpdateAdditionalUserInformationInputModel input)
        {
            var result = await _additionalUserInformationService.UpdateAdditionalInformation(userId, input);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }

}
