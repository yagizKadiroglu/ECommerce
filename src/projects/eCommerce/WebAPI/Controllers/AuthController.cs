using Application.Features.Auth.Commands.Login;
using Core.Security.Dtos;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            AccessToken result = await Mediator.Send(loginCommand);

            return Ok(result);
        }
    }
}
