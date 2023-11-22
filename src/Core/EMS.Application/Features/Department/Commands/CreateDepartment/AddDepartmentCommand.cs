using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Commands.CreateDepartment
{
    public class AddDepartmentCommand : IRequest<Response<EMS.Domain.Entities.Department>>
    {
        public string DeptName { get; set; }
    }
}
