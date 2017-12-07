using EksiChallenge.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Web.ServiceReferences
{
    public interface IBreweryServiceProxy
    {
        Task<ServiceResponse<Brewery>> GetBreweries(ServiceParameter parameter);
    }
}
