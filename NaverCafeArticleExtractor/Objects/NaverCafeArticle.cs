using System;

namespace NaverCafeArticleExtractor.Objects
{
    /// <summary>
    /// Naver Cafe Article object using in codes.
    /// </summary>
    public class NaverCafeArticle
    {
        /// <summary>
        /// Article unique id.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Title of article.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Writer's Naver Auth Id.
        /// </summary>
        public string WriterId { get; set; }
        /// <summary>
        /// Writer's Naver cafe nickname.
        /// </summary>
        public string WriterNickname { get; set; }
        /// <summary>
        /// DateTime for wrote article.
        /// </summary>
        public DateTime WrotedDateTime { get; set; }
    }
}
