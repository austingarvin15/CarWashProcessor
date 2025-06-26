using CarWashProcessor.Models;


namespace CarWashProcessor.Services.ServiceAddOns
{
    public interface IAddOnService
    {
        public Task PerformAddOnService(CarJob carJob);

    }
}
