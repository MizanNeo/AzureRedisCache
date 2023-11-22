using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace EMS.WebAPI.Middleware
{
    public class HandleException 
    {
        private RequestDelegate requestDelegate;

        public HandleException(RequestDelegate requestDelegate)
        {
            this.requestDelegate=requestDelegate;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception e)
            {
                var errorMessage=JsonConvert.SerializeObject(new {e.Message,e.StackTrace});
                context.Response.ContentType= "application/json";
                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(errorMessage);
            }
        }
    }
}
