using Microsoft.AspNetCore.Builder;

namespace ClientSideConfig
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseClientSideConfig(this IApplicationBuilder builder, object config, IClientSideConfigOptions options = null, IClientSideHandlerFactory handlerFactory = null)
        {
            return builder.UseMiddleware<ClientSideConfigMiddleware>(config, options ?? new ClientSideConfigJsOptions(), handlerFactory ?? new DefaultClientSideHandlerFactory());
        }
    }
}
