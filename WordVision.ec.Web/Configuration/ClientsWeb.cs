
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Web.Configuration
{
    public static class ClientsWeb
    {
        static string[] allowedScopes =
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Email
        };

        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "interactive.confidential",
                    ClientName = "interactive.confidential",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequirePkce = false,
                    RequireConsent = true,
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "http://localhost/idsrv/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost/idsrv/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost/idsrv/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                },
            };
        }
    }

}
