namespace MvcPresentationLayer.Models.User
{
    public class UserUpdateViewModel
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public string? About { get; set; }
        public byte[]? CoverImage { get; set; }
        public byte[]? AvatarImage { get; set; }
    }
}
