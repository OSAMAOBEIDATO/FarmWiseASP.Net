using AutoMapper;
using DTOS.CropDTOs;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Profiles
{
    public class CropProfile:Profile
    {
        public CropProfile()
        {
            CreateMap<Crop, CropDTO>().ReverseMap();
            CreateMap<Crop, AddCropRequest>().ReverseMap();
            CreateMap<Crop, UpdataCropsRequest>().ReverseMap();
        }
    }
}
