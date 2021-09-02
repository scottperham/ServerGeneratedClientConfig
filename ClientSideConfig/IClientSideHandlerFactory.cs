using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ClientSideConfig
{
    public interface IClientSideHandlerFactory
    {
        void AddHandler<T>(Func<object, HttpContext, IClientSideConfigOptions, Task> handler) where T : IClientSideConfigOptions;

        Func<object, HttpContext, IClientSideConfigOptions, Task> GetHandler(Type type);
    }
}
