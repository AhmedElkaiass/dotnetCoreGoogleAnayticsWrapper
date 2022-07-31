using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnayticsWrapper.DTOs;
public static class ApplicationDateCulutre
{
    public static CultureInfo localDateCuture = new CultureInfo("ar-EG");
    public static CultureInfo latinDateCuture = new CultureInfo("en-US");
}
public class ChartDataDto
{
    public ChartDataDto()
    {
        CurrentWeek = new List<WeeklyChartDataDTO>();
        LastWeek = new List<WeeklyChartDataDTO>();
    }
    public List<WeeklyChartDataDTO> CurrentWeek { get; set; }
    public List<WeeklyChartDataDTO> LastWeek { get; set; }
    public decimal TotalCurrentWeek { get => CurrentWeek.Sum(x => Convert.ToDecimal(x.Value)); }
    public decimal TotalLastWeek { get => LastWeek.Sum(x => Convert.ToDecimal(x.Value)); }
    public decimal Total { get => TotalCurrentWeek + TotalLastWeek; }
    public decimal Diffrance { get => LastWeek.Sum(x => Convert.ToDecimal(x.Value)) - CurrentWeek.Sum(x => Convert.ToDecimal(x.Value)); }
    public decimal DiffranceInPrecentage { get => Total > 0 ? Convert.ToDecimal((Diffrance / Total * 100).ToString("00.00")) : 0; }
}
public class WeeklyChartDataDTO
{
    public DateInfoDto DateInfo { get; set; }
    public string Value { get; set; }
    public string Label { get; set; }
}
public class PagePathViewsDTO
{
    public string Path { get; set; }
    public float Views { get; set; }
}
public class DateInfoDto
{
    public DateTime Date { get; set; }
    public string LocalDayName { get => Date.ToString("dddd", ApplicationDateCulutre.localDateCuture); }
    public string LatinDayName { get => Date.ToString("dddd", ApplicationDateCulutre.latinDateCuture); }
}
