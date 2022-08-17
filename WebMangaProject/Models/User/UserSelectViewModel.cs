namespace MvcPresentationLayer.Models.User
{
    public class UserSelectViewModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public int FavoritesCount { get; set; }
        public int ReviewsCount { get; set; }
    }
}
