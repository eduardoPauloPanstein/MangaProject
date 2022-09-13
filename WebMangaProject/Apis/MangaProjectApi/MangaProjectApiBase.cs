﻿using MvcPresentationLayer.Utilities;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public abstract class MangaProjectApiBase
    {
        public HttpClient client = new();

        public MangaProjectApiBase()
        {
            client.BaseAddress = new Uri("https://localhost:7164/api/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ////First get user claims    
            //var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

            ////Filter specific claim    
            //var token = (claims?.FirstOrDefault(x => x.Type.Equals("Token", StringComparison.OrdinalIgnoreCase))?.Value);

            //if (token != null)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}

        }
    }
}
