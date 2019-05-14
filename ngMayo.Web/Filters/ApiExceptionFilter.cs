using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ngMayo.Logging;
using ngMayo.Logging.Contracts;
using ngMayo.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace ngMayo.Web.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public bool AllowMultiple { get { return true; } }

        private readonly ILogStrategyFactory Logger;

        public ApiExceptionFilter(ILogStrategyFactory logger)
        {
            Logger = logger;
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var statusCode = HttpStatusCode.InternalServerError; // 500 error
            var responseObject = new JObject();
            dynamic responseData = responseObject;
            var ex = actionExecutedContext.Exception;
            responseData.message = ex.Message;

            #if (RELEASE == false)
            AddDiagnosticInformation(ex, responseObject);
            #endif

            string jsonText = JsonConvert.SerializeObject(responseData, JsonSettings.CamelCase);

            var httpContent = new StringContent(jsonText, Encoding.UTF8);
            httpContent.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                {
                    CharSet = "utf-8"
                };

            var httpResponse =
                new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = httpContent,
                };

            Logger.GetStrategy(LogType.Error).Execute(actionExecutedContext.Exception.Message, actionExecutedContext.Exception.StackTrace);

            actionExecutedContext.Response = httpResponse;

            return Task.FromResult(false);
        }

        /// <summary>
        /// Add stack trace to response data if debug build.
        /// </summary>
        /// <param name="ex">The Exception</param>
        /// <param name="responseObject">The JSON response object</param>
        private void AddDiagnosticInformation(Exception ex, JObject responseObject)
        {
            dynamic responseData = responseObject;
            var exLst = new List<Exception>();
            for (var x = ex; x != null; x = x.InnerException)
            {
                exLst.Add(x);
            }
            responseData.Exceptions = new JArray(
                exLst
                    .Select(
                        x =>
                        JObject.FromObject(
                            new
                            {
                                errorType = x.GetType().FullName,
                                message = x.Message,
                            }))
                    .ToList());
            responseData.StackTrace = ex.StackTrace;
        }
    }
}