using CommandLine;
using NaverCafeArticleExtractor.Builders;
using NaverCafeArticleExtractor.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaverCafeArticleConsoleExtractor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int currentPage = 0;

            bool all = false;
            var builder = new NaverCafeRestAPIRequestParameterBuilder();

            var p = CommandLine.Parser.Default.ParseArguments<Arguments>(args).WithParsed<Arguments>(o =>
            {
                if (string.IsNullOrEmpty(o.Url)) 
                {
                    o.Url = "https://apis.naver.com/cafe-web/cafe2/ArticleList.json";
                }

                builder.SetUrl(o.Url)
                    .Search
                    .SetClubId(o.ClubId)
                    .SetMenuId(o.MenuId)
                    .SetPage(currentPage);

                if (o.PerPage > 0)
                {
                    builder.Search.SetPerPage(o.PerPage);
                }

                if (!string.IsNullOrEmpty(o.QueryType))
                {
                    builder.Search.SetQueryType(o.QueryType);
                }

                all = o.All ?? false;
            });

            if (all)
            {
                await NaverCafeArticleExtractor.Extractor.ExtractAllAsync(builder, PrintLists);
            }
            else
            {
                var list = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);
                PrintLists(list);
            }
        }

        static void PrintLists(IList<NaverCafeArticle> list)
        {
            foreach (var article in list)
            {
                System.Console.WriteLine(string.Join('\t', article.ToStringArray()));
            }
        }
    }
}
