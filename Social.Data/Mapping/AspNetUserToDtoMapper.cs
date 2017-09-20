using AutoMapper;
using Social.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Mapping
{
    public class AspNetUserToDtoMapper : Profile
    {
        public override string ProfileName
        {
            get { return "AspNetUserMappingsToDtoMapper"; }
        }
        public AspNetUserToDtoMapper()
        {
            CreateMap<AspNetUser, UserDto>()
                .ForMember(dto => dto.DateOfBirth, map => map.MapFrom(x => x.UserProfile.DateOfBirth));
        }
    }
}
