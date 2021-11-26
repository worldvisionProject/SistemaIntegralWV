using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Infrastructure.Data.Repositories.Mensajeria
{
    public class EmailRepository : IEmailRepository
    {

        private readonly IRepositoryAsync<Email> _repository;
        private readonly IDistributedCache _distributedCache;
        public EmailRepository(IRepositoryAsync<Email> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }
        public IQueryable<Email> emails => _repository.Entities;

        public IQueryable<Email> solicitudes => throw new NotImplementedException();

        public async Task DeleteAsync(Email emails)
        {
            await _repository.DeleteAsync(emails);
        }




        public async Task<List<Email>> GetEmailAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<Email> GetEmailAsync(int idEmail)
        {
            return await _repository.Entities.Where(x => x.Id == idEmail).FirstOrDefaultAsync();
        }

        public async Task<List<Email>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Email>> GetListSolicitudxAsignadoAsync(string asignadoA)
        {
            return await _repository.Entities.Where(x => x.PersonaEnvioEmail == asignadoA).ToListAsync();
        }

        public async Task<int> InsertAsync(Email email)
        {
            await _repository.AddAsync(email);
            return email.Id;
        }

        public async Task UpdateAsync(Email emails)
        {
            await _repository.UpdateAsync(emails);
        }
    }
}
