using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSideConfig
{
    public class DefaultClientSideHandlerFactory : IClientSideHandlerFactory
    {
        private readonly IDictionary<Type, Func<object, HttpContext, IClientSideConfigOptions, Task>> _handlers;

        public DefaultClientSideHandlerFactory()
        {
            _handlers = new Dictionary<Type, Func<object, HttpContext, IClientSideConfigOptions, Task>>{
                { typeof(ClientSideConfigEnvOptions), (obj, httpContext, options) => DefaultHandlers.GenerateEnv(obj, httpContext, (ClientSideConfigEnvOptions)options) },
                { typeof(ClientSideConfigJsOptions), (obj, httpContext, options) => DefaultHandlers.GenerateJs(obj, httpContext, (ClientSideConfigJsOptions)options) },
                { typeof(ClientSideConfigJsonOptions), (obj, httpContext, options) => DefaultHandlers.GenerateJson(obj, httpContext, (ClientSideConfigJsonOptions)options) }
            };
        }

        public void AddHandler<T>(Func<object, HttpContext, IClientSideConfigOptions, Task> handler) where T : IClientSideConfigOptions
        {
            _handlers[typeof(T)] = handler;
        }

        public Func<object, HttpContext, IClientSideConfigOptions, Task> GetHandler(Type type)
        {
            if (!_handlers.TryGetValue(type, out var handler))
            {
                throw new InvalidOperationException($"Unable to find client-side config handler for type {type.Name}");
            }

            return handler;
        }
    }
}
