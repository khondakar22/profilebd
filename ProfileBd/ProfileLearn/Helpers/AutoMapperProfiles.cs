using AutoMapper;
using ProfileLearn.Dto;
using ProfileLearn.Entities;

namespace ProfileLearn.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Photo, PhotoDto>();   
        }
    }
}
