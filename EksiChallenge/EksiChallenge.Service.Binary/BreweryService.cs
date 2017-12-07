using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EksiChallenge.Business.Interfaces;
using EksiChallenge.Service.Interface;
using EksiChallenge.CrossCutting.Common.Models;

namespace EksiChallenge.Services.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly IBreweryBusiness business;

        public BreweryService(IBreweryBusiness business)
        {
            this.business = business;
        }
        public async Task<ServiceResponse<Brewery>> GetBreweries(ServiceParameter parameter)
        {
            return await this.business.GetBreweries(parameter);
        }
    }
}
