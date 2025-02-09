using LanguageExchange.Application.Models.UserServices;
using LanguageExchange.Application.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserInputModel user)
        {
            var result = await _userService.CreateUser(user);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetUser), new { id = result.Data }, $"Usuário {user.FullName} criado com sucesso. Id: {result.Data} ");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await _userService.GetUser(id);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, ChangePasswordInputModel user)
        {
            var result = await _userService.ChangePassword(id, user);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id,CreateUserInputModel user)
        {
            var result = await _userService.UpdateUser(id, user);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
       

    }
}
