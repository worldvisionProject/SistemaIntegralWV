using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class LogFrameRepository : ILogFrameRepository
    {
        private readonly IRepositoryAsync<LogFrame> _repository;
        public LogFrameRepository(IRepositoryAsync<LogFrame> repository)
        {
            _repository = repository;
        }

        public async Task<LogFrame> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<LogFrame>> GetListAsync(LogFrame logFrame)
        {
            IQueryable<LogFrame> list = _repository.Entities;

            if (logFrame.Include)
            {
                list = list.Include(p => p.Nivel).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(LogFrame logFrame)
        {
            await _repository.AddAsync(logFrame);
            return logFrame.Id;
        }

        public async Task UpdateAsync(LogFrame logFrame)
        {
            await _repository.UpdateAsync(logFrame);
        }
    }
}
