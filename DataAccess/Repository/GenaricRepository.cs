using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public void Add(T Entity)
        {
            DbSet.Add(Entity);
            dBContext.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            var query=DbSet.Where(filter);
            return query;
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            var entity = DbSet.Where(expression).FirstOrDefault();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var query = DbSet.ToList();
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
