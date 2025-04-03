using AgendamientosCitas.Medicos.Domain.Interfaces;
using AgendamientosCitas.Medicos.Infrastruture.Repositories.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Medicos.Infrastruture.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AgendamientoDbContext _context;
        public AgendamientoDbContext Contexto { get { return _context; } set { _context = value; } }

        public UnitOfWork()
        {

        }

        public UnitOfWork(AgendamientoDbContext context)
        {
            this._context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public IGenericRepository<T> Crud<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
