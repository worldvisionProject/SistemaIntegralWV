using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Infrastructure.Data.Repositories.Soporte
{
    public class SolicitudRepository : ISolicitudRepository
    {

        private readonly IRepositoryAsync<Solicitud> _repository;
        private readonly IDistributedCache _distributedCache;
        public SolicitudRepository(IRepositoryAsync<Solicitud> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }

        public IQueryable<Solicitud> Solicitudes => _repository.Entities;



        public async Task DeleteAsync(Solicitud solicitud)
        {
            await _repository.DeleteAsync(solicitud);
        }

        public async Task<List<Solicitud>> GetListAsync()
        {
            return await _repository.Entities.Include(x => x.Colaboradores).Include(m => m.Mensajerias)
                .Include(m => m.Comunicaciones).Include(p => p.Comunicaciones.Ponentes)
                .Include(p => p.Comunicaciones.LogoSocios).ToListAsync();
        }

        public async Task<List<Solicitud>> GetListSolicitudxAsignadoAsync(int idAsignadoA)
        {
            return await _repository.Entities.Where(x => x.IdAsignadoA == idAsignadoA && (x.Estado == 2 || x.Estado == 3 || x.Estado == 4)).Include(x => x.Colaboradores).Include(m => m.Mensajerias)
                .Include(m => m.Comunicaciones).Include(p => p.Comunicaciones.Ponentes)
                .Include(p => p.Comunicaciones.LogoSocios).ToListAsync();
        }

        public async Task<Solicitud> GetByIdAsync(int idSolicitud)
        {
            return await _repository.Entities.Where(x => x.Id == idSolicitud).Include(x => x.Colaboradores).Include(m => m.Mensajerias)
                .Include(m => m.Comunicaciones)
                .Include(p => p.Comunicaciones.Ponentes)
                .Include(p => p.Comunicaciones.LogoSocios).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(Solicitud solicitud)
        {
            await _repository.AddAsync(solicitud);
            return solicitud.Id;
        }

        public async Task UpdateAsync(Solicitud solicitud)
        {
            await _repository.UpdateAsync(solicitud);
        }

        public async Task<List<Solicitud>> GetListSolicitudxSolicitanteAsync(int idSolicitante)
        {
            return await _repository.Entities.Where(x => x.IdColaborador == idSolicitante && x.TipoSistema == 1).Include(v => v.Colaboradores).Include(b => b.Mensajerias).ToListAsync();
        }

        public async Task<List<Solicitud>> GetListSolicitudxEstadoAsync(int idEstado)
        {
            return await _repository.Entities.Where(x => x.TipoSistema == 1)
                .Include(v => v.Colaboradores).Include(b => b.Mensajerias).ToListAsync();
        }

        public async Task<List<Solicitud>> GetListSolicitudxSolicitanteComunicaAsync(int idSolicitante)
        {
            return await _repository.Entities.Where(x => x.IdColaborador == idSolicitante && x.TipoSistema == 2).Include(v => v.Colaboradores)
                .Include(b => b.Comunicaciones)
                .Include(p => p.Comunicaciones.Ponentes)
                .Include(p => p.Comunicaciones.LogoSocios)
                .ToListAsync();

        }

        public async Task<List<Solicitud>> GetListSolicitudxEstadoComunicaAsync(int idEstado)
        {
            return await _repository.Entities.Where(x => x.TipoSistema == 2).Include(v => v.Colaboradores)
                .Include(b => b.Comunicaciones)
                .Include(p => p.Comunicaciones.Ponentes)
                .Include(p => p.Comunicaciones.LogoSocios)
                .ToListAsync();
        }
    }
}
