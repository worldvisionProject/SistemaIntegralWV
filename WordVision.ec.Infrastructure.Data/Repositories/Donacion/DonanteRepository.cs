using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Infrastructure.Data.Contexts;

namespace WordVision.ec.Infrastructure.Data.Repositories.Donacion
{



    public class DonanteRepository : IDonanteRepository

    {
        private readonly RegistroDbContext _db;
        private readonly IRepositoryAsync<Donante> _repository;
        private readonly IRepositoryAsync<DetalleCatalogo> _repositoryDetalle;
        private readonly IDistributedCache _distributedCache;

        public DonanteRepository(IRepositoryAsync<DetalleCatalogo> repositoryDetalle,RegistroDbContext db,IRepositoryAsync<Donante> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _db = db;
            _repositoryDetalle = repositoryDetalle;
        }

        public IQueryable<Donante> donantes => _repository.Entities;


        public async Task DeleteAsync(Donante donante)
        {
            await _repository.DeleteAsync(donante);
        }


        public async Task<Donante> GetDonantesAsync(int idDonante)
        {
            return await _repository.Entities.Where(x => x.Id == idDonante).FirstOrDefaultAsync();
        }

        public async Task<List<Donante>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Donante donante)
        {
            await _repository.AddAsync(donante);
            return donante.Id;
        }

        public async Task UpdateAsync(Donante donante)
        {
            await _repository.UpdateAsync(donante);
        }

        public async Task<Donante> GetByIdAsync(int idDonante)
        {
            return await _repository.Entities.Where(x => x.Id == idDonante).FirstOrDefaultAsync();
        }

        public async Task<List<ReporteDonantesResponse>> GetReporteDonantesAsync(DateTime fechaDesde, DateTime fechaHasta, int tipoDonante, int formaPago, int estadoDonante)
        {
            _db.Database.SetCommandTimeout(TimeSpan.FromMinutes(20));
            var resultado1 = _repository.Entities.Where(c => (c.Tipo==tipoDonante || tipoDonante==0) && (c.FormaPago == formaPago || formaPago == 0) && (c.EstadoDonante == estadoDonante || estadoDonante == 0) && (fechaDesde >=  c.FechaConversion && c.FechaConversion <= fechaHasta ))
                                    .Select(a => new ReporteDonantesResponse
                                    {
                                        Id =a.Id ,
                                        FechaCaptacion =Convert.ToDateTime( a.FechaConversion) ,
                                        Canal = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 22 && c.Secuencia == a.Canal.ToString()).FirstOrDefault().Nombre,
                                        Frecuencia = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 34 && c.Secuencia == a.FrecuenciaDonacion.ToString()).FirstOrDefault().Nombre,
                                        Genero = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 28 && c.Secuencia == a.Genero.ToString()).FirstOrDefault().Nombre,
                                        //Provincia = ,
                                        NombreDonante = a.Apellido1+" "+a.Apellido2+" "+a.Nombre1 + " " + a.Nombre2,
                                        Nombre1 = a.Nombre1,
                                        Nombre2 = a.Nombre2,
                                        Apellido1 = a.Apellido1,
                                        Apellido2 = a.Apellido2,
                                        Identificacion =a.RUC ,
                                        FormaPago = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 21 && c.Secuencia == a.FormaPago.ToString()).FirstOrDefault().Nombre,
                                        //EntidadBancaria = ,
                                        TipoCuenta = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 25 && c.Secuencia == a.TipoCuenta.ToString()).FirstOrDefault().Nombre,
                                        Cuenta = a.NumeroCuenta,
                                        Valor =a.Cantidad ,

                                        //Mes = ,
                                        //Anio = ,
                                        CodigoSCI = Convert.ToInt32(a.Banco),
                                        Categoria = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 25 && c.Secuencia == a.Categoria.ToString()).FirstOrDefault().Nombre,
                                        TipoDonante = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 24 && c.Secuencia == a.Tipo.ToString()).FirstOrDefault().Nombre,
                                        //EstadoDebito = ,
                                        //FechaDebito = ,
                                        Estado = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 27 && c.Secuencia == a.EstadoDonante.ToString()).FirstOrDefault().Nombre,


                                    }
                                    ).ToListAsync();

            return await resultado1;
        }
    }
}
