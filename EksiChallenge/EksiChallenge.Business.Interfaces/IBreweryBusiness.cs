using EksiChallenge.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Business.Interfaces
{
    public interface IBreweryBusiness
    {
        Task<ServiceResponse<Brewery>> GetBreweries(ServiceParameter parameter);
    }
}
