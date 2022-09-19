using Entities.Enums;
using Entities.MangaS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.ApiConsumer.MangaApi
{
    public class ConverterToCategory
    {
        public static List<Manga> ConvertDTOToManga(Root mangaRootDTO)
        {
            List<Manga> mangaList = new();

            foreach (var item in mangaRootDTO.data)
            {
                MangaTitles titles = new()
                {
                    En = item.attributes.titles.en,
                    En_us = item.attributes.titles.en_us,
                    En_jp = item.attributes.titles.en_jp,
                    Ja_jp = item.attributes.titles.ja_jp,
                };

                MangaStatus status;
                bool hasStatusParse = Enum.TryParse(item.attributes.status, out status);
                //_ = Enum.TryParse(item.attributes.status, out MangaStatus status);

                Manga manga = new()
                {
                    Name = item.attributes.slug,
                    Synopsis = item.attributes.synopsis,
                    Titles = titles,
                    CanonicalTitle = item.attributes.canonicalTitle,
                    AverageRating = item.attributes.averageRating,
                    //RatingFrequencies - Alguns atributos não serão pegos, pois nosso site que ira gerar tais dados, mas por hora é testes
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
                    Apiids = item.id,
                };
                mangaList.Add(manga);
            }

            return mangaList;
        }
    }
}
