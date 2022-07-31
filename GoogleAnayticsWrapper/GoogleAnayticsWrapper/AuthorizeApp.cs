using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsWrapper;
public interface IAuthorizeApp
{
    GoogleCredential GetCredential(string KeyFilePath);
    AnalyticsReportingService GetAnalyticsReportingService(string KeyFilePath);
    IList<Report> PerformRequest(GetReportsRequest body, AnalyticsReportingService svc);
    IList<Report> PerformRequest(GetReportsRequest body, string KeyFilePath);
    IList<Report> PerformRequest(DateRange DateRange, List<Dimension> dimensions, List<Metric> metrics);

}
public class AuthorizeApp : IAuthorizeApp
{
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly IConfiguration configuration;

    public AuthorizeApp(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        this.webHostEnvironment = webHostEnvironment;
        this.configuration = configuration;
    }

    public GoogleCredential GetCredential(string KeyFilePath)
    {
        GoogleCredential credential;
        using (var stream = new FileStream(KeyFilePath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped(VisionService.Scope.CloudPlatform)
                .CreateScoped(AnalyticsReportingService.Scope.AnalyticsReadonly);
        }
        return credential;
    }
    public AnalyticsReportingService GetAnalyticsReportingService(string KeyFilePath)
    {
        var credential = GetCredential(KeyFilePath);
        var svc = new AnalyticsReportingService(
               new BaseClientService.Initializer
               {
                   HttpClientInitializer = credential,
                   ApplicationName = "ebusiness"
               });
        return svc;
    }
    public IList<Report> PerformRequest(GetReportsRequest body, AnalyticsReportingService svc)
    {
        var batchRequest = svc.Reports.BatchGet(body);
        var response = batchRequest.Execute();
        return response.Reports;
    }
    public IList<Report> PerformRequest(GetReportsRequest body, string KeyFilePath)
    {
        var svc = GetAnalyticsReportingService(KeyFilePath);
        var batchRequest = svc.Reports.BatchGet(body);
        var response = batchRequest.Execute();
        return response.Reports;
    }
    public IList<Report> PerformRequest(DateRange DateRange, List<Dimension> dimensions, List<Metric> metrics)
    {
        var relativePath = configuration["GoogleAnalytics:KeyFilePath"];
        string ServerAbsolutePath = webHostEnvironment.WebRootPath;
        string KeyFilePath = ServerAbsolutePath + relativePath;// System.IO.Path.Combine();
        var reportRequest = new ReportRequest
        {
            DateRanges = new List<DateRange> { DateRange },
            Dimensions = dimensions,
            Metrics = metrics,
            ViewId = configuration["GoogleAnalytics:ViewID"]
        };
        var getReportsRequest = new GetReportsRequest
        {
            ReportRequests = new List<ReportRequest> { reportRequest }
        };
        var svc = GetAnalyticsReportingService(KeyFilePath);
        var batchRequest = svc.Reports.BatchGet(getReportsRequest);
        var response = batchRequest.Execute();
        return response.Reports;
    }

}
