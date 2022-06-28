using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class SeguimientoObjetivoRepository : ISeguimientoObjetivoRepository
    {
        private readonly IRepositoryAsync<SeguimientoObjetivo> _repository;
        public SeguimientoObjetivoRepository(IRepositoryAsync<SeguimientoObjetivo> repository)
        {
            _repository = repository;
        }
        public IQueryable<SeguimientoObjetivo> seguimientoObjetivos => _repository.Entities;

        public async Task DeleteAsync(SeguimientoObjetivo seguimientoObjetivo)
        {
            await _repository.DeleteAsync(seguimientoObjetivo);
        }

        public async Task<SeguimientoObjetivo> GetSeguimientoxColaboradorAsync(int idColaborador, int idAnioFiscal)
        {
            return await _repository.Entities.Where(x=>x.IdColaborador==idColaborador && x.AnioFiscal== idAnioFiscal).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(SeguimientoObjetivo seguimientoObjetivo)
        {
            await _repository.AddAsync(seguimientoObjetivo);
            return seguimientoObjetivo.Id;
        }

        public async Task UpdateAsync(SeguimientoObjetivo seguimientoObjetivo)
        {
            await _repository.UpdateAsync(seguimientoObjetivo);
        }

        public async Task UpdatexTodoAsync(int idColaborador, int idAnioFiscal)
        {
            var e = _repository.Entities.Where(x => x.IdColaborador == idColaborador && x.AnioFiscal==idAnioFiscal).ToList();
            foreach (var e2 in e)
            {
                e2.Ultimo = 0;
                await _repository.UpdateAsync(e2);
            }

        }
    }
}
