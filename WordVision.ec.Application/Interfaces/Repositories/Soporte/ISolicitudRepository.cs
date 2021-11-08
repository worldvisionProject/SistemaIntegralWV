using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface ISolicitudRepository
    {


        //Permite hacer una consulta con where, insert, update,delete,etc.. a la entidad Solcitudes
        IQueryable<Solicitud> Solicitudes { get; }


        //Permite hacer un select * from
        Task<List<Solicitud>> GetListAsync();
        
        Task<int> InsertAsync(Solicitud solicitud);

        Task UpdateAsync(Solicitud solicitud);

        Task DeleteAsync(Solicitud solicitud);

        Task<Solicitud> GetByIdAsync(int idSolicitud);

        Task<List<Solicitud>> GetListSolicitudxAsignadoAsync(int idAsignadoA);

        Task<List<Solicitud>> GetListSolicitudxSolicitanteAsync(int idSolicitante);

        Task<List<Solicitud>> GetListSolicitudxSolicitanteComunicaAsync(int idSolicitante);

        Task<List<Solicitud>> GetListSolicitudxEstadoAsync(int idEstado);
    }
}
