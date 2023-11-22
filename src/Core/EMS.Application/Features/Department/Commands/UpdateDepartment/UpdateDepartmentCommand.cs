using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
    }
}
