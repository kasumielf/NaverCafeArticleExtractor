using NaverCafeArticleExtractor.Parameters;
using System;

namespace NaverCafeArticleExtractor.Builders
{
    /// <summary>
    /// Parameter builder for Naver Cafe REST API Request.
    /// </summary>
    public class NaverCafeRestAPIRequestParameterBuilder
    {
        private Uri _apiUri;
        public Search Search { get; init; }

        public NaverCafeRestAPIRequestParameterBuilder()
        {
            Search = new Search();
        }

        public NaverCafeRestAPIRequestParameterBuilder SetUrl(string url)
        {
            if(Uri.TryCreate(url, UriKind.Absolute, out _apiUri))
            {
                return this;
            }
            else
            {
                Uri.TryCreate("https://apis.naver.com/cafe-web/cafe2/ArticleList.json", UriKind.Absolute, out _apiUri);

                return this;
            }
        }

        public Uri ToUri()
        {
            return new Uri($"{_apiUri}?{Search.ToQueryString()}");
        }
    }
}
