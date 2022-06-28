using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface  ISeguimientoObjetivoRepository
    {
        IQueryable<SeguimientoObjetivo> seguimientoObjetivos { get; }

        Task<SeguimientoObjetivo> GetSeguimientoxColaboradorAsync(int idColaborador, int idAnioFiscal);
      
        Task<int> InsertAsync(SeguimientoObjetivo seguimientoObjetivo);

        Task UpdatexTodoAsync(int idColaborador, int idAnioFiscal);

        Task UpdateAsync(SeguimientoObjetivo seguimientoObjetivo);

        Task DeleteAsync(SeguimientoObjetivo seguimientoObjetivo);
    }
}
