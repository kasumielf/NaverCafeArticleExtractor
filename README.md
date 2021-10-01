# Introduce
* Naver Cafe REST API Extractor Library and Console Extractor

# Requirement and Dependencies
* Microfost .NET 5
* Newtonsoft.JSON(13.0.1)
* CommandLineParser(2.8.0)

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
## Library
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
## Console Extractor
### Command Line Arguments
1. -u, --url : Naver Cafe REST API URL(Required)
2. -c, --clubid : Naver Cafe clubId(Required)
3. -m, --menuid : Naver Cafe MenuId in specifie Cafe(Club)(Required)
4. -p, --per : Article per one page.(Not Required)
5. -q, --query : REST API Query Type(Not Required)
6. -a, --all : Extract all articles or only setted page(Warning : It would be takes a long time. )(Not Required, default is false)
