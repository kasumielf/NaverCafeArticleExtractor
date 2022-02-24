using CommandLine;

namespace NaverCafeArticleConsoleExtractor
{
    public class Arguments
    {
        [Option('u', "url", Required = false, HelpText = "Naver Cafe REST API URL")]
        public string Url { get; set; }
        [Option('c', "clubid", Required = true, HelpText = "Naver Cafe clubId.")]
        public long ClubId { get; set; }
        [Option('m', "menuid", Required = true, HelpText = "MenuId for extract articles.")]
        public int MenuId { get; set; }
        [Option('p', "per", Required = false, HelpText = "Article per one page.")]
        public int PerPage { get; set; }
        [Option('q', "query", Required = false, HelpText = "REST API Query Type")]
        public string QueryType { get; set; }
        [Option('a', "all", Required = false, HelpText = "Extract all articles or only setted page(Warning : It would be takes a long time. )")]
        public bool? All { get; set; }
    }
}
