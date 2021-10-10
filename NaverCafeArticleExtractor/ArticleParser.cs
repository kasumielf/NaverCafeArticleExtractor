using NaverCafeArticleExtractor.Builders;
using NaverCafeArticleExtractor.Objects;
using NaverCafeArticleExtractor.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NaverCafeArticleExtractor
{
    public static class Extractor
    {
        public static async Task<IList<NaverCafeArticle>> ExtractAsync(NaverCafeRestAPIRequestParameterBuilder builder)
        {
            var http = new HttpClient();
            var res = await http.GetStringAsync(builder.ToUri());
            var list = new List<NaverCafeArticle>();

            if (!string.IsNullOrEmpty(res))
            {
                var jsonResponse = JsonConvert.DeserializeObject<JsonNaverCafeArticleResponse>(res);

                if (jsonResponse != null && jsonResponse.IsValid())
                {
                    foreach (var a in jsonResponse.Message.Result.ArticleList)
                    {
                        list.Add(a.ToArticle());
                    }
                }
            }

            return list;
        }

        public static async Task<IList<NaverCafeArticle>> ExtractAllAsync(NaverCafeRestAPIRequestParameterBuilder builder)
        {
            var list = new List<NaverCafeArticle>();

            int page = 1;

            while (true)
            {
                var articles = await ExtractAsync(builder);

                list.AddRange(articles);

                if (articles == null || articles.Count <= 0)
                {
                    break;
                }

                builder.Search.SetPage(++page);
            }

            return list;
        }
    }
}
