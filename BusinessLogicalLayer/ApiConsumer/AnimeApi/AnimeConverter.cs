using Entities.AnimeS;
using Entities.Enums;

namespace BusinessLogicalLayer.ApiConsumer.NovaPasta
{
    public class AnimeConverter
    {
        public static Anime ConvertDTOToAnime(RootANI mangaRootDTO)
        {
            var item = mangaRootDTO.data;
            AnimeSTitles titles = new()
            {
                En_jp = item.attributes.titles.en_jp,
                Ja_jp = item.attributes.titles.ja_jp,
            };

            MangaStatus status;
            bool hasStatusParse = Enum.TryParse(item.attributes.status, out status);
            //_ = Enum.TryParse(item.attributes.status, out MangaStatus status);

            Anime anime = new()
            {
                Id = Convert.ToInt32(item.id),
                name = item.attributes.slug,
                createdAt = item.attributes.createdAt,
                updatedAt = item.attributes.updatedAt,
                description = item.attributes.description,
                synopsis = item.attributes.synopsis,
                AnimeTitles = titles,
                canonicalTitle = item.attributes.canonicalTitle,
                averageRating = item.attributes.averageRating,
                ratingRank = item.attributes.ratingRank,
                popularityRank = item.attributes.popularityRank,
                userCount = item.attributes.userCount,
                favoritesCount = item.attributes.favoritesCount,
                startDate = item.attributes.startDate,
                endDate = item.attributes.endDate,
                ageRating = item.attributes.ageRating,
                status = status,
                youtubeVideoId = item.attributes.youtubeVideoId,
                AnimePosterImage = item.attributes.posterImage?.original,
                AnimeCoverImage = item.attributes.coverImage?.original,
                showType = item.attributes.showType,
                episodeCount = item.attributes.episodeCount,
                episodeLength = item.attributes.episodeLength,
                totalLength = item.attributes.totalLength,
                subtype = item.attributes.subtype,

            };

            return anime;
        }
    }
}
