using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Domain.Entities;
namespace EMS.Application.Features.Department.Queries.GetDepartmentList
{
    public class GetDepartmentListQuery : IRequest<IEnumerable<EMS.Domain.Entities.Department>>
    {
    }
}
