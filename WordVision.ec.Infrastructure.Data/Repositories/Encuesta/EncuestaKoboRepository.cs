using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Encuesta;
using WordVision.ec.Application.DTOs.Encuesta;
using System;
using Newtonsoft.Json.Linq;

namespace WordVision.ec.Infrastructure.Data.Repositories.Encuesta
{

    public class EncuestaKoboRepository : IEncuestaKoboRepository
    {
        private readonly IRepositoryAsync<EncuestaKobo> _repository;

        public EncuestaKoboRepository(IRepositoryAsync<EncuestaKobo> repository)
        {
            _repository = repository;
        }

        public IQueryable<EncuestaKobo> EncuestaKobos => _repository.Entities;
        public async Task<List<EncuestaKobo>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<EncuestaKobo> GetByIdAsync(int idEncuestaKobo)
        {
            return await _repository.Entities.Where(x => x.Id == idEncuestaKobo).FirstOrDefaultAsync();
        }
        public async Task<List<EncuestaKobo>> GetKoboAPIAsync()
        {
            //Esta funcion trae un listado de encuestas (no las respuestas) del API de Kobo
            List<EncuestaKoboAPIResponse> ListadoEncuestaKoboAPI = new List<EncuestaKoboAPIResponse>();

            using(var httpCliente = new HttpClient())
            {
                //Ponemos la seguridad en la cabecera
                Encoding ascii = Encoding.ASCII;
                httpCliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(ascii.GetBytes("super_admin" + ":" + "wve**Bio*_?2022")));

                //Ejecutamos la consulta del API
                using var respuesta = await httpCliente.GetAsync("https://kc.visionmundial.org.ec/api/v1/data");
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();
                ListadoEncuestaKoboAPI = JsonConvert.DeserializeObject<List<EncuestaKoboAPIResponse>>(respuestaAPI);

                ////************* De la respuesta del API le ponemos en una variable dinamica
                //dynamic d1 = new List<JArray>();
                //d1 = JArray.Parse(respuestaAPI);

                ////Del primer registro vamos a iterar con las propiedades para insertar en PreguntaKobos
                //foreach (JProperty property in d1[0].Properties())
                //{
                //    Console.WriteLine(property.Name + " - " + property.Value);
                //}

                ////************* Mapeamos el resultado del API en la clase modelo para que posteriormente se inserte en la base de datos
                //JArray d2 = JArray.Parse(respuestaAPI);
                //IList<EncuestaKobo> encuestaKoboJS = d2.Select(p => new EncuestaKobo
                //{
                //    Id = (int)p["id"],
                //    enk_Id_string = (string)p["id_string"],
                //    enk_Title = (string)p["title"],
                //    enk_Description = (string)p["description"],
                //    enk_Url = (string)p["url"]
                //}).ToList();

                //************* Vamos a iterar con todos los registros para insertar en EncuestadoKobos
                //foreach (EncuestaKobo fila in encuestaKoboJS)
                //{
                //    //Insertar en la base de datos.
                //    await _repository.AddAsync(fila);
                //}


            }

            //Mapeamos al respuesta del API al objeto modelo
            List<EncuestaKobo> modelo = new List<EncuestaKobo>();
            foreach(var respuesta in ListadoEncuestaKoboAPI)
            {
                EncuestaKobo filaEncuestaKobo = new EncuestaKobo();
                filaEncuestaKobo.Id = respuesta.Id;
                filaEncuestaKobo.enk_Id_string = respuesta.id_string;
                filaEncuestaKobo.enk_Title = respuesta.title;
                filaEncuestaKobo.enk_Description = respuesta.description;
                filaEncuestaKobo.enk_Url = respuesta.url;
                filaEncuestaKobo.enk_Fecha = System.DateTime.Now;
                modelo.Add(filaEncuestaKobo);
            }
            return modelo;
        }


        public async Task<int> InsertAsync(EncuestaKobo encuestaKobo)
        {
            await _repository.AddAsync(encuestaKobo);
            return encuestaKobo.Id;
        }
        public async Task UpdateAsync(EncuestaKobo encuestaKobo)
        {
            await _repository.UpdateAsync(encuestaKobo);
        }
        public async Task DeleteAsync(EncuestaKobo encuestaKobo)
        {
            await _repository.DeleteAsync(encuestaKobo);
        }


    }
}
