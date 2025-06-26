using CarWashProcessor.Models;

namespace CarWashProcessor.Services.WashServices;

public class BasicWashService : IWashService
{
	private readonly ILogger<BasicWashService> _logger;

	public BasicWashService(ILogger<BasicWashService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task PerformWash(CarJob carJob)
	{
		await PerformBasicWash(carJob);
	}

    public async Task PerformBasicWash(CarJob carJob)
    {
        // Wait a second
        await Task.Delay(TimeSpan.FromSeconds(1));
        // Log information
        _logger.LogInformation("--> Basic wash performed for customer {}!", carJob.CustomerId);
    }
}
