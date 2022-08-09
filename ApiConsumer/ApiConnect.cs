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
    public class ApiConnect
    {
        //https://kitsu.io/api/edge/manga?page[limit]=20&page[offset]=0
        // pageLimit Max=20

        Uri baseAddress = new Uri("https://kitsu.io/api/edge/");
        String requestString = $"manga?page[limit]=1&page[offset]=";

        /// <summary>
        /// Consome mangas da API exerna kitsu, e insere na DB(DAL)
        /// </summary>
        /// <param name="qtdMangas"></param>
        /// <returns></returns>
        public async Task Consume(int qtdMangas)
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                int qtdMangasCadastrados = 0;
                Response responseManga = new();
                MangaDAL dAL = new();

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
                            responseManga = dAL.Insert(item);
                            Console.WriteLine($"{i} :{item.Name}, {responseManga.Message}");
                            if (responseManga.HasSuccess)
                            {
                                qtdMangasCadastrados++;
                            }
                            else
                            {
                                Console.WriteLine($"{item.Name}, {responseManga.Exception}");
                            }
                        }

                    }
                }
                Console.WriteLine($"qtdMangasCadastrados: {qtdMangasCadastrados}");
            }
        }
        public void DeleteAllDatas()
        {
            MangaDAL dAL = new();
            Response responseManga = new();

            responseManga = dAL.DeleteAllDatas();
            Console.WriteLine(responseManga.Message);
            if (!responseManga.HasSuccess)
            {
                Console.WriteLine(responseManga.Exception);
            }
        }
    }
}
