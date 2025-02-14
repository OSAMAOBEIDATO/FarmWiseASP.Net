using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.CropDataDTO
{
    public class SoilDataDTOs
    {
        public Guid Id { get; set; }    
        public string? SoilType { get; set; }

        public string Location { get; set; }

        public decimal PHLevel { get; set; }

        public decimal SoilMoisture { get; set; }

        //public ICollection<Crop> Crops { get; set; }
    }
}
