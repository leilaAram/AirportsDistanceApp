using System;
using System.Threading.Tasks;
using Core.IOModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Request
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate next;
        public RequestMiddleware( RequestDelegate next )
        {
            this.next = next;
        }
        public async Task Invoke( HttpContext context )
        {
            var cancellationToken = context.RequestAborted;
            try
            {
                await next( context );
            }
            catch( Exception exp )
            {
                var res = new JsonResponse { IsSuccess = false, ErrorCode = Enums.ErrorCodes.Unknown_Exception, Message = exp.Message };
                //await context.Response.WriteAsJsonAsync( JsonConvert.SerializeObject( res ) );
                await context.Response.WriteAsync( res.Message );
            }
        }
    }
}
