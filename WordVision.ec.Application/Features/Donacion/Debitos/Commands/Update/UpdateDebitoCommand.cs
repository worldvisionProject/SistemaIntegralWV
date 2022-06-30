using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Commands.Update
{
    public class UpdateDebitoCommand : IRequest<Result<int>>
    {
        public List<GetDebitosByIdResponse> ListaDebitos { get; set; }
        public class UpdateDebitoCommandHandler : IRequestHandler<UpdateDebitoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDebitoRepository _debitoRepository;
            private readonly IMapper _mapper;

            public UpdateDebitoCommandHandler(IDebitoRepository debitoRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _debitoRepository = debitoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateDebitoCommand command, CancellationToken cancellationToken)
            {
                foreach (var item in command.ListaDebitos)
                {
                    var debito = await _debitoRepository.GetByContrapartidaAsync(item.FormaPago, item.CodigoBanco, item.Anio, item.Mes, item.Contrapartida);
                    if (debito != null)
                    {
                        debito.Estado = 2;
                        debito.FechaDebito = Convert.ToDateTime(item.FechaDebito);
                        debito.CodigoRespuesta = item.CodigoRespuesta;
                        await _debitoRepository.UpdateAsync(debito);//INsertar a la BBDD

                    }


                }


                await _unitOfWork.Commit(cancellationToken);//commit
                return Result<int>.Success(1);

            
            }
        }


    }
}
