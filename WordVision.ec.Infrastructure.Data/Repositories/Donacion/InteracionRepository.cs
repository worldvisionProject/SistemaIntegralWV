﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Donacion.Interaciones.Queries.GetAll;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Infrastructure.Data.Contexts;

namespace WordVision.ec.Infrastructure.Data.Repositories.Donacion
{
    public class InteracionRepository : IInteracionRepository
    {
        private readonly RegistroDbContext _db;
        private readonly IRepositoryAsync<Interacion> _repository;
        private readonly IRepositoryAsync<DetalleCatalogo> _repositoryDetalle;
        private readonly IRepositoryAsync<Debito> _repositoryDebito;


        public InteracionRepository(RegistroDbContext db, IRepositoryAsync<Interacion> repository, IRepositoryAsync<DetalleCatalogo> repositoryDetalle, IRepositoryAsync<Debito> repositoryDebito)
        {
            _repository = repository;
            _db = db;
            _repositoryDetalle = repositoryDetalle;
            _repositoryDebito = repositoryDebito;
        }

        public IQueryable<Interacion> interaciones => _repository.Entities;

        public Task<List<GetAllInteracionesResponse>> GetDebitoXDonante(int idDonante)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllInteracionesResponse>> GetInteracionXDonanteAsync(int idDonante, int tipo)// , int estadoCourier
        {


            var resultado1 = _repository.Entities.Where(x => x.IdDonante == idDonante && x.Tipo == tipo) // && (x.EstadoKitCourier == estadoCourier|| estadoCourier== 0)
                              .Select(a => new GetAllInteracionesResponse
                              {
                                  IdDonante = a.Id,
                                  DescGestion = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 70 && c.Secuencia == a.Gestion.ToString()).FirstOrDefault().Nombre,
                                  DescTipo = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 68 && c.Secuencia == a.Tipo.ToString()).FirstOrDefault().Nombre,
                                  Observacion = a.Observacion,
                                  DescEstadoKitCourier = _repositoryDetalle.Entities.Where(c => c.IdCatalogo == 72 && c.Secuencia == a.EstadoKitCourier.ToString()).FirstOrDefault().Nombre,
                                  FechaEntregaKit = a.FechaEntregaKit,
                                  NumeroGuiaKit = a.NumeroGuiaKit,
                                  Gestion = a.Gestion,
                                  Tipo = a.Tipo,
                                  EstadoKitCourier = a.EstadoKitCourier,
                                  CreatedBy = a.CreatedBy,
                                  CreatedOn = a.CreatedOn,

                              }
                              ).ToListAsync();
            return await resultado1;




        }




        //public async Task<List<Interacion>> GetInteracionXDonanteAsync(int idDonante, int tipo)
        //{
        //    return await _repository.Entities.Where(x => x.IdDonante == idDonante && x.Tipo == tipo).ToListAsync();

        //}

        public async Task<int> InsertAsync(Interacion interacion)
        {
            await _repository.AddAsync(interacion);
            return interacion.Id;
        }

        
    }
}
