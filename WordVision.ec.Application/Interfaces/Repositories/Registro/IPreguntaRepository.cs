using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IPreguntaRepository
    {
        IQueryable<Pregunta> Preguntas { get; }

        Task<List<Pregunta>> GetListAsync();

        Task<Pregunta> GetByIdAsync(int preguntaId);

        Task<List<Pregunta>> GetByIdDocumentoAsync(int documentoId);

        Task<int> InsertAsync(Pregunta pregunta);

        Task UpdateAsync(Pregunta pregunta);

        //Task DeleteAsync(Pregunta pregunta);
    }
}
