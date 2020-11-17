using IdentityServer4.Models;
using System.Collections.Generic;

namespace KaercherNet.IDP
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("kaerchernetApi", "Customer api for kaerchernet")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "kaerchernetApi" }
                }
            };
        }
    }
}
