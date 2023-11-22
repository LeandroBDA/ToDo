using ToDo.API.Token;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.API.Controllers;
[ApiController]

public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
    {
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost]
    [Route("/api/v1/auth/login")]
    public IActionResult Login([FromForm] LoginViewModel loginViewModel)
    {
        try
        {
            var tokenLogin = _configuration["Jwt:Login"];
            var tokenPassword = _configuration["Jwt:Password"];

            if (loginViewModel.Login == tokenLogin && loginViewModel.Password == tokenPassword)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Usuário autenticado com sucesso",
                    Success = true,
                    Data = new
                    {
                        Token = _tokenGenerator.GenerateToken(),
                        tokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                    }
                });
            }

            return StatusCode(401, Responses.UnauthorizedErrorMessage());
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }
}