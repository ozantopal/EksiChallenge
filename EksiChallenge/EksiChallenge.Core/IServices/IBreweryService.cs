using EksiChallenge.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Core.IServices
{
    public interface IBreweryService
    {
        Task<ServiceResponse> GetBreweries(string apiKey, string searchName, bool isAscending, int pageNumber);
    }
}
