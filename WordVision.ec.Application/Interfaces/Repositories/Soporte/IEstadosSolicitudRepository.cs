using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface IEstadosSolicitudRepository
    {
        //Permite hacer una consulta con where, insert, update,delete,etc.. a la entidad Solcitudes
        IQueryable<EstadosSolicitud> estadosSolicitudes { get; }

        //Permite hacer un select * from
        Task<List<EstadosSolicitud>> GetListAsync();

        Task<int> InsertAsync(EstadosSolicitud estadosSolicitud);

        Task UpdateAsync(EstadosSolicitud estadosSolicitud);

        Task DeleteAsync(EstadosSolicitud estadosSolicitud);

      


    }
}
