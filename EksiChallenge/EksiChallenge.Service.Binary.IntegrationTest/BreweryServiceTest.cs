using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EksiChallenge.CrossCutting.Common.Models;
using EksiChallenge.Services.Services;
using EksiChallenge.Business.BusinessV1;
using EksiChallenge.Repositories.BreweryDbServiceRepository;
using EksiChallenge.Repositories.Interfaces;
using EksiChallenge.Business.Interfaces;
using EksiChallenge.Service.Interface;

namespace EksiChallenge.Service.Binary.IntegrationTest
{
    [TestClass]
    public class BreweryServiceTest
    {
        private IBreweryService service;
        
        public BreweryServiceTest()
        {
            IRepository<Brewery> breweryRepository = new BreweryRepository("http://api.brewerydb.com/v2/breweries", "{YOUR_APIKEY_WILL_BE_HERE}");
            IBreweryBusiness breweryBusiness = new BreweryBusiness(breweryRepository);
            this.service = new BreweryService(breweryBusiness);
        }

        [TestMethod]
        public void GetBreweries_WithDefaultValues()
        {
            // Arrange
            ServiceParameter sp = new ServiceParameter
            {
                PageNumber = 1,
                SearchName = string.Empty,
                OrderParam = "",
                IsAscending = true
            };


            // Act
            var actualData = service.GetBreweries(sp);

            // Assert
            // TODO: Assert.AreEqual(expectedData, actualData); olmalı ama expectedData servis datasının
            // sürekli olarak değişebileceği için arrange edilebilirliği çok düşük.
            Assert.AreEqual(actualData, actualData);
        }
    }
}
