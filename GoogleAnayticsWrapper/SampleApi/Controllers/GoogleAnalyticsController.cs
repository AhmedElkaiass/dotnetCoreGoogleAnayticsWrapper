using GoogleAnalyticsWrapper.Dto;
using GoogleAnayticsWrapper.DTOs;
using GoogleAnayticsWrapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SampileApi;
[Route("[controller]")]
[ApiController]
public class GoogleAnalyticsController : ControllerBase
{
    private readonly IGoogleAnaylticsService googleAnaylticsService;

    public GoogleAnalyticsController(IGoogleAnaylticsService googleAnaylticsService)
    {
        this.googleAnaylticsService = googleAnaylticsService;
    }

    [HttpPost("GetSessions")]
    public ActionResult<ServiceResponse> GetSessions()
    {
        return Ok(googleAnaylticsService.GetSession(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetUsers")]
    public ActionResult<ServiceResponse> GetUsers()
    {
        return Ok(googleAnaylticsService.GetUsers(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("BouncceRate")]
    public ActionResult<ServiceResponse> BouncceRate()
    {
        return Ok(googleAnaylticsService.BouncceRate(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("SessionDuration")]
    public ActionResult<ServiceResponse> SessionDuration()
    {
        return Ok(googleAnaylticsService.SessionDuration(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetPerCountry")]
    public ActionResult<ServiceResponse> GetPerCountry()
    {
        return Ok(googleAnaylticsService.GetPerCountry(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetPerCity")]
    public ActionResult<ServiceResponse> GetPerCity()
    {
        return Ok(googleAnaylticsService.GetPerCity(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetByDeviceCategory")]
    public ActionResult<ServiceResponse> GetByDeviceCategory()
    {
        return Ok(googleAnaylticsService.GetByDeviceCategory(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetByBrowser")]
    public ActionResult<ServiceResponse> GetByBrowser()
    {
        return Ok(googleAnaylticsService.GetByBrowser(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetByLanguage")]
    public ActionResult<ServiceResponse> GetByLanguage()
    {
        return Ok(googleAnaylticsService.GetByLanguage(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("ChannelGroups")]
    public ActionResult<ServiceResponse> ChannelGroups()
    {
        return Ok(googleAnaylticsService.ChannelGroups(new SolidDateRangeFillter
        {

            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("SourceMedium")]
    public ActionResult<ServiceResponse> SourceMedium()
    {
        return Ok(googleAnaylticsService.SourceMedium(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-7),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetPagesVeiws")]
    public ActionResult<ServiceResponse> GetPagesVeiws()
    {
        return Ok(googleAnaylticsService.GetPagesVeiws(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now,
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetByOperatingSystem")]
    public ActionResult<ServiceResponse> GetByOperatingSystem()
    {
        return Ok(googleAnaylticsService.GetByOperatingSystem(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetByServiceProvider")]
    public ActionResult<ServiceResponse> GetByServiceProvider()
    {
        return Ok(googleAnaylticsService.GetByServiceProvider(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
    [HttpPost("GetScreenResolution")]
    public ActionResult<ServiceResponse> GetScreenResolution()
    {
        return Ok(googleAnaylticsService.GetScreenResolution(new SolidDateRangeFillter
        {
            FromDate = DateTime.Now.AddDays(-8),
            ToDate = DateTime.Now
        }));
    }
}