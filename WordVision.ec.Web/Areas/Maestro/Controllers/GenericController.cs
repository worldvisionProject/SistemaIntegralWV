using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using WordVision.ec.Web.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Create;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Update;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetAll;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetById;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Web.Areas.Maestro.Models;
using WordVision.ec.Web.Common;
using WordVision.ec.Web.Common.Constants;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.Extensions.Logging;

namespace WordVision.ec.Web.Areas.Maestro.Controllers
{
    public class GenericController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        
    }
}
