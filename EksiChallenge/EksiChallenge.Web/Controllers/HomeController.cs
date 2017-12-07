using EksiChallenge.CrossCutting.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EksiChallenge.Repositories.Interfaces;
using EksiChallenge.Web.ServiceReferences;

namespace EksiChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBreweryServiceProxy service;
        public HomeController(IBreweryServiceProxy service)
        {
            this.service = service;
        }

        [NonAction]
        private SelectList GetPageSelectList(int threshold,
                                             int selected)
        {
            var numberList = Enumerable.Range(1, threshold).ToList();
            var result = new SelectList(numberList, selected);

            return result;
        }

        public async Task<ActionResult> Index(string searchQuery = "",
                                              bool isAscending = true,
                                              int pageNumber = 1,
                                              string orderParam = "")
        {
            ServiceParameter sp = new ServiceParameter
            {
                PageNumber = pageNumber,
                SearchName = searchQuery,
                OrderParam = orderParam,
                IsAscending = isAscending
            };

            ServiceResponse<Brewery> response = await service.GetBreweries(sp);

            var pagingSelectList = GetPageSelectList(response.TotalPage, response.CurrentPage);
            ViewData["PagingList"] = pagingSelectList;
            ViewData["SearchQuery"] = searchQuery;
            ViewData["IsAscending"] = isAscending;

            return View(response);
        }
    }
}