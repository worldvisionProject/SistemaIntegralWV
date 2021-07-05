using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Infrastructure.Data.Contexts;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    public class UnitOfWork : IUnitOfWork//<T> : IUnitOfWork<T> where T : DbContext
    {
       // private readonly IAuthenticatedUserService _authenticatedUserService;
        //private readonly DbContext _dbContext;
        private bool disposed;
        private readonly RegistroDbContext _dbContext;
        public UnitOfWork(RegistroDbContext dbContext)//, IAuthenticatedUserService authenticatedUserService)
        {
            //if (dbContext==null)
            //{
            //    _dbContext = _dbContextRegistro ?? throw new ArgumentNullException(nameof(dbContext));
            //    return;
            //}
           
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
           // _authenticatedUserService = authenticatedUserService;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback()
        {
            //todo
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}