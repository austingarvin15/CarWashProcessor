using CarWashProcessor.Models;


namespace CarWashProcessor.Services.AddOnServices
{
    public interface IAddOnService
    {
        public Task PerformAddOnService(CarJob carJob);

    }
}
