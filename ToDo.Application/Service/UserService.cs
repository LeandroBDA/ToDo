using AutoMapper;
using ToDo.Application.Dto.User;
using ToDo.Application.Interfaces;
using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;
using ToDo.Infra.Interfaces;

namespace ToDo.Application.Service;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> Create(UserDto userDto)
    {
        var userExits = await 
    }

    public async Task<UserDto> Update(UserDto userDto)
    {
        var userExists = await _userRepository.GetById(userDto.Id);
        if (userExists == null)
        {
            throw new DomainException("Não existe usuário com o Id informado.");
        }
        
        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userUpdated = await _userRepository.Update(user);
        return _mapper.Map<UserDto>(userUpdated);
    }

    public Task Remove(int id)
    {
        await _userRepository.Remove(id);
    }

    public async Task<UserDto> Get(int id)
    {
        var user = await _userRepository.GetById(id);

        if (user == null)
        {
            throw new DomainException("Não existe usuário com o Id informado.");
        }

        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserDto>> Get()
    {
        var allUsers = await _userRepository.();

        return _mapper.Map<List<UserDto>>(allUsers);
    }
    

    public async Task<List<UserDto>> SearchByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDto>>(allUsers);
    }

    public Task<UserDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        if (user == null)
        {
            throw new DomainException("Não existe usuário com o email informado");
        }

        return _mapper.Map<UserDto>(user);
    }
}