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
    
    public async Task<UserDto> Create(CreateUserDto userDto)
    {
        var map = _mapper.Map<User>(userDto);
        Validator(map);
        
        var userExits = await _userRepository.Create(map);
        return _mapper.Map<UserDto>(userExits);
    }

    public async Task<UserDto> Update(UserDto userDto)
    {
        var userExists = await _userRepository.GetById(userDto.Id);
        if (userExists == null)
        {
            throw new DomainException("Não existe usuário com o Id informado.");
        }
        
        var user = _mapper.Map<User>(userDto);
        Validator(user);

        var userUpdated = await _userRepository.Update(user);
        return _mapper.Map<UserDto>(userUpdated);
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Remove(int id)
    {
        var RemoveId = await _userRepository.GetById(id);
        if (RemoveId == null)
        {
            throw new DomainException("Não existe usuário com o Id informado");
        }
        await _userRepository.Remove(RemoveId);
        
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

    public async Task<List<UserDto>> GetAllUsers()
    {
        var allUsers = await _userRepository.Get();

        return _mapper.Map<List<UserDto>>(allUsers);
    }
    
    public async Task<List<UserDto>> SearchByName(string name)
    {
        var allNames = await _userRepository.SearchByName(name);

        return _mapper.Map<List<UserDto>>(allNames);
    }

    public async Task<List<UserDto>> SearchByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDto>>(allUsers);
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        if (user == null)
        {
            throw new DomainException("Não existe usuário com o email informado");
        }

        return _mapper.Map<UserDto>(user);
    }

    private bool Validator(User user)
    {
        if (!user.Validate())
        {
            return false;
        }

        return true;
    }
}