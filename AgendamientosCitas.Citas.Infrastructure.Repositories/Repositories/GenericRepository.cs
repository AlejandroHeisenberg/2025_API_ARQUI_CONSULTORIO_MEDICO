using AgendamientosCitas.Citas.Domain.Interfaces;
using AgendamientosCitas.Citas.Infrastructure.Repositories.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Citas.Infrastructure.Repositories.Repositories
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly AgendamientoDbContext _context;
        protected readonly DbSet<TEntity> _entity;

        public GenericRepository(AgendamientoDbContext context)
        {
            this._context = context;
            _entity = this._context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            _entity.Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            _entity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);
            return query;
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _entity.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _entity;
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
