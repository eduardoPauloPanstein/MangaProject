using Entities.MangaS;
using Newtonsoft.Json;
using Shared;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Mangas
{
    public class MangaService : MangaProjectApiBase, IMangaService
    {
        public Task<Response> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Manga item)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<Manga>> Select(string title)
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.GetAsync($"Manga/{title}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<DataResponse<Manga>>(data);
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse<Manga>(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(ex);
            }
        }

        public Task<SingleResponse<Manga>> Select(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Manga>> Select(int skip = 0, int take = 25)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Manga item)
        {
            throw new NotImplementedException();
        }
    }
}
