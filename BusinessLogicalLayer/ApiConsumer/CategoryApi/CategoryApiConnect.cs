using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using Entities.MangaS;
using Newtonsoft.Json;
using Shared;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.ApiConsumer.CategoryApi
{
    public class CategoryApiConnect : ICategoryApiConnect
    {
        Uri baseAddress = new Uri("https://kitsu.io/api/edge/");

        private readonly IMangaService _mangaService;
        public CategoryApiConnect(IMangaService mangaService)
        {
            this._mangaService = mangaService;
        }
        public Task<Response> DeleteAllDatas()
        {
            throw new NotImplementedException();
        }
        public async Task<DataResponse<Category>> CovertiCatego()
        {
            int qtdPages = 18000;

            List<Category> mangasTotal = new();

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                for (int i = 1; i <= qtdPages; i++)
                {
                    using (var response = await httpClient.GetAsync($"categories/{i}"))
                    {

                        string jsonString = await response.Content.ReadAsStringAsync();
                        if (jsonString.Contains("errors"))
                        {

                        }
                        else
                        {
                            RootCate? mangaRootDTO = JsonConvert.DeserializeObject<RootCate>(jsonString);

                            //Ou pegar em lista ou convert um por um pois ta fazendo lista de um so sempre
                            Category c = Convertercate.CovertiCatego(mangaRootDTO);


                            //BLL
                            Response responseManga = await _mangaService.InsertCategory(c);
                            if (responseManga.HasSuccess)
                            {
                                mangasTotal.Add(c);
                            }

                        }
                    }
                }
            }
            if (mangasTotal.Count > 0)
            {
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse<Category>(mangasTotal);
            }

            return ResponseFactory.CreateInstance().CreateDataFailedResponse<Category>(null);
        }
    }
}
