using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Update
{
    public class UpdateMetaEstrategicaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdGestion { get; set; }
        public ICollection<MetaEstrategica> MetaEstrategicas { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateMetaEstrategicaCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMetaEstrategicaRepository _metaEstrategicaRepository;
            private readonly IIndicadorEstrategicoRepository _indicadorEstrategicoRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IIndicadorEstrategicoRepository indicadorEstrategicoRepository, IMetaEstrategicaRepository metaEstrategicaRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _metaEstrategicaRepository = metaEstrategicaRepository;
                _indicadorEstrategicoRepository = indicadorEstrategicoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateMetaEstrategicaCommand command, CancellationToken cancellationToken)
            {
                var IndicadorEstrategico = await _indicadorEstrategicoRepository.GetByIdAsync(command.Id,0);

                if (IndicadorEstrategico == null)
                {
                    return Result<int>.Fail($"IndicadorEstrategico no encontrado.");
                }
                else
                {

                    var idGestion = command.IdGestion;
                    foreach (var indicador in command.MetaEstrategicas)
                    {
                        var indicadorAF = await _metaEstrategicaRepository.GetByIdAsync(indicador.Id);
                        if (indicadorAF == null)
                        {
                            var _indicadorAF = _mapper.Map<MetaEstrategica>(indicador);
                            _indicadorAF.IdIndicadorEstrategico = IndicadorEstrategico.Id;
                            _indicadorAF.IdGestion = idGestion;
                            await _metaEstrategicaRepository.InsertAsync(_indicadorAF);
                        }
                        else
                        {
                            indicadorAF.IdGestion = idGestion;
                            indicadorAF.NumMeses = indicador.NumMeses;
                            indicadorAF.TipoMedida = indicador.TipoMedida;
                            indicadorAF.Valor = indicador.Valor;
                            await _metaEstrategicaRepository.UpdateAsync(indicadorAF);
                        }


                    }

                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(IndicadorEstrategico.Id);
                }
            }
        }

    }
}
