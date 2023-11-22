using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
