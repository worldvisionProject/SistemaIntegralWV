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
    public class PreguntaKoboRepository : IPreguntaKoboRepository
    {
        private readonly IRepositoryAsync<PreguntaKobo> _repository;

        public PreguntaKoboRepository(IRepositoryAsync<PreguntaKobo> repository)
        {
            _repository = repository;
        }

        public IQueryable<PreguntaKobo> PreguntaKobos => _repository.Entities;

        public async Task<List<PreguntaKobo>> GetListAsync(int encuestaKoboId)
        {
            return await _repository.Entities.Where(s => s.EncuestaKobo.Id == encuestaKoboId).ToListAsync();
        }

        public async Task<PreguntaKobo> GetByNameAsync(int encuestaKoboId, string nombrePropiedad)
        {
            return await _repository.Entities.Where(x => x.EncuestaKobo.Id == encuestaKoboId && x.prk_CodigoKobo == nombrePropiedad).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(int encuestaKoboId)
        {
            return await _repository.Entities.Where(s => s.EncuestaKobo.Id == encuestaKoboId).CountAsync();
        }

        public async Task<int> InsertAsync(PreguntaKobo preguntaKobo)
        {
            await _repository.AddAsync(preguntaKobo);
            return preguntaKobo.Id;
        }

        public async Task DeleteAllAsync(List<PreguntaKobo> preguntaKoboList)
        {
            foreach (PreguntaKobo preguntaKobo in preguntaKoboList)
            {
                await _repository.DeleteAsync(preguntaKobo);
            }

        }


    }
}
