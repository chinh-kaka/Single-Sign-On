// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Kaercher.IDP
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("kaerchernet-api", "Implement API for KaercherNet")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "kaerchernet-webapp",
                    ClientName = "kaerchernet-project",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,


                    RedirectUris =           { "http://localhost:4200/signin-callback", "http://localhost:4200/assets/silent-callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback" },
                    AllowedCorsOrigins =     { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "kaerchernet-api"
                    },
                    AccessTokenLifetime = 600
                },
            };

        }
    }
}