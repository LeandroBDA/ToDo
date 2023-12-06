using ToDo.Services.DTO;
using ToDo.Services.DTO.User;
using ToDo.Services.DTO.User;

namespace ToDo.Services.Interfaces;

public interface IUserService
{
    Task<CreateUserDTO> Create(string userDTO);
    Task<UpdateUserDto> Update(UserDTO userDTO);
    Task Remove(Guid id);
    Task<UserDTO> Get(Guid id);
    Task<List<UserDTO>> Get();
    Task<List<UserDTO>> SearchByName(string name);
    Task<List<UserDTO>> SearchByEmail(string email);
    Task<UserDTO?> GetByEmail(string email);
}