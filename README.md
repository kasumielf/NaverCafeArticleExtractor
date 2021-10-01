# Introduce
네이버 카페의 REST API를 이용해 카페 내 특정 게시판의 게시물 리스트를 가져오는 .NET Core Library 및 CLI 코드

# Requirement and Dependencies
* Microfost .NET 5
* Newtonsoft.JSON(13.0.1)

# Parameters

Using parameter builder class.

```csharp
var builder = new NaverCafeRestAPIRequestParameterBuilder("https://apis.naver.com/cafe-web/cafe2/ArticleList.json");

builder.Search
    .SetClubId(19480246)            // Naver Cafe clubId.
    .SetMenuId(24)                  // MenuId for extract articles.
    .SetPage(3)                     // Page number
    .SetPerPage(50)                 // Article per one page.
    .SetQueryType("lastArticle");   // REST API Query Type
```

# Usage
1. Place parameters builder.
2. Using extract static class by async.
3. Using extracted articles.

```csharp
var builder = new NaverCafeRestAPIRequestParameterBuilder("https://apis.naver.com/cafe-web/cafe2/ArticleList.json");

builder.Search
    .SetClubId(19480246)
    .SetMenuId(24);

Task.Run(async () =>
{
    var articles = await NaverCafeArticleExtractor.Extractor.ExtractAsync(builder);
}).Wait();
```
