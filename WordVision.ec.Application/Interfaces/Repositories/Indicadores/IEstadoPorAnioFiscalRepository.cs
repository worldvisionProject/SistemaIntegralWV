using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IEstadoPorAnioFiscalRepository
    {
        Task<EstadoPorAnioFiscal> GetByIdAsync(int id);
        Task<List<EstadoPorAnioFiscal>> GetListAsync(EstadoPorAnioFiscal entity);
        Task<int> InsertAsync(EstadoPorAnioFiscal entity);
        Task UpdateAsync(EstadoPorAnioFiscal entity);
    }
}
