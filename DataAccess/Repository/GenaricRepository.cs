using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly FarmWiseDBContext dBContext;
        private readonly DbSet<T> DbSet;

        public GenaricRepository(FarmWiseDBContext farmWiseDBContext)
        {
            this.dBContext=farmWiseDBContext;
            this.DbSet=dBContext.Set<T>();
        }
        public async Task Add(T Entity)
        {
             await DbSet.AddAsync(Entity);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter)
        {
            var query = await DbSet.Where(filter).ToListAsync();
            return query;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            var entity =await DbSet.Where(expression).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query = await DbSet.ToListAsync();
            return query;
        }

        public void Remove(T Entity)
        {
            DbSet.Remove(Entity);
        }

        public void RemoveRang(IEnumerable<T> Entitys)
        {
            DbSet.RemoveRange(Entitys);
        }

        public void Update(T Entity)
        {
            DbSet.Update(Entity);
        }
    }
}
