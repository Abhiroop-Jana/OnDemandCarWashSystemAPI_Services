using OnDemandCarWashSystemAPI.DTOs;
using OnDemandCarWashSystemAPI.Models;
using AutoMapper;

namespace OnDemandCarWashSystemAPI.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateUserDto, UserDetails>().ReverseMap();
        }
    }
}
