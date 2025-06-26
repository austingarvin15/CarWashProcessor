using CarWashProcessor.Models;

namespace CarWashProcessor.Services.AddOnServices;

public class InteriorCleanService : IAddOnService
{
	private readonly ILogger<InteriorCleanService> _logger;

	public InteriorCleanService(ILogger<InteriorCleanService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task PerformAddOnService(CarJob carJob)
	{
		await PerformInteriorClean(carJob);
	}

    public async Task PerformInteriorClean(CarJob carJob)
    {
        // Wait a second
        await Task.Delay(TimeSpan.FromSeconds(1));
        // Log information
        _logger.LogInformation("--> Interior has been cleaned for customer {}!", carJob.CustomerId);
    }
}
