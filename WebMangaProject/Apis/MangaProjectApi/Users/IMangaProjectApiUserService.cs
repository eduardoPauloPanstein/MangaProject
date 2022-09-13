using Entities.MangaS;
using Entities.UserS;
using Shared;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi
{
    public interface IMangaProjectApiUserService : IMangaProjectApiService<User>
    {
        Task<SingleResponseWToken<User>> Login(UserLogin user);
    }
}
