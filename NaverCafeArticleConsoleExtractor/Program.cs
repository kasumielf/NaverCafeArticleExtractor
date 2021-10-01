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

            var list = new List<NaverCafeArticle>();

            while (true)
            {
                var articles = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);

                list.AddRange(articles);

                if (articles == null || articles.Count <= 0 || all == false)
                {
                    break;
                }

                builder.Search.SetPage(++currentPage);
            }

            foreach (var article in list)
            {
                System.Console.WriteLine(string.Join('\t', article.ToStringArray()));
            }
        }
    }
}
