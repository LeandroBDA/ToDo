using AutoMapper;
using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;
using ToDo.Infra.Interfaces;
using ToDo.Services.DTO.User;
using ToDo.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDo.Services.Services;

public class UserServices : IUserService
{
    public UserServices(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public async Task<CreateUserDTO> Create(string userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto);

        if (userExists != null)
        {
            throw new DomainException("Esse email já está cadastrado.");
        }
        Console.WriteLine("Email disponível. Pode Ser cadastrado");
        var user = _mapper.Map<User>(userDto);
        user.Password = userDto;
        user.Validate();

        var userCreated = await _userRepository.Create(user);
        return _mapper.Map<CreateUserDTO>(userCreated);
    }

    public async Task<UpdateUserDto> Update(UserDTO userDTO)
    {
        UpdateUserDto updatedUser = new UpdateUserDto
        {
            UserId = userDTO.UserId,
       
        };

        return updatedUser;
    }

    public async Task Remove(Guid id)
    {
        await _userRepository.Remove(id);
    }

    public async Task<UserDTO> Get(Guid id)
    {
        var user = await _userRepository.Get(id);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> Get()
    {
        var allUsers = await _userRepository.Get();

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SearchByName(string name)
    {
        var allUsers = await _userRepository.SearchByName(name);

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<UserDTO?> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        return _mapper.Map<UserDTO>(user);
    }

}