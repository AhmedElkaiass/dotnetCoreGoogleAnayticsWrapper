using GoogleAnayticsWrapper.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsWrapper;
public static class _DI
{
    public static void AddGoogleAnalytics(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizeApp, AuthorizeApp>();
        services.AddSingleton<IBrowsingService, BrowsingService>();
        services.AddScoped<IGoogleAnaylticsService, GoogleAnaylticsService>();
    }
}
