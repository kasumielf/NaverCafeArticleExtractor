using NaverCafeArticleExtractor.Builders;
using System.Threading.Tasks;

namespace NaverCafeArticleConsoleExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new NaverCafeRestAPIRequestParameterBuilder("https://apis.naver.com/cafe-web/cafe2/ArticleList.json");

            builder.Search
                .SetClubId(19480246)            // Naver Cafe clubId.
                .SetMenuId(24)                  // MenuId for extract articles.
                .SetPage(3)                     // Page number
                .SetPerPage(50)                 // Article per one page.
                .SetQueryType("lastArticle");   // REST API Query Type

            Task.Run(async () =>
            {
                var articles = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);

                foreach (var article in articles)
                {
                    System.Console.WriteLine(article.Title);
                }

            }).Wait();
        }
    }
}
