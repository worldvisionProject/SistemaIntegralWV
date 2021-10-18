using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface IMensajeriaRepository
    {

        //Permite hacer una consulta con where, insert, update,delete,etc.. a la entidad Solcitudes
        IQueryable<Mensajeria> Mensajeriaes { get; }


        //Permite hacer un select * from
        Task<List<Mensajeria>> GetListAsync();
        
        Task<int> InsertAsync(Mensajeria entidad);
        Task UpdateAsync(Mensajeria entidad);

        Task DeleteAsync(Mensajeria entidad);

        Task<Mensajeria> GetByIdAsync(int idSolicitud);

       
    }
}
