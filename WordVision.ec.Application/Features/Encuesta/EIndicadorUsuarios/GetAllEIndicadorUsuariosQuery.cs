using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadorUsuarios
{
    public class GetAllEIndicadorUsuariosResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EIndicadorId { get; set; }

    }
    public class GetAllEIndicadorUsuariosQuery : IRequest<Result<List<GetAllEIndicadorUsuariosResponse>>>
    {
        public GetAllEIndicadorUsuariosQuery()
        {
        }
        public class GetAllEIndicadorUsuariosQueryHandler : IRequestHandler<GetAllEIndicadorUsuariosQuery, Result<List<GetAllEIndicadorUsuariosResponse>>>
        {
            private readonly IEIndicadorUsuarioRepository _eIndicadorUsuario;
            private readonly IMapper _mapper;

            public GetAllEIndicadorUsuariosQueryHandler(IEIndicadorUsuarioRepository eIndicadorUsuario,
                                                    IMapper mapper)
            {
                _eIndicadorUsuario = eIndicadorUsuario;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEIndicadorUsuariosResponse>>> Handle(GetAllEIndicadorUsuariosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EIndicadorUsuarioList = await _eIndicadorUsuario.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEIndicadorUsuariosResponse
                var mappedEIndicadorUsuarios = _mapper.Map<List<GetAllEIndicadorUsuariosResponse>>(EIndicadorUsuarioList);

                return Result<List<GetAllEIndicadorUsuariosResponse>>.Success(mappedEIndicadorUsuarios);
            }
        }




    }

}
