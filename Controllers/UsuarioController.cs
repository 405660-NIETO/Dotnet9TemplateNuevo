using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Programacion3Template.Interfaces;

namespace Programacion3Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _usuarioService.Register(request.Email, request.Password);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _usuarioService.Login(request.Email, request.Password);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
