﻿using AutoMapper;
using DemoMapperDTO.Models;
using DemoMapperDTO.DTO;

namespace DemoMapperDTO.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRegisteration,UserDTO>();
        }
    }
}
