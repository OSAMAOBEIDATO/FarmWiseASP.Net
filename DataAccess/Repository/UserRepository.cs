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
    public class UserRepository : GenaricRepository<User>, IUserRepository
    {
        public UserRepository(FarmWiseDBContext farmWiseDBContext) : base(farmWiseDBContext)
        {
        }
    }
}
