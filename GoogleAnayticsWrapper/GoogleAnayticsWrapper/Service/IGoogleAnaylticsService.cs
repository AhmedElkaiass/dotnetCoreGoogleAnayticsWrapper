using GoogleAnalyticsWrapper.Dto;
using GoogleAnayticsWrapper.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnayticsWrapper.Services;
public interface IGoogleAnaylticsService
{
    ServiceResponse<ChartDataDto> GetSession(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetUsers(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> BouncceRate(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> SessionDuration(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetPerCountry(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetPerCity(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetByOperatingSystem(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetScreenResolution(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetByServiceProvider(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetByDeviceCategory(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetByBrowser(SolidDateRangeFillter fillter);
    ServiceResponse<ChartDataDto> GetByLanguage(SolidDateRangeFillter fillter);
    ServiceResponse ChannelGroups(SolidDateRangeFillter fillter);
    ServiceResponse SourceMedium(SolidDateRangeFillter fillter);
    ServiceResponse VisitSource(SolidDateRangeFillter fillter);
    ServiceResponse<List<PagePathViewsDTO>> GetPagesVeiws(SolidDateRangeFillter fillter);
}
