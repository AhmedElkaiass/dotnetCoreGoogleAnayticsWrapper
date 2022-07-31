using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsWrapper.Dto
{


    public class ServiceResponse
    {
        public ServiceResponse(ServiceResponseCode responseCode, string responseMessage = null)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }

        public ServiceResponse(ModelStateDictionary modelState, string responseMessage = null)
        {
            if (!modelState.IsValid)
                this.ResponseCode = ServiceResponseCode.ValidationErrors;
            ResponseMessage = responseMessage;
        }
        public ServiceResponse(Exception exception, string responseMessage = null)
        {
            ResponseCode = ServiceResponseCode.Failed;
            ResponseMessage = responseMessage ?? "Some thing went wrong";
            Exception = exception.ToString();
        }

        public ServiceResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCodeText => this.ResponseCode.ToString();
        public bool IsSuccess => ResponseCode == ServiceResponseCode.Success;

        public string Exception { get; set; }
        public object ResponseData { get; set; }
    }
    public class ServiceResponse<TResponse> : ServiceResponse
    {

        public ServiceResponse(ServiceResponseCode responseCode, string responseMessage = null) : base(responseCode, responseMessage)
        { }



        public ServiceResponse(ModelStateDictionary modelState, string responseMessage = null) : base(modelState, responseMessage)
        { }
        public ServiceResponse(ServiceResponseCode responseCode, TResponse response, string responseMessage = null) : base(responseCode, responseMessage)
        {
            ResponseData = response;
        }
        public new TResponse ResponseData { get; set; }
    }
}
