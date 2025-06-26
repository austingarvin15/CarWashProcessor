using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class CarJobProcessorService
{
	private readonly ICarJobServiceFactory _carJobServiceFactory;

	public CarJobProcessorService(ICarJobServiceFactory carJobServiceFactory)
	{
		_carJobServiceFactory = carJobServiceFactory;
	}

	public async Task ProcessCarJobAsync(CarJob carJob)
	{
		await PerformMainWash(carJob);

		await PerformAddOnServices(carJob);
	}

	private async Task PerformMainWash(CarJob carJob)
	{
        //Get the apropriate injected service for the chosen main wash type
        var _washService = _carJobServiceFactory.GetWashService(carJob.ServiceWash);

        await _washService.PerformWash(carJob);
    }


	private async Task PerformAddOnServices(CarJob carJob)
	{
        //Perform all add on services to the main wash
        foreach (var serviceAddOn in carJob.ServiceAddons)
        {
			//Get appropriate injected service for add on option
            var _addOnService = _carJobServiceFactory.GetAddOnService(serviceAddOn);

            await _addOnService.PerformAddOnService(carJob);
        }
    }
}
