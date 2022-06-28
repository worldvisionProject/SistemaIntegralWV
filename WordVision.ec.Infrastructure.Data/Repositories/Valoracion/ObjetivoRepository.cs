﻿using Microsoft.EntityFrameworkCore;
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
    public class ObjetivoRepository : IObjetivoRepository
    {
        private readonly IRepositoryAsync<Objetivo> _repository;
        private readonly IRepositoryAsync<ObjetivoAnioFiscal> _repositoryObjAnio;
        private readonly IDistributedCache _distributedCache;
        public ObjetivoRepository(IRepositoryAsync<ObjetivoAnioFiscal> repositoryObjAnio, IRepositoryAsync<Objetivo> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _repositoryObjAnio = repositoryObjAnio;
        }
        public IQueryable<Objetivo> Objetivos => _repository.Entities;

        public async Task DeleteAsync(Objetivo objetivo)
        {
            await _repository.DeleteAsync(objetivo);
        }

        public async Task<Objetivo> GetByIdAsync(int objetivoId)
        {
            return await _repository.Entities.Where(x => x.Id == objetivoId).Include(x => x.ObjetivoAnioFiscales)
               
                .FirstOrDefaultAsync();
        }

        public async Task<List<Objetivo>> GetListAsync()
        {
            return await _repository.Entities.Include(x => x.ObjetivoAnioFiscales).ToListAsync();
        }

        public async Task<List<Objetivo>> GetListxAnioFiscalAsync(int idAnioFiscal)
        {
            return await _repository.Entities.Include(x => x.ObjetivoAnioFiscales).ToListAsync();
        }

        public async Task<ObjetivoAnioFiscal> GetPonderacionByIdAsync(int objetivoId)
        {
            return await _repositoryObjAnio.Entities.Where(x => x.IdObjetivo== objetivoId).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(Objetivo objetivo)
        {
            await _repository.AddAsync(objetivo);
            return objetivo.Id;
        }

        public async Task UpdateAsync(Objetivo objetivo)
        {
            await _repository.UpdateAsync(objetivo);
        }
    }
}
