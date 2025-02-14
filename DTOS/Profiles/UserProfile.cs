using AutoMapper;
using DTOS.UserDTOs;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User, AddUserRequest>().ReverseMap();
            CreateMap<User, UpdataUserRequest>().ReverseMap();
        }
    }
}
