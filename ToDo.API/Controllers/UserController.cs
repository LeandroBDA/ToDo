using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.ViewModels.UserViewModels;
using ToDo.Application.Dto.User;
using ToDo.Application.Interfaces;

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
    [Route("/api/v1/Users/CreateUser")]
    public async Task<IActionResult> Create([FromForm] CreateUserDto userDto)
    {
        userDto = _mapper.Map<CreateUserDto>(_userService);
        var userCreated = await _userService.Create(userDto);
        return Ok(new ResultViewModel
        {
            Message = "Usuário criado com sucesso",
            Sucess = true,
            Data = userCreated
        });
    }

    [HttpPut]
    [Route("/api/v1/Users/UpdateUser")]
    [Authorize]
    public async Task<IActionResult> Update([FromForm] UserDto userDto)
    {
        userDto = _mapper.Map<UserDto>(userDto);
        userDto.Id = int.Parse(User.Identity.Name);
        var userUpdate = await _userService.Update(userDto);
        return Ok(new ResultViewModel(
        {
            Message = "Update feito com sucesso",
            Sucess = true,
            Data = userUpdate
        });
    }

    [HttpDelete]
    [Route("/api/v1/users/RemoveUser")]
    [Authorize]
    public async Task Remove()
    {
        await _userService.Remove(int.Parse(User.Identity.Name));
        return Ok(new ResultViewModel(
        {
            Message = "Usuário removido com sucesso",
            Sucess = true,
            Data = null
        });
    }

    [HttpGet]
    [Route("/api/v1/Users/GetUser")]
    [Authorize(Roles = "MOD")]
    public async Task<OkObjectResult> Get()
    {
        var userDto = await _userService.Get(int.Parse(User.Identity.Name));

        if (userDto == null)
        {
            return Ok(new ResultViewModel
            {
                Message = "Nenhum usuã́rio com o id informado foi encontrado.",
                Sucess = true,
                Data = userDto
            });
        }

        return Ok(new ResultViewModel
        {
            Message = "Pesquisa realizada com sucesso.",
            Sucess = true,
            Data = userDto
        });
    }

    [HttpGet]
    [Route("/api/v1/Users/GetAllUsers")]
    [Authorize(Roles = "MOD")]
    public async Task<OkObjectResult> GetAllUsers()
    {
        var allUsers = await _userService.GetAllUsers();
        return Ok(new ResultViewModel
        {
            Message = "Pesquisa realizada com sucesso",
            Sucess = true,
            Data = allUsers
        });
    }

    [HttpGet]
    [Route("/api/v1/Users/SearchByName")]
    [Authorize(Roles = "MOD")]
    public async Task<IActionResult> SearchByName([Required] string name)
    {
        List<UserDto> searchUsers = await _userService.SearchByName(name);

        return Ok(new ResultViewModel
        {
            Message = "Pesquisa realizada com sucesso",
            Sucess = true,
            Data = searchUsers
        });
    }
    
    [HttpGet]
    [Route("/api/v1/Users/SearchByEmail")]
    [Authorize(Roles = "MOD")]
    public async Task<IActionResult> SearchByEmail([Required] string email)
    {
        List<UserDto> searchUsers = await _userService.SearchByEmail(email);

        return Ok(new ResultViewModel
        {
            Message = "Pesquisa realizada com sucesso",
            Sucess = true,
            Data = searchUsers
        });
    }
   
    [HttpGet]
    [Route("/api/v1/Users/GetByEmail")]
    [Authorize(Roles = "MOD")]
    public async Task<IActionResult> GetByEmail([Required] string email)
    {
        var searchUsers = await _userService.GetByEmail(email);

        return Ok(new ResultViewModel
        {
            Message = "Pesquisa realizada com sucesso",
            Sucess = true,
            Data = searchUsers
        });
    }

}
