using Entities.AnimeS;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Shared.Models.Anime
{
    public class AnimeCatalog
    {
        public int Id { get; set; }
        public string canonicalTitle { get; set; }
        public string? AnimePosterImage { get; set; }

        public static Expression<Func<Entities.AnimeS.Anime, AnimeCatalog>> Projection => x => new AnimeCatalog()
        {
            Id = x.Id,
            canonicalTitle = x.canonicalTitle,
            AnimePosterImage = x.AnimePosterImage
        };
    }

}
