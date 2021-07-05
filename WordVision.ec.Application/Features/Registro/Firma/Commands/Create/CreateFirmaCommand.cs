using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Firma.Commands.Create
{
    public class CreateFirmaCommand :  IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
      
        public int IdDocumento { get; set; }

        public byte[] Image { get; set; }
    }

    public class CreateFirmaCommandHandler : IRequestHandler<CreateFirmaCommand, Result<int>>
    {
        private readonly IFirmaRepository _firmaRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateFirmaCommandHandler(IFirmaRepository firmaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _firmaRepository = firmaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateFirmaCommand request, CancellationToken cancellationToken)
        {
            var colaborador = await _firmaRepository.GetByIdColaboradorAsync(request.IdColaborador,request.IdDocumento);

            if (colaborador == null)
            {
                var firma = _mapper.Map<WordVision.ec.Domain.Entities.Registro.Firma>(request);
                await _firmaRepository.InsertAsync(firma);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(firma.Id);
            }
            else
            {
                colaborador.IdColaborador = request.IdColaborador==0 ? colaborador.IdColaborador: request.IdColaborador;
                colaborador.IdDocumento = request.IdDocumento == 0 ? colaborador.IdDocumento : request.IdDocumento;
                colaborador.Image = request.Image ?? colaborador.Image;
                
                await _firmaRepository.UpdateAsync(colaborador);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(colaborador.Id);
            }

            
        }
    }

}
