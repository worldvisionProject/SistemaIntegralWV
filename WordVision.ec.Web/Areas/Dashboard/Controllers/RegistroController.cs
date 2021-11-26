using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.DashBoards.Queries.GetAllDashBoards;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Dashboard.Models;

namespace WordVision.ec.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class RegistroController : BaseController<RegistroController>
    {
        public async Task<IActionResult> Index()
        {
            RegistroDashBoardViewModel viewModel = new RegistroDashBoardViewModel();
            var response = await _mediator.Send(new GetDashBoardsQuery());
            if (response.Succeeded)
            {
                viewModel = _mapper.Map<RegistroDashBoardViewModel>(response.Data);
                return View(viewModel);
            }
            return View(viewModel);
        }


    }
}
