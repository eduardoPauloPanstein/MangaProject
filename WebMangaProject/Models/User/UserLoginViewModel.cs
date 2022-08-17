using System.ComponentModel.DataAnnotations;

namespace MvcPresentationLayer.Models.User
{
    public class UserLoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter email please", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password please", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
