using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace KaercherNet.IDP
{
    //public class Config
    //{
    //    public static List<TestUser> GetUsers()
    //    {
    //        return new List<TestUser>
    //        {
    //            new TestUser { SubjectId = "1", Username = "kaka", Password = "P@ssword123" }
    //        };
    //    }

    //    public static IEnumerable<ApiScope> ApiScopes()
    //    {
    //        return new List<ApiScope>
    //        {
    //            new ApiScope("kaerchernetApi", "Customer api for kaerchernet")
    //        };
    //    }

    //    public static IEnumerable<Client> Clients()
    //    {
    //        return new List<Client>
    //        {
    //            new Client
    //            {
    //                ClientId = "client",
    //                AllowedGrantTypes = GrantTypes.ClientCredentials,
    //                ClientSecrets =
    //                {
    //                    new Secret("secret".Sha256())
    //                },
    //                AllowedScopes = { "kaerchernetApi" }
    //            }
    //        };
    //    }
    //}

    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "kaka",
                    Password = "P@ssword123"
                }
            };
        }

        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("kaerchernetApi", "Customer Api for kaerchernet")
            };
        }

        public static IEnumerable<Client> GetClients()
        {

            return new List<Client>
            {
                //Client-Credential based grant type
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "kaerchernetApi" }
                },

                //Resource Owner Password grant type
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "kaerchernetApi" }
                },

                //Implicit Flow Grant Type
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { "http://localhost:5005/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5005/signout-callback-oidc"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                 //Swagger Client
                new Client
                {
                    ClientId = "swaggerapiui",
                    ClientName = "Swagger API UI",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { "http://localhost:5005/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { "http://localhost:5005/swagger"},

                    AllowedScopes = { "kaerchernetApi" },
                    AllowAccessTokensViaBrowser = true
                }
            };
        }
    }
}
