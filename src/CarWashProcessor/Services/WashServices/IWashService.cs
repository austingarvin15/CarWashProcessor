using CarWashProcessor.Models;


namespace CarWashProcessor.Services.WashServices
{
    public interface IWashService
    {
        public Task PerformWash(CarJob carJob);

    }
}
