using Entities;
using Newtonsoft.Json;
using Shared;
using System.Text;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public class MangaProjectApiUserService : MangaProjectApiBase, IMangaProjectApiUserService
    {

        public async Task<Response> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(User item)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(item);
                using HttpResponseMessage responseHttp = await client.PostAsJsonAsync("User", serialized);

                var response = JsonConvert.DeserializeObject<Response>(responseHttp.Content.ReadAsStringAsync().Result);

                if (responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
                return ResponseFactory.CreateInstance().CreateFailedResponse(null, response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<User>(ex);
            }
        }

        public Task<SingleResponse<User>> Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<SingleResponse<User>> Select(int? id)
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.GetAsync($"User/{id}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(null, null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<SingleResponse<User>>(data);
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse<User>(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(ex, null);
            }
        }

        public async Task<DataResponse<User>> SelectAll()
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.GetAsync("User/GetAll");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateDataFailedResponse<User>(null);
                }
                var data = await responseHttp.Content.ReadAsStringAsync();
                var dataResponse = JsonConvert.DeserializeObject<DataResponse<User>>(data);
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(dataResponse.Data);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<User>(ex);
            }
        }

        public async Task<Response> Update(User item)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(item);
                using HttpResponseMessage responseHttp = await client.PutAsJsonAsync($"User/{item.Id}", serialized);

                var response = JsonConvert.DeserializeObject<Response>(responseHttp.Content.ReadAsStringAsync().Result);

                if (responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
                return ResponseFactory.CreateInstance().CreateFailedResponse(null, response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<User>(ex);
            }
        }
    }
}
