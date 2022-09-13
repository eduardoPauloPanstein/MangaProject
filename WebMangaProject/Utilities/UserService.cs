using System.Security.Claims;

namespace MvcPresentationLayer.Utilities
{
    public class UserService
    {
        public static string GetToken(HttpContext _context)
        {
            var token = _context.User.Claims?.Where(c => c.Type == "Token")
                   .Select(c => c.Value).SingleOrDefault();
            return token;
        }
        public static string GetId(HttpContext _context)
        {
            return _context.User.Claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.PrimarySid, StringComparison.OrdinalIgnoreCase))?.Value;
        }
    }
}
