using EksiChallenge.Business.Interfaces;
using EksiChallenge.CrossCutting.Common.Models;
using EksiChallenge.Repositories.BreweryDbServiceRepository;
using EksiChallenge.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Business.BusinessV1
{
    public class BreweryBusiness : IBreweryBusiness
    {
        private readonly IRepository<Brewery> breweryRepository;
        public BreweryBusiness(BreweryRepository breweryRepository)
        {
            this.breweryRepository = breweryRepository;
        }
        public Task<ServiceResponse<Brewery>> GetBreweries(ServiceParameter parameter)
        {
            return this.breweryRepository.Get(parameter);
        }
    }
}
