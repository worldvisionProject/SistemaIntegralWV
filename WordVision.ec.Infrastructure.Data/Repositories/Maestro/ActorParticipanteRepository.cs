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
    public class ActorParticipanteRepository : IActorParticipanteRepository
    {
        private readonly IRepositoryAsync<ActorParticipante> _repository;
        public ActorParticipanteRepository(IRepositoryAsync<ActorParticipante> repository)
        {
            _repository = repository;
        }

        public async Task<ActorParticipante> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ActorParticipante>> GetListAsync(ActorParticipante actor)
        {
            IQueryable<ActorParticipante> list = _repository.Entities;

            if (!string.IsNullOrEmpty(actor.Codigo))
                list = list.Where(c => c.Codigo == actor.Codigo);

            if (actor.Include)
            {
                list = list.Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(ActorParticipante actorParticipante)
        {
            await _repository.AddAsync(actorParticipante);
            return actorParticipante.Id;
        }

        public async Task UpdateAsync(ActorParticipante actorParticipante)
        {
            await _repository.UpdateAsync(actorParticipante);
        }
    }
}
