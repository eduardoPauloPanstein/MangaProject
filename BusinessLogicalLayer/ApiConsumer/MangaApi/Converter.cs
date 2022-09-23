using Entities.Enums;
using Entities.MangaS;

namespace BusinessLogicalLayer.ApiConsumer.MangaApi
{
    public class ConverterToCategory
    {
        public static Manga ConvertDTOToManga(Root mangaRootDTO)
        {
            var item = mangaRootDTO.data;
            MangaTitles titles = new()
            {
                En = item.attributes.titles.en,
                En_jp = item.attributes.titles.en_jp,
                Ja_jp = item.attributes.titles.ja_jp,

            };

            MangaStatus status;
            bool hasStatusParse = Enum.TryParse(item.attributes.status, out status);
            //_ = Enum.TryParse(item.attributes.status, out MangaStatus status);

            Entities.MangaS.RatingFrequencies Rating = new();


            Rating.Id = Convert.ToInt32(item.id);

                Rating._1 = Convert.ToInt32(item.attributes.ratingFrequencies._2) +
                Convert.ToInt32(item.attributes.ratingFrequencies._3) +
                Convert.ToInt32(item.attributes.ratingFrequencies._4);

            Rating._2 = Convert.ToInt32(item.attributes.ratingFrequencies._5) +
            Convert.ToInt32(item.attributes.ratingFrequencies._6) +
            Convert.ToInt32(item.attributes.ratingFrequencies._7) +
            Convert.ToInt32(item.attributes.ratingFrequencies._8);


            Rating._3 = Convert.ToInt32(item.attributes.ratingFrequencies._9) +
            Convert.ToInt32(item.attributes.ratingFrequencies._10) +
            Convert.ToInt32(item.attributes.ratingFrequencies._11) +
            Convert.ToInt32(item.attributes.ratingFrequencies._12);



            Rating._4 = Convert.ToInt32(item.attributes.ratingFrequencies._13) +
            Convert.ToInt32(item.attributes.ratingFrequencies._14) +
            Convert.ToInt32(item.attributes.ratingFrequencies._15) +
            Convert.ToInt32(item.attributes.ratingFrequencies._16);

            Rating._5 =
            Convert.ToInt32(item.attributes.ratingFrequencies._17) +
            Convert.ToInt32(item.attributes.ratingFrequencies._18) +
            Convert.ToInt32(item.attributes.ratingFrequencies._19) +
            Convert.ToInt32(item.attributes.ratingFrequencies._20);

            Manga manga = new()
            {
                Id = Convert.ToInt32(item.id),
                Name = item.attributes.slug,
                Synopsis = item.attributes.synopsis,
                Titles = titles,
                CanonicalTitle = item.attributes.canonicalTitle,
                AverageRating = item.attributes.averageRating,
                RatingFrequencies = Rating,
                RatingRank = item.attributes.ratingRank,
                PopularityRank = item.attributes.popularityRank,
                UserCount = item.attributes.userCount,
                FavoritesCount = item.attributes.favoritesCount,
                StartDate = item.attributes.startDate,
                EndDate = item.attributes.endDate,
                AgeRating = item.attributes.ageRating,
                Status = status,
                VolumeCount = item.attributes.volumeCount,
                Serialization = item.attributes.serialization,
                PosterImageLink = item.attributes.posterImage?.original,
                CoverImageLink = item.attributes.coverImage?.original,
            };

            return manga;
        }
    }
}
