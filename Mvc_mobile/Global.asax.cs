using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace Mvc_mobile
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //讀取預設的Display Modes設定
            var displayModes = DisplayModeProvider.Instance.Modes;

            //新增Display Modes設定
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            {
               ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("Android")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
