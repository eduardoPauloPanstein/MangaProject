﻿using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using DataAccessLayer.Implementations;
using Entities.MangaS;
using Newtonsoft.Json;
using Shared;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.ApiConsumer.MangaApi
{
    public class ApiConnect : IApiConnect
    {
        //https://kitsu.io/api/edge/manga?page[limit]=20&page[offset]=0
        // pageLimit Max=20

        Uri baseAddress = new Uri("https://kitsu.io/api/edge/");
        string requestString = $"manga?page[limit]=20&page[offset]=";

        private readonly IMangaService _mangaService;
        public ApiConnect(IMangaService mangaService)
        {
            _mangaService = mangaService;
        }


        public async Task<DataResponse<Manga>> Consume()
        {
            //1 page get 20 mangas
            int qtdPages = 800;
            int qtdMangas = qtdPages * 20;
            List<Manga> mangasTotal = new();

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                for (int i = 1; i <= qtdMangas; i ++)
                {
                    using (var response = await httpClient.GetAsync(requestString + i))
                    {

                        string jsonString = await response.Content.ReadAsStringAsync();


                        Root? mangaRootDTO = JsonConvert.DeserializeObject<Root>(jsonString);

                        //Ou pegar em lista ou convert um por um pois ta fazendo lista de um so sempre
                        List<Manga> mangas = ConverterToCategory.ConvertDTOToManga(mangaRootDTO);

                        foreach (var item in mangas)
                        {
                            List<Category> Response = await CategoryApi.MangaCategory(Convert.ToInt32(item.Id));
                            //BLL
                            item.Categoria = Response;
                            Response responseManga = await _mangaService.Insert(item);
                            responseManga.Message = $"{i} :{item.Name}, {responseManga.Message}";
                            if (responseManga.HasSuccess)
                            {
                                mangasTotal.Add(item);
                            }
                        }

                    }
                }
            }
            if (mangasTotal.Count > 0)
            {
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(mangasTotal);
            }

            return ResponseFactory.CreateInstance().CreateDataFailedResponse<Manga>(null);
        }
        public async Task<Response> DeleteAllDatas()
        {
            Response responseManga = await _mangaService.DeleteAllDatas();
            return responseManga;

        }
    }
}
