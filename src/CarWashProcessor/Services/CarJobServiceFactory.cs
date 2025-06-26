using CarWashProcessor.Models;
using CarWashProcessor.Services.AddOnServices;
using CarWashProcessor.Services.WashServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashProcessor.Services
{
    public class CarJobServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CarJobServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IAddOnService GetAddOnService(EServiceAddon serviceAddOn)
        {
           //Specific implementations of IAddOnService are registered in Program.cs with related EServiceAddOn value as the key
           var serviceKey = serviceAddOn.ToString();

           var _addOnService = _serviceProvider.GetKeyedService<IAddOnService>(serviceKey);

           if (_addOnService == null) {

                throw new InvalidOperationException(
                            $"Add On service ({serviceAddOn}) not recognized."
                        );
           }

           return _addOnService;
        }

        public IWashService GetWashService(EServiceWash serviceWash)
        {
            //Specific implementations of IWashService are registered in Program.cs with related EServiceWash value as the key
            var serviceKey = serviceWash.ToString();

            var _washService = _serviceProvider.GetKeyedService<IWashService>(serviceKey);

            if (_washService == null) {
                throw new InvalidOperationException(
                            $"Wash service ({serviceWash}) not recognized."
                        );
            }

            return _washService;
        }
    }
}
