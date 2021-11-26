using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetAllCached;
using WordVision.ec.Web.Abstractions;
using WordVision.ec.Web.Areas.Presupuesto.Models;

namespace WordVision.ec.Web.Areas.Presupuesto.Controllers
{
    [Area("Presupuesto")]
    [Authorize]
    public class DatosLDRController : BaseController<DatosLDRController>
    {
        public IActionResult Index(int id)
        {
            var model = new DatosLDRViewModel();
            model.Id = id;
            return View(model);

        }



        public async Task<IActionResult> LoadDatosLDR(int id = 0)
        {

            var response = await _mediator.Send(new GetAllDatosLDRsCachedQuery());
            if (response.Succeeded)
            {
                //DatosLDRViewModel r = new DatosLDRViewModel();
                //foreach (var l in response.Data)
                //{
                //    r.Identificacion=
                //}

                var viewModel = _mapper.Map<List<DatosLDRViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }


        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int idColaborador, DatosLDRViewModel datos)
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
                    List<DatosLDRViewModel> listaDatos = new List<DatosLDRViewModel>();
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
                            DatosLDRViewModel D = new DatosLDRViewModel();
                            D.Identificacion = cells[0];
                            D.Nombres = cells[1];
                            D.Area = cells[2];
                            D.Cargo = cells[3];
                            D.Ubicacion = cells[4];
                            D.T0 = cells[5];
                            D.T1 = cells[6];
                            D.T2 = cells[7];
                            D.T3 = cells[8];
                            D.T4 = cells[9];
                            D.T5 = cells[10];
                            D.T6 = cells[11];
                            D.T7 = cells[12];
                            D.T8 = cells[13];
                            D.T9 = cells[14];
                            D.FijoEventual = cells[15].ToString() == "X" ? "F" : "E";
                            D.Ldr = Convert.ToDecimal(cells[17].ToString());

                            var createLDRCommand = _mapper.Map<CreateDatosLDRCommand>(D);
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
