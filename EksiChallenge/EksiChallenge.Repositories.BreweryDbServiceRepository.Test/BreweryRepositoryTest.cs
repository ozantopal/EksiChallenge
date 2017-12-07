using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EksiChallenge.Repositories.BreweryDbServiceRepository;
using EksiChallenge.CrossCutting.Common.Models;

namespace EksiChallenge.Repositories.BreweryDbServiceRepository.Test
{
    [TestClass]
    public class BreweryRepositoryTest
    {
        private BreweryRepository repository;
        [TestInitialize]
        public void Setup()
        {
            repository = new BreweryRepository("http://api.brewerydb.com/v2/breweries", "{YOUR_APIKEY_WILL_BE_HERE}");
        }

        [TestMethod]
        public void GetQuerySuffix_WithDefaultValues()
        {
            ServiceParameter sp = new ServiceParameter
            {
                PageNumber = 1,
                SearchName = String.Empty,
                OrderParam = String.Empty,
                IsAscending = true
            };
            var suffix = repository.GetQuerySuffix(sp);
            Assert.AreEqual(suffix, "&p=1&order=");
        }
    }
}
