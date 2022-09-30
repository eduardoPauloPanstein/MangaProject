using Entities.AnimeS;
using MvcPresentationLayer.Apis.MangaProjectApi.Mangas;
using Newtonsoft.Json;
using Shared;
using Shared.Responses;
using System.Net.Http.Headers;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Animes
{
    public class MangaProjectApiAnimeService : MangaProjectApiBase, IMangaProjectApiAnimeService
    {
        public async Task<Response> Delete(int? id, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using HttpResponseMessage responseHttp = await client.DeleteAsync($"Manga/{id}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedSingleResponse<Anime>();
                }
                return JsonConvert.DeserializeObject<Response>(await responseHttp.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Insert(Anime item, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string serialized = JsonConvert.SerializeObject(item);
                using HttpResponseMessage responseHttp = await client.PostAsJsonAsync("Anime", serialized);

                var response = JsonConvert.DeserializeObject<Response>(responseHttp.Content.ReadAsStringAsync().Result);

                if (responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
                return ResponseFactory.CreateInstance().CreateFailedResponse(response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<DataResponse<Anime>> Get(string title)
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByName/{title}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<DataResponse<Anime>>(data);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData<Anime>(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(ex);
            }
        }

        public async Task<SingleResponse<Anime>> Get(int? id, string? token)
        {
            try
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ById/{id}");

                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedSingleResponse<Anime>();
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<SingleResponse<Anime>>(data);
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse<Anime>(dataResponse.Item);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponse<Anime>(ex);
            }
        }

        public async Task<DataResponse<Anime>> Get(string? token, int skip = 0, int take = 25)
        {
            try
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/skip/{skip}/take/{take}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<DataResponse<Anime>>(data);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(ex);
            }
        }

        public async Task<DataResponse<Anime>> GetByFavorites(int skip = 0, int take = 25)
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByFavorites/skip/{skip}/take/{take}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<DataResponse<Anime>>(data);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(ex);
            }
        }

        public async Task<DataResponse<Anime>> GetByUserCount(int skip = 0, int take = 25)
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByUserCount/skip/{skip}/take/{take}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<DataResponse<Anime>>(data);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(ex);
            }
        }

        public async Task<Response> Update(Anime item, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string serialized = JsonConvert.SerializeObject(item);
                using HttpResponseMessage responseHttp = await client.PutAsJsonAsync($"Anime/{item.Id}", serialized);

                var response = JsonConvert.DeserializeObject<Response>(responseHttp.Content.ReadAsStringAsync().Result);

                if (responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
                return ResponseFactory.CreateInstance().CreateFailedResponse(response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<DataResponse<Anime>> GetByRating(int skip, int take)
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByRating/skip/{skip}/take/{take}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<DataResponse<Anime>>(data);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(ex);
            }
        }
    }
}
