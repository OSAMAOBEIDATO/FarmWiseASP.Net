using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGenaricRepository<User> Users { get; }
        IGenaricRepository<Crop> Crops { get; }
        IGenaricRepository<SoilData> SoilDatas { get; }

        void Save();
    }
}
