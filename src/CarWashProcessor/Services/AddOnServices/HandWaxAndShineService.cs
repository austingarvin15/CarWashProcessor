using CarWashProcessor.Models;

namespace CarWashProcessor.Services.AddOnServices;

public class HandWaxAndShineService: IAddOnService
{
	private readonly ILogger<HandWaxAndShineService> _logger;

	public HandWaxAndShineService(ILogger<HandWaxAndShineService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task PerformAddOnService(CarJob carJob)
	{
		await PerformHandWaxAndShine(carJob);
	}

    public async Task PerformHandWaxAndShine(CarJob carJob)
    {
        // Wait a second
        await Task.Delay(TimeSpan.FromSeconds(1));
        // Log information
        _logger.LogInformation("--> Hand waxed and shined for customer {}!", carJob.CustomerId);
    }
}
