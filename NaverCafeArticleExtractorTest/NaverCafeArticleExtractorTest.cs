using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaverCafeArticleExtractor.Builders;
using NaverCafeArticleExtractor.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaverCafeArticleExtractorTest
{
    [TestClass]
    public class NaverCafeArticleExtractorTest
    {
        [TestMethod]
        public async Task Success_BasicExtractAsync()
        {
            var builder = new NaverCafeRestAPIRequestParameterBuilder();
            builder.SetUrl("https://apis.naver.com/cafe-web/cafe2/ArticleListV2dot1.json");
            builder.Search.SetClubId(19480246).SetMenuId(24);
            var res = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.Count, 50);
        }

        [TestMethod]
        public async Task Success_SetPerPage_ExtractAsync()
        {
            var builder = new NaverCafeRestAPIRequestParameterBuilder();
            builder.SetUrl("https://apis.naver.com/cafe-web/cafe2/ArticleListV2dot1.json");
            builder.Search.SetClubId(19480246).SetMenuId(24).SetPerPage(10);
            var res = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.Count, 10);
        }

        [TestMethod]
        public async Task Success_ExtractAllAsync()
        {
            var builder = new NaverCafeRestAPIRequestParameterBuilder();
            builder.SetUrl("https://apis.naver.com/cafe-web/cafe2/ArticleListV2dot1.json");
            builder.Search.SetClubId(19480246).SetMenuId(176);
            var res = new List<NaverCafeArticle>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            await NaverCafeArticleExtractor.Extractor.ExtractAllAsync(builder, (list) => 
            {
                res.AddRange(list);
            });

            var duplicated = res.GroupBy(x => x.Id).Any(g => g.Count() > 1);

            Assert.IsNotNull(res);
            Assert.IsFalse(duplicated);
        }
    }
}
