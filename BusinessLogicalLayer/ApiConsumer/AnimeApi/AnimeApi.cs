using BusinessLogicalLayer.ApiConsumer.AnimeApi;
using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using DataAccessLayer.Interfaces.IMangaInterfaces;
using Entities.AnimeS;
using Newtonsoft.Json;

namespace BusinessLogicalLayer.ApiConsumer.NovaPasta
{
    public class AnimeApi : IAnimeApiConnect
    {
        Uri baseAddress = new Uri("https://kitsu.io/api/edge/");

        private readonly IMangaService _mangaService;
        private readonly IMangaDAL _mangaDAL;
        public AnimeApi(IMangaService mangaService, IMangaDAL mangaDAL)
        {
            this._mangaDAL = mangaDAL;
            this._mangaService = mangaService;
        }
        public async Task ConsumeAnime()
        {
            //int last = await _mangaDAL.GetLastIndexManga();
            int LimiteManga = 64595;

            //if (last >= LimiteManga)
            //{
            //    return;
            //}
            //last++;
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                for (int i = 1; i <= LimiteManga; i++)
                {
                    using (var response = await httpClient.GetAsync($"anime/{i}"))
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        if (jsonString.Contains("errors"))
                        {
                        }
                        else
                        {
                            RootANI? mangaRootDTO = JsonConvert.DeserializeObject<RootANI>(jsonString);
                            string s = "";
                            Anime manga = AnimeConverter.ConvertDTOToAnime(mangaRootDTO);
                            //manga.Categoria = await CategoryApi.MangaCategory(Convert.ToInt32(manga.Id));
                            ////BLL
                            //Response responseManga = await _mangaService.Insert(manga);
                        }
                    }
                }
            }
            return;
        }
    }
}
