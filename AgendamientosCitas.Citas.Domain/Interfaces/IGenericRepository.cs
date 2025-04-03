using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Citas.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Get(Func<T, bool> predicate);
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
