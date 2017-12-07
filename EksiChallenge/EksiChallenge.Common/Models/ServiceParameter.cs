using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.CrossCutting.Common.Models
{
    public class ServiceParameter
    {
        public string SearchName { get; set; }
        public bool IsAscending { get; set; }
        public string OrderParam { get; set; }
        public int PageNumber { get; set; }
    }
}
