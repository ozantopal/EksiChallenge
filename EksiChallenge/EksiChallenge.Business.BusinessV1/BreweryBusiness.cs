using EksiChallenge.Business.Interfaces;
using EksiChallenge.CrossCutting.Common.Models;
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
        public BreweryBusiness(IRepository<Brewery> breweryRepository)
        {
            this.breweryRepository = breweryRepository;
        }
        public async Task<ServiceResponse<Brewery>> GetBreweries(ServiceParameter parameter)
        {
            var result = await this.breweryRepository.Get(parameter);
            if (result.TotalPage < result.CurrentPage)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

    }
}
