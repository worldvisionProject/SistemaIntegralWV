using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Identity;

namespace WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetById
{
    public class GetUsuarioByIdQuery : IRequest<Result<GetUsuarioByIdResponse>>
    {
        public string Id { get; set; }

        public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, Result<GetUsuarioByIdResponse>>
        {
            private readonly IIdentityCacheRepository _usuarioCache;
            private readonly IMapper _mapper;

            public GetUsuarioByIdQueryHandler(IIdentityCacheRepository usuarioCache, IMapper mapper)
            {
                _usuarioCache = usuarioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetUsuarioByIdResponse>> Handle(GetUsuarioByIdQuery query, CancellationToken cancellationToken)
            {
                var usuario = await _usuarioCache.GetByIdAsync(query.Id);
                var mappedUsuario = _mapper.Map<GetUsuarioByIdResponse>(usuario);
                return Result<GetUsuarioByIdResponse>.Success(mappedUsuario);
            }
        }
    }
}
