﻿using Entities.AnimeS;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Shared;
using Shared.Models.Anime;
using Shared.Responses;
using System.Net.Http.Headers;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Animes
{
    public class MangaProjectApiAnimeService : MangaProjectApiBase, IMangaProjectApiAnimeService
    {
        private readonly IDistributedCache _distributedCache;

        public MangaProjectApiAnimeService(IDistributedCache distributedCache)
        {
            this._distributedCache = distributedCache;
        }

        public async Task<Response> Delete(int? id, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using HttpResponseMessage responseHttp = await client.DeleteAsync($"Anime/{id}");
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
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(ex);
            }
        }

        public async Task<SingleResponse<Anime>> Get(int id, string? token)
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

        public async Task<DataResponse<AnimeCatalog>> GetByFavorites(int skip = 0, int take = 25)
        {
            try
            {
                var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetByFavorites);
                if (json != null)
                {
                    var animeCatalog = JsonConvert.DeserializeObject<List<AnimeCatalog>>(json);
                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(animeCatalog);
                }
                else
                {
                    using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByFavorites/skip/{skip}/take/{take}");
                    if (!responseHttp.IsSuccessStatusCode)
                    {
                        return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(null);
                    }
                    var data = await responseHttp.Content.ReadAsStringAsync();
                    var dataResponse = JsonConvert.DeserializeObject<DataResponse<AnimeCatalog>>(data);

                    json = JsonConvert.SerializeObject(dataResponse.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Anime.GetByFavorites, json);

                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(ex);
            }

        }

        public async Task<DataResponse<AnimeCatalog>> GetByUserCount(int skip = 0, int take = 25)
        {
            try
            {
                var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetByUserCount);
                if (json != null)
                {
                    var animeCatalog = JsonConvert.DeserializeObject<List<AnimeCatalog>>(json);
                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(animeCatalog);
                }
                else
                {
                    using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByUserCount/skip/{skip}/take/{take}");
                    if (!responseHttp.IsSuccessStatusCode)
                    {
                        return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(null);
                    }
                    var data = await responseHttp.Content.ReadAsStringAsync();
                    var dataResponse = JsonConvert.DeserializeObject<DataResponse<AnimeCatalog>>(data);

                    json = JsonConvert.SerializeObject(dataResponse.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Anime.GetByUserCount, json);

                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(ex);
            }
        }

        public async Task<DataResponse<AnimeCatalog>> GetByRating(int skip, int take)
        {
            try
            {
                var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetByRating);
                if (json != null)
                {
                    var animeCatalog = JsonConvert.DeserializeObject<List<AnimeCatalog>>(json);
                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(animeCatalog);
                }
                else
                {
                    using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByRating/skip/{skip}/take/{take}");
                    if (!responseHttp.IsSuccessStatusCode)
                    {
                        return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(null);
                    }
                    var data = await responseHttp.Content.ReadAsStringAsync();
                    var dataResponse = JsonConvert.DeserializeObject<DataResponse<AnimeCatalog>>(data);


                    json = JsonConvert.SerializeObject(dataResponse.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Anime.GetByRating, json);

                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(ex);
            }
        }

        public async Task<DataResponse<AnimeCatalog>> GetByPopularity(int skip, int take)
        {
            try
            {
                var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetByPopularity);
                if (json != null)
                {
                    var animeCatalog = JsonConvert.DeserializeObject<List<AnimeCatalog>>(json);
                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(animeCatalog);
                }
                else
                {
                    using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByPopularity/skip/{skip}/take/{take}");
                    if (!responseHttp.IsSuccessStatusCode)
                    {
                        return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(null);
                    }
                    var data = await responseHttp.Content.ReadAsStringAsync();
                    var dataResponse = JsonConvert.DeserializeObject<DataResponse<AnimeCatalog>>(data);

                    json = JsonConvert.SerializeObject(dataResponse.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Anime.GetByPopularity, json);

                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<AnimeCatalog>(ex);
            }
        }

        public async Task<DataResponse<Anime>> GetByCategory(int ID)
        {
            try
            {
                var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetByPopularity);
                if (json != null)
                {
                    var anime = JsonConvert.DeserializeObject<List<Anime>>(json);
                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(anime);
                }
                else
                {
                    using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/ByCategory/{ID}");
                    if (!responseHttp.IsSuccessStatusCode)
                    {
                        return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(null);
                    }
                    var data = await responseHttp.Content.ReadAsStringAsync();
                    var dataResponse = JsonConvert.DeserializeObject<DataResponse<Anime>>(data);

                    json = JsonConvert.SerializeObject(dataResponse.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Anime.GetByPopularity, json);

                    return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(dataResponse.Data);
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedDataResponse<Anime>(ex);
            }
        }

        public async Task<SingleResponse<Anime>> GetComplete(int ID)
        {
            try
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using HttpResponseMessage responseHttp = await client.GetAsync($"Anime/AnimeOnPage/{ID}");

                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateFailedSingleResponse<Anime>();
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<SingleResponse<Anime>>(data);
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(dataResponse.Item);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedSingleResponse<Anime>(ex);
            }
        }

        public Task<int> GetLastIndexCategory()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetLastIndex()
        {
            throw new NotImplementedException();
        }
    }
}
