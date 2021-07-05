using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WordVision.ec.Application.Interfaces.Shared;

namespace WordVision.ec.Api.Abstractions
{
    public abstract class BaseApiController<T> : ControllerBase
    {
        private IConfiguration _configurationInstance;
        private IWebHostEnvironment _envInstance;


        private IMediator _mediatorInstance;
        private ILogger<T> _loggerInstance;
   
        private IMapper _mapperInstance;
   
        protected IConfiguration _configuration => _configurationInstance ??= HttpContext.RequestServices.GetService<IConfiguration>();
        protected IWebHostEnvironment _env => _envInstance ??= HttpContext.RequestServices.GetService<IWebHostEnvironment>();
    
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
         protected IMapper _mapper => _mapperInstance ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
