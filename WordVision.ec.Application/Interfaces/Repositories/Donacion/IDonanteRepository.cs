using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Donacion
{
    public interface IDonanteRepository
    {
        IQueryable<Donante> donantes { get; }
        Task<List<Donante>> GetListAsync();

        Task<int> InsertAsync(Donante donante);

        Task UpdateAsync(Donante donante);
        Task DeleteAsync(Donante donante);
        Task<Donante> GetDonantesAsync(int idDonante);
        Task<Donante> GetByIdAsync(int idDonante);

        Task<List<ReporteDonantesResponse>> GetReporteDonantesAsync(DateTime fechaDesde, DateTime fechaHasta, int tipoDonante, int formaPago, int estadoDonante);
    }
}
