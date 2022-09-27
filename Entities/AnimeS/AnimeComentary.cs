using Entities.UserS;

namespace Entities.AnimeS
{
    public class AnimeComentary
    {
        public int ID { get; set; }
        public Anime Anime { get; set; }
        public User User { get; set; }
        public string Comentary { get; set; }
        public DateTime DataComentary { get; set; }
    }
}
