using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EksiChallenge.CrossCutting.Common.Models;
using EksiChallenge.Services.Services;

namespace EksiChallenge.Web.ServiceReferences
{
    public class BinaryBreweryServiceProxy : IBreweryServiceProxy
    {
        private readonly BreweryService service;

        public BinaryBreweryServiceProxy(BreweryService service)
        {
            this.service = service;
        }

        public Task<ServiceResponse<Brewery>> GetBreweries(ServiceParameter parameter)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<Brewery>> IBreweryServiceProxy.GetBreweries(ServiceParameter parameter)
        {
            return service.GetBreweries(parameter);
        }
    }
}