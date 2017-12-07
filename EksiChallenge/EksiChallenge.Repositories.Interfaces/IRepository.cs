using EksiChallenge.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ServiceResponse<T>> Get(ServiceParameter serviceParameter);
    }
}
