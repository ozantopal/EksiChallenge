using EksiChallenge.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.CrossCutting.Common.Models
{
    public class ServiceResponse<T> where T : BaseEntity
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public List<T> Data { get; set; }
    }
}

