using NaverCafeArticleExtractor.Objects;
using System;
using System.Collections.Generic;

namespace NaverCafeArticleExtractor.Responses
{
    [Serializable]
    public class Message
    {
        public string Status { get; set; }
        public Error Error { get; set; }
        public Result Result { get; set; }
    }

    [Serializable]
    public class Error
    {
        public string Code { get; set; }
        public string Msg { get; set; }
    }

    [Serializable]
    public class Result
    {
        public long CafeId { get; set; }
        public string CafeName { get; set; }
        public bool CafeStaff { get; set; }
        public bool CafeMember { get; set; }
        public bool HasNext { get; set; }
        public IList<JsonNaverCafeArticle> ArticleList { get; set; }
    }

    [Serializable]
    public class JsonNaverCafeArticleResponse
    {
        public Message Message { get; set; }

        public bool IsValid()
        {
            return Message.Result != null &&
                    Message.Result.ArticleList != null &&
                    Message.Result.ArticleList.Count > 0;
        }
    }
}
