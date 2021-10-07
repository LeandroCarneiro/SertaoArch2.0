using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof($safeprojectname$.Startup))]
namespace $safeprojectname$
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddOptions<GimmeBooksApi>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("GimmeBooksApi").Bind(settings);
            });
        }
    }

    public class GimmeBooksApi
    {
        public string Url { get; set; }
    }
}
