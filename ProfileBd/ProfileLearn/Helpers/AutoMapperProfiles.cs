using AutoMapper;
using ProfileLearn.Dto;
using ProfileLearn.Entities;
using System.Linq;

namespace ProfileLearn.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Photo, PhotoDto>();   
        }
    }
}
