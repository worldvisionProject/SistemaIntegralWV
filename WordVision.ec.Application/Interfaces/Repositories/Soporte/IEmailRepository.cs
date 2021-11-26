using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Interfaces.Repositories.Soporte
{
    public interface IEmailRepository
    {
        IQueryable<Email> solicitudes { get; }


        //Permite hacer un select * from
        Task<List<Email>> GetListAsync();

        Task<int> InsertAsync(Email email);

        Task UpdateAsync(Email email);
        Task DeleteAsync(Email email);
        Task<Email> GetEmailAsync(int idEmail);
        Task<List<Email>> GetListSolicitudxAsignadoAsync(string AsignadoA);

    }
}
