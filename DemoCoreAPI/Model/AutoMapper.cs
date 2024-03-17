using AutoMapper;

namespace DemoCoreAPI.Model
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest =>
                dest.Name,
                opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest =>
                dest.Location,
                opt => opt.MapFrom(src => src.City));
        }
    }
}
