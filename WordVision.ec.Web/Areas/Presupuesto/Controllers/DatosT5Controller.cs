using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Presupuesto.DatosT5.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.DatosT5.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Presupuesto.Models;

namespace WordVision.ec.Web.Areas.Presupuesto.Controllers
{
    [Area("Presupuesto")]
    [Authorize]
    public class DatosT5Controller : BaseController<DatosT5Controller>
    {

        public IActionResult Index(int id)
        {
            var model = new DatosT5ViewModel();
            model.Id = id;
            return View(model);

        }



        public async Task<IActionResult> LoadDatosT5(int id = 0)
        {

            var response = await _mediator.Send(new GetAllDatosT5sCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<DatosT5ViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int idColaborador, DatosT5ViewModel datos)
        {

            try
            {
                int i = 0;
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    var filename = Path.GetFileName(file.FileName);
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Upload\\" + filename;
                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    List<DatosT5ViewModel> listaDatos = new List<DatosT5ViewModel>();
                    List<string> strContent = new List<string>();
                    using (var stream = new StreamReader(file.OpenReadStream()))
                    {
                        while (!stream.EndOfStream)
                        {
                            var linea = stream.ReadLine();
                            strContent.Add(linea);//agrego al List el contenido del archivo                   
                        }
                        i = 0;
                        foreach (var item in strContent.Skip(1))//salteo las cabeceras
                        {
                            var cells = item.Split(";");//separo por ;
                            DatosT5ViewModel D = new DatosT5ViewModel();
                            D.Codigo = cells[0];
                            D.Nombre = cells[1];
                            D.Cuentasop = cells[2];
                            D.T2 = cells[3];
                            D.DescripcionT2 = cells[4];
                            D.Tipo = 1;

                            var createLDRCommand = _mapper.Map<CreateDatosT5Command>(D);
                            var resultLDR = await _mediator.Send(createLDRCommand);
                            if (resultLDR.Succeeded)
                            {

                                i++;
                            }
                            else _notify.Error(resultLDR.Message);

                            listaDatos.Add(D);
                        }




                    }

                }

                _notify.Success($"{i} Registros almacenadas.");
                return new JsonResult(new { isValid = true });
            }
            catch (Exception ex)
            {
                _notify.Success($"Error al Insertar.");
                return new JsonResult(new { isValid = false });
            }

        }
    }

}
