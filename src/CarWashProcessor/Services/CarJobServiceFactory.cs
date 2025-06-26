using CarWashProcessor.Models;
using CarWashProcessor.Services.ServiceAddOns;
using CarWashProcessor.Services.ServiceWashes;
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
            //Specific implementations of IAddOnService are registered in Program.cs with related EServiceAddOn value
            var _addOnService = _serviceProvider.GetKeyedService<IAddOnService>(nameof(serviceAddOn));

           if (_addOnService == null) {

                throw new InvalidOperationException(
                            $"Add On service ({serviceAddOn}) not recognized."
                        );
           }

           return _addOnService;
        }

        public IWashService GetWashService(EServiceWash serviceWash)
        {
            //Specific implementations of IWashService are registered in Program.cs with related EServiceWash value
            var _washService = _serviceProvider.GetKeyedService<IWashService>(nameof(serviceWash));

            if (_washService == null) {
                throw new InvalidOperationException(
                            $"Wash service ({serviceWash}) not recognized."
                        );
            }

            return _washService;
        }
    }
}
