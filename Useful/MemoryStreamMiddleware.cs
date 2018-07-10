using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Extendhealth.RetailLeads.Service.Middleware
{
    public class MemoryStreamMiddleware
    {
        private readonly RequestDelegate _next;

        public MemoryStreamMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            using (var requestStream = new MemoryStream())
            {
                context.Request.Body.CopyTo(requestStream);
                requestStream.Position = 0;
                context.Request.Body = requestStream;
                await _next(context);
            }
        }
    }
}
