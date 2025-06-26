using CarWashProcessor.Models;
using CarWashProcessor.Services;
using CarWashProcessor.Services.ServiceAddOns;
using CarWashProcessor.Services.ServiceWashes;

namespace CarWashProcessor;

public class Program
{
	public static void Main(string[] args)
	{
		// Create builder
		var builder = Host.CreateApplicationBuilder(args);
		// Configure logging
		builder.Logging.AddSystemdConsole();
		// Register services
		builder.Services.AddHostedService<Worker>();
		builder.Services.AddSingleton<CarJobService>();
		_RegisterServices(builder.Services);
		// Build and run host
		var host = builder.Build();
		host.Run();
	}

	private static void _RegisterServices(IServiceCollection services)
	{
		// Register services
		services.AddSingleton<CarJobProcessorService>();
        services.AddSingleton<CarJobServiceFactory>();

        //Register car wash and add on implementations with the related key from the EServiceAddOn or EServiceWash enum
        //Services can be retrieved and injected with the related key
        services.AddKeyedSingleton<IWashService, BasicWashService>(nameof(EServiceWash.Basic));
        services.AddKeyedSingleton<IWashService, AwesomeWashService>(nameof(EServiceWash.Awesome));
        services.AddKeyedSingleton<IWashService, ToTheMaxWashService>(nameof(EServiceWash.ToTheMax));

        services.AddKeyedSingleton<IAddOnService, HandWaxAndShineService>(nameof(EServiceAddon.HandWaxAndShine));
        services.AddKeyedSingleton<IAddOnService, TireShineService>(nameof(EServiceAddon.TireShine));
        services.AddKeyedSingleton<IAddOnService, InteriorCleanService>(nameof(EServiceAddon.InteriorClean));

    }
}
