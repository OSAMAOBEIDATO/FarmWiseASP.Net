using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CropRepository : GenaricRepository<Crop>, ICropRepoistory
    {
        public CropRepository(FarmWiseDBContext farmWiseDBContext) : base(farmWiseDBContext)
        {
        }
    }
}
