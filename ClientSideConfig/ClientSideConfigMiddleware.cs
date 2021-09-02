using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSideConfig
{
    public class ClientSideConfigMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly object _config;
        private readonly IClientSideConfigOptions _options;
        private readonly IClientSideHandlerFactory _handlerFactory;

        public ClientSideConfigMiddleware(RequestDelegate next, object config, IClientSideConfigOptions options, IClientSideHandlerFactory handlerFactory)
        {
            _next = next;
            _config = config;
            _options = options;
            _handlerFactory = handlerFactory;
        }

        public async Task Invoke (HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.EndsWith(_options.PathEnd, StringComparison.OrdinalIgnoreCase))
            {
                httpContext.Response.StatusCode = 200;

                await _handlerFactory.GetHandler(_options.GetType())(_config, httpContext, _options);

                return;
            }

            await _next(httpContext);
        }
    }
}
