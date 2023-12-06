using Microsoft.AspNetCore.Mvc;
using ToDo.Services.Interfaces;
using AutoMapper;
using ToDo.API.Utilities;
using ToDo.API.ViewModels;
using ToDo.Core.Exceptions;
using ToDo.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using ToDo.API.ViewModels.UserViewModels;
using ToDo.Services.DTO.User;

namespace ToDo.API.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    [HttpPost]
    [Route("/api/v1/users/create")]
    public async Task<IActionResult> Create([FromForm] CreateUserViewModel userViewModel)
    {
        try
        {
            string userDto = _mapper.Map<string>(userViewModel);
            var userCreated = await _userService.Create(userDto);

            return Ok(new ResultViewModel
            {
                Message = "Usuário criado com sucesso",
                Success = true,
                Data = userCreated
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }

    [HttpPut]
    // [Authorize]
    [Route("/api/v1/users/update")]
    public async Task<IActionResult> Update([FromForm] UpdateViewModel userViewModel)
    {
        try
        {
            UserDTO userDto = _mapper.Map<UserDTO>(userViewModel);
            var userUpdated = await _userService.Update(userDto);

            return Ok(new ResultViewModel
            {
                Message = "Usuario atualizado com sucesso!",
                Success = true,
                Data = userUpdated
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }

    [HttpDelete]
    // [Authorize]
    [Route("/api/v1/users/Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        try
        {
            await _userService.Remove(id);

            return Ok(new ResultViewModel
            {
                Message = "Usuario excluido com sucesso",
                Success = true,
                Data = null
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }

    [HttpGet]
    // [Authorize]
    [Route("/api/v1/users/Get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário com o id informado foi encontrado",
                    Success = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso",
                Success = true,
                Data = user
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }

    [HttpGet]
    // [Authorize]
    [Route("/api/v1/users/Get-All")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var user = await _userService.Get();

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado",
                    Success = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Pesquisa realizada com sucesso",
                Success = true,
                Data = user
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }

    [HttpGet]
    // [Authorize]
    [Route("/api/v1/users/Search-By-Name")]
    public async Task<IActionResult> SearchByName(string name)
    {
        try
        {
            var user = await _userService.SearchByName(name);

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado",
                    Success = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Pesquisa realizada com sucesso",
                Success = true,
                Data = user
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }

    [HttpGet]
    // [Authorize]
    [Route("/api/v1/users/Search-By-Email")]
    public async Task<IActionResult> SearchByEmail(string email)
    {
        try
        {
            var user = await _userService.SearchByEmail(email);

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado",
                    Success = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Pesquisa realizada com sucesso",
                Success = true,
                Data = user
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }

    [HttpGet]
    // [Authorize]
    [Route("/api/v1/users/Get-By-Email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        try
        {
            var user = await _userService.GetByEmail(email);

            if (user == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado",
                    Success = true,
                    Data = user
                });
            }

            return Ok(new ResultViewModel
            {
                Message = "Pesquisa realizada com sucesso",
                Success = true,
                Data = user
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro");
        }
    }
}
