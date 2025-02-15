using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGenaricRepository<T> where T:class
    {
        Task<T> Get(Expression<Func<T,bool>> expression);
        Task<IEnumerable<T>> GetAll();
        void Remove(T Entity);
        Task Add(T Entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter);
        void Update(T Entity);
        void RemoveRang(IEnumerable<T> Entitys);

    }
}
