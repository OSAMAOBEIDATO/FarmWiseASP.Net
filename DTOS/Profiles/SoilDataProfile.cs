using AutoMapper;
using DTOS.CropDataDTO;
using DTOS.SoilDataDTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Profiles
{
    public class SoilDataProfile:Profile
    {
        public SoilDataProfile()
        {
            CreateMap<SoilData, SoilDataDTOs>().ReverseMap();
            CreateMap<SoilData, AddSoilDataRequest>().ReverseMap();
            CreateMap<SoilData, UpdataSoilDataRequest>().ReverseMap();
        }
    }
}
