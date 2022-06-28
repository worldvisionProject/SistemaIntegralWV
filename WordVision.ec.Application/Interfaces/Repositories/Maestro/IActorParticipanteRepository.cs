using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IActorParticipanteRepository
    {
        Task<ActorParticipante> GetByIdAsync(int id);
        Task<List<ActorParticipante>> GetListAsync(ActorParticipante actor);
        Task<int> InsertAsync(ActorParticipante actorParticipante);
        Task UpdateAsync(ActorParticipante actorParticipante);
    }
}
