using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Configuration
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            var clients = new List<Client>();

            clients.AddRange(ClientsWeb.Get());

            return clients;
        }
    }
}
