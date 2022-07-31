using Google.Apis.AnalyticsReporting.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsWrapper;
public interface IBrowsingService
{
    IList<Report> GetSession(DateTime FromDate, DateTime ToDate);
    IList<Report> GetUsers(DateTime FromDate, DateTime ToDate);
    IList<Report> BouncceRate(DateTime FromDate, DateTime ToDate);
    IList<Report> SessionDuration(DateTime FromDate, DateTime ToDate);
    IList<Report> GetPerCountry(DateTime FromDate, DateTime ToDate);
    IList<Report> GetPerCity(DateTime FromDate, DateTime ToDate);
    IList<Report> GetByDeviceCategory(DateTime FromDate, DateTime ToDate);
    IList<Report> GetByBrowser(DateTime FromDate, DateTime ToDate);
    IList<Report> GetScreenResolution(DateTime FromDate, DateTime ToDate);
    IList<Report> GetByLanguage(DateTime FromDate, DateTime ToDate);
    IList<Report> GetByOperatingSystem(DateTime FromDate, DateTime ToDate);
    IList<Report> GetByServiceProvider(DateTime FromDate, DateTime ToDate);
    IList<Report> ChannelGroups(DateTime FromDate, DateTime ToDate);
    IList<Report> VisitSource(DateTime FromDate, DateTime ToDate);
    IList<Report> PagePath(DateTime FromDate, DateTime ToDate);
    IList<Report> GetPagesVeiws(DateTime FromDate, DateTime ToDate);
    IList<Report> SourceMedium(DateTime FromDate, DateTime ToDate);
}
public class BrowsingService : IBrowsingService
{
    private readonly IAuthorizeApp authorizeApp;

    public BrowsingService(IAuthorizeApp authorizeApp)
    {
        this.authorizeApp = authorizeApp;
    }
    public IList<Report> GetSession(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var sessions = new Metric
        {
            Expression = "ga:sessions",
            Alias = "Sessions"
        };
        var date = new Dimension { Name = "ga:date" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { date }, new List<Metric> { sessions });
    }
    public IList<Report> GetUsers(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var users = new Metric
        {
            Expression = "ga:users",
            Alias = "Users"
        };
        var date = new Dimension { Name = "ga:date" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { date }, new List<Metric> { users });
    }

    //tested 
    public IList<Report> BouncceRate(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var users = new Metric
        {
            Expression = "ga:bounceRate",
            Alias = "bounceRate"
        };
        var date = new Dimension { Name = "ga:date" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { date }, new List<Metric> { users });
    }
    // tested
    public IList<Report> SessionDuration(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var users = new Metric
        {
            Expression = "ga:avgSessionDuration",
            Alias = "sessionDuration"
        };
        var date = new Dimension { Name = "ga:date" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { date }, new List<Metric> { users });
    }
    // tested
    public IList<Report> GetPerCountry(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var country = new Dimension { Name = "ga:country" };
        var date = new Dimension { Name = "ga:date" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { country, date }, new List<Metric> { });
    }
    public IList<Report> GetByOperatingSystem(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var operatingSystem = new Dimension { Name = "ga:operatingSystem" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { operatingSystem }, new List<Metric> { });
    }
    public IList<Report> GetScreenResolution(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var screenResolution = new Dimension { Name = "ga:screenResolution" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { screenResolution }, new List<Metric> { });
    }

    public IList<Report> GetByServiceProvider(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var operatingSystem = new Dimension { Name = "ga:networkLocation" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { operatingSystem }, new List<Metric> { });
    }

    // tested
    public IList<Report> GetPerCity(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        //var date = new Dimension { Name = "ga:date" };
        var country = new Dimension { Name = "ga:city" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { country }, new List<Metric> { });
    }

    // tested
    public IList<Report> GetByDeviceCategory(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var deviceCategory = new Dimension { Name = "ga:deviceCategory" };
        return authorizeApp.PerformRequest(dateRange, new List<Dimension> { deviceCategory }, new List<Metric> { });
    }
    // tested
    public IList<Report> GetByBrowser(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        //var date = new Dimension { Name = "ga:date" };
        var browser = new Dimension { Name = "ga:browser" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { browser }, metrics: new List<Metric> { });
    }

    //tested
    public IList<Report> GetByLanguage(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        //var date = new Dimension { Name = "ga:date" };
        var language = new Dimension { Name = "ga:language" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { language }, new List<Metric> { });
    }
    public IList<Report> ChannelGroups(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var date = new Dimension { Name = "ga:date" };
        var channelGrouping = new Dimension { Name = "ga:channelGrouping" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { date, channelGrouping }, new List<Metric> { });
    }
    public IList<Report> SourceMedium(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var date = new Dimension { Name = "ga:date" };
        var channelGrouping = new Dimension { Name = "ga:sourceMedium" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { date, channelGrouping }, new List<Metric> { });
    }
    public IList<Report> VisitSource(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var date = new Dimension { Name = "ga:date" };
        var source = new Dimension { Name = "ga:source" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { date, source }, new List<Metric> { });
    }
    public IList<Report> PagePath(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var source = new Dimension { Name = "ga:pagePath" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { source }, new List<Metric> { });
    }
    public IList<Report> GetPagesVeiws(DateTime FromDate, DateTime ToDate)
    {
        var dateRange = new DateRange
        {
            StartDate = FromDate.ToString("yyyy-MM-dd"),
            EndDate = ToDate.ToString("yyyy-MM-dd")
        };
        var pageViews = new Metric
        {
            Expression = "ga:pageviews",
            Alias = "pageviews"
        };
        var pagePath = new Dimension { Name = "ga:pagePath" };
        return authorizeApp.PerformRequest(dateRange, dimensions: new List<Dimension> { pagePath }, new List<Metric> { pageViews });
    }
}
