using DataAccess.Data;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SoilDataRepository : GenaricRepository<SoilData>, ISoilDataRepository
    {
        public SoilDataRepository(FarmWiseDBContext farmWiseDBContext):base(farmWiseDBContext)
        {
            
        }
    }
}
