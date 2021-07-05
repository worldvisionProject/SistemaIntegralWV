using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IUnitOfWork<T> : IUnitOfWork where T : DbContext
    {
    }

    public interface IUnitOfWork 
    {
      
        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}