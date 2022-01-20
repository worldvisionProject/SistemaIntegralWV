using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IResponsabilidadRepository
    {
        IQueryable<Responsabilidad> responsabilidades { get; }

        Task<List<Responsabilidad>> GetListAsync();
        Task<Responsabilidad> GetByIdAsync(int responsabilidadId);
        Task<List<ResponsabilidadResponse>> GetListPadreAsync(int idEstructura);
        Task<List<Responsabilidad>> GetListxPadreAsync(int idPadre);
        Task<int> InsertAsync(Responsabilidad responsabilidad);

        Task UpdateAsync(Responsabilidad responsabilidad);

        Task DeleteAsync(Responsabilidad responsabilidad);
    }
}
