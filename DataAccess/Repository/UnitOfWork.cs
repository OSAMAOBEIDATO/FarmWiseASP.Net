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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FarmWiseDBContext _context;

        public IGenaricRepository<User> Users { get; private set; }
        public IGenaricRepository<Crop> Crops { get; private set; }
        public IGenaricRepository<SoilData> SoilDatas { get; private set; }

        public UnitOfWork(FarmWiseDBContext context)
        {
            _context = context;
            Users = new GenaricRepository<User>(context);
            Crops = new GenaricRepository<Crop>(context);
            SoilDatas = new GenaricRepository<SoilData>(_context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
