using LanguageExchange.Application.Models.UserServices;
using LanguageExchange.Application.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LanguageExchangeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            return CreatedAtAction(nameof(GetUser), new { id = result.Data }, $"Usuário {user.Name} criado com sucesso.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,CreateUserInputModel user)
        {
            var result = await _userService.UpdateUser(id, user);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUser(id);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
