using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Contracts
{
    public interface IEmployeeRepository 
    {
        Task<int> AddAsync(Employee entity);
    }
}
