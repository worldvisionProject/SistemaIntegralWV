using System;
using System.Threading;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Interfaces.Repositories.Identity
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}