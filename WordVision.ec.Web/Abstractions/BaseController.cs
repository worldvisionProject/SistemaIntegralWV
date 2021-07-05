using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WordVision.ec.Application.Interfaces.Shared;

namespace WordVision.ec.Web.Abstractions
{
    public abstract class BaseController<T> : Controller
    {
        private IConfiguration _configurationInstance;
        private IEmailSender _emailSenderInstance;
        private IWebHostEnvironment _envInstance;


        private IMediator _mediatorInstance;
        private ILogger<T> _loggerInstance;
        private IViewRenderService _viewRenderInstance;
        private IMapper _mapperInstance;
        private INotyfService _notifyInstance;

        protected IEmailSender _emailSender => _emailSenderInstance ??= HttpContext.RequestServices.GetService<IEmailSender>();
        protected IConfiguration _configuration => _configurationInstance ??= HttpContext.RequestServices.GetService<IConfiguration>();
        protected IWebHostEnvironment _env => _envInstance ??= HttpContext.RequestServices.GetService<IWebHostEnvironment>();
        protected INotyfService _notify => _notifyInstance ??= HttpContext.RequestServices.GetService<INotyfService>();

        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        protected IViewRenderService _viewRenderer => _viewRenderInstance ??= HttpContext.RequestServices.GetService<IViewRenderService>();
        protected IMapper _mapper => _mapperInstance ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
