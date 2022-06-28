using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IProyectoITTRepository
    {
        Task<ProyectoITT> GetByIdAsync(int id);
        Task<List<ProyectoITT>> GetListAsync(ProyectoITT entity);
        Task<int> InsertAsync(ProyectoITT entity);
        Task UpdateAsync(ProyectoITT entity);
    }
}
