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
    public class EncuestadoPreguntaKoboRepository : IEncuestadoPreguntaKoboRepository
    {

        private readonly IRepositoryAsync<EncuestadoPreguntaKobo> _repository;

        public EncuestadoPreguntaKoboRepository(IRepositoryAsync<EncuestadoPreguntaKobo> repository)
        {
            _repository = repository;
        }

        public IQueryable<EncuestadoPreguntaKobo> EncuestadoPreguntaKobos => _repository.Entities;

        public async Task<List<EncuestadoPreguntaKobo>> GetListAsyncByEncuestadoKobo(int encuestadoKoboId)
        {
            return await _repository.Entities.Where(s => s.EncuestadoKobo.Id == encuestadoKoboId).ToListAsync();
        }

        public async Task<List<EncuestadoPreguntaKobo>> GetListAsyncByPreguntaKobo(int preguntaKoboId)
        {
            return await _repository.Entities.Where(s => s.PreguntaKobo.Id == preguntaKoboId).ToListAsync();
        }


        public async Task<int> InsertAsync(EncuestadoPreguntaKobo encuestadoPreguntaKobo)
        {
            await _repository.AddAsync(encuestadoPreguntaKobo);
            return encuestadoPreguntaKobo.Id;
        }

        public async Task DeleteAllAsync(List<EncuestadoPreguntaKobo> encuestadoPreguntaKoboList)
        {
            foreach(EncuestadoPreguntaKobo encuestadoPreguntaKobo in encuestadoPreguntaKoboList)
            {
                await _repository.DeleteAsync(encuestadoPreguntaKobo);
            }
            
        }



    }
}
