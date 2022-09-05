using System.Net.Http.Headers;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public abstract class MangaProjectApiBase
    {
        public HttpClient client = new();

        public MangaProjectApiBase()
        {
            client.BaseAddress = new Uri("https://localhost:7164/api/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
