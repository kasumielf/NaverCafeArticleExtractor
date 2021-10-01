using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaverCafeArticleExtractor.Builders;
using System.Threading.Tasks;

namespace NaverCafeArticleParserTest
{
    [TestClass]
    public class NaverCafeArticleExtractorTest
    {
        [TestMethod]
        public async Task Success_BasicExtractAsync()
        {
            var builder = new NaverCafeRestAPIRequestParameterBuilder("https://apis.naver.com/cafe-web/cafe2/ArticleList.json");
            builder.Search.SetClubId(19480246).SetMenuId(24);
            var res = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.Count, 50);
        }

        [TestMethod]
        public async Task Success_SetPerPage_ExtractAsync()
        {
            var builder = new NaverCafeRestAPIRequestParameterBuilder("https://apis.naver.com/cafe-web/cafe2/ArticleList.json");
            builder.Search.SetClubId(19480246).SetMenuId(24).SetPerPage(10);
            var res = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.Count, 10);
        }
    }
}
