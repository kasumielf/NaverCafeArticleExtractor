using NaverCafeArticleExtractor.Parameters;
using System;

namespace NaverCafeArticleExtractor.Builders
{
    /// <summary>
    /// Parameter builder for Naver Cafe REST API Request.
    /// </summary>
    public class NaverCafeRestAPIRequestParameterBuilder
    {
        private readonly string _apiUrl;
        public Search Search { get; init; }

        public NaverCafeRestAPIRequestParameterBuilder(string apiUrl)
        {
            _apiUrl = apiUrl;

            Search = new Search();
        }

        public Uri ToUri()
        {
            return new Uri($"{_apiUrl}?{Search.ToQueryString()}");
        }
    }
}
