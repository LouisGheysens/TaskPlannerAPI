using API.Routes;
using Business.Interface;
using Data.Model;
using DTO.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private static User _user = new();

    public AuthController(IUserService userService) => this._userService = userService;


    [HttpPost(ApiRoutes.Register)]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        _userService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
        _user.Username = request.Username;
        _user.PasswordHash = passwordHash;
        _user.PasswordSalt = passwordSalt;
        return Ok(_user);
    }

    [HttpPost(ApiRoutes.Login)]
    public async Task<ActionResult<string>> Login(UserDto request)
    {
        if(_user.Username != request.Username)
        {
            return BadRequest("User not found!");
        }

        if(!_userService.VerifyPasswordHash(request.Password, _user.PasswordHash, _user.PasswordSalt))
        {
            return BadRequest("Wrong password!");
        }

        string token = CreateToken(_user);

        return Ok(token);
    }
}
