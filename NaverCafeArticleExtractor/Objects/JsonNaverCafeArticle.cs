using System;

namespace NaverCafeArticleExtractor.Objects
{
    /// <summary>
    /// Naver Cafe REST API Json result object.
    /// </summary>
    public class JsonNaverCafeArticle
    {
        public long CafeId { get; set; }
        public long ArticleId { get; set; }
        public long RefArticleId { get; set; }
        public string ReplyListOrder { get; set; }
        public long MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuType { get; set; }
        public bool RestrictMenu { get; set; }
        public string BoardType { get; set; }
        public string Subject { get; set; }
        public string WriterId { get; set; }
        public string WriterNickname { get; set; }
        public long WriteDateTimestamp { get; set; }

        public NaverCafeArticle ToArticle()
        {
            var res = new NaverCafeArticle()
            {
                Id = ArticleId,
                Title = Subject,
                WriterId = WriterId,
                WriterNickname = WriterNickname,
                WrotedDateTime = DateTime.UnixEpoch.AddMilliseconds(WriteDateTimestamp)
            };

            return res;
        }
    }
}
