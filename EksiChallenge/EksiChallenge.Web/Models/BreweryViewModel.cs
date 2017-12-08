using EksiChallenge.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EksiChallenge.Web.Models
{
    public class BreweryViewModel<T> where T : BaseEntity
    {
        public SelectList PagingList { get; set; }
        public string SearchQuery { get; set; }
        public string RequestUrl { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public List<T> Data { get; set; }
    }
}