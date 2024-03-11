using AutoMapper;
using CQRS.Mediatr_Application.Dto_S;
using CQRS.Mediatr_Domen.Entity;

namespace CQRS_Mediatr_API.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }

    }
}
