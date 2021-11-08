using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface IComunicacionRepository
    {

        //Permite hacer una consulta con where, insert, update,delete,etc.. a la entidad Solcitudes
        IQueryable<Comunicacion> Comunicaciones { get; }


        //Permite hacer un select * from
        Task<List<Comunicacion>> GetListAsync();
        
        Task<int> InsertAsync(Comunicacion entidad);
        Task UpdateAsync(Comunicacion entidad);

        Task DeleteAsync(Comunicacion entidad);

        Task<Comunicacion> GetByIdAsync(int idSolicitud);

       
    }
}
