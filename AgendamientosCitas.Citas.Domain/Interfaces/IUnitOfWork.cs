using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendamientosCitas.Citas.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        IGenericRepository<T> Crud<T>() where T : class;
    }
}
