using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Infrastructure.Data.Repositories.Indicadores
{
    public class ProyectoITTDIPRepository : IProyectoITTDIPRepository
    {
        private readonly IRepositoryAsync<ProyectoITTDIP> _repository;
        public ProyectoITTDIPRepository(IRepositoryAsync<ProyectoITTDIP> repository)
        {
            _repository = repository;
        }

        public async Task<ProyectoITTDIP> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProyectoITTDIP>> GetListAsync(ProyectoITTDIP entity)
        {
            IQueryable<ProyectoITTDIP> list = _repository.Entities;

            if (entity.Include)
            {
                list = list.Include(p => p.ProyectoTecnico).Include(p => p.ProgramaArea);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ProyectoITTDIP entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(ProyectoITTDIP entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
