using EksiChallenge.Common.Models;
using EksiChallenge.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EksiChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBreweryService service;
        public HomeController(IBreweryService service)
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
                                              int pageNumber = 1)
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["apiKey"];
            ServiceResponse response = await service.GetBreweries(apiKey, searchQuery, isAscending, pageNumber);

            var pagingSelectList = GetPageSelectList(response.TotalPage, response.CurrentPage);
            ViewData["PagingList"] = pagingSelectList;
            ViewData["SearchQuery"] = searchQuery;
            ViewData["IsAscending"] = isAscending;

            return View(response);
        }
    }
}