using Entities.UserS;
using Newtonsoft.Json;
using Shared;
using Shared.Responses;
using System.Text;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public class MangaProjectApiUserService : MangaProjectApiBase, IMangaProjectApiUserService
    {

        public async Task<Response> Delete(int? id)
        {
            try
            {
                using HttpResponseMessage responseHttp = await client.DeleteAsync($"User/{id}");
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(null, null);
                }
                return JsonConvert.DeserializeObject<Response>(await responseHttp.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<Response> Insert(User user)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(user);
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
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public async Task<SingleResponse<User>> Login(UserLogin userLogin)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(userLogin);
                using HttpResponseMessage responseHttp = await client.PostAsJsonAsync("User/Login", serialized);

                var response = JsonConvert.DeserializeObject<SingleResponse<User>>(responseHttp.Content.ReadAsStringAsync().Result);

                if (responseHttp.IsSuccessStatusCode)
                {
                    return response;
                }
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(null, null, response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(ex, null);
            }
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

        public async Task<Response> Update(User user)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(user);
                using HttpResponseMessage responseHttp = await client.PutAsJsonAsync($"User/{user.Id}", serialized);

                var response = JsonConvert.DeserializeObject<Response>(responseHttp.Content.ReadAsStringAsync().Result);

                if (responseHttp.IsSuccessStatusCode)
                {
                    return ResponseFactory.CreateInstance().CreateSuccessResponse();
                }
                return ResponseFactory.CreateInstance().CreateFailedResponse(null, response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }
    }
}
