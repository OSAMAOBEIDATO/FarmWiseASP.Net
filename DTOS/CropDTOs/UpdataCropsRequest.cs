using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.CropDTOs
{
    public class UpdataCropsRequest
    {
        public string CropName { get; set; }
        public string CropType { get; set; }
        public string Pesticides { get; set; } = string.Empty;
        public string Fertilizers { get; set; } = string.Empty;
        public DateTime PlantDate { get; set; }
        public DateTime HarvestDate { get; set; }

        // Foreign Key for User
        public Guid UserId { get; set; }

        // Foreign Key for SoilData
        public Guid SoilDataId { get; set; }
    }
}
