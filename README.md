# Introduce
* Naver Cafe REST API Extractor

# Requirement and Dependencies
* Microfost .NET 5
* Newtonsoft.JSON(13.0.1)

# Projects
* NaverCafeArticleExtractor is .NET Library. You can include this library for using other .NET 5 projects.
* Test project is simple examples of using library.

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
