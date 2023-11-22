using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<EMS.Domain.Entities.Department>
    {
        public int Id { get; set; }
    }
}
