using GoogleAnalyticsWrapper.Dto;
using Google.Apis.AnalyticsReporting.v4.Data;
using GoogleAnalyticsWrapper;
using GoogleAnayticsWrapper.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnayticsWrapper.Services;

public class GoogleAnaylticsService : IGoogleAnaylticsService
{
    private readonly IBrowsingService browsingService;

    public GoogleAnaylticsService(IBrowsingService browsingService)
    {
        this.browsingService = browsingService;
    }
    public ServiceResponse<ChartDataDto> GetSession(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        var mutex = new object();
        var mutex1 = new object();
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        Parallel.Invoke(() =>
        {
            lock (mutex)
            {
                browsingService.GetSession(fillter.FromDate, fillter.ToDate)
              .ToList()
              .ForEach(r =>
              {
                  if (r != null && r.Data != null && r.Data.Rows != null)
                      foreach (var x in r.Data.Rows)
                      {
                          chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                          {
                              DateInfo = new DateInfoDto
                              {
                                  Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                              },
                              Value = string.Join(",", x.Metrics.First().Values)
                          });
                      }
              });
            }

        });
        //var timeInSec = stopwatch.ElapsedMilliseconds / 1000.0;
        //stopwatch.Restart();
        browsingService.GetSession(fillter.FromDate.AddDays(-7), fillter.ToDate.AddDays(-7))
          .ToList()
          .ForEach(r =>
          {
              if (r != null && r.Data != null && r.Data.Rows != null)
                  foreach (var x in r.Data.Rows)
                  {
                      chartDataDto.LastWeek.Add(new WeeklyChartDataDTO
                      {
                          DateInfo = new DateInfoDto
                          {
                              Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                          },
                          Value = string.Join(",", x.Metrics.First().Values)
                      });
                  }
          });
        //stopwatch.Stop();
        //var timeInSec2 = stopwatch.ElapsedMilliseconds / 1000.0;


        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }

    public ServiceResponse<ChartDataDto> GetUsers(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        var mutex = new object();
        var mutex1 = new object();
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        Parallel.Invoke(() =>
        {
            lock (mutex)
            {
                browsingService.GetUsers(fillter.FromDate, fillter.ToDate)
              .ToList()
              .ForEach(r =>
              {
                  if (r != null && r.Data != null && r.Data.Rows != null)
                      foreach (var x in r.Data.Rows)
                      {
                          chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                          {
                              DateInfo = new DateInfoDto
                              {
                                  Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                              },
                              Value = string.Join(",", x.Metrics.First().Values)
                          });
                      }
              });
            }

        });
        //var timeInSec = stopwatch.ElapsedMilliseconds / 1000.0;
        //stopwatch.Restart();
        browsingService.GetUsers(fillter.FromDate.AddDays(-7), fillter.ToDate.AddDays(-7))
          .ToList()
          .ForEach(r =>
          {
              if (r != null && r.Data != null && r.Data.Rows != null)
                  foreach (var x in r.Data.Rows)
                  {
                      chartDataDto.LastWeek.Add(new WeeklyChartDataDTO
                      {
                          DateInfo = new DateInfoDto
                          {
                              Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                          },
                          Value = string.Join(",", x.Metrics.First().Values)
                      });
                  }
          });
        //stopwatch.Stop();
        //var timeInSec2 = stopwatch.ElapsedMilliseconds / 1000.0;


        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }

    public ServiceResponse<ChartDataDto> BouncceRate(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        var mutex = new object();
        var mutex1 = new object();
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        Parallel.Invoke(() =>
        {
            lock (mutex)
            {
                browsingService.BouncceRate(fillter.FromDate, fillter.ToDate)
              .ToList()
              .ForEach(r =>
              {
                  if (r != null && r.Data != null && r.Data.Rows != null)
                      foreach (var x in r.Data.Rows)
                      {
                          chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                          {
                              DateInfo = new DateInfoDto
                              {
                                  Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                              },
                              Value = string.Join(",", x.Metrics.First().Values)
                          });
                      }
              });
            }

        });
        //var timeInSec = stopwatch.ElapsedMilliseconds / 1000.0;
        //stopwatch.Restart();
        browsingService.BouncceRate(fillter.FromDate.AddDays(-7), fillter.ToDate.AddDays(-7))
          .ToList()
          .ForEach(r =>
          {
              if (r != null && r.Data != null && r.Data.Rows != null)
                  foreach (var x in r.Data.Rows)
                  {
                      chartDataDto.LastWeek.Add(new WeeklyChartDataDTO
                      {
                          DateInfo = new DateInfoDto
                          {
                              Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                          },
                          Value = string.Join(",", x.Metrics.First().Values)
                      });
                  }
          });
        //stopwatch.Stop();
        //var timeInSec2 = stopwatch.ElapsedMilliseconds / 1000.0;


        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }
    public ServiceResponse<ChartDataDto> SessionDuration(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        var mutex = new object();
        var mutex1 = new object();
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        Parallel.Invoke(() =>
        {
            lock (mutex)
            {
                browsingService.SessionDuration(fillter.FromDate, fillter.ToDate)
              .ToList()
              .ForEach(r =>
              {
                  if (r != null && r.Data != null && r.Data.Rows != null)
                      foreach (var x in r.Data.Rows)
                      {
                          chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                          {
                              DateInfo = new DateInfoDto
                              {
                                  Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                              },
                              Value = string.Join(",", x.Metrics.First().Values)
                          });
                      }
              });
            }

        });
        //var timeInSec = stopwatch.ElapsedMilliseconds / 1000.0;
        //stopwatch.Restart();
        browsingService.SessionDuration(fillter.FromDate.AddDays(-7), fillter.ToDate.AddDays(-7))
          .ToList()
          .ForEach(r =>
          {
              if (r != null && r.Data != null && r.Data.Rows != null)
                  foreach (var x in r.Data.Rows)
                  {
                      chartDataDto.LastWeek.Add(new WeeklyChartDataDTO
                      {
                          DateInfo = new DateInfoDto
                          {
                              Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                          },
                          Value = string.Join(",", x.Metrics.First().Values)
                      });
                  }
          });
        chartDataDto.CurrentWeek.ForEach(x =>
        {
            x.Value = (Convert.ToDecimal(x.Value) / 60.0m).ToString("00.00");
        });
        chartDataDto.LastWeek.ForEach(x =>
        {
            x.Value = (Convert.ToDecimal(x.Value) / 60.0m).ToString("00.00");
        });
        //stopwatch.Stop();
        //var timeInSec2 = stopwatch.ElapsedMilliseconds / 1000.0;


        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }
    public ServiceResponse<ChartDataDto> GetPerCountry(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        browsingService.GetPerCountry(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                        {
                            Label = x.Dimensions.First(),
                            Value = string.Join(",", x.Metrics.First().Values),
                            DateInfo = new DateInfoDto
                            {
                                Date = DateTime.ParseExact(x.Dimensions[1], "yyyyMMdd", CultureInfo.InvariantCulture),
                            },
                        });
                    }
            });

        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }

    public ServiceResponse<ChartDataDto> GetByOperatingSystem(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        browsingService.GetByOperatingSystem(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                        {
                            Label = x.Dimensions.First(),
                            Value = string.Join(",", x.Metrics.First().Values)
                        });
                    }
            });

        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }

    public ServiceResponse<ChartDataDto> GetByServiceProvider(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        browsingService.GetByServiceProvider(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                        {
                            Label = x.Dimensions.First(),
                            Value = string.Join(",", x.Metrics.First().Values)
                        });
                    }
            });

        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }
    public ServiceResponse<ChartDataDto> GetPerCity(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        browsingService.GetPerCity(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                        {
                            Label = x.Dimensions.First(),
                            Value = string.Join(",", x.Metrics.First().Values)
                        });
                    }
            });

        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }
    public ServiceResponse<ChartDataDto> GetScreenResolution(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        browsingService.GetScreenResolution(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                        {
                            Label = x.Dimensions.First(),
                            Value = string.Join(",", x.Metrics.First().Values)
                        });
                    }
            });

        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }
    public ServiceResponse<ChartDataDto> GetByDeviceCategory(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();


        browsingService.GetByDeviceCategory(fillter.FromDate, fillter.ToDate)
      .ToList()
      .ForEach(r =>
      {
          if (r != null && r.Data != null && r.Data.Rows != null)
              foreach (var x in r.Data.Rows)
              {
                  chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                  {
                      Label = x.Dimensions.First(),
                      Value = string.Join(",", x.Metrics.First().Values),
                  });
              }
      });


        browsingService.GetByDeviceCategory(fillter.FromDate.AddDays(-7), fillter.ToDate.AddDays(-7))
    .ToList()
    .ForEach(r =>
    {
        if (r != null && r.Data != null && r.Data.Rows != null)
            foreach (var x in r.Data.Rows)
            {
                chartDataDto.LastWeek.Add(new WeeklyChartDataDTO
                {
                    Label = x.Dimensions.First(),
                    Value = string.Join(",", x.Metrics.First().Values),
                });
            }
    });

        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }

    public ServiceResponse<ChartDataDto> GetByBrowser(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();

        browsingService.GetByBrowser(fillter.FromDate, fillter.ToDate)
              .ToList()
              .ForEach(r =>
              {
                  if (r != null && r.Data != null && r.Data.Rows != null)
                      foreach (var x in r.Data.Rows)
                      {
                          chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                          {
                              Label = x.Dimensions.First(),
                              Value = string.Join(",", x.Metrics.First().Values)
                          });
                      }
              });

        browsingService.GetByBrowser(fillter.FromDate.AddDays(-7), fillter.ToDate.AddDays(-7))
              .ToList()
              .ForEach(r =>
              {
                  if (r != null && r.Data != null && r.Data.Rows != null)
                      foreach (var x in r.Data.Rows)
                      {
                          chartDataDto.LastWeek.Add(new WeeklyChartDataDTO
                          {
                              Label = x.Dimensions.First(),
                              Value = string.Join(",", x.Metrics.First().Values)
                          });
                      }
              });


        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }

    public ServiceResponse<ChartDataDto> GetByLanguage(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();

        browsingService.GetByLanguage(fillter.FromDate, fillter.ToDate)
      .ToList()
      .ForEach(r =>
      {
          if (r != null && r.Data != null && r.Data.Rows != null)
              foreach (var x in r.Data.Rows)
              {
                  chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                  {
                      Label = x.Dimensions.First(),
                      Value = string.Join(",", x.Metrics.First().Values)
                  });
              }
      });

        return new ServiceResponse<ChartDataDto>(ServiceResponseCode.Success, chartDataDto);
    }
    public ServiceResponse VisitSource(SolidDateRangeFillter fillter)
    {
        ChartDataDto chartDataDto = new ChartDataDto();
        chartDataDto.CurrentWeek = new List<WeeklyChartDataDTO>();
        chartDataDto.LastWeek = new List<WeeklyChartDataDTO>();
        browsingService.VisitSource(fillter.FromDate, fillter.ToDate)
      .ToList()
      .ForEach(r =>
      {
          if (r != null && r.Data != null && r.Data.Rows != null)
              foreach (var x in r.Data.Rows)
              {
                  chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                  {
                      DateInfo = new DateInfoDto
                      {
                          Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                      },
                      Label = x?.Dimensions[1],
                      Value = string.Join(",", x.Metrics.First().Values)
                  });
              }
      });
        var result = chartDataDto.CurrentWeek.GroupBy(X => X.DateInfo.Date).ToList();
        return new ServiceResponse(ServiceResponseCode.Success) { ResponseData = result };
    }

    public ServiceResponse<List<PagePathViewsDTO>> GetPagesVeiws(SolidDateRangeFillter fillter)
    {
        var response = new ServiceResponse<List<PagePathViewsDTO>>(ServiceResponseCode.Success);
        response.ResponseData = new List<PagePathViewsDTO>();
        browsingService
            .GetPagesVeiws(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        response.ResponseData.Add(new PagePathViewsDTO
                        {
                            Path = x.Dimensions.First(),
                            Views = float.Parse(string.Join(",", x.Metrics.First().Values))
                        });
                    }

            });
        return response;
    }

    public ServiceResponse ChannelGroups(SolidDateRangeFillter fillter)
    {
        var response = new ServiceResponse<List<PagePathViewsDTO>>(ServiceResponseCode.Success);
        ChartDataDto chartDataDto = new ChartDataDto();
        response.ResponseData = new List<PagePathViewsDTO>();
        browsingService
            .ChannelGroups(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                        {
                            DateInfo = new DateInfoDto
                            {
                                Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                            },
                            Label = x?.Dimensions[1],
                            Value = string.Join(",", x.Metrics.First().Values)
                        });
                    }

            });
        return new ServiceResponse(ServiceResponseCode.Success) { ResponseData = chartDataDto.CurrentWeek.GroupBy(x => x.Label).ToList() };
    }
    public ServiceResponse SourceMedium(SolidDateRangeFillter fillter)
    {
        var response = new ServiceResponse<List<PagePathViewsDTO>>(ServiceResponseCode.Success);
        ChartDataDto chartDataDto = new ChartDataDto();
        response.ResponseData = new List<PagePathViewsDTO>();
        browsingService
            .SourceMedium(fillter.FromDate, fillter.ToDate)
            .ToList()
            .ForEach(r =>
            {
                if (r != null && r.Data != null && r.Data.Rows != null)
                    foreach (var x in r.Data.Rows)
                    {
                        chartDataDto.CurrentWeek.Add(new WeeklyChartDataDTO
                        {
                            DateInfo = new DateInfoDto
                            {
                                Date = DateTime.ParseExact(x.Dimensions.First(), "yyyyMMdd", CultureInfo.InvariantCulture),
                            },
                            Label = x?.Dimensions[1],
                            Value = string.Join(",", x.Metrics.First().Values)
                        });
                    }

            });
        return new ServiceResponse(ServiceResponseCode.Success) { ResponseData = chartDataDto.CurrentWeek.GroupBy(x => x.Label).ToList() };
    }
}

