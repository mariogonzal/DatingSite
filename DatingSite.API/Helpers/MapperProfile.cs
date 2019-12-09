using System;
using System.Linq;
using AutoMapper;
using DatingSite.API.Dto;
using DatingSite.API.Models;
using DatingSite.API.Helpers;

namespace DatingSite.API.Helpers
{
    public class MapperProfile: Profile
    {
        
        public MapperProfile(){
            CreateMap<User,UserForDetailDto>()
            .ForMember(d=>d.PhotoUrl , o=>o.MapFrom(p=>p.Photos.FirstOrDefault(l=>l.IsMain).Url));
            CreateMap<User,UserForListDto>()
            .ForMember(d=>d.PhotoUrl , o=>o.MapFrom(p=>p.Photos.FirstOrDefault(l=>l.IsMain).Url))
            .ForMember(d=>d.Age, o=>o.MapFrom(p=> p.DateOfBird.CalculateAge()));
            
            CreateMap<Photo,PhotoForDto>();
        }
    }
}
