// using Microsoft.AspNetCore.Mvc;
//
// namespace ToDo.API.Controllers
// { 
//     [ApiController]
//     
//     public class UserController : ControllerBase
//     {
//         private readonly IMapper _mapper;
//         private readonly IUserService _userService;
//         
//         public UserController(IMapper mapper, IUserService userService)
//         {
//             _mapper = mapper;
//             _userService = userService;
//         }
//
//         [HttpPost]
//         [Route("/api/v1/users/create")]
//         public async Task<IActionResult> Create([FromBody] CreatedResultViewModel userViewModel)
//         {
//             try
//             {
//                 var userDto = _mapper.Map<UserDto>(userViewModel);
//
//                 var userCreated = await _userService.Create(userDto);
//
//                 return Ok(new ResultViewModels
//                 {
//                     Message = "Usuário criado com sucesso",
//                     Success = true,
//                     Data = userCreated
//                 });
//                 
//             }
//             catch (DomainException eX)
//             {
//                 return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
//             }
//             catch(Exception)
//             {
//                 return StatusCode(500, Responses.ApplicartionErrorMensage());
//             }
//         }
//     }
//     
// }

