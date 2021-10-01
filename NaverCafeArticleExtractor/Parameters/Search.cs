using System;
using System.Collections.Generic;
using System.Text;

namespace NaverCafeArticleExtractor.Parameters
{
    /// <summary>
    /// Naver Cafe REST API Search Parameters.
    /// </summary>
    [Serializable]
    public class Search
    {
        private readonly Dictionary<string, object> _parameters;

        public Search()
        {
            _parameters = new Dictionary<string, object>();

            _parameters.Add("search.clubid", 0);
            _parameters.Add("search.queryType", "lastArticle");
            _parameters.Add("search.menuid", 0);
            _parameters.Add("search.page", 1);
            _parameters.Add("search.perPage", 50);
        }

        public Search SetClubId(long clubId)
        {
            _parameters["search.clubid"] = clubId;
            return this;
        }

        public Search SetQueryType(string queryType)
        {
            _parameters["search.queryType"] = queryType;
            return this;
        }

        public Search SetMenuId(int menuId)
        {
            _parameters["search.menuid"] = menuId;
            return this;
        }

        public Search SetPage(int page)
        {
            _parameters["search.page"] = page;
            return this;
        }

        public Search SetPerPage(int perPage)
        {
            _parameters["search.perPage"] = perPage;
            return this;
        }

        public string ToQueryString()
        {
            var sb = new StringBuilder();

            foreach (var param in _parameters)
            {
                sb.Append(param.Key);
                sb.Append('=');
                sb.Append(param.Value);
                sb.Append('&');
            }

            return sb.ToString()[..^1];
        }
    }
}
