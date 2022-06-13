using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IProyectoITTDIPRepository
    {
        Task<ProyectoITTDIP> GetByIdAsync(int id);
        Task<List<ProyectoITTDIP>> GetListAsync(ProyectoITTDIP entity);
        Task<int> InsertAsync(ProyectoITTDIP entity);
        Task UpdateAsync(ProyectoITTDIP entity);
    }
}
