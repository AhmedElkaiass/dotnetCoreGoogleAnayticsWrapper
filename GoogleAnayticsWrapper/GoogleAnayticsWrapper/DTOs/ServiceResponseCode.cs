using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsWrapper.Dto;
public enum ServiceResponseCode
{
    Success = 200,
    ValidationErrors = 400,
    Failed = 500,

    // custom response codess
    InvalidActivationCode = 100,
    InvalidSocailToken = 100,
    InvalidEmailOrPhoneNumber = 102,
    // data 
    NotFoundData = 103,
    DataHasFound = 104,
    VoidExecution = 105,
    UnknownUser = 106,
    InvalidData = 107,
}
