Visual Studio 已將 ASP.NET Web API 2 的 整組 相依性新增至專案 'MvcJsonWebAPI'。

專案中的 Global.asax.cs 檔案需要其他變更，才能啟用 ASP.NET Web API。

1. 新增下列命名空間參考:

    using System.Web.Http;
    using System.Web.Routing;

2. 如果程式碼尚未定義 Application_Start 方法，請新增下列方法:

    protected void Application_Start()
    {
    }

3. 將以下幾行新增至 Application_Start 方法的開頭處:

    GlobalConfiguration.Configure(WebApiConfig.Register);