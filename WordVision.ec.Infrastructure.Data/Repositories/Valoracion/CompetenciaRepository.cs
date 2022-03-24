using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class CompetenciaRepository : ICompetenciaRepository
    {
        private readonly IRepositoryAsync<Competencia> _repository;
        private readonly IDistributedCache _distributedCache;
        public CompetenciaRepository(IRepositoryAsync<Competencia> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }
        public IQueryable<Competencia> Competencias => _repository.Entities;

        public async Task DeleteAsync(Competencia competencia)
        {
            await _repository.DeleteAsync(competencia);
        }

        public async Task<Competencia> GetByIdAsync(int competenciaId)
        {
            return await _repository.Entities.Where(x => x.Id == competenciaId)
               .FirstOrDefaultAsync();
        }

        public async Task<List<Competencia>> GetListAsync()
        {
            return await _repository.Entities
               .ToListAsync();
        }

        public async Task<List<CompetenciaResponse>> GetListPadreAsync(int idNivel)
        {
          
            if (idNivel != 4)
                return await _repository.Entities.Where(c =>  c.IdNivel == 1)
                 .Select(x => new CompetenciaResponse
                 {
                     //Id = x.Padre,
                     IdCompetencia = x.IdCompetencia,
                     NombreCompetencia = x.NombreCompetencia,
                     Descripcion = x.Descripcion,
                     EsObligatorio = x.EsObligatorio
                 }).Distinct().ToListAsync();
            else
            {
                return await _repository.Entities.Where(c => c.IdNivel == 0)
                  .Select(x => new CompetenciaResponse
                  {
                      //Id = x.Padre,
                      IdCompetencia = x.IdCompetencia,
                      NombreCompetencia = x.NombreCompetencia,
                      Descripcion = x.Descripcion,
                      EsObligatorio = x.EsObligatorio
                  }).Distinct().ToListAsync();
            }
               
           
        }

        public async Task<List<Competencia>> GetListxPadreAsync(int idPadre)
        {
            return await _repository.Entities.Where(x => x.Padre == idPadre).ToListAsync();
        }

        public async Task<int> InsertAsync(Competencia competencia)
        {
            await _repository.AddAsync(competencia);
            return competencia.Id;
        }

        public async Task UpdateAsync(Competencia competencia)
        {
            await _repository.UpdateAsync(competencia);
        }
    }
}
