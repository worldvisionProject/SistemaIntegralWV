using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Models;

namespace WordVision.ec.Web.Services
{
    public class IdentityWindowsService
    {
        private readonly IConfiguration _configurations;
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public IdentityWindowsService(
            IConfiguration configurations,
            IHttpClientFactory clientFactory)
        {
            _configurations = configurations;
            _clientFactory = clientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<IdentityWindows> GetUserWindows(string userWindows)
        {
            try
            {
                              
                var client = _clientFactory.CreateClient("windowsAuthClient");
                client.BaseAddress = new Uri(_configurations["IdentityApiUrl"]);
                // api / Identity / FindDomainUser /{ search}
                var response = await client.GetAsync("api/Identity/FindDomainUser/"+ userWindows);
                if (response.IsSuccessStatusCode)
                {
                    var data = await JsonSerializer.DeserializeAsync<IdentityWindows>(
                    await response.Content.ReadAsStreamAsync());

                    return data;
                }

                var error = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Status code: {response.StatusCode}, Error: {response.ReasonPhrase}, Message: {error}");

            }
            catch (Exception e)
            {
                throw new Exception($"Exception {e}");
            }
        }

        //public async Task<List<ColaboradorViewModel>> Suggest(string term)
        //{
        //    try
        //    {
        //        var client = _clientFactory.CreateClient("windowsAuthClient");
        //        client.BaseAddress = new Uri(_configurations["MyApiUrl"]);

        //        var response = await client.GetAsync($"api/AutoCompleteSearch?term={term}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = await JsonSerializer.DeserializeAsync<List<ColaboradorViewModel>>(
        //            await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions);

        //            return data;
        //        }

        //        var error = await response.Content.ReadAsStringAsync();
        //        throw new ApplicationException($"Status code: {response.StatusCode}, Error: {response.ReasonPhrase}, Message: {error}");

        //    }
        //    catch (Exception e)
        //    {
        //        throw new ApplicationException($"Exception {e}");
        //    }
        //}
    }
}
