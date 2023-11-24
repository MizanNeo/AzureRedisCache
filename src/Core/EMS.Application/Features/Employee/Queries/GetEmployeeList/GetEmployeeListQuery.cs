using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employee.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery : IRequest<IEnumerable<EMS.Domain.Entities.Employee>>
    {

    }
}
