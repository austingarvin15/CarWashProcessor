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
    public interface ICarJobServiceFactory
    {
        public IAddOnService GetAddOnService(EServiceAddon serviceAddOn);

        public IWashService GetWashService(EServiceWash serviceWash);
    }
}
