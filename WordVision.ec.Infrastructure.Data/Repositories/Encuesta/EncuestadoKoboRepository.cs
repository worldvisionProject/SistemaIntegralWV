using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Encuesta;
using WordVision.ec.Application.DTOs.Encuesta;
using System;

namespace WordVision.ec.Infrastructure.Data.Repositories.Encuesta
{
    public class EncuestadoKoboRepository : IEncuestadoKoboRepository
    {
        private readonly IRepositoryAsync<EncuestadoKobo> _repository;

        public EncuestadoKoboRepository(IRepositoryAsync<EncuestadoKobo> repository)
        {
            _repository = repository;
        }

        public IQueryable<EncuestadoKobo> EncuestadoKobos => _repository.Entities;

        public async Task<List<EncuestadoKobo>> GetListAsync(int encuestaKoboId)
        {
            return await _repository.Entities.Where(s => s.EncuestaKobo.Id == encuestaKoboId).ToListAsync();
        }

        public async Task<EncuestadoKobo> GetByIdAsync(int idEncuestadoKobo)
        {
            return await _repository.Entities.Where(x => x.Id == idEncuestadoKobo).FirstOrDefaultAsync();
        }

        public async Task<int> GetLastIdAsync(int encuestaKoboId)
        {
            int UltimoId = 0;
            //EncuestadoKobo ek = await _repository.Entities.Where(s => s.EncuestaKobo.Id == encuestaKoboId).MaxAsync();
            EncuestadoKobo ek = await _repository.Entities.Where(s => s.EncuestaKobo.Id == encuestaKoboId).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

            if (ek != null) UltimoId = ek.Id;
            return UltimoId;
        }

        public async Task<int> GetCountAsync(int encuestaKoboId)
        {
            return await _repository.Entities.Where(s => s.EncuestaKobo.Id == encuestaKoboId).CountAsync();
        }

        public async Task<int> InsertAsync(EncuestadoKobo encuestadoKobo)
        {
            await _repository.AddAsync(encuestadoKobo);
            return encuestadoKobo.Id;
        }

        public async Task DeleteAsync(EncuestadoKobo encuestadoKobo)
        {
            await _repository.DeleteAsync(encuestadoKobo);
        }

        public async Task DeleteAllAsync(List<EncuestadoKobo> encuestadoKoboList)
        {
            foreach (EncuestadoKobo encuestadoKobo in encuestadoKoboList)
            {
                await _repository.DeleteAsync(encuestadoKobo);
            }

        }


    }
}
