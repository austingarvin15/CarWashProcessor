using CarWashProcessor.Models;


namespace CarWashProcessor.Services.ServiceWashes
{
    public interface IWashService
    {
        public Task PerformWash(CarJob carJob);

    }
}
