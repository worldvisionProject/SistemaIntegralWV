using IdentityServer4.Models;
using System.Collections.Generic;

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
