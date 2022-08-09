using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Implementations;
using Entities.Manga;
using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer
{
    public class ApiConnect : IApiConnect
    {
        //https://kitsu.io/api/edge/manga?page[limit]=20&page[offset]=0
        // pageLimit Max=20

        Uri baseAddress = new Uri("https://kitsu.io/api/edge/");
        String requestString = $"manga?page[limit]=1&page[offset]=";

        private readonly IMangaService _mangaService;
        public ApiConnect(IMangaService mangaService)
        {
            this._mangaService = mangaService;
        }


        public async Task<DataResponse<Response>> Consume(int qtdMangas)
        {
            //int qtdMangasCadastrados = 0;
            Response responseManga = new();
            DataResponse<Response> responseList = new();

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                for (int i = 1; i <= qtdMangas; i++)
                {
                    using (var response = await httpClient.GetAsync(requestString + i))
                    {

                        string jsonString = await response.Content.ReadAsStringAsync();


                        Root? mangaRootDTO = JsonConvert.DeserializeObject<Root>(jsonString);

                        List<Manga> mangas = Converter.ConvertDTOToManga(mangaRootDTO);

                        foreach (var item in mangas)
                        {
                            //BLL
                            responseManga = await _mangaService.Insert(item);
                            responseManga.Message = $"{i} :{item.Name}, {responseManga.Message}";
                            responseList.Data?.Add(responseManga);
                        }

                    }
                }
            }
            return responseList;
        }
        public async Task<Response> DeleteAllDatas()
        {
            Response responseManga = await _mangaService.DeleteAllDatas();
            return responseManga;

        }
    }
}
