using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Donacion
{
    public interface IInteracionRepository
    {
        IQueryable<Interacion> interacion { get; }

        Task<int> InsertAsync(Interacion interacion);

       

        Task UpdateAsync(Interacion interacion);

        Task DeleteAsync(Interacion interacion);

        Task<Interacion> GetInteracionAsync(int idInteracion);


        Task<Interacion> GetByIdAsync(int idInteracion);


    }
}
