using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EksiChallenge.CrossCutting.Common.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using EksiChallenge.Repositories.BreweryDbServiceRepository;
using NSubstitute;
using EksiChallenge.Business.BusinessV1;
using EksiChallenge.Business.Interfaces;
using EksiChallenge.Repositories.Interfaces;

namespace EksiChallenge.Business.BusinessV1.Test
{
    [TestClass]
    public class BreweryBusinessTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetBreweries_ValidatePages()
        {
            ServiceParameter sp = new ServiceParameter
            {
                PageNumber = 1,
                SearchName = string.Empty,
                OrderParam = "",
                IsAscending = true
            };

            IBreweryBusiness business;
            
            object[] parameters = { "http://api.brewerydb.com/v2/breweries", "{YOUR_APIKEY_WILL_BE_HERE}" };

            var repo = Substitute.For<BreweryRepository>(parameters);
            repo.Get(sp).Returns(Task.FromResult<ServiceResponse<Brewery>>(new ServiceResponse<Brewery>()
            {
                Data = new List<Brewery>(),
                TotalPage = 5,
                CurrentPage = 6,
            }
            ));

            business = new BreweryBusiness(repo);
            var result = business.GetBreweries(sp);
        }
    }
}
