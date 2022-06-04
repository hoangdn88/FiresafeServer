using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IInternalService
    {
        Task<(HttpStatusCode, T)> SendRequest<T>(string url, Object body, Method method, Dictionary<string, string> headers = null);
        Exception CreateException(string message);
    }
}
