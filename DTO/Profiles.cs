using AutoMapper;
using Data.Model;
using DTO.Model;

namespace DTO;
public class Profiles: Profile
{
    public Profiles()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
