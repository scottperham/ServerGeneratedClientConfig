using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace ClientSideConfig
{
    public static class DefaultHandlers
    {
        public async static Task GenerateEnv(object config, HttpContext httpContext, ClientSideConfigEnvOptions options)
        {
            foreach (var property in config.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                await httpContext.Response.WriteAsync($"{property.Name}={property.GetValue(config) ?? ""}\n");
            }
        }

        public async static Task GenerateJs(object config, HttpContext httpContext, ClientSideConfigJsOptions options)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(config, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            await httpContext.Response.WriteAsync($"{options.VariableName} = {json}");
        }

        public async static Task GenerateJson(object config, HttpContext httpContext, ClientSideConfigJsonOptions options)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(config, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            await httpContext.Response.WriteAsync(json);
        }
    }
}
