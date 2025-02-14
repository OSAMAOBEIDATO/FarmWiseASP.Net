using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.SoilDataDTO
{
    public class UpdataSoilDataRequest
    {
        public string? SoilType { get; set; }

        public string Location { get; set; }

        public decimal PHLevel { get; set; }

        public decimal SoilMoisture { get; set; }
    }
}
