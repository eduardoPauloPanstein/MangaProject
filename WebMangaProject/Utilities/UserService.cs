using System.Security.Claims;

namespace MvcPresentationLayer.Utilities
{
    public class UserService
    {
        public static string GetToken(HttpContext _context)
        {
            var token = _context.User.Claims.Where(c => c.Type == "Token")
                   .Select(c => c.Value).SingleOrDefault();
            return token;
        }
    }
}
