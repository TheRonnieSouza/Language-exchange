using LanguageExchange.Application.Models.UserAddressModels;
using LanguageExchange.Application.Services.UserAddressServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [Route("api/userAddress")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        public UserAddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(Guid userId)
        {
            var result = await _userAddressService.GetAddress(userId);
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(Guid userId, [FromBody] CreateUserAddressInputModel input)
        {
            var result = await _userAddressService.CreateAddress(userId,input);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetAddress),  result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(Guid userId, [FromBody] UpdateUserAddressInputModel input)
        {
            var result = await _userAddressService.UpdateAddress(userId, input);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid userId, Guid id)
        {
            var result = await _userAddressService.DeleteAddress(userId,id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
