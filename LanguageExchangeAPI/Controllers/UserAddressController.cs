using LanguageExchange.Application.Models.UserAddressModels;
using LanguageExchange.Application.Services.UserAddressServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [Route("api/users/{userId}/user-address")]
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
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(Guid userId, [FromBody] CreateUserAddressInputModel input)
        {
            var result = await _userAddressService.CreateAddress(userId,input);
            if (!result.IsSuccess)
                return BadRequest(result);
           
            return CreatedAtAction(nameof(GetAddress), new { userId = userId, id = result.Data }, $"Endereço criado com sucesso. Id: {result.Data} ");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(Guid userId, [FromBody] UpdateUserAddressInputModel input)
        {
            var result = await _userAddressService.UpdateAddress(userId, input);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid userId, Guid id)
        {
            var result = await _userAddressService.DeleteAddress(userId,id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return NoContent();
        }
    }
}
