namespace ClientSideConfig
{
    public interface IClientSideConfigOptions
    {
        string PathEnd { get; }
    }

    public class ClientSideConfigJsonOptions : IClientSideConfigOptions
    {
        public string PathEnd { get; set; } = "/config.json";
    }

    public class ClientSideConfigJsOptions : IClientSideConfigOptions
    {
        public string VariableName { get; set; } = "window.global";
        public string PathEnd { get; set; } = "/config.js";
    }

    public class ClientSideConfigEnvOptions : IClientSideConfigOptions
    {
        public string PathEnd { get; set; } = "/.env";
    }
}
